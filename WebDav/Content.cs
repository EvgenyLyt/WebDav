using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace WebDav
{
    public class Content
    {
        public List<string> CopyHref = new List<string>();
        public List<string> CopyName = new List<string>();
        public struct FileInformation
        {
            public string Href;
            public string ContentType;
            public string DatelLastModified;
            public string ContentLength;
            public string DisplayName;
            public string CreationDate;
        }
        public List<FileInformation> All = new List<FileInformation>();

        public void CopyFiles(int Count, ListView ListFiles)
        {
            CopyHref.Clear();
            CopyName.Clear();
            for (int index = 0; index < Count; index++)
            {
                int IndexFile = ListFiles.SelectedItems[index].Index;
                if (All[IndexFile].ContentType != "d:collection")
                {
                    CopyHref.Add(All[IndexFile].Href);
                    CopyName.Add(All[IndexFile].DisplayName);
                }
            }
        }

        public void ShowProperties(int Index)
        {
            string[] Proper_s = {All[Index].ContentType,All[Index].DisplayName,
            All[Index].DatelLastModified, All[Index].CreationDate, All[Index].ContentLength};
            PropFiles Prop_s = new PropFiles(Proper_s);
            Prop_s.ShowDialog();
        }

        public void SetInfoContent(Stream ResponseStream, ref List<FileInformation> All, ref ListView ListFiles)
        {
            string[] Types = { "audio", "collection", "image", "text", "video" };
            XmlDocument ResponseXmlDoc = new XmlDocument();
            ResponseXmlDoc.Load(ResponseStream);
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(ResponseXmlDoc.NameTable);
            nsmgr.AddNamespace("d", "DAV:");
            List<string> AllHref = new List<string>();
            foreach (XmlNode MainNode in ResponseXmlDoc.SelectNodes("//d:response", nsmgr))
                AllHref.Add((MainNode.ChildNodes[0].InnerText));
            int index = 0;
            foreach (XmlNode MainNode in ResponseXmlDoc.SelectNodes("//d:prop", nsmgr))
            {
                FileInformation One = new FileInformation();
                One.Href = AllHref[index];
                foreach (XmlNode Date in MainNode.ChildNodes)
                {
                    switch (Date.Name)
                    {
                        case "d:resourcetype": { if (Date.HasChildNodes) One.ContentType = Date.ChildNodes[0].Name; } break;
                        case "d:getlastmodified": { One.DatelLastModified = Date.InnerText; } break;
                        case "d:getcontenttype": { One.ContentType = Date.InnerText; } break;
                        case "d:getcontentlength": { One.ContentLength = Date.InnerText; } break;
                        case "d:displayname": { One.DisplayName = Date.InnerText; } break;
                        case "d:creationdate": { One.CreationDate = Date.InnerText; } break;
                    }
                }
                ListFiles.Items.Add(One.DisplayName);
                ListFiles.Items[index].ImageIndex = 5;
                for (int i = 0; i < Types.Length; i++)
                    if (One.ContentType.Contains(Types[i]))
                        ListFiles.Items[index].ImageIndex = i;
                All.Add(One);
                index++;
            }
        }
    }
}
