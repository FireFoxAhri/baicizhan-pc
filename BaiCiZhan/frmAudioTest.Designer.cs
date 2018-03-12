namespace BaiCiZhan
{
    partial class frmAudioTest
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
            this.ucAudioPlayer1 = new BaiCiZhan.view.ucAudioPlayer();
            this.btnTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ucAudioPlayer1
            // 
            this.ucAudioPlayer1.Location = new System.Drawing.Point(17, 15);
            this.ucAudioPlayer1.Name = "ucAudioPlayer1";
            this.ucAudioPlayer1.Size = new System.Drawing.Size(333, 76);
            this.ucAudioPlayer1.TabIndex = 4;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(259, 109);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 5;
            this.btnTest.Text = "button1";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // frmAudioTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 390);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.ucAudioPlayer1);
            this.Name = "frmAudioTest";
            this.Text = "frm";
            this.ResumeLayout(false);

        }

        #endregion

        private view.ucAudioPlayer ucAudioPlayer1;
        private System.Windows.Forms.Button btnTest;
    }
}