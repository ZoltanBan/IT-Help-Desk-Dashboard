namespace desktopDashboard___Y_Lee.Forms
{
    partial class pingPc
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
            this.pnPingPcMain = new System.Windows.Forms.Panel();
            this.pnPingPcBody = new System.Windows.Forms.Panel();
            this.btnPingPcClearResult = new System.Windows.Forms.Button();
            this.lbPingPcMain = new System.Windows.Forms.Label();
            this.lbLookUpUser = new System.Windows.Forms.Label();
            this.btnPingPcOK = new System.Windows.Forms.Button();
            this.txtPingPc = new System.Windows.Forms.TextBox();
            this.pnPingPcTop = new System.Windows.Forms.Panel();
            this.lbPingPcTop = new System.Windows.Forms.Label();
            this.rtxtPingPc = new System.Windows.Forms.RichTextBox();
            this.pnPingPcMain.SuspendLayout();
            this.pnPingPcBody.SuspendLayout();
            this.pnPingPcTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnPingPcMain
            // 
            this.pnPingPcMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.pnPingPcMain.Controls.Add(this.pnPingPcBody);
            this.pnPingPcMain.Controls.Add(this.pnPingPcTop);
            this.pnPingPcMain.Controls.Add(this.rtxtPingPc);
            this.pnPingPcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnPingPcMain.Location = new System.Drawing.Point(0, 0);
            this.pnPingPcMain.Margin = new System.Windows.Forms.Padding(2);
            this.pnPingPcMain.Name = "pnPingPcMain";
            this.pnPingPcMain.Size = new System.Drawing.Size(901, 680);
            this.pnPingPcMain.TabIndex = 3;
            // 
            // pnPingPcBody
            // 
            this.pnPingPcBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(100)))));
            this.pnPingPcBody.Controls.Add(this.btnPingPcClearResult);
            this.pnPingPcBody.Controls.Add(this.lbPingPcMain);
            this.pnPingPcBody.Controls.Add(this.lbLookUpUser);
            this.pnPingPcBody.Controls.Add(this.btnPingPcOK);
            this.pnPingPcBody.Controls.Add(this.txtPingPc);
            this.pnPingPcBody.Location = new System.Drawing.Point(12, 46);
            this.pnPingPcBody.Name = "pnPingPcBody";
            this.pnPingPcBody.Size = new System.Drawing.Size(394, 89);
            this.pnPingPcBody.TabIndex = 15;
            // 
            // btnPingPcClearResult
            // 
            this.btnPingPcClearResult.BackColor = System.Drawing.Color.White;
            this.btnPingPcClearResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPingPcClearResult.ForeColor = System.Drawing.Color.Black;
            this.btnPingPcClearResult.Location = new System.Drawing.Point(281, 56);
            this.btnPingPcClearResult.Margin = new System.Windows.Forms.Padding(2);
            this.btnPingPcClearResult.Name = "btnPingPcClearResult";
            this.btnPingPcClearResult.Size = new System.Drawing.Size(109, 28);
            this.btnPingPcClearResult.TabIndex = 3;
            this.btnPingPcClearResult.Text = "Clear Result";
            this.btnPingPcClearResult.UseVisualStyleBackColor = false;
            this.btnPingPcClearResult.Click += new System.EventHandler(this.btnPingPcClearResult_Click);
            // 
            // lbPingPcMain
            // 
            this.lbPingPcMain.AutoSize = true;
            this.lbPingPcMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPingPcMain.ForeColor = System.Drawing.SystemColors.Window;
            this.lbPingPcMain.Location = new System.Drawing.Point(13, 5);
            this.lbPingPcMain.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPingPcMain.Name = "lbPingPcMain";
            this.lbPingPcMain.Size = new System.Drawing.Size(82, 20);
            this.lbPingPcMain.TabIndex = 6;
            this.lbPingPcMain.Text = "Device ID:";
            // 
            // lbLookUpUser
            // 
            this.lbLookUpUser.AutoSize = true;
            this.lbLookUpUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLookUpUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbLookUpUser.Location = new System.Drawing.Point(13, 60);
            this.lbLookUpUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbLookUpUser.Name = "lbLookUpUser";
            this.lbLookUpUser.Size = new System.Drawing.Size(183, 20);
            this.lbLookUpUser.TabIndex = 11;
            this.lbLookUpUser.Text = "e.g. AMMVW5ML81T3-L";
            this.lbLookUpUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPingPcOK
            // 
            this.btnPingPcOK.BackColor = System.Drawing.Color.White;
            this.btnPingPcOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPingPcOK.Location = new System.Drawing.Point(202, 27);
            this.btnPingPcOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnPingPcOK.Name = "btnPingPcOK";
            this.btnPingPcOK.Size = new System.Drawing.Size(56, 28);
            this.btnPingPcOK.TabIndex = 2;
            this.btnPingPcOK.Text = "OK";
            this.btnPingPcOK.UseVisualStyleBackColor = false;
            this.btnPingPcOK.Click += new System.EventHandler(this.btnPingPcOK_Click);
            // 
            // txtPingPc
            // 
            this.txtPingPc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.txtPingPc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPingPc.ForeColor = System.Drawing.Color.White;
            this.txtPingPc.Location = new System.Drawing.Point(15, 28);
            this.txtPingPc.Margin = new System.Windows.Forms.Padding(2);
            this.txtPingPc.Name = "txtPingPc";
            this.txtPingPc.Size = new System.Drawing.Size(181, 26);
            this.txtPingPc.TabIndex = 1;
            // 
            // pnPingPcTop
            // 
            this.pnPingPcTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(100)))));
            this.pnPingPcTop.Controls.Add(this.lbPingPcTop);
            this.pnPingPcTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnPingPcTop.Location = new System.Drawing.Point(0, 0);
            this.pnPingPcTop.Margin = new System.Windows.Forms.Padding(2);
            this.pnPingPcTop.Name = "pnPingPcTop";
            this.pnPingPcTop.Size = new System.Drawing.Size(901, 34);
            this.pnPingPcTop.TabIndex = 2;
            // 
            // lbPingPcTop
            // 
            this.lbPingPcTop.AutoSize = true;
            this.lbPingPcTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPingPcTop.ForeColor = System.Drawing.Color.White;
            this.lbPingPcTop.Location = new System.Drawing.Point(357, 9);
            this.lbPingPcTop.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPingPcTop.Name = "lbPingPcTop";
            this.lbPingPcTop.Size = new System.Drawing.Size(72, 20);
            this.lbPingPcTop.TabIndex = 7;
            this.lbPingPcTop.Text = "Ping PC";
            // 
            // rtxtPingPc
            // 
            this.rtxtPingPc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.rtxtPingPc.Font = new System.Drawing.Font("Courier New", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtPingPc.ForeColor = System.Drawing.Color.White;
            this.rtxtPingPc.Location = new System.Drawing.Point(12, 141);
            this.rtxtPingPc.Margin = new System.Windows.Forms.Padding(2);
            this.rtxtPingPc.Name = "rtxtPingPc";
            this.rtxtPingPc.Size = new System.Drawing.Size(879, 499);
            this.rtxtPingPc.TabIndex = 4;
            this.rtxtPingPc.Text = "";
            // 
            // pingPc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 680);
            this.Controls.Add(this.pnPingPcMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "pingPc";
            this.Text = "pingPc";
            this.pnPingPcMain.ResumeLayout(false);
            this.pnPingPcBody.ResumeLayout(false);
            this.pnPingPcBody.PerformLayout();
            this.pnPingPcTop.ResumeLayout(false);
            this.pnPingPcTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnPingPcMain;
        private System.Windows.Forms.Label lbPingPcMain;
        private System.Windows.Forms.Button btnPingPcOK;
        private System.Windows.Forms.TextBox txtPingPc;
        private System.Windows.Forms.Panel pnPingPcTop;
        private System.Windows.Forms.Label lbPingPcTop;
        private System.Windows.Forms.RichTextBox rtxtPingPc;
        private System.Windows.Forms.Panel pnPingPcBody;
        private System.Windows.Forms.Button btnPingPcClearResult;
        private System.Windows.Forms.Label lbLookUpUser;
    }
}