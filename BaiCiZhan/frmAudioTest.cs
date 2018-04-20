using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace BaiCiZhan
{
    public partial class frmAudioTest : Form
    {

        //string file = @"D:\资料\百词斩数据文件\单词\1_解压\abandon\sa_1_4719_0_6_160123165116.aac";
        string file = @"F:\CloudMusic\孟庭苇 - 羞答答的玫瑰静悄悄地开.mp3";
        public frmAudioTest()
        {
            InitializeComponent();

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //ucAudioPlayer1.Play(file);
        }



    }
}
