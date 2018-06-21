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
    public partial class ucWordView : UserControl
    {
        public event Action SentencePlayDoneAction;
        public RichTextBox InputSentenceRichTextBox
        {
            get
            {
                return rtbInputSentence;
            }
        }

        public ucAudioPlayer UcAudioPlayer
        {
            get
            {
                return ucAudioPlayer1;
            }
        }
        WordInfo wordInfo;
        bool isShowPicture;
        bool isPlaySentence;
        //播放单词的player
        Helper.IAudioPlayer wordAudioPlayer = AudioPlayerFactory.GetNewAudioPlayer();
        public ucWordView()
        {
            InitializeComponent();
            this.Load += WordView_Load;

            ucAudioPlayer1.btnPlay.Click += btnPlay_Click;
            this.Disposed += WordView_Disposed;
            this.cbPicture.Checked = true;
            this.cbSentence.Checked = true;
        }

        void WordView_Disposed(object sender, EventArgs e)
        {
            wordAudioPlayer.Close();
        }

        void btnPlay_Click(object sender, EventArgs e)
        {
            rtbInputSentence.Select();
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
            btnShowSentenc.Text = "显示";
            pictureBox1.BackgroundImage = null;
            this.isPlaySentence = cbSentence.Checked;
            this.isShowPicture = cbPicture.Checked;

            #region 添加历史记录

            IWordSaveHelper helper = Helper.WordSaveFactory
                            .GetWordSaveHelper(Helper.WordSaveFactory.WordSaveType.history);

            ////如果当前单词和最后一个单词不相同就添加, 也就是最近的单词不重复添加
            //var wh = helper.GetAll().Aggregate((max, n) => max.AddTime > n.AddTime ? max : n);
            //if (wh.Word != wordInfo.word)
            //{
            //    helper.Add(wordInfo);
            //}

            //三天之内不重复添加
            //查找最近三天之内添加的单词, 如果没找到, 就添加
            var wh = helper.GetAll().FirstOrDefault(n => n.AddTime > DateTime.Now.AddDays(-3) && n.Word == wordInfo.word);
            if (wh == null)
            {
                helper.Add(wordInfo);
            }

            #endregion

            this.wordInfo = wordInfo;
            var msg = string.Format(@"
_   {0}  {1}
{2}
{3}
", wordInfo.word, wordInfo.accent, wordInfo.word_etyma, wordInfo.mean_cn).Trim();
            rtbWrodInfo.Text = msg;
            if (isShowPicture)
            {
                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                pictureBox1.BackgroundImage = new Bitmap(wordInfo.image_file);
            }
            ucAudioPlayer1.File = wordInfo.sentence_audio;
            wordAudioPlayer.Play(wordInfo.word_audio, () =>
            {
                if (isPlaySentence)
                {
                    this.Invoke((MethodInvoker)delegate
                          {
                              playSentence();
                          });
                }
            });
            if (isFavorite(this.wordInfo.word))
            {
                btnFavorite.Text = "已收藏";
            }
            else
            {
                btnFavorite.Text = "收藏";
            }
        }

        public void playSentence()
        {
            try
            {
                ucAudioPlayer1.Play(wordInfo.sentence_audio, SentencePlayDoneAction);
                rtbInputSentence.Select();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        string getTranslateText(WordInfo word)
        {
            if (rbEng.Checked)
            {
                return word.sentence;
            }
            else if (rbChn.Checked)
            {
                return word.sentence_trans;
            }
            else 
            {
                return wordInfo.sentence + "\n" + wordInfo.sentence_trans;
            }

        }

        private void btnShowSentenc_Click(object sender, EventArgs e)
        {

            try
            {
                if (this.wordInfo == null)
                {
                    return;
                }
                string text = getTranslateText(this.wordInfo);
               
                text = text.Replace("\r\n", "\n");
                if (rtbSentence.Text.Contains(text))
                {
                    rtbSentence.Text = "";
                    btnShowSentenc.Text = "显示";
                }
                else
                {
                    rtbSentence.Text = text;
                    btnShowSentenc.Text = "隐藏";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
                wordAudioPlayer.Play(file);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void btnFavorite_Click(object sender, EventArgs e)
        {
            var word = this.wordInfo.word;
            if (!isFavorite(word))
            {
                var helper = Helper.WordSaveFactory.GetWordSaveHelper(Helper.WordSaveFactory.WordSaveType.favorit);
                helper.Add(this.wordInfo);
                btnFavorite.Text = "已收藏";
            }
        }

        bool isFavorite(string word)
        {
            var helper = Helper.WordSaveFactory.GetWordSaveHelper(Helper.WordSaveFactory.WordSaveType.favorit);
            var w = helper.GetAll(word + "/").FirstOrDefault();
            return w != null;
        }
    }
}
