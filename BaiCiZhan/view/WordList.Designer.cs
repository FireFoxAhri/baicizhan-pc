namespace BaiCiZhan.view
{
    partial class WordList
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
            this.tbWord = new System.Windows.Forms.TextBox();
            this.cboWordSource = new System.Windows.Forms.ComboBox();
            this.listView1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // tbWord
            // 
            this.tbWord.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbWord.Location = new System.Drawing.Point(2, 4);
            this.tbWord.Name = "tbWord";
            this.tbWord.Size = new System.Drawing.Size(145, 22);
            this.tbWord.TabIndex = 1;
            // 
            // cboWordSource
            // 
            this.cboWordSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboWordSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWordSource.FormattingEnabled = true;
            this.cboWordSource.Items.AddRange(new object[] {
            "四级单词",
            "历史记录"});
            this.cboWordSource.Location = new System.Drawing.Point(6, 492);
            this.cboWordSource.Name = "cboWordSource";
            this.cboWordSource.Size = new System.Drawing.Size(139, 20);
            this.cboWordSource.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.FormattingEnabled = true;
            this.listView1.Location = new System.Drawing.Point(2, 30);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(145, 459);
            this.listView1.TabIndex = 0;
            // 
            // WordList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboWordSource);
            this.Controls.Add(this.tbWord);
            this.Controls.Add(this.listView1);
            this.Name = "WordList";
            this.Size = new System.Drawing.Size(156, 523);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbWord;
        private System.Windows.Forms.ComboBox cboWordSource;
        private System.Windows.Forms.ListBox listView1;
    }
}
