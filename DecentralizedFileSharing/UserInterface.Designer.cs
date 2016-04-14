namespace DecentralizedFileSharing
{
    partial class UserInterface
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.usernameText = new System.Windows.Forms.TextBox();
            this.addressText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.connectBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.searchText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.fileList = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.peerList = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.searchBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(456, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please enter a username for yourself, and an IP address for a host you would like" +
    " to connect to.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username:";
            // 
            // usernameText
            // 
            this.usernameText.Location = new System.Drawing.Point(82, 25);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(207, 20);
            this.usernameText.TabIndex = 2;
            // 
            // addressText
            // 
            this.addressText.Location = new System.Drawing.Point(82, 51);
            this.addressText.Name = "addressText";
            this.addressText.Size = new System.Drawing.Size(207, 20);
            this.addressText.TabIndex = 3;
            this.addressText.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "IP Address:";
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(471, 57);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(75, 23);
            this.connectBtn.TabIndex = 5;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(267, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Once connected, you may search for files to download.";
            // 
            // searchText
            // 
            this.searchText.Location = new System.Drawing.Point(82, 119);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(207, 20);
            this.searchText.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Search:";
            // 
            // fileList
            // 
            this.fileList.FormattingEnabled = true;
            this.fileList.Location = new System.Drawing.Point(12, 170);
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(336, 290);
            this.fileList.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Files:";
            // 
            // peerList
            // 
            this.peerList.FormattingEnabled = true;
            this.peerList.Location = new System.Drawing.Point(355, 170);
            this.peerList.Name = "peerList";
            this.peerList.Size = new System.Drawing.Size(191, 290);
            this.peerList.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(355, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Peers";
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(470, 115);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(75, 23);
            this.searchBtn.TabIndex = 13;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 472);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.peerList);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.fileList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.searchText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addressText);
            this.Controls.Add(this.usernameText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UserInterface";
            this.Text = "Decentralized File Sharing";
            this.Load += new System.EventHandler(this.UserInterface_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usernameText;
        private System.Windows.Forms.TextBox addressText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox searchText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox fileList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox peerList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button searchBtn;
    }
}

