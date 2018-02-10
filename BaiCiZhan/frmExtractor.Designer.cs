namespace BaiCiZhan
{
    partial class frmExtractor
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
            this.ucOpenFileDialogZpk = new QXX.Common.Forms.ucOpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ucOpenFileDialog2 = new QXX.Common.Forms.ucOpenFileDialog();
            this.btnExtract = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbMsg
            // 
            this.rtbMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbMsg.Location = new System.Drawing.Point(399, 0);
            this.rtbMsg.Size = new System.Drawing.Size(200, 536);
            // 
            // cbMsgAutoScroll
            // 
            this.cbMsgAutoScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMsgAutoScroll.Location = new System.Drawing.Point(412, 542);
            this.cbMsgAutoScroll.Visible = true;
            // 
            // ucOpenFileDialogZpk
            // 
            this.ucOpenFileDialogZpk.FilePath = "";
            this.ucOpenFileDialogZpk.Location = new System.Drawing.Point(12, 28);
            this.ucOpenFileDialogZpk.Name = "ucOpenFileDialogZpk";
            this.ucOpenFileDialogZpk.Size = new System.Drawing.Size(364, 30);
            this.ucOpenFileDialogZpk.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "zpk文件夹";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "解压后文件夹";
            // 
            // ucOpenFileDialog2
            // 
            this.ucOpenFileDialog2.FilePath = "";
            this.ucOpenFileDialog2.Location = new System.Drawing.Point(14, 91);
            this.ucOpenFileDialog2.Name = "ucOpenFileDialog2";
            this.ucOpenFileDialog2.Size = new System.Drawing.Size(364, 30);
            this.ucOpenFileDialog2.TabIndex = 2;
            // 
            // btnExtract
            // 
            this.btnExtract.Location = new System.Drawing.Point(14, 140);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(75, 23);
            this.btnExtract.TabIndex = 4;
            this.btnExtract.Text = "解压";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // frmExtractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 557);
            this.Controls.Add(this.btnExtract);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucOpenFileDialog2);
            this.Controls.Add(this.ucOpenFileDialogZpk);
            this.Name = "frmExtractor";
            this.Text = "frmExtractor";
            this.Controls.SetChildIndex(this.rtbMsg, 0);
            this.Controls.SetChildIndex(this.cbMsgAutoScroll, 0);
            this.Controls.SetChildIndex(this.ucOpenFileDialogZpk, 0);
            this.Controls.SetChildIndex(this.ucOpenFileDialog2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnExtract, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QXX.Common.Forms.ucOpenFileDialog ucOpenFileDialogZpk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private QXX.Common.Forms.ucOpenFileDialog ucOpenFileDialog2;
        private System.Windows.Forms.Button btnExtract;
    }
}