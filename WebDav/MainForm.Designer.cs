namespace WebDav
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Actions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshData = new System.Windows.Forms.ToolStripMenuItem();
            this.Separ = new System.Windows.Forms.ToolStripSeparator();
            this.copyFile = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteFile = new System.Windows.Forms.ToolStripMenuItem();
            this.S = new System.Windows.Forms.ToolStripSeparator();
            this.downloadFile = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFile = new System.Windows.Forms.ToolStripMenuItem();
            this.renameFile = new System.Windows.Forms.ToolStripMenuItem();
            this.Sep = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnMakeCol = new System.Windows.Forms.Button();
            this.UpFiles = new System.Windows.Forms.OpenFileDialog();
            this.btnUpload = new System.Windows.Forms.Button();
            this.ListFiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Icons = new System.Windows.Forms.ImageList(this.components);
            this.Loading = new System.Windows.Forms.ProgressBar();
            this.NewFolder = new System.Windows.Forms.TextBox();
            this.Actions.SuspendLayout();
            this.SuspendLayout();
            // 
            // Actions
            // 
            this.Actions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshData,
            this.Separ,
            this.copyFile,
            this.pasteFile,
            this.S,
            this.downloadFile,
            this.deleteFile,
            this.renameFile,
            this.Sep,
            this.propertiesFile});
            this.Actions.Name = "contextMenuStrip1";
            this.Actions.Size = new System.Drawing.Size(162, 176);
            this.Actions.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ClickItem);
            // 
            // refreshData
            // 
            this.refreshData.Name = "refreshData";
            this.refreshData.Size = new System.Drawing.Size(161, 22);
            this.refreshData.Text = "Обновить";
            // 
            // Separ
            // 
            this.Separ.Name = "Separ";
            this.Separ.Size = new System.Drawing.Size(158, 6);
            // 
            // copyFile
            // 
            this.copyFile.Name = "copyFile";
            this.copyFile.Size = new System.Drawing.Size(161, 22);
            this.copyFile.Text = "Копировать";
            // 
            // pasteFile
            // 
            this.pasteFile.Name = "pasteFile";
            this.pasteFile.Size = new System.Drawing.Size(161, 22);
            this.pasteFile.Text = "Вставить";
            // 
            // S
            // 
            this.S.Name = "S";
            this.S.Size = new System.Drawing.Size(158, 6);
            // 
            // downloadFile
            // 
            this.downloadFile.Name = "downloadFile";
            this.downloadFile.Size = new System.Drawing.Size(161, 22);
            this.downloadFile.Text = "Скачать";
            // 
            // deleteFile
            // 
            this.deleteFile.Name = "deleteFile";
            this.deleteFile.Size = new System.Drawing.Size(161, 22);
            this.deleteFile.Text = "Удалить";
            // 
            // renameFile
            // 
            this.renameFile.Name = "renameFile";
            this.renameFile.Size = new System.Drawing.Size(161, 22);
            this.renameFile.Text = "Переименовать";
            // 
            // Sep
            // 
            this.Sep.Name = "Sep";
            this.Sep.Size = new System.Drawing.Size(158, 6);
            // 
            // propertiesFile
            // 
            this.propertiesFile.Name = "propertiesFile";
            this.propertiesFile.Size = new System.Drawing.Size(161, 22);
            this.propertiesFile.Text = "Свойства";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Calibri", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBack.Location = new System.Drawing.Point(937, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(122, 51);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.ButClick);
            // 
            // btnMakeCol
            // 
            this.btnMakeCol.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMakeCol.Location = new System.Drawing.Point(937, 71);
            this.btnMakeCol.Name = "btnMakeCol";
            this.btnMakeCol.Size = new System.Drawing.Size(122, 64);
            this.btnMakeCol.TabIndex = 4;
            this.btnMakeCol.Text = "Создать папку";
            this.btnMakeCol.UseVisualStyleBackColor = true;
            this.btnMakeCol.Click += new System.EventHandler(this.ButClick);
            // 
            // UpFiles
            // 
            this.UpFiles.Multiselect = true;
            // 
            // btnUpload
            // 
            this.btnUpload.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUpload.Location = new System.Drawing.Point(937, 198);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(122, 60);
            this.btnUpload.TabIndex = 5;
            this.btnUpload.Text = "Загрузить";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.ButClick);
            // 
            // ListFiles
            // 
            this.ListFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.ListFiles.ContextMenuStrip = this.Actions;
            this.ListFiles.LabelEdit = true;
            this.ListFiles.LargeImageList = this.Icons;
            this.ListFiles.Location = new System.Drawing.Point(0, 0);
            this.ListFiles.Name = "ListFiles";
            this.ListFiles.Size = new System.Drawing.Size(937, 524);
            this.ListFiles.SmallImageList = this.Icons;
            this.ListFiles.TabIndex = 10;
            this.ListFiles.UseCompatibleStateImageBehavior = false;
            this.ListFiles.View = System.Windows.Forms.View.Details;
            this.ListFiles.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.AfterEdit);
            this.ListFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listFiles_MouseDoubleClick);
            // 
            // Icons
            // 
            this.Icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Icons.ImageStream")));
            this.Icons.TransparentColor = System.Drawing.Color.Transparent;
            this.Icons.Images.SetKeyName(0, "Audio.ico");
            this.Icons.Images.SetKeyName(1, "Dir.ico");
            this.Icons.Images.SetKeyName(2, "Image.ico");
            this.Icons.Images.SetKeyName(3, "Text.ico");
            this.Icons.Images.SetKeyName(4, "Video.ico");
            this.Icons.Images.SetKeyName(5, "Unknown.ico");
            // 
            // Loading
            // 
            this.Loading.Location = new System.Drawing.Point(0, 524);
            this.Loading.Maximum = 800;
            this.Loading.Name = "Loading";
            this.Loading.Size = new System.Drawing.Size(937, 23);
            this.Loading.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.Loading.TabIndex = 12;
            // 
            // NewFolder
            // 
            this.NewFolder.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewFolder.Location = new System.Drawing.Point(937, 154);
            this.NewFolder.MaxLength = 30;
            this.NewFolder.Name = "NewFolder";
            this.NewFolder.Size = new System.Drawing.Size(209, 27);
            this.NewFolder.TabIndex = 14;
            this.NewFolder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Rules);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1150, 548);
            this.Controls.Add(this.NewFolder);
            this.Controls.Add(this.Loading);
            this.Controls.Add(this.ListFiles);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnMakeCol);
            this.Controls.Add(this.btnBack);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WebDav";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Actions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip Actions;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnMakeCol;
        private System.Windows.Forms.OpenFileDialog UpFiles;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.ListView ListFiles;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ImageList Icons;
        private System.Windows.Forms.ToolStripMenuItem copyFile;
        private System.Windows.Forms.ToolStripMenuItem pasteFile;
        private System.Windows.Forms.ToolStripSeparator S;
        private System.Windows.Forms.ToolStripMenuItem downloadFile;
        private System.Windows.Forms.ToolStripMenuItem deleteFile;
        private System.Windows.Forms.ToolStripMenuItem renameFile;
        private System.Windows.Forms.ToolStripSeparator Sep;
        private System.Windows.Forms.ToolStripMenuItem propertiesFile;
        private System.Windows.Forms.ProgressBar Loading;
        private System.Windows.Forms.TextBox NewFolder;
        private System.Windows.Forms.ToolStripMenuItem refreshData;
        private System.Windows.Forms.ToolStripSeparator Separ;


    }
}

