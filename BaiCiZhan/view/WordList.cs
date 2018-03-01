﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaiCiZhan.Model;

namespace BaiCiZhan.view
{
    public partial class WordList : UserControl
    {
        //todo: 单词数据源(从文件夹里读取单词)和历史记录数据源, 属于不同的数据源, 根据单一职责原理, 这个WordList应该只处理一种数据源, 处理两种数据源必然会导致冗余; 
        //解决办法: 1. 新建一个类统一单词数据源和历史记录数据源; 2. 为两种数据源分别建立不同的显示控件;
        const string HISTORY = "历史记录";
        Helper.WordHelper wordHelper = new Helper.WordHelper();
        public ListBox WordListBox
        {
            get
            {
                return this.listView1;
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

            List<string> lstSource = Helper.WordHelper.GetWordSources().Select(n => n.Name).ToList();
            lstSource.Add(HISTORY);
            this.cboWordSource.DataSource = lstSource;
            this.cboWordSource.SelectedIndexChanged += cboWordSource_SelectedIndexChanged;

            wordHelper.SetDataSourceByName(lstSource.First());
        }

        void cboWordSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbWord.Text = "";
            if (isHistory())
            {
                loadList();
                return;
            }
            var source = cboWordSource.SelectedItem as string;
            wordHelper.SetDataSourceByName(source);
            loadList();
        }

        //如果选中的数据源是历史记录需要单独处理;
        bool isHistory()
        {
            var item = cboWordSource.SelectedItem as string;
            return (item == HISTORY);
        }

        void tbWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                listView1.Select();
                if (listView1.Items.Count >= 1)
                {
                    listView1.SelectedIndex = 0;
                }
            }
        }
        public WordInfo GetSelectWrod()
        {
            if (isHistory())
            {
                var wh = listView1.SelectedItem as WordHistory;
                return Helper.WordHelper.GetWordBySourceName(wh.WordSource, wh.Word);
            }

            var word = listView1.SelectedItem as string;
            if (string.IsNullOrEmpty(word))
            {
                return null;
            }

            var wd = wordHelper.GetWord(word);
            return wd;
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
                if (isHistory())
                {
                    string wordPattern1 = tbWord.Text.Trim();
                    var words1 = new Helper.HistoryHelper().GetAll(wordPattern1);

                    listView1.Items.Clear();
                    for (int i = 0; i < words1.Count(); i++)
                    {
                        var index = listView1.Items.Add(words1[i]);
                    }
                    return;
                }

                string wordPattern = tbWord.Text.Trim();
                List<string> words = wordHelper.GetWordList(wordPattern);
                listView1.Items.Clear();
                listView1.Items.AddRange(words.Select(n => n as object).ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
