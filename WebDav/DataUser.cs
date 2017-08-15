using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Xml;
using System.Web;
using System.Threading;
using System.Xml.Xsl;
using System.Net.NetworkInformation;

namespace WebDav
{
    public class DataUser
    {
        public event Message GotMessage;
        public delegate void Message(string ForMessageBox);
        public struct UserInfo
        {
            public string UrlServer;
            public string Name;
            public string Password;
            public Form Log;
            public List<string> Hrefs;
            public UserInfo(string Url, string Name, string Password, string Href, Form LogIn)
            {
                this.UrlServer = Url;
                this.Name = Name;
                this.Password = Password;
                this.Log = LogIn;
                this.Hrefs = new List<string>();
                this.Hrefs.Add(Href);
            }
        }
        public UserInfo Data;

        public void FillData(string Url, string Name, string Password, string Href, Form LogIn)
        {
            Data = new UserInfo(Url, Name, Password, Href, LogIn);
        }

        public bool CheckIntConnect()
        {
            try
            {
                Ping myPing = new Ping();
                PingReply reply = myPing.Send("yandex.ru", 3000, new byte[32], new PingOptions());
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void InfoFiles(ref Content Files, ref DataUser User, ref ListView ListFiles, string Folder, bool forward)
        {
            if (User.CheckIntConnect())
            {
                ReqRes Act = new ReqRes();
                try
                { 
                    HttpWebRequest Request = Act.MakeRequest(User.Data.UrlServer, Folder, User.Data.Name, User.Data.Password);
                    Request.Accept = "*/*";
                    Request.Headers.Add("Depth: 1");
                    Request.Method = "PROPFIND";
                    HttpWebResponse Response = Act.GetResponseStream(Request);
                    Stream ResponseStream = Response.GetResponseStream();
                    Files.All.Clear();
                    ListFiles.Items.Clear();
                    Files.SetInfoContent(ResponseStream, ref Files.All, ref ListFiles);
                    ResponseStream.Close();
                    Response.Close();
                    if (forward)
                    {
                        if (!User.Data.Hrefs.Contains(Folder))
                           User.Data.Hrefs.Add(Folder);
                    }
                    else
                       User.Data.Hrefs.RemoveAt(User.Data.Hrefs.Count - 1);
                }
                catch(WebException ex)
                {
                    if (GotMessage != null)
                        GotMessage(ex.Message);
                }
            }
            else
            {
                if (GotMessage != null)
                    GotMessage("Вы не подключены к Интернету!");
            }
        }
    }
}
