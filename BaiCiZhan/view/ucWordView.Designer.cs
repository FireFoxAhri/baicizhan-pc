namespace BaiCiZhan.view
{
    partial class ucWordView
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbWrodInfo = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rtbSentence = new System.Windows.Forms.RichTextBox();
            this.rtbInputSentence = new System.Windows.Forms.RichTextBox();
            this.btnShowSentenc = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbEngChn = new System.Windows.Forms.RadioButton();
            this.rbEng = new System.Windows.Forms.RadioButton();
            this.rbChn = new System.Windows.Forms.RadioButton();
            this.ucAudioPlayer1 = new BaiCiZhan.view.ucAudioPlayer();
            this.btnPlayWord = new System.Windows.Forms.Button();
            this.cbPicture = new System.Windows.Forms.CheckBox();
            this.cbSentence = new System.Windows.Forms.CheckBox();
            this.btnFavorite = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbWrodInfo
            // 
            this.rtbWrodInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbWrodInfo.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbWrodInfo.Location = new System.Drawing.Point(6, 2);
            this.rtbWrodInfo.Name = "rtbWrodInfo";
            this.rtbWrodInfo.Size = new System.Drawing.Size(404, 174);
            this.rtbWrodInfo.TabIndex = 0;
            this.rtbWrodInfo.Text = "_  consoles";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(419, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 165);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // rtbSentence
            // 
            this.rtbSentence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbSentence.Location = new System.Drawing.Point(4, 151);
            this.rtbSentence.Name = "rtbSentence";
            this.rtbSentence.Size = new System.Drawing.Size(635, 82);
            this.rtbSentence.TabIndex = 3;
            this.rtbSentence.Text = "";
            // 
            // rtbInputSentence
            // 
            this.rtbInputSentence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbInputSentence.Location = new System.Drawing.Point(4, 58);
            this.rtbInputSentence.Name = "rtbInputSentence";
            this.rtbInputSentence.Size = new System.Drawing.Size(635, 79);
            this.rtbInputSentence.TabIndex = 3;
            this.rtbInputSentence.Text = "";
            // 
            // btnShowSentenc
            // 
            this.btnShowSentenc.Location = new System.Drawing.Point(433, 21);
            this.btnShowSentenc.Name = "btnShowSentenc";
            this.btnShowSentenc.Size = new System.Drawing.Size(62, 23);
            this.btnShowSentenc.TabIndex = 4;
            this.btnShowSentenc.Text = "显示";
            this.btnShowSentenc.UseVisualStyleBackColor = true;
            this.btnShowSentenc.Click += new System.EventHandler(this.btnShowSentenc_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.ucAudioPlayer1);
            this.groupBox1.Controls.Add(this.btnShowSentenc);
            this.groupBox1.Controls.Add(this.rtbInputSentence);
            this.groupBox1.Controls.Add(this.rtbSentence);
            this.groupBox1.Location = new System.Drawing.Point(-1, 195);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(647, 258);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "句子";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbEngChn);
            this.groupBox2.Controls.Add(this.rbEng);
            this.groupBox2.Controls.Add(this.rbChn);
            this.groupBox2.Location = new System.Drawing.Point(503, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(151, 33);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // rbEngChn
            // 
            this.rbEngChn.AutoSize = true;
            this.rbEngChn.Location = new System.Drawing.Point(87, 10);
            this.rbEngChn.Name = "rbEngChn";
            this.rbEngChn.Size = new System.Drawing.Size(47, 16);
            this.rbEngChn.TabIndex = 12;
            this.rbEngChn.Text = "中英";
            this.rbEngChn.UseVisualStyleBackColor = true;
            // 
            // rbEng
            // 
            this.rbEng.AutoSize = true;
            this.rbEng.Checked = true;
            this.rbEng.Location = new System.Drawing.Point(4, 10);
            this.rbEng.Name = "rbEng";
            this.rbEng.Size = new System.Drawing.Size(35, 16);
            this.rbEng.TabIndex = 11;
            this.rbEng.TabStop = true;
            this.rbEng.Text = "英";
            this.rbEng.UseVisualStyleBackColor = true;
            // 
            // rbChn
            // 
            this.rbChn.AutoSize = true;
            this.rbChn.Location = new System.Drawing.Point(45, 10);
            this.rbChn.Name = "rbChn";
            this.rbChn.Size = new System.Drawing.Size(35, 16);
            this.rbChn.TabIndex = 10;
            this.rbChn.Text = "中";
            this.rbChn.UseVisualStyleBackColor = true;
            // 
            // ucAudioPlayer1
            // 
            this.ucAudioPlayer1.Location = new System.Drawing.Point(9, 15);
            this.ucAudioPlayer1.Name = "ucAudioPlayer1";
            this.ucAudioPlayer1.Size = new System.Drawing.Size(418, 35);
            this.ucAudioPlayer1.TabIndex = 8;
            // 
            // btnPlayWord
            // 
            this.btnPlayWord.Image = global::BaiCiZhan.Properties.Resources.Play;
            this.btnPlayWord.Location = new System.Drawing.Point(9, 6);
            this.btnPlayWord.Name = "btnPlayWord";
            this.btnPlayWord.Size = new System.Drawing.Size(26, 20);
            this.btnPlayWord.TabIndex = 7;
            this.btnPlayWord.UseVisualStyleBackColor = true;
            this.btnPlayWord.Click += new System.EventHandler(this.btnPlayWord_Click);
            // 
            // cbPicture
            // 
            this.cbPicture.AutoSize = true;
            this.cbPicture.Location = new System.Drawing.Point(8, 459);
            this.cbPicture.Name = "cbPicture";
            this.cbPicture.Size = new System.Drawing.Size(72, 16);
            this.cbPicture.TabIndex = 8;
            this.cbPicture.Text = "显示图片";
            this.cbPicture.UseVisualStyleBackColor = true;
            // 
            // cbSentence
            // 
            this.cbSentence.AutoSize = true;
            this.cbSentence.Location = new System.Drawing.Point(8, 479);
            this.cbSentence.Name = "cbSentence";
            this.cbSentence.Size = new System.Drawing.Size(72, 16);
            this.cbSentence.TabIndex = 9;
            this.cbSentence.Text = "播放句子";
            this.cbSentence.UseVisualStyleBackColor = true;
            // 
            // btnFavorite
            // 
            this.btnFavorite.Location = new System.Drawing.Point(9, 501);
            this.btnFavorite.Name = "btnFavorite";
            this.btnFavorite.Size = new System.Drawing.Size(75, 23);
            this.btnFavorite.TabIndex = 10;
            this.btnFavorite.Text = "收藏";
            this.btnFavorite.UseVisualStyleBackColor = true;
            this.btnFavorite.Click += new System.EventHandler(this.btnFavorite_Click);
            // 
            // ucWordView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFavorite);
            this.Controls.Add(this.cbSentence);
            this.Controls.Add(this.cbPicture);
            this.Controls.Add(this.btnPlayWord);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.rtbWrodInfo);
            this.Name = "ucWordView";
            this.Size = new System.Drawing.Size(653, 516);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbWrodInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox rtbSentence;
        private System.Windows.Forms.RichTextBox rtbInputSentence;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button btnShowSentenc;
        private System.Windows.Forms.Button btnPlayWord;
        private ucAudioPlayer ucAudioPlayer1;
        private System.Windows.Forms.CheckBox cbPicture;
        private System.Windows.Forms.CheckBox cbSentence;
        private System.Windows.Forms.Button btnFavorite;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbEngChn;
        private System.Windows.Forms.RadioButton rbEng;
        private System.Windows.Forms.RadioButton rbChn;

    }
}
