using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QXX.Common.Forms;
using BaiCiZhan.Helper;

namespace BaiCiZhan
{
    public partial class frmStudy : Form
    {
        public frmStudy()
        {
            InitializeComponent();
            this.wordList1.WordListBox.DoubleClick += ListBox_DoubleClick;
            this.wordList1.WordListBox.KeyDown += ListBox_KeyDown;

            this.KeyPreview = true;
            this.KeyDown += frmStudy_KeyDown;
        }

        void ListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLoadWord.PerformClick();
            }
        }

        void frmStudy_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F2)
            {
                this.wordList1.WordTextBox.Select();
                this.wordList1.WordTextBox.SelectAll();
            }
            else if (e.KeyCode == Keys.F4)
            {
                this.wordView1.btnAudio.PerformClick();
                this.wordView1.InputSentenceRichTextBox.Select();
            }
            else if (e.KeyCode == Keys.F5)
            {
                this.wordView1.btnShowSentenc.PerformClick();
            }
        }

        void ListBox_DoubleClick(object sender, EventArgs e)
        {
            btnLoadWord_Click(null, null);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {

        }

        private void btnLoadWord_Click(object sender, EventArgs e)
        {
            try
            {
                var word = wordList1.GetSelectWrod();
                if (string.IsNullOrEmpty(word))
                {
                    MessageBox.Show("没有选中单词");
                    return;
                }
                var info = CET4Helper.GetInstance().GetWord(word);
                wordView1.ShowWordInfo(info);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }


    }
}
