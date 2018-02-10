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
        public WordView()
        {
            InitializeComponent();
            this.Load += WordView_Load;
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


            this.wordInfo = wordInfo;
            var msg = string.Format(@"
{0}
{1}
{2}
{3}
{4}
", wordInfo.word, wordInfo.accent, wordInfo.word_etyma, wordInfo.mean_cn, wordInfo.word_etyma).Trim();
            rtbWrodInfo.Text = msg;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.BackgroundImage = new Bitmap(wordInfo.image_file);
            Helper.AudioHelper.GetInstance().Play(wordInfo.word_audio, () =>
            {
                Helper.AudioHelper.GetInstance().Play(wordInfo.sentence_audio);
            });


        }

        private void btnAudio_Click(object sender, EventArgs e)
        {
            var text = btnAudio.Text;
            try
            {
                //添加历史记录
                IHistoryHelper helper = new HistoryHelper();
                var wh = helper.GetAll().Last();
                if (wh.Word != wordInfo.word)
                {
                    helper.Add(wordInfo.word);
                }


                btnAudio.Text = "播放中";
                btnAudio.Refresh();
                var file = this.wordInfo.sentence_audio;
                Helper.AudioHelper.GetInstance().Play(file);
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
