namespace desktopDashboard___Y_Lee.Forms
{
    partial class lookupUser
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
            this.pnLookupUserMain = new System.Windows.Forms.Panel();
            this.pnResetPassword = new System.Windows.Forms.Panel();
            this.btnClearResult = new System.Windows.Forms.Button();
            this.lbLookUpUser = new System.Windows.Forms.Label();
            this.lbLookupUserMain = new System.Windows.Forms.Label();
            this.txtLookupUser = new System.Windows.Forms.TextBox();
            this.btnLookupUserOK = new System.Windows.Forms.Button();
            this.pnLookupUserTop = new System.Windows.Forms.Panel();
            this.lbLookupUserTop = new System.Windows.Forms.Label();
            this.rtxtLookupUser = new System.Windows.Forms.RichTextBox();
            this.pnLookupUserMain.SuspendLayout();
            this.pnResetPassword.SuspendLayout();
            this.pnLookupUserTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnLookupUserMain
            // 
            this.pnLookupUserMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.pnLookupUserMain.Controls.Add(this.pnResetPassword);
            this.pnLookupUserMain.Controls.Add(this.pnLookupUserTop);
            this.pnLookupUserMain.Controls.Add(this.rtxtLookupUser);
            this.pnLookupUserMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnLookupUserMain.Location = new System.Drawing.Point(0, 0);
            this.pnLookupUserMain.Margin = new System.Windows.Forms.Padding(2);
            this.pnLookupUserMain.Name = "pnLookupUserMain";
            this.pnLookupUserMain.Size = new System.Drawing.Size(901, 680);
            this.pnLookupUserMain.TabIndex = 2;
            // 
            // pnResetPassword
            // 
            this.pnResetPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(100)))));
            this.pnResetPassword.Controls.Add(this.btnClearResult);
            this.pnResetPassword.Controls.Add(this.lbLookUpUser);
            this.pnResetPassword.Controls.Add(this.lbLookupUserMain);
            this.pnResetPassword.Controls.Add(this.txtLookupUser);
            this.pnResetPassword.Controls.Add(this.btnLookupUserOK);
            this.pnResetPassword.Location = new System.Drawing.Point(12, 46);
            this.pnResetPassword.Name = "pnResetPassword";
            this.pnResetPassword.Size = new System.Drawing.Size(484, 89);
            this.pnResetPassword.TabIndex = 14;
            // 
            // btnClearResult
            // 
            this.btnClearResult.BackColor = System.Drawing.Color.White;
            this.btnClearResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearResult.ForeColor = System.Drawing.Color.Black;
            this.btnClearResult.Location = new System.Drawing.Point(369, 56);
            this.btnClearResult.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearResult.Name = "btnClearResult";
            this.btnClearResult.Size = new System.Drawing.Size(109, 28);
            this.btnClearResult.TabIndex = 3;
            this.btnClearResult.Text = "Clear Result";
            this.btnClearResult.UseVisualStyleBackColor = false;
            this.btnClearResult.Click += new System.EventHandler(this.btnClearResult_Click);
            // 
            // lbLookUpUser
            // 
            this.lbLookUpUser.AutoSize = true;
            this.lbLookUpUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLookUpUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbLookUpUser.Location = new System.Drawing.Point(13, 60);
            this.lbLookUpUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbLookUpUser.Name = "lbLookUpUser";
            this.lbLookUpUser.Size = new System.Drawing.Size(272, 20);
            this.lbLookUpUser.TabIndex = 11;
            this.lbLookUpUser.Text = "NTID / Display name / E-Mail Address";
            this.lbLookUpUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbLookupUserMain
            // 
            this.lbLookupUserMain.AutoSize = true;
            this.lbLookupUserMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLookupUserMain.ForeColor = System.Drawing.SystemColors.Window;
            this.lbLookupUserMain.Location = new System.Drawing.Point(13, 5);
            this.lbLookupUserMain.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbLookupUserMain.Name = "lbLookupUserMain";
            this.lbLookupUserMain.Size = new System.Drawing.Size(97, 20);
            this.lbLookupUserMain.TabIndex = 6;
            this.lbLookupUserMain.Text = "Seach User:";
            // 
            // txtLookupUser
            // 
            this.txtLookupUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.txtLookupUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLookupUser.ForeColor = System.Drawing.Color.White;
            this.txtLookupUser.Location = new System.Drawing.Point(15, 28);
            this.txtLookupUser.Margin = new System.Windows.Forms.Padding(2);
            this.txtLookupUser.Name = "txtLookupUser";
            this.txtLookupUser.Size = new System.Drawing.Size(270, 26);
            this.txtLookupUser.TabIndex = 1;
            // 
            // btnLookupUserOK
            // 
            this.btnLookupUserOK.BackColor = System.Drawing.Color.White;
            this.btnLookupUserOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLookupUserOK.Location = new System.Drawing.Point(291, 27);
            this.btnLookupUserOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnLookupUserOK.Name = "btnLookupUserOK";
            this.btnLookupUserOK.Size = new System.Drawing.Size(56, 28);
            this.btnLookupUserOK.TabIndex = 2;
            this.btnLookupUserOK.Text = "OK";
            this.btnLookupUserOK.UseVisualStyleBackColor = false;
            this.btnLookupUserOK.Click += new System.EventHandler(this.btnLookupUserOK_Click);
            // 
            // pnLookupUserTop
            // 
            this.pnLookupUserTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(100)))));
            this.pnLookupUserTop.Controls.Add(this.lbLookupUserTop);
            this.pnLookupUserTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLookupUserTop.Location = new System.Drawing.Point(0, 0);
            this.pnLookupUserTop.Margin = new System.Windows.Forms.Padding(2);
            this.pnLookupUserTop.Name = "pnLookupUserTop";
            this.pnLookupUserTop.Size = new System.Drawing.Size(901, 34);
            this.pnLookupUserTop.TabIndex = 2;
            // 
            // lbLookupUserTop
            // 
            this.lbLookupUserTop.AutoSize = true;
            this.lbLookupUserTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLookupUserTop.ForeColor = System.Drawing.Color.White;
            this.lbLookupUserTop.Location = new System.Drawing.Point(357, 9);
            this.lbLookupUserTop.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbLookupUserTop.Name = "lbLookupUserTop";
            this.lbLookupUserTop.Size = new System.Drawing.Size(119, 20);
            this.lbLookupUserTop.TabIndex = 7;
            this.lbLookupUserTop.Text = "Look Up User";
            // 
            // rtxtLookupUser
            // 
            this.rtxtLookupUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.rtxtLookupUser.Font = new System.Drawing.Font("Courier New", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtLookupUser.ForeColor = System.Drawing.Color.White;
            this.rtxtLookupUser.Location = new System.Drawing.Point(12, 141);
            this.rtxtLookupUser.Margin = new System.Windows.Forms.Padding(2);
            this.rtxtLookupUser.Name = "rtxtLookupUser";
            this.rtxtLookupUser.Size = new System.Drawing.Size(879, 499);
            this.rtxtLookupUser.TabIndex = 4;
            this.rtxtLookupUser.Text = "";
            // 
            // lookupUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 680);
            this.Controls.Add(this.pnLookupUserMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "lookupUser";
            this.Text = "lookUpUser";
            this.pnLookupUserMain.ResumeLayout(false);
            this.pnResetPassword.ResumeLayout(false);
            this.pnResetPassword.PerformLayout();
            this.pnLookupUserTop.ResumeLayout(false);
            this.pnLookupUserTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnLookupUserMain;
        private System.Windows.Forms.Label lbLookupUserMain;
        private System.Windows.Forms.Button btnLookupUserOK;
        private System.Windows.Forms.TextBox txtLookupUser;
        private System.Windows.Forms.Panel pnLookupUserTop;
        private System.Windows.Forms.Label lbLookupUserTop;
        private System.Windows.Forms.RichTextBox rtxtLookupUser;
        private System.Windows.Forms.Panel pnResetPassword;
        private System.Windows.Forms.Label lbLookUpUser;
        private System.Windows.Forms.Button btnClearResult;
    }
}