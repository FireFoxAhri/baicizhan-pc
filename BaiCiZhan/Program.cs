using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiCiZhan
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ApplicationExit += Application_ApplicationExit;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());

        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            Helper.AudioHelper.GetInstance().Close();
        }
    }
}
