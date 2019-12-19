namespace PureCloud_HomeDivisionRemoval
{
    partial class MainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnButton2 = new System.Windows.Forms.Button();
            this.lblEnvironment = new System.Windows.Forms.Label();
            this.lblClientSecret = new System.Windows.Forms.Label();
            this.lblClientId = new System.Windows.Forms.Label();
            this.txtClientSecret = new System.Windows.Forms.TextBox();
            this.txtClientId = new System.Windows.Forms.TextBox();
            this.cmbEnvironment = new System.Windows.Forms.ComboBox();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.btnRemoveHomeDivision = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDisconnect);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.btnButton2);
            this.groupBox1.Controls.Add(this.lblEnvironment);
            this.groupBox1.Controls.Add(this.lblClientSecret);
            this.groupBox1.Controls.Add(this.lblClientId);
            this.groupBox1.Controls.Add(this.txtClientSecret);
            this.groupBox1.Controls.Add(this.txtClientId);
            this.groupBox1.Controls.Add(this.cmbEnvironment);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 182);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PureCloud Settings";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(237, 134);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(100, 28);
            this.btnDisconnect.TabIndex = 20;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(129, 134);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(100, 28);
            this.btnConnect.TabIndex = 19;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnButton2
            // 
            this.btnButton2.Location = new System.Drawing.Point(351, 133);
            this.btnButton2.Name = "btnButton2";
            this.btnButton2.Size = new System.Drawing.Size(75, 29);
            this.btnButton2.TabIndex = 15;
            this.btnButton2.Text = "GetOrg";
            this.btnButton2.UseVisualStyleBackColor = true;
            this.btnButton2.Click += new System.EventHandler(this.btnButton2_Click);
            // 
            // lblEnvironment
            // 
            this.lblEnvironment.AutoSize = true;
            this.lblEnvironment.Location = new System.Drawing.Point(31, 41);
            this.lblEnvironment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnvironment.Name = "lblEnvironment";
            this.lblEnvironment.Size = new System.Drawing.Size(91, 17);
            this.lblEnvironment.TabIndex = 18;
            this.lblEnvironment.Text = "Environment:";
            // 
            // lblClientSecret
            // 
            this.lblClientSecret.AutoSize = true;
            this.lblClientSecret.Location = new System.Drawing.Point(29, 106);
            this.lblClientSecret.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClientSecret.Name = "lblClientSecret";
            this.lblClientSecret.Size = new System.Drawing.Size(92, 17);
            this.lblClientSecret.TabIndex = 17;
            this.lblClientSecret.Text = "Client Secret:";
            // 
            // lblClientId
            // 
            this.lblClientId.AutoSize = true;
            this.lblClientId.Location = new System.Drawing.Point(59, 74);
            this.lblClientId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClientId.Name = "lblClientId";
            this.lblClientId.Size = new System.Drawing.Size(62, 17);
            this.lblClientId.TabIndex = 16;
            this.lblClientId.Text = "Client Id:";
            // 
            // txtClientSecret
            // 
            this.txtClientSecret.Location = new System.Drawing.Point(129, 104);
            this.txtClientSecret.Margin = new System.Windows.Forms.Padding(4);
            this.txtClientSecret.Name = "txtClientSecret";
            this.txtClientSecret.PasswordChar = '*';
            this.txtClientSecret.Size = new System.Drawing.Size(297, 22);
            this.txtClientSecret.TabIndex = 15;
            // 
            // txtClientId
            // 
            this.txtClientId.Location = new System.Drawing.Point(129, 72);
            this.txtClientId.Margin = new System.Windows.Forms.Padding(4);
            this.txtClientId.Name = "txtClientId";
            this.txtClientId.Size = new System.Drawing.Size(297, 22);
            this.txtClientId.TabIndex = 14;
            // 
            // cmbEnvironment
            // 
            this.cmbEnvironment.FormattingEnabled = true;
            this.cmbEnvironment.Items.AddRange(new object[] {
            "mypurecloud.ie",
            "mypurecloud.de",
            "mypurecloud.com",
            "mypurecloud.com.au",
            "mypurecloud.jp"});
            this.cmbEnvironment.Location = new System.Drawing.Point(129, 41);
            this.cmbEnvironment.Name = "cmbEnvironment";
            this.cmbEnvironment.Size = new System.Drawing.Size(297, 24);
            this.cmbEnvironment.TabIndex = 13;
            // 
            // lstLog
            // 
            this.lstLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLog.FormattingEnabled = true;
            this.lstLog.ItemHeight = 16;
            this.lstLog.Location = new System.Drawing.Point(13, 214);
            this.lstLog.Margin = new System.Windows.Forms.Padding(4);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(783, 180);
            this.lstLog.TabIndex = 17;
            // 
            // btnRemoveHomeDivision
            // 
            this.btnRemoveHomeDivision.Location = new System.Drawing.Point(532, 84);
            this.btnRemoveHomeDivision.Name = "btnRemoveHomeDivision";
            this.btnRemoveHomeDivision.Size = new System.Drawing.Size(195, 49);
            this.btnRemoveHomeDivision.TabIndex = 18;
            this.btnRemoveHomeDivision.Text = "Remove Home Division";
            this.btnRemoveHomeDivision.UseVisualStyleBackColor = true;
            this.btnRemoveHomeDivision.Click += new System.EventHandler(this.btnRemoveHomeDivision_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 407);
            this.Controls.Add(this.btnRemoveHomeDivision);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "PureCloud";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnButton2;
        private System.Windows.Forms.Label lblEnvironment;
        private System.Windows.Forms.Label lblClientSecret;
        private System.Windows.Forms.Label lblClientId;
        private System.Windows.Forms.TextBox txtClientSecret;
        private System.Windows.Forms.TextBox txtClientId;
        private System.Windows.Forms.ComboBox cmbEnvironment;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Button btnRemoveHomeDivision;
    }
}

