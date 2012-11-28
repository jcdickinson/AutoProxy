namespace AutoProxy
{
    partial class SettingsWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            this.profilesComboBox = new System.Windows.Forms.ComboBox();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.scriptTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.scriptCheckBox = new System.Windows.Forms.CheckBox();
            this.automaticCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sameProxyCheckBox = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.socksPortTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ftpPortTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.securePortTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.httpPortTextBox = new System.Windows.Forms.TextBox();
            this.socksServerTextBox = new System.Windows.Forms.TextBox();
            this.ftpServerTextBox = new System.Windows.Forms.TextBox();
            this.secureServerTextBox = new System.Windows.Forms.TextBox();
            this.httpServerTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.useProxyCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bypassTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.bypassCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.currentButton = new System.Windows.Forms.Button();
            this.gatewayTextBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.subnetTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.profileLabel = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.githubPictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.githubPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // profilesComboBox
            // 
            this.profilesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.profilesComboBox.FormattingEnabled = true;
            this.profilesComboBox.Location = new System.Drawing.Point(12, 12);
            this.profilesComboBox.Name = "profilesComboBox";
            this.profilesComboBox.Size = new System.Drawing.Size(644, 21);
            this.profilesComboBox.TabIndex = 0;
            this.profilesComboBox.SelectedIndexChanged += new System.EventHandler(this.profilesComboBox_SelectedIndexChanged);
            this.profilesComboBox.TextUpdate += new System.EventHandler(this.profilesComboBox_TextUpdate);
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.Location = new System.Drawing.Point(691, 11);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(23, 23);
            this.removeButton.TabIndex = 2;
            this.removeButton.Text = "-";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(662, 11);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(23, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "+";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.scriptTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.scriptCheckBox);
            this.groupBox1.Controls.Add(this.automaticCheckBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 145);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Automatic Configuration";
            // 
            // scriptTextBox
            // 
            this.scriptTextBox.Enabled = false;
            this.scriptTextBox.Location = new System.Drawing.Point(77, 114);
            this.scriptTextBox.Name = "scriptTextBox";
            this.scriptTextBox.Size = new System.Drawing.Size(252, 22);
            this.scriptTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "A&ddress:";
            // 
            // scriptCheckBox
            // 
            this.scriptCheckBox.AutoSize = true;
            this.scriptCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.scriptCheckBox.Location = new System.Drawing.Point(3, 89);
            this.scriptCheckBox.Name = "scriptCheckBox";
            this.scriptCheckBox.Padding = new System.Windows.Forms.Padding(3);
            this.scriptCheckBox.Size = new System.Drawing.Size(342, 23);
            this.scriptCheckBox.TabIndex = 2;
            this.scriptCheckBox.Text = "Use an automatic configuration &script";
            this.scriptCheckBox.UseVisualStyleBackColor = true;
            this.scriptCheckBox.CheckedChanged += new System.EventHandler(this.scriptCheckBox_CheckedChanged);
            // 
            // automaticCheckBox
            // 
            this.automaticCheckBox.AutoSize = true;
            this.automaticCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.automaticCheckBox.Location = new System.Drawing.Point(3, 66);
            this.automaticCheckBox.Name = "automaticCheckBox";
            this.automaticCheckBox.Padding = new System.Windows.Forms.Padding(3);
            this.automaticCheckBox.Size = new System.Drawing.Size(342, 23);
            this.automaticCheckBox.TabIndex = 1;
            this.automaticCheckBox.Text = "&Automatically detect settings";
            this.automaticCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(342, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Automatic configuration may override manual settings. To ensure the use of manual" +
    " settings, disable automatic configuration.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sameProxyCheckBox);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.socksPortTextBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.ftpPortTextBox);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.securePortTextBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.httpPortTextBox);
            this.groupBox2.Controls.Add(this.socksServerTextBox);
            this.groupBox2.Controls.Add(this.ftpServerTextBox);
            this.groupBox2.Controls.Add(this.secureServerTextBox);
            this.groupBox2.Controls.Add(this.httpServerTextBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.useProxyCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 190);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(348, 219);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Servers";
            // 
            // sameProxyCheckBox
            // 
            this.sameProxyCheckBox.Checked = true;
            this.sameProxyCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sameProxyCheckBox.Enabled = false;
            this.sameProxyCheckBox.Location = new System.Drawing.Point(26, 187);
            this.sameProxyCheckBox.Name = "sameProxyCheckBox";
            this.sameProxyCheckBox.Size = new System.Drawing.Size(303, 27);
            this.sameProxyCheckBox.TabIndex = 20;
            this.sameProxyCheckBox.Text = "Use the same proxy server for all protocols";
            this.sameProxyCheckBox.UseVisualStyleBackColor = true;
            this.sameProxyCheckBox.CheckedChanged += new System.EventHandler(this.proxyCheckBox_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 164);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Soc&ks:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 138);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "&FTP:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Secu&re:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "&HTTP:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(260, 164);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = ":";
            // 
            // socksPortTextBox
            // 
            this.socksPortTextBox.Enabled = false;
            this.socksPortTextBox.Location = new System.Drawing.Point(277, 161);
            this.socksPortTextBox.Name = "socksPortTextBox";
            this.socksPortTextBox.Size = new System.Drawing.Size(52, 22);
            this.socksPortTextBox.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(260, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = ":";
            // 
            // ftpPortTextBox
            // 
            this.ftpPortTextBox.Enabled = false;
            this.ftpPortTextBox.Location = new System.Drawing.Point(277, 135);
            this.ftpPortTextBox.Name = "ftpPortTextBox";
            this.ftpPortTextBox.Size = new System.Drawing.Size(52, 22);
            this.ftpPortTextBox.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(260, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = ":";
            // 
            // securePortTextBox
            // 
            this.securePortTextBox.Enabled = false;
            this.securePortTextBox.Location = new System.Drawing.Point(277, 109);
            this.securePortTextBox.Name = "securePortTextBox";
            this.securePortTextBox.Size = new System.Drawing.Size(52, 22);
            this.securePortTextBox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(260, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = ":";
            // 
            // httpPortTextBox
            // 
            this.httpPortTextBox.Enabled = false;
            this.httpPortTextBox.Location = new System.Drawing.Point(277, 83);
            this.httpPortTextBox.Name = "httpPortTextBox";
            this.httpPortTextBox.Size = new System.Drawing.Size(52, 22);
            this.httpPortTextBox.TabIndex = 7;
            // 
            // socksServerTextBox
            // 
            this.socksServerTextBox.Enabled = false;
            this.socksServerTextBox.Location = new System.Drawing.Point(89, 161);
            this.socksServerTextBox.Name = "socksServerTextBox";
            this.socksServerTextBox.Size = new System.Drawing.Size(165, 22);
            this.socksServerTextBox.TabIndex = 17;
            // 
            // ftpServerTextBox
            // 
            this.ftpServerTextBox.Enabled = false;
            this.ftpServerTextBox.Location = new System.Drawing.Point(89, 135);
            this.ftpServerTextBox.Name = "ftpServerTextBox";
            this.ftpServerTextBox.Size = new System.Drawing.Size(165, 22);
            this.ftpServerTextBox.TabIndex = 13;
            // 
            // secureServerTextBox
            // 
            this.secureServerTextBox.Enabled = false;
            this.secureServerTextBox.Location = new System.Drawing.Point(89, 109);
            this.secureServerTextBox.Name = "secureServerTextBox";
            this.secureServerTextBox.Size = new System.Drawing.Size(165, 22);
            this.secureServerTextBox.TabIndex = 9;
            // 
            // httpServerTextBox
            // 
            this.httpServerTextBox.Enabled = false;
            this.httpServerTextBox.Location = new System.Drawing.Point(89, 83);
            this.httpServerTextBox.Name = "httpServerTextBox";
            this.httpServerTextBox.Size = new System.Drawing.Size(165, 22);
            this.httpServerTextBox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(274, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Proxy address to use";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Type";
            // 
            // useProxyCheckBox
            // 
            this.useProxyCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.useProxyCheckBox.Location = new System.Drawing.Point(3, 18);
            this.useProxyCheckBox.Name = "useProxyCheckBox";
            this.useProxyCheckBox.Padding = new System.Windows.Forms.Padding(3);
            this.useProxyCheckBox.Size = new System.Drawing.Size(342, 38);
            this.useProxyCheckBox.TabIndex = 0;
            this.useProxyCheckBox.Text = "Use a pro&xy server for your LAN (These settings will not apply to dial-up or VPN" +
    " connections).";
            this.useProxyCheckBox.UseVisualStyleBackColor = true;
            this.useProxyCheckBox.CheckedChanged += new System.EventHandler(this.proxyCheckBox_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bypassTextBox);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.bypassCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(366, 39);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(348, 145);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Exceptions";
            // 
            // bypassTextBox
            // 
            this.bypassTextBox.Location = new System.Drawing.Point(6, 61);
            this.bypassTextBox.Multiline = true;
            this.bypassTextBox.Name = "bypassTextBox";
            this.bypassTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.bypassTextBox.Size = new System.Drawing.Size(327, 75);
            this.bypassTextBox.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Top;
            this.label14.Location = new System.Drawing.Point(3, 41);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(3);
            this.label14.Size = new System.Drawing.Size(270, 19);
            this.label14.TabIndex = 1;
            this.label14.Text = "Do not &use the proxy server for addresses such as:";
            // 
            // bypassCheckBox
            // 
            this.bypassCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.bypassCheckBox.Location = new System.Drawing.Point(3, 18);
            this.bypassCheckBox.Name = "bypassCheckBox";
            this.bypassCheckBox.Padding = new System.Windows.Forms.Padding(3);
            this.bypassCheckBox.Size = new System.Drawing.Size(342, 23);
            this.bypassCheckBox.TabIndex = 0;
            this.bypassCheckBox.Text = "&Bypass the proxy server for local addresses";
            this.bypassCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.currentButton);
            this.groupBox4.Controls.Add(this.gatewayTextBox);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.ipTextBox);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.subnetTextBox);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Location = new System.Drawing.Point(366, 190);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(348, 129);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Detection";
            // 
            // currentButton
            // 
            this.currentButton.Location = new System.Drawing.Point(257, 98);
            this.currentButton.Name = "currentButton";
            this.currentButton.Size = new System.Drawing.Size(79, 23);
            this.currentButton.TabIndex = 6;
            this.currentButton.Text = "Curren&t";
            this.currentButton.UseVisualStyleBackColor = true;
            this.currentButton.Click += new System.EventHandler(this.currentButton_Click);
            // 
            // gatewayTextBox
            // 
            this.gatewayTextBox.Location = new System.Drawing.Point(64, 71);
            this.gatewayTextBox.Name = "gatewayTextBox";
            this.gatewayTextBox.Size = new System.Drawing.Size(269, 22);
            this.gatewayTextBox.TabIndex = 5;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 74);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(54, 13);
            this.label17.TabIndex = 4;
            this.label17.Text = "&Gateway:";
            // 
            // ipTextBox
            // 
            this.ipTextBox.Location = new System.Drawing.Point(64, 19);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(269, 22);
            this.ipTextBox.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 48);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Sub&net:";
            // 
            // subnetTextBox
            // 
            this.subnetTextBox.Location = new System.Drawing.Point(64, 45);
            this.subnetTextBox.Name = "subnetTextBox";
            this.subnetTextBox.Size = new System.Drawing.Size(269, 22);
            this.subnetTextBox.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(19, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "&IP:";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(632, 387);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(79, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(547, 387);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(79, 23);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.exitButton.Location = new System.Drawing.Point(451, 387);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(79, 23);
            this.exitButton.TabIndex = 9;
            this.exitButton.Text = "E&xit";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // profileLabel
            // 
            this.profileLabel.Location = new System.Drawing.Point(451, 353);
            this.profileLabel.Name = "profileLabel";
            this.profileLabel.Size = new System.Drawing.Size(260, 13);
            this.profileLabel.TabIndex = 7;
            this.profileLabel.Text = "Active profile:";
            this.profileLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(451, 371);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(260, 13);
            this.label18.TabIndex = 10;
            this.label18.Text = "Copyright (c) 2012 Jonathan Chayce Dickinson";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(620, 328);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(91, 21);
            this.titleLabel.TabIndex = 11;
            this.titleLabel.Text = "AutoProxy";
            // 
            // githubPictureBox
            // 
            this.githubPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.githubPictureBox.Image = global::AutoProxy.Properties.Resources.forkme100;
            this.githubPictureBox.Location = new System.Drawing.Point(359, 317);
            this.githubPictureBox.Name = "githubPictureBox";
            this.githubPictureBox.Size = new System.Drawing.Size(91, 93);
            this.githubPictureBox.TabIndex = 12;
            this.githubPictureBox.TabStop = false;
            this.githubPictureBox.Click += new System.EventHandler(this.githubPictureBox_Click);
            // 
            // SettingsWindow
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(726, 422);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.profileLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.profilesComboBox);
            this.Controls.Add(this.githubPictureBox);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsWindow";
            this.Text = "AutoProxy";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.githubPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox profilesComboBox;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox scriptTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox scriptCheckBox;
        private System.Windows.Forms.CheckBox automaticCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox sameProxyCheckBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox socksPortTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ftpPortTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox securePortTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox httpPortTextBox;
        private System.Windows.Forms.TextBox socksServerTextBox;
        private System.Windows.Forms.TextBox ftpServerTextBox;
        private System.Windows.Forms.TextBox secureServerTextBox;
        private System.Windows.Forms.TextBox httpServerTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox useProxyCheckBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox bypassTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox bypassCheckBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button currentButton;
        private System.Windows.Forms.TextBox gatewayTextBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox subnetTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label profileLabel;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.PictureBox githubPictureBox;
    }
}

