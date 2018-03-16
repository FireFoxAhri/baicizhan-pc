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
        DateTime loadTime;
        Timer timer;
        public frmStudy()
        {
            InitializeComponent();
            this.wordList1.WordListBox.DoubleClick += ListBox_DoubleClick;
            this.wordList1.WordListBox.KeyDown += ListBox_KeyDown;
            this.wordView1.Enabled = false;

            this.KeyPreview = true;
            this.KeyDown += frmStudy_KeyDown;
            this.Load += frmStudy_Load;

            timer = new Timer();
            timer.Tick += timer_Tick;
            timer.Interval = 1000;

        }

        void frmStudy_Load(object sender, EventArgs e)
        {
            timer.Start();
            this.loadTime = DateTime.Now;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (this.wordView1.Enabled)
            {
                var lblSeconds = toolStripStatusLabel2;
                var text = Convert.ToString(lblSeconds.Tag);
                int seconds;
                int.TryParse(text, out seconds);
                seconds++;
                var m = seconds / 60;
                var s = seconds % 60;

                string msg = string.Format(" {0}s [{1:00}:{2:00}]", seconds, m, s);
                lblSeconds.Text = msg;
                lblSeconds.Tag = seconds;
            }

            var timeSpand = DateTime.Now.Subtract(loadTime);
            toolStripStatusLabel3.Text = timeSpand.ToString(@"hh\:mm\:ss") + " ";
        }

        void resetWordLoad()
        {
            //timer.Stop();
            //timer.Start();
            toolStripStatusLabel2.Text = "";
            toolStripStatusLabel2.Tag = 0;
        }
        void ListBox_KeyDown(object sender, KeyEventArgs e)
        {

            //if (e.KeyCode == Keys.Enter)
            if (e.KeyValue == 13) //todo: 2018-03-11上面的判断出问题了,先用这个; keycode lbutton|mbutton|back
            {
                btnLoadWord.PerformClick();
            }
        }

        void frmStudy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D1)
            {
                this.wordList1.WordTextBox.Select();
                this.wordList1.WordTextBox.SelectAll();
                e.Handled = true;
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D2)
            {
                this.wordView1.playSentence();
                e.Handled = true;

            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D3)
            {
                this.wordView1.btnShowSentenc.PerformClick();
                e.Handled = true;
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
                this.Cursor = Cursors.WaitCursor;
                var word = wordList1.GetSelectWrod();
                if (word == null)
                {
                    MessageBox.Show("没有选中单词");
                    return;
                }
                if (wordView1.Enabled == false)
                {
                    wordView1.Enabled = true;
                }
                wordView1.ShowWordInfo(word);
                showMsg1(word.word);
                resetWordLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

        }

        void showMsg1(string msg)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.toolStripStatusLabel1.Text = msg;
            });
        }
        void showMsg2(string msg)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.toolStripStatusLabel2.Text = msg;
            });
        }
    }
}
