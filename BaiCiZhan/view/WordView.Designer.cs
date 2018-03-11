﻿namespace BaiCiZhan.view
{
    partial class WordView
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
            this.lblSeconds = new System.Windows.Forms.Label();
            this.btnPlayWord = new System.Windows.Forms.Button();
            this.ucAudioPlayer1 = new BaiCiZhan.view.ucAudioPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbWrodInfo
            // 
            this.rtbWrodInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbWrodInfo.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbWrodInfo.Location = new System.Drawing.Point(2, 2);
            this.rtbWrodInfo.Name = "rtbWrodInfo";
            this.rtbWrodInfo.Size = new System.Drawing.Size(311, 174);
            this.rtbWrodInfo.TabIndex = 0;
            this.rtbWrodInfo.Text = "_  consoles";
            this.rtbWrodInfo.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(322, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(198, 174);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // rtbSentence
            // 
            this.rtbSentence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbSentence.Location = new System.Drawing.Point(4, 151);
            this.rtbSentence.Name = "rtbSentence";
            this.rtbSentence.Size = new System.Drawing.Size(518, 82);
            this.rtbSentence.TabIndex = 3;
            this.rtbSentence.Text = "";
            // 
            // rtbInputSentence
            // 
            this.rtbInputSentence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbInputSentence.Location = new System.Drawing.Point(4, 58);
            this.rtbInputSentence.Name = "rtbInputSentence";
            this.rtbInputSentence.Size = new System.Drawing.Size(518, 79);
            this.rtbInputSentence.TabIndex = 3;
            this.rtbInputSentence.Text = "";
            // 
            // btnShowSentenc
            // 
            this.btnShowSentenc.Location = new System.Drawing.Point(436, 21);
            this.btnShowSentenc.Name = "btnShowSentenc";
            this.btnShowSentenc.Size = new System.Drawing.Size(62, 23);
            this.btnShowSentenc.TabIndex = 4;
            this.btnShowSentenc.Text = "显示(C3)";
            this.btnShowSentenc.UseVisualStyleBackColor = true;
            this.btnShowSentenc.Click += new System.EventHandler(this.btnShowSentenc_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ucAudioPlayer1);
            this.groupBox1.Controls.Add(this.btnShowSentenc);
            this.groupBox1.Controls.Add(this.rtbInputSentence);
            this.groupBox1.Controls.Add(this.rtbSentence);
            this.groupBox1.Location = new System.Drawing.Point(-1, 195);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 258);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "句子";
            // 
            // lblSeconds
            // 
            this.lblSeconds.AutoSize = true;
            this.lblSeconds.Location = new System.Drawing.Point(5, 456);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(11, 12);
            this.lblSeconds.TabIndex = 6;
            this.lblSeconds.Text = "0";
            // 
            // btnPlayWord
            // 
            this.btnPlayWord.Image = global::BaiCiZhan.Properties.Resources.Play;
            this.btnPlayWord.Location = new System.Drawing.Point(5, 6);
            this.btnPlayWord.Name = "btnPlayWord";
            this.btnPlayWord.Size = new System.Drawing.Size(26, 20);
            this.btnPlayWord.TabIndex = 7;
            this.btnPlayWord.UseVisualStyleBackColor = true;
            this.btnPlayWord.Visible = false;
            this.btnPlayWord.Click += new System.EventHandler(this.btnPlayWord_Click);
            // 
            // ucAudioPlayer1
            // 
            this.ucAudioPlayer1.Location = new System.Drawing.Point(9, 15);
            this.ucAudioPlayer1.Name = "ucAudioPlayer1";
            this.ucAudioPlayer1.Size = new System.Drawing.Size(418, 35);
            this.ucAudioPlayer1.TabIndex = 8;
            // 
            // WordView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPlayWord);
            this.Controls.Add(this.lblSeconds);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.rtbWrodInfo);
            this.Name = "WordView";
            this.Size = new System.Drawing.Size(536, 494);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblSeconds;
        private System.Windows.Forms.Button btnPlayWord;
        private ucAudioPlayer ucAudioPlayer1;

    }
}
