using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using System.IO;

namespace BaiCiZhan.view
{
    public partial class ucAudioPlayer : UserControl
    {
        string file = "";
        //string file = @"D:\资料\百词斩数据文件\单词\1_解压\abandon\sa_1_4719_0_6_160123165116.aac";
        //string file = @"F:\CloudMusic\孟庭苇 - 羞答答的玫瑰静悄悄地开.mp3";
        Helper.AudioPlayer2 audioPlayer = Helper.AudioPlayer2.GetInstance();
        public ucAudioPlayer()
        {
            InitializeComponent();

            audioPlayer.PlayTimeChanged += audioPlayer_PlayTimeChanged;
            trackBar1.MouseWheel += trackBar1_MouseWheel;
            trackBar1.MouseUp += trackBar1_MouseUp;
            trackBar1.MouseDown += trackBar1_MouseDown;

        }

        public void Play(string file)
        {
            this.file = file;
            if (string.IsNullOrEmpty(file))
            {
                MessageBox.Show("没有加载文件");
                return;
            }
            if (!System.IO.File.Exists(file))
            {
                MessageBox.Show("文件不存在: " + file);
                return;
            }
            audioPlayer.Play(file);
            trackBar1.Value = trackBar1.Minimum;
        }

        void audioPlayer_PlayTimeChanged(AudioFileReader audioFile)
        {
            int percent = (int)(audioFile.CurrentTime.TotalSeconds * 100 / audioFile.TotalTime.TotalSeconds);
            percent = Math.Max(trackBar1.Minimum, percent);
            percent = Math.Min(trackBar1.Maximum, percent);
            this.Invoke((MethodInvoker)(() =>
            {
                //鼠标按下的时候认为正在手动调整游标, 不设置游标的位置;
                if (MouseButtons != System.Windows.Forms.MouseButtons.Left)
                {
                    trackBar1.Value = percent;
                }
                double current = 0;
                try
                {
                    //todo 有时候获取CurrentTime会报空指针异常
                    current = Math.Max(0, audioFile.CurrentTime.TotalSeconds);
                    current = Math.Min(audioFile.TotalTime.TotalSeconds, current);
                }
                catch (Exception)
                {
                    current = 0;
                }

                lblCurrentTime.Text = string.Format("{0:0}/{1:0}", current, audioFile.TotalTime.TotalSeconds);
            }));
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                Play(this.file);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            trackBar1.Value = trackBar1.Minimum;
            audioPlayer.Close();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
        }

        //禁用鼠标滚轮调整进度条的游标
        void trackBar1_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        //鼠标弹起时才开始播放; 这样便于调整
        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                int percent = trackBar1.Value;
                audioPlayer.Play(file, null, percent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //把游标设置在鼠标单击的地方
        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            double dblValue;
            dblValue = ((double)(e.X - 10) / (double)(trackBar1.Width - 20)) * (trackBar1.Maximum - trackBar1.Minimum);
            dblValue = Math.Min(dblValue, trackBar1.Maximum);
            dblValue = Math.Max(dblValue, trackBar1.Minimum);

            trackBar1.Value = Convert.ToInt32(dblValue);
        }


    }
}
