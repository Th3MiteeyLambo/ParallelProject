namespace DecentralizedFileSharing
{
    partial class PeerList
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
            this.peerListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Here are all of the directly connected peers:";
            // 
            // peerListBox
            // 
            this.peerListBox.FormattingEnabled = true;
            this.peerListBox.Location = new System.Drawing.Point(12, 37);
            this.peerListBox.Name = "peerListBox";
            this.peerListBox.Size = new System.Drawing.Size(448, 342);
            this.peerListBox.TabIndex = 1;
            // 
            // PeerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 391);
            this.Controls.Add(this.peerListBox);
            this.Controls.Add(this.label1);
            this.Name = "PeerList";
            this.Text = "PeerList";
            this.Load += new System.EventHandler(this.PeerList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox peerListBox;
    }
}