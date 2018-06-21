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
using BaiCiZhan.DAL;

namespace BaiCiZhan.view
{
    public partial class ucWordList : UserControl
    {
        #region 初始化

        WordSourceHelper wordSourceHelper = new WordSourceHelper();
        public ListBox WordListBox
        {
            get
            {
                return this.listBox1;
            }
        }

        public TextBox WordTextBox
        {
            get
            {
                return this.tbWord;
            }
        }
        public ucWordList()
        {
            InitializeComponent();

            if (this.DesignMode)
            {
                return;
            }
            this.Load += WordList_Load;
            this.tbWord.TextChanged += tbWord_TextChanged;
            this.tbWord.KeyDown += tbWord_KeyDown;
            this.cboWordSource.SelectedIndexChanged += cboWordSource_SelectedIndexChanged;
        }


        void WordList_Load(object sender, EventArgs e)
        {
            var lstSource = wordSourceHelper.GetAllSource();
            this.cboWordSource.DataSource = lstSource;
            loadList();
        }

        #endregion

        #region 事件

        void cboWordSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbWord.Text = "";
            loadList();
        }

        void tbWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                e.Handled = true;
                listBox1.Select();
                if (listBox1.Items.Count >= 1)
                {
                    listBox1.SelectedIndex = 0;
                }
            }
        }

        void tbWord_TextChanged(object sender, EventArgs e)
        {
            loadList();
        }

        #endregion

        #region 获取数据

        public WordInfo GetSelectWrod()
        {
            var wh = listBox1.SelectedItem as WordItemInfo;
            return WordHelper.GetWordByFolderName(wh.WordSource, wh.Word);
        }

        void loadList()
        {
            try
            {
                string wordPattern = tbWord.Text.Trim();
                var name = cboWordSource.SelectedItem as string;
                IWordSource source = wordSourceHelper.GetWordSource(name);
                var words = source.GetAll(wordPattern);
                listBox1.Items.Clear();
                listBox1.Items.AddRange(words.Select(n => n as object).ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
    }
}
