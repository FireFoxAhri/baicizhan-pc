using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiCiZhan.view
{
    public partial class WordList : UserControl
    {

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
        public WordList()
        {
            InitializeComponent();
            this.Load += WordList_Load;
            this.tbWord.TextChanged += tbWord_TextChanged;

            this.tbWord.KeyDown += tbWord_KeyDown;
            this.cboWordSource.DataSource = new string[] { "四级单词", "历史记录" };
            this.cboWordSource.SelectedIndexChanged += cboWordSource_SelectedIndexChanged;
        }

        void cboWordSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadList();
        }

        void tbWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                listBox1.Select();
                if (listBox1.Items.Count >= 1)
                {
                    listBox1.SelectedIndex = 0;
                }
            }
        }


        public string GetSelectWrod()
        {
            return listBox1.SelectedItem as string;

        }
        void tbWord_TextChanged(object sender, EventArgs e)
        {
            loadList();
        }

        void WordList_Load(object sender, EventArgs e)
        {
            loadList();
        }
        void loadList()
        {
            try
            {

                string wordPattern = tbWord.Text.Trim();
                List<string> words = new List<string>();
                if (cboWordSource.SelectedIndex == 0)
                {
                    words = Helper.CET4Helper.GetInstance().GetWordList(wordPattern);
                }
                else
                {
                    words = new Helper.HistoryHelper().GetAll(wordPattern).Select(n => n.Word).ToList();
                }
                listBox1.Items.Clear();
                listBox1.Items.AddRange(words.Select(n => n as object).ToArray());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
