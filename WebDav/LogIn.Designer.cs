namespace WebDav
{
    partial class LogIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLog = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.edtEmail = new System.Windows.Forms.TextBox();
            this.edtPassword = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.showPass = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnLog
            // 
            this.btnLog.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLog.Location = new System.Drawing.Point(176, 125);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(90, 38);
            this.btnLog.TabIndex = 0;
            this.btnLog.Text = "Войти";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblName.Location = new System.Drawing.Point(50, 28);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(55, 19);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "E-mail:";
            // 
            // edtEmail
            // 
            this.edtEmail.Location = new System.Drawing.Point(111, 29);
            this.edtEmail.MaxLength = 40;
            this.edtEmail.Name = "edtEmail";
            this.edtEmail.Size = new System.Drawing.Size(243, 20);
            this.edtEmail.TabIndex = 2;
            this.edtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditKey);
            // 
            // edtPassword
            // 
            this.edtPassword.Location = new System.Drawing.Point(111, 73);
            this.edtPassword.MaxLength = 30;
            this.edtPassword.Name = "edtPassword";
            this.edtPassword.Size = new System.Drawing.Size(146, 20);
            this.edtPassword.TabIndex = 4;
            this.edtPassword.UseSystemPasswordChar = true;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPass.Location = new System.Drawing.Point(42, 72);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(63, 19);
            this.lblPass.TabIndex = 3;
            this.lblPass.Text = "Пароль:";
            // 
            // showPass
            // 
            this.showPass.AutoSize = true;
            this.showPass.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showPass.Location = new System.Drawing.Point(274, 71);
            this.showPass.Name = "showPass";
            this.showPass.Size = new System.Drawing.Size(151, 23);
            this.showPass.TabIndex = 5;
            this.showPass.Text = "Показать пароль";
            this.showPass.UseVisualStyleBackColor = true;
            this.showPass.CheckedChanged += new System.EventHandler(this.showPass_CheckedChanged);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(448, 188);
            this.Controls.Add(this.showPass);
            this.Controls.Add(this.edtPassword);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.edtEmail);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogIn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox edtEmail;
        private System.Windows.Forms.TextBox edtPassword;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.CheckBox showPass;
    }
}