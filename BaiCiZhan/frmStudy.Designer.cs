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
            this.wordView1 = new BaiCiZhan.view.WordView();
            this.wordList1 = new BaiCiZhan.view.WordList();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(812, 536);
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
            this.btnLoadWord.Location = new System.Drawing.Point(212, 487);
            this.btnLoadWord.Name = "btnLoadWord";
            this.btnLoadWord.Size = new System.Drawing.Size(75, 23);
            this.btnLoadWord.TabIndex = 4;
            this.btnLoadWord.Text = "加载单词";
            this.btnLoadWord.UseVisualStyleBackColor = true;
            this.btnLoadWord.Click += new System.EventHandler(this.btnLoadWord_Click);
            // 
            // wordView1
            // 
            this.wordView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wordView1.AutoScroll = true;
            this.wordView1.Location = new System.Drawing.Point(174, 9);
            this.wordView1.Name = "wordView1";
            this.wordView1.Size = new System.Drawing.Size(713, 501);
            this.wordView1.TabIndex = 3;
            // 
            // wordList1
            // 
            this.wordList1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.wordList1.Location = new System.Drawing.Point(12, 0);
            this.wordList1.Name = "wordList1";
            this.wordList1.Size = new System.Drawing.Size(156, 559);
            this.wordList1.TabIndex = 6;
            // 
            // frmStudy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 559);
            this.Controls.Add(this.wordView1);
            this.Controls.Add(this.wordList1);
            this.Controls.Add(this.btnLoadWord);
            this.Controls.Add(this.btnTest);
            this.Name = "frmStudy";
            this.Text = "frmStudy";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnLoadWord;
        private view.WordList wordList1;
        private view.WordView wordView1;
    }
}