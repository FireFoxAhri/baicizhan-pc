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
using System.IO;

namespace BaiCiZhan
{
    public partial class frmExtractor : frmBase
    {
        //todo: 多线程解压; 显示内容分批次:每10个显示一次?(每个都显示占用太多速度);
        //todo: 已经存在的跳过;

        DateTime lastShowTime;
        ZPKExtractor extractor = new ZPKExtractor();
        public frmExtractor()
        {
            InitializeComponent();
            extractor.ShowProcessing += extractor_ShowProcessing;
            lastShowTime = DateTime.Now;
        }

        void extractor_ShowProcessing(string msg, int level)
        {
            int milleSeconds = 200; //两次显示的最小间隔;
            if (lastShowTime.AddMilliseconds(milleSeconds) < DateTime.Now)
            {
                ShowMsg(msg);
            }
        }


        private void btnExtract_Click(object sender, EventArgs e)
        {
            try
            {
                var dir = ucOpenFileDialogZpk.FilePath;
                var dirInfo = new DirectoryInfo(dir);
                var extDir = ucOpenFileDialog2.FilePath;
                if (extDir == "")
                {
                    extDir = dirInfo.FullName + "_解压";
                }

                extractor.ExtractFiles(dirInfo, extDir);
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
            }
        }


    }
}
