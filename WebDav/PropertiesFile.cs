using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WebDav
{

    public partial class PropFiles : Form
    {

        public PropFiles(params string []Properties)
        {
            InitializeComponent();
            Label[] LabelProp_s = { lblType, lblName, lblLastMod, lblCrDate, lblSize };
            MakeProperties(Properties, LabelProp_s);
        }

        private void MakeProperties(string[] Properties, Label[]LabelProp_s)
        {
            DateTime Times = new DateTime();
            Times = DateTime.Parse(Properties[2]);
            Properties[2] = Times.ToString("dd-MM-yyyy HH:mm:ss");
            Times = DateTime.Parse(Properties[3]);
            Properties[3] = Times.ToString("dd-MM-yyyy HH:mm:ss");
            string[] Names = { "", "Имя: ", "Изменён: ", "Создан: ", "Размер файла: " };
            lblSize.Visible = true;
            if (Properties[0].Contains("collection"))
            {
                Properties[0] = "Папка";
                lblSize.Visible = false;
            }
            else
                Properties[0] = "Файл: " + Properties[0];
            for (int index=0; index<Properties.Length; index++)
                LabelProp_s[index].Text = Names[index]+Properties[index];
            if (Properties[4]!=null)
            {
                long Size = Int64.Parse(Properties[4]);
                lblSize.Text=Names[4];
                if (Size/(1024*1024)>0)
                    lblSize.Text += (Math.Round((double)Size/(1024*1024),2).ToString()) + " МБ ";
                else
                    if (Size/1024>0)
                        lblSize.Text += (Math.Round((double)Size/(1024),2).ToString()) + " КБ ";
                lblSize.Text += Size.ToString() + " байт(а)";
            }
        }
    }
}
