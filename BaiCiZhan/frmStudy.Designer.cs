namespace BaiCiZhan
{
    partial class frmStudy
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
            this.btnTest = new System.Windows.Forms.Button();
            this.btnLoadWord = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ucWordView1 = new BaiCiZhan.view.ucWordView();
            this.wordList1 = new BaiCiZhan.view.ucWordList();
            this.btnPlaylist = new System.Windows.Forms.Button();
            this.btnStopPlaylist = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(626, 504);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "测试";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnLoadWord
            // 
            this.btnLoadWord.Location = new System.Drawing.Point(48, 409);
            this.btnLoadWord.Name = "btnLoadWord";
            this.btnLoadWord.Size = new System.Drawing.Size(75, 23);
            this.btnLoadWord.TabIndex = 4;
            this.btnLoadWord.Text = "加载单词";
            this.btnLoadWord.UseVisualStyleBackColor = true;
            this.btnLoadWord.Click += new System.EventHandler(this.btnLoadWord_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Controls.Add(this.ucWordView1);
            this.panel1.Controls.Add(this.btnLoadWord);
            this.panel1.Controls.Add(this.btnTest);
            this.panel1.Location = new System.Drawing.Point(165, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(717, 523);
            this.panel1.TabIndex = 7;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 497);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(717, 26);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(78, 21);
            this.toolStripStatusLabel3.Text = "00:00:00  ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(90, 21);
            this.toolStripStatusLabel1.Text = "未加载单词";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 21);
            // 
            // ucWordView1
            // 
            this.ucWordView1.AutoScroll = true;
            this.ucWordView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWordView1.Location = new System.Drawing.Point(0, 0);
            this.ucWordView1.Name = "ucWordView1";
            this.ucWordView1.Size = new System.Drawing.Size(717, 523);
            this.ucWordView1.TabIndex = 3;
            // 
            // wordList1
            // 
            this.wordList1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.wordList1.Location = new System.Drawing.Point(8, 3);
            this.wordList1.Name = "wordList1";
            this.wordList1.Size = new System.Drawing.Size(156, 556);
            this.wordList1.TabIndex = 6;
            // 
            // btnPlaylist
            // 
            this.btnPlaylist.Location = new System.Drawing.Point(174, 3);
            this.btnPlaylist.Name = "btnPlaylist";
            this.btnPlaylist.Size = new System.Drawing.Size(75, 23);
            this.btnPlaylist.TabIndex = 8;
            this.btnPlaylist.Text = "列表播放";
            this.btnPlaylist.UseVisualStyleBackColor = true;
            this.btnPlaylist.Click += new System.EventHandler(this.btnPlaylist_Click);
            // 
            // btnStopPlaylist
            // 
            this.btnStopPlaylist.Location = new System.Drawing.Point(269, 3);
            this.btnStopPlaylist.Name = "btnStopPlaylist";
            this.btnStopPlaylist.Size = new System.Drawing.Size(75, 23);
            this.btnStopPlaylist.TabIndex = 9;
            this.btnStopPlaylist.Text = "停止播放";
            this.btnStopPlaylist.UseVisualStyleBackColor = true;
            this.btnStopPlaylist.Click += new System.EventHandler(this.btnStopPlaylist_Click);
            // 
            // frmStudy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 559);
            this.Controls.Add(this.btnStopPlaylist);
            this.Controls.Add(this.btnPlaylist);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.wordList1);
            this.Name = "frmStudy";
            this.Text = "背单词";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnLoadWord;
        private view.ucWordList wordList1;
        private view.ucWordView ucWordView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Button btnPlaylist;
        private System.Windows.Forms.Button btnStopPlaylist;
    }
}