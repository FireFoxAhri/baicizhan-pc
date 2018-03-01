using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaiCiZhan.Model;
using Un4seen.Bass;

using BaiCiZhan.Helper;

namespace BaiCiZhan.view
{
    public partial class WordView : UserControl
    {
        public RichTextBox InputSentenceRichTextBox
        {
            get
            {
                return rtbInputSentence;
            }
        }
        WordInfo wordInfo;
        Timer timer = new Timer();
        public WordView()
        {
            InitializeComponent();
            this.Load += WordView_Load;
            timer.Tick += timer_Tick;
            timer.Interval = 1000;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            var text = lblSeconds.Text;
            int seconds;
            int.TryParse(text, out seconds);
            lblSeconds.Text = (++seconds).ToString();
        }

        void WordView_Load(object sender, EventArgs e)
        {
            rtbWrodInfo.Text = "";
            rtbSentence.Font = rtbWrodInfo.Font;
            rtbInputSentence.Font = rtbWrodInfo.Font;
            if (this.DesignMode)
            {
                return;
            }

        }

        public void ShowWordInfo(WordInfo wordInfo)
        {
            if (Helper.AudioHelper.GetInstance().isPlaying)
            {
                return;
            }
            //清理;
            rtbWrodInfo.Text = "";
            rtbSentence.Text = "";
            rtbInputSentence.Text = "";
            pictureBox1.BackgroundImage = null;
            lblSeconds.Text = "0";
            this.timer.Stop();

            //添加历史记录
            IHistoryHelper helper = new HistoryHelper();
            var wh = helper.GetAll().Aggregate((max, n) => max.AddTime > n.AddTime ? max : n);
            if (wh.Word != wordInfo.word)
            {
                helper.Add(wordInfo);
            }

            this.timer.Start();
            this.wordInfo = wordInfo;
            var msg = string.Format(@"
{0}
{1}
{2}
{3}
", wordInfo.word, wordInfo.accent, wordInfo.word_etyma, wordInfo.mean_cn).Trim();
            rtbWrodInfo.Text = msg;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.BackgroundImage = new Bitmap(wordInfo.image_file);
            Helper.AudioHelper.GetInstance().Play(wordInfo.word_audio, () =>
            {
                this.Invoke((MethodInvoker)delegate
                {
                    btnAudio.PerformClick();
                });

            });
        }

        private void btnAudio_Click(object sender, EventArgs e)
        {
            var text = btnAudio.Text;
            try
            {
                btnAudio.Text = "播放中";
                btnAudio.Refresh();
                var file = this.wordInfo.sentence_audio;
                Helper.AudioHelper.GetInstance().Play(file);
                rtbInputSentence.Select();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnAudio.Text = text;
            }
        }

        private void btnShowSentenc_Click(object sender, EventArgs e)
        {
            rtbSentence.Text = wordInfo.sentence;
        }

    }
}
