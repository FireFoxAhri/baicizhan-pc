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
        Helper.IAudioPlayer audioPlayer = AudioPlayerFactory.GetNewAudioPlayer();
        public WordView()
        {
            InitializeComponent();
            this.Load += WordView_Load;
            timer.Tick += timer_Tick;
            timer.Interval = 1000;
            ucAudioPlayer1.btnPlay.Click += btnPlay_Click;
            this.Disposed += WordView_Disposed;
        }

        void WordView_Disposed(object sender, EventArgs e)
        {
            audioPlayer.Close();
        }

        void btnPlay_Click(object sender, EventArgs e)
        {
            rtbInputSentence.Select();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            var text = Convert.ToString(lblSeconds.Tag);
            int seconds;
            int.TryParse(text, out seconds);
            seconds++;
            var m = seconds / 60;
            var s = seconds % 60;
            string msg = string.Format("{0}s [{1}m{2}s]", seconds, m, s);
            lblSeconds.Text = msg;
            lblSeconds.Tag = seconds;
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
            //清理;
            rtbWrodInfo.Text = "";
            rtbSentence.Text = "";
            rtbInputSentence.Text = "";
            pictureBox1.BackgroundImage = null;
            lblSeconds.Text = "";
            lblSeconds.Tag = 0;
            this.timer.Stop();

            //添加历史记录
            IHistoryHelper helper = new HistoryHelper();

            ////如果当前单词和最后一个单词不相同就添加, 也就是最近的单词不重复添加
            //var wh = helper.GetAll().Aggregate((max, n) => max.AddTime > n.AddTime ? max : n);
            //if (wh.Word != wordInfo.word)
            //{
            //    helper.Add(wordInfo);
            //}
            //一小时之内不重复添加
            var wh = helper.GetAll().FirstOrDefault(n => n.AddTime > DateTime.Now.AddHours(-1) && n.Word == wordInfo.word);
            if (wh == null)
            {
                helper.Add(wordInfo);
            }

            this.timer.Start();
            this.wordInfo = wordInfo;
            var msg = string.Format(@"
_   {0}  {1}
{2}
{3}
", wordInfo.word, wordInfo.accent, wordInfo.word_etyma, wordInfo.mean_cn).Trim();
            rtbWrodInfo.Text = msg;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.BackgroundImage = new Bitmap(wordInfo.image_file);
            audioPlayer.Play(wordInfo.word_audio, () =>
            {
                this.Invoke((MethodInvoker)delegate
                {
                    playSentence();
                });
            });
        }

        public void playSentence()
        {
            try
            {
                ucAudioPlayer1.Play(wordInfo.sentence_audio);
                rtbInputSentence.Select();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnShowSentenc_Click(object sender, EventArgs e)
        {
            rtbSentence.Text = wordInfo.sentence;
        }

        private void btnPlayWord_Click(object sender, EventArgs e)
        {

            try
            {
                if (this.wordInfo == null)
                {
                    MessageBox.Show("没有加载单词"); ;
                    return;
                }
                var file = this.wordInfo.word_audio;
                audioPlayer.Play(file);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

    }
}
