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
namespace BaiCiZhan
{
    public partial class frmMain : frmMDIParent
    {
        public frmMain()
        {
            InitializeComponent();

            this.mdiForms.Add(new MdiForm(typeof(frmExtractor), "解压zpk"));
            this.mdiForms.Add(new MdiForm(typeof(frmStudy), "英语学习"));
            //this.mdiForms.Add(new MdiForm(typeof(frmAudioTest), "audio 测试"));
            this.Load += frmMain_Load;
        }

        void frmMain_Load(object sender, EventArgs e)
        {
            this.Size = new Size(900, 800);
        }
    }

}
