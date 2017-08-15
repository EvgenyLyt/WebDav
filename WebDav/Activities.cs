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
    public class Activities
    {
        static EventWaitHandle handle;
        delegate void Function(object it);
        DataUser InterUser = new DataUser();
        Content InterFiles = new Content();
        string[] SafeNames;
        string[] Names;
        public event Message GotMessage;
        public delegate void Message(string ForMessageBox);

        Dictionary<string, Function> Capabilities = new Dictionary<string, Function>();

        public Activities()
        {
            MakeDictionary();
        }

        public Activities(string[] NamesNew, string[] SafeNamesNew)
        {
            MakeDictionary();
            Names = NamesNew;
            SafeNames = SafeNamesNew;
        }

        private void MakeDictionary()
        {
            Capabilities.Add("Paste", Paste);
            Capabilities.Add("Delete", Delete);
            Capabilities.Add("Download", Download);
            Capabilities.Add("Upload", Upload);
        }

        public void Activity(ref Content Files, ref DataUser User, ListView ListFiles, ProgressBar Loading, int Count, bool SelIt, string Function)
        {
            if (User.CheckIntConnect())
            {
                handle = new AutoResetEvent(false);
                int ThreadCount = Count;
                Loading.Maximum = ThreadCount;
                InterUser = User;
                InterFiles = Files;
                for (int index = 0; index < ThreadCount; index++)
                {
                    Thread thread = new Thread(new ParameterizedThreadStart(Capabilities[Function]));
                    thread.IsBackground = true;
                    if (SelIt)
                        thread.Start(ListFiles.SelectedItems[index].Index);
                    else
                        thread.Start(index);
                }
                while (ThreadCount > 0)
                {
                    handle.WaitOne();
                    Loading.Increment(1);
                    ThreadCount--;
                }
                Loading.Value = 0;
                User.InfoFiles(ref Files, ref User, ref ListFiles, User.Data.Hrefs.Last(), true);
            }
        }

        private void Paste(object it)
        {
            if (InterUser.CheckIntConnect())
            {
                int index = (int)it;
                ReqRes Act = new ReqRes();
                try
                {
                    HttpWebRequest Request = Act.MakeRequest(InterUser.Data.UrlServer, InterFiles.CopyHref[index], InterUser.Data.Name, InterUser.Data.Password);
                    Request.Method = "COPY";
                    Request.Accept = "*/*";
                    Request.Headers.Add("Destination: " + HttpUtility.UrlPathEncode(InterUser.Data.Hrefs.Last() + InterFiles.CopyName[index]));
                    Act.GetResponse(Request);
                }
                catch (WebException ex)
                {
                    if (GotMessage != null)
                        GotMessage(ex.Message);
                }
            }
            handle.Set();
        }

        private void Download(object it)
        {
            if (InterUser.CheckIntConnect())
            {
                int index = (int)it;
                if (InterFiles.All[index].ContentType != "d:collection")
                {
                    ReqRes Act = new ReqRes();
                    try
                    {
                        HttpWebRequest Request = Act.MakeRequest(InterUser.Data.UrlServer, InterFiles.All[index].Href, InterUser.Data.Name, InterUser.Data.Password);
                        Request.Method = WebRequestMethods.Http.Get;
                        HttpWebResponse Response = Act.GetResponseStream(Request);
                        int byteTransferRate = 8192;
                        byte[] bytes = new byte[byteTransferRate];
                        int bytesRead = 0;
                        long totalBytesRead = 0;
                        Directory.CreateDirectory("./Download/");
                        long contentLength = long.Parse(Response.GetResponseHeader("Content-Length"));
                        Stream NewStream = Response.GetResponseStream();
                        FileStream NewFileStream = new FileStream("./Download/" + InterFiles.All[index].DisplayName, FileMode.Create, FileAccess.Write);
                         do
                         {
                             bytesRead = NewStream.Read(bytes, 0, bytes.Length);
                             if (bytesRead > 0)
                             {
                                totalBytesRead += bytesRead;
                                 NewFileStream.Write(bytes, 0, bytesRead);
                             }
                          }
                          while (bytesRead > 0);
                          NewStream.Close();
                          NewFileStream.Close();
                          Response.Close();
                    }   
                    catch(WebException ex)
                    {
                        if (GotMessage != null)
                            GotMessage(ex.Message);
                    }
                }
            }
            handle.Set();
        }

        private void Delete(object it)
        {
            if (InterUser.CheckIntConnect())
            {
                int index = (int)it;
                if (InterFiles.All[index].Href != InterUser.Data.Hrefs.Last())
                {
                    ReqRes Act = new ReqRes();
                    try
                    {
                        HttpWebRequest Request = Act.MakeRequest(InterUser.Data.UrlServer, InterFiles.All[index].Href, InterUser.Data.Name, InterUser.Data.Password);
                        Request.Method = "DELETE";
                        Act.GetResponse(Request);
                    }
                    catch(WebException ex)
                    {
                        if (GotMessage != null)
                            GotMessage(ex.Message);
                    }
                }
            }
            handle.Set();
        }

        public void MakeDirectory(ref Content Files, ref DataUser User, ListView ListFiles, TextBox NewFolder, string Folder)
        {
            Rename Active = new Rename();
            if (Active.CheckName(Folder, Files))
            {
                if (User.CheckIntConnect())
                {
                    ReqRes Act = new ReqRes();
                    try
                    {
                        HttpWebRequest Request = Act.MakeRequest(User.Data.UrlServer, User.Data.Hrefs.Last() + Folder, User.Data.Name, User.Data.Password);
                        if (Request != null)
                        {
                            Request.Method = WebRequestMethods.Http.MkCol;
                            Act.GetResponse(Request);
                            User.InfoFiles(ref Files, ref User, ref ListFiles, User.Data.Hrefs.Last(), true);
                            NewFolder.Text = "";
                        }
                    }
                    catch (WebException ex)
                    {
                        if (GotMessage != null)
                            GotMessage(ex.Message);
                    }
                }
            }
        }

        private void Upload(object it)
        {
            if (InterUser.CheckIntConnect())
            {
                int index = (int)it;
                ReqRes Act = new ReqRes();
                try
                {
                    HttpWebRequest Request = Act.MakeRequest(InterUser.Data.UrlServer, InterUser.Data.Hrefs.Last()+SafeNames[index], InterUser.Data.Name, InterUser.Data.Password);
                    FileStream ReadStream = new FileStream(Names[index], FileMode.Open, FileAccess.Read);
                    Request.Method = WebRequestMethods.Http.Put;
                    Request.ContentLength = ReadStream.Length;
                    Request.KeepAlive = false;
                    Request.ReadWriteTimeout = -1;
                    Request.Timeout = -1;
                    Request.AllowWriteStreamBuffering = true;
                    Request.PreAuthenticate = false;
                    Request.SendChunked = false;
                    Request.ContentType = "application/binary";
                    Request.ProtocolVersion = HttpVersion.Version11;
                    Request.ServicePoint.ConnectionLimit = 1;
                    Request.AllowAutoRedirect = false;
                    Request.ServicePoint.Expect100Continue = true;
                    Request.Accept = "*/*";
                    Stream reqStream = Request.GetRequestStream();
                    if (reqStream!=null)
                    {
                        byte[] inData = new byte[8192];
                        int bytesRead = ReadStream.Read(inData, 0, inData.Length);
                        while (bytesRead > 0)
                        {
                            reqStream.Write(inData, 0, bytesRead);
                            bytesRead = ReadStream.Read(inData, 0, inData.Length);
                        }
                        ReadStream.Close();
                        reqStream.Close();
                        Act.GetResponse(Request);
                    }
                }
                catch (WebException ex)
                {
                    if (GotMessage != null)
                        GotMessage(ex.Message);
                }
            }
            handle.Set();
        }
    }
}
