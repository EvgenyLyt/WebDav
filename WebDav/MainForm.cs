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
    public partial class MainForm : Form
    {
        DataUser User;
        Content Files = new Content();
        delegate void Function();
        Dictionary<string, Function> Options = new Dictionary<string, Function>();

        public MainForm(string Url, string Name, string Password, Form Log)
        {
            InitializeComponent();
            MakeMenu();
            User = new DataUser();
            User.GotMessage += GetMessage;
            User.FillData(Url, Name, Password, "/", Log);
            User.InfoFiles(ref Files, ref User, ref ListFiles, User.Data.Hrefs.Last(), true);
        }

        private void MakeMenu()
        {
            Options.Add(refreshData.Name, RefreshFiles);
            Options.Add(copyFile.Name, CopyFile);
            Options.Add(pasteFile.Name, PasteFile);
            Options.Add(downloadFile.Name, DownloadFile);
            Options.Add(deleteFile.Name, DeleteFile);
            Options.Add(renameFile.Name, RenameFile);
            Options.Add(propertiesFile.Name, PropertiesFile);
            Options.Add(btnBack.Name, Back);
            Options.Add(btnMakeCol.Name, MakeCol);
            Options.Add(btnUpload.Name, UploadFiles);
        }

        private void RefreshFiles()
        {
            User.InfoFiles(ref Files, ref User, ref ListFiles, User.Data.Hrefs.Last(), true);
        }

        private void CopyFile()
        {
            Copy(ListFiles.SelectedIndices.Count);
        }

        private void Copy(int AmountFiles)
        {
            if (AmountFiles != 0)
                Files.CopyFiles(AmountFiles, ListFiles);
        }

        private void PasteFile()
        {
            Activities Act = new Activities();
            Act.GotMessage += GetMessage;
            Act.Activity(ref Files, ref User, ListFiles, Loading, Files.CopyHref.Count, false, "Paste");
        }

        private void DownloadFile()
        {
            Activities Act = new Activities();
            Act.GotMessage += GetMessage;
            Act.Activity(ref Files, ref User, ListFiles, Loading, ListFiles.SelectedIndices.Count, true, "Download");
        }

        private void DeleteFile()
        {
            Activities Act = new Activities();
            Act.GotMessage += GetMessage;
            Act.Activity(ref Files, ref User, ListFiles, Loading, ListFiles.SelectedIndices.Count, true, "Delete");
        }

        private void RenameFile()
        {
            RenameFiles(false);
        }

        private void RenameFiles(bool DoubleClick)
        {
            Rename Act = new Rename();
            Act.StartRename(ListFiles, User, Files, DoubleClick);
        }

        private void AfterEdit(object sender, LabelEditEventArgs e)
        {
            Rename Act = new Rename();
            Act.GotMessage += GetMessage;
            Act.EndRename(ref Files, ref User, ref ListFiles, e);
        }

        private void PropertiesFile()
        {
            if (ListFiles.SelectedIndices.Count==1)
                Files.ShowProperties(ListFiles.SelectedItems[0].Index);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            User.Data.Log.Show();
        }

        private void listFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RenameFiles(true);
        }

        private void Back()
        {
            if (User.Data.Hrefs.Count != 1)
                User.InfoFiles(ref Files, ref User, ref ListFiles, User.Data.Hrefs[User.Data.Hrefs.Count-2], false);
        }

        private void MakeCol()
        {
            Activities Act = new Activities();
            Act.GotMessage += GetMessage;
            Act.MakeDirectory(ref Files, ref User, ListFiles, NewFolder, NewFolder.Text);
        }

        private void Rules(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '/') || (e.KeyChar == ' '))
                e.KeyChar = '\0';
        }

        private void UploadFiles()
        {
            if (UpFiles.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Activities Act = new Activities(UpFiles.FileNames, UpFiles.SafeFileNames);
                Act.GotMessage += GetMessage;
                Act.Activity(ref Files, ref User, ListFiles, Loading, UpFiles.FileNames.Count(), false, "Upload");
            }
        }

        private void GetMessage(string Message)
        {
            MessageBox.Show(Message);
        }

        private void ClickItem(object sender, ToolStripItemClickedEventArgs e)
        {
            if (Options.ContainsKey(e.ClickedItem.Name))
            {
                Actions.Close();
                Options[e.ClickedItem.Name]();
            }
        }

        private void ButClick(object sender, EventArgs e)
        {
            var But = (Button)sender;
            if (Options.ContainsKey(But.Name))
                Options[But.Name]();
        }
    }
}
