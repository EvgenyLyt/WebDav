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
    public class ReqRes
    {
        public HttpWebRequest MakeRequest(string Url, string Folder, string Name, string Password)
        {
            HttpWebRequest Request = HttpWebRequest.Create(Url + Folder) as HttpWebRequest;
            Request.Credentials = new NetworkCredential(Name, Password);
            return Request;
        }

        public void GetResponse(HttpWebRequest Request)
        {
            HttpWebResponse Response = (HttpWebResponse)Request.GetResponse() as HttpWebResponse;
            Response.Close();
        }

        public HttpWebResponse GetResponseStream(HttpWebRequest Request)
        {
            HttpWebResponse Response = (HttpWebResponse)Request.GetResponse() as HttpWebResponse;
            return Response;      
        }
    }
}
