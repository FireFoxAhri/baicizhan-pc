﻿using System;
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

using BaiCiZhan.Model;
using Newtonsoft.Json;
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
            this.ucWordView1.Enabled = false;

            this.KeyPreview = true;
            this.KeyDown += frmStudy_KeyDown;
            this.Load += frmStudy_Load;

            timer = new Timer();
            timer.Tick += timer_Tick;
            timer.Interval = 1000;
            playlistTimer.Interval = 500;
            playlistTimer.Tick += playlistTimer_Tick;
            ucWordView1.SentencePlayDoneAction += ucWordView1_SentencePlayDoneAction;
        }


        void frmStudy_Load(object sender, EventArgs e)
        {
            timer.Start();
            this.loadTime = DateTime.Now;
            cbPlaylistOrder.SelectedIndex = 0;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (this.ucWordView1.Enabled)
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
                this.ucWordView1.playSentence();
                e.Handled = true;
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D3)
            {
                this.ucWordView1.btnShowSentenc.PerformClick();
                e.Handled = true;
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Q)
            {
                this.ucWordView1.playSentence();
                this.ucWordView1.UcAudioPlayer.SelectTrackBar();
                e.Handled = true;
            }
        }

        void ListBox_DoubleClick(object sender, EventArgs e)
        {
            btnLoadWord_Click(null, null);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            WordInfo info = new WordInfo();
            info.word = "ceshi";
            var json = JsonConvert.SerializeObject(info);

            info = JsonConvert.DeserializeObject<WordInfo>(json);

        }

        private void btnLoadWord_Click(object sender, EventArgs e)
        {
            loadWord();

        }

        private void loadWord()
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
                if (ucWordView1.Enabled == false)
                {
                    ucWordView1.Enabled = true;
                }
                ucWordView1.ShowWordInfo(word);
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

        Timer playlistTimer = new Timer();

        void playlistTimer_Tick(object sender, EventArgs e)
        {

        }
        bool isPlaylist = false;
        void ucWordView1_SentencePlayDoneAction()
        {
            Task.Delay(2000).ContinueWith((t) =>
            {
                if (isPlaylist &&
                    (ucWordView1.UcAudioPlayer.PlayState == (int)NAudio.Wave.PlaybackState.Stopped ||
                    ucWordView1.UcAudioPlayer.PlayState < 0))
                {
                    getPlaylistNext();
                    loadWord();
                }
                else if (isPlaylist)
                {
                    //ucWordView1_SentencePlayDoneAction();
                }
            });

        }

        WordInfo getPlaylistNext()
        {
            //0: 顺序播放;
            //1: 随机播放;
            if (cbPlaylistOrder.SelectedIndex == 1)
            {
                return getPlaylistRandomNext();
            }
            else
            {
                return getPlaylistSequenceNext();
            }
        }
        WordInfo getPlaylistSequenceNext()
        {
            var wordListbox = wordList1.WordListBox;
            var count = wordListbox.Items.Count;
            if (count <= 0)
            {
                throw new Exception("播放列表是空的");
            }
            var index = wordListbox.SelectedIndex;
            index = index < 0 ? 0 : index;
            wordListbox.SelectedIndex = index + 1;
            var word = wordList1.GetSelectWrod();
            return word;
        }
        WordInfo getPlaylistRandomNext()
        {
            var wordListbox = wordList1.WordListBox;
            var count = wordListbox.Items.Count;
            if (count <= 0)
            {
                throw new Exception("播放列表是空的");
            }
            var index = QXX.Common.MathHelper.GetRandomList(0, count, 1).First();
            wordListbox.SelectedIndex = index;
            var word = wordList1.GetSelectWrod();
            return word;
        }



        private void btnPlaylist_Click(object sender, EventArgs e)
        {
            try
            {
                isPlaylist = true;
                //如果没有选中单词, 就选中第一个单词
                var wordListbox = wordList1.WordListBox;
                var count = wordListbox.Items.Count;
                if (count <= 0)
                {
                    throw new Exception("播放列表是空的");
                }
                if (wordListbox.SelectedIndex < 0)
                {
                    wordListbox.SelectedIndex = 0;
                }
                loadWord();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStopPlaylist_Click(object sender, EventArgs e)
        {
            isPlaylist = false;
        }

    }
}
