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
using System.Xml.Xsl;
using System.Net.NetworkInformation;

namespace WebDav
{
    public class Rename
    {
        public event Message GotMessage;
        public delegate void Message(string ForMessageBox);

        public bool CheckName(string Name, Content Files)
        {
            bool result = true;
            int index = 0;
            if ((Name != null) && (Name != "") && (!Name.Contains("/")))
                while ((index < Files.All.Count) && (result))
                {
                    if (Files.All[index].DisplayName == Name)
                        result = false;
                    index++;
                }
            else
                result = false;
            return result;
        }

        public bool MakeNewName(DataUser User, int Item, string Name, Content Files)
        {
            if (User.CheckIntConnect())
            {
                ReqRes Act = new ReqRes();
                try
                {
                    HttpWebRequest Request = Act.MakeRequest(User.Data.UrlServer, Files.All[Item].Href, User.Data.Name, User.Data.Password);
                    Request.Method = "MOVE";
                    Request.Accept = "*/*";
                    string NewName = User.Data.Hrefs.Last() + Name;
                    if (Files.All[Item].ContentType == "d:collection")
                        NewName += "/";
                    Request.Headers.Add("Destination: " + HttpUtility.UrlPathEncode(NewName));
                    Act.GetResponse(Request);
                    return true;
                }
                catch (WebException ex)
                {
                    if (GotMessage != null)
                        GotMessage(ex.Message);
                    return false;
                }
            }
            return false;
        }

        public void StartRename(ListView ListFiles, DataUser User, Content Files, bool DoubleClick)
        {
            if (ListFiles.SelectedIndices.Count == 1)
            {
                int index = ListFiles.SelectedItems[0].Index;
                if (Files.All[index].ContentType == "d:collection")
                {
                    if (User.Data.Hrefs.Last() != Files.All[index].Href)
                        if (DoubleClick)
                            User.InfoFiles(ref Files, ref User, ref ListFiles, Files.All[index].Href, true);
                        else
                            ListFiles.SelectedItems[0].BeginEdit();
                }
                else
                    ListFiles.SelectedItems[0].BeginEdit();
            }
        }

        public void EndRename(ref Content Files, ref DataUser User, ref ListView ListFiles, LabelEditEventArgs e)
        {
            if (CheckName(e.Label, Files))
            {
                if (!MakeNewName(User, e.Item, e.Label, Files))
                    e.CancelEdit = true;
                else
                    User.InfoFiles(ref Files, ref User, ref ListFiles, User.Data.Hrefs.Last(), true);
            }
            else
                e.CancelEdit = true;
        }
    }
}
