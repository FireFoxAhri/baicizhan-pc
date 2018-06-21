using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaiCiZhan.Model;

namespace BaiCiZhan.DAL
{
    public class FolderWordSource : IWordSource
    {
        WordHelper wordHelper = new WordHelper();
        public FolderWordSource(string sourceName)
        {
            this.Name = sourceName;
        }

        public string Name { get; set; }

        public void Add(WordInfo wordInfo)
        {
            throw new NotImplementedException();
        }

        public List<WordItemInfo> GetAll(string pattern = "")
        {
            wordHelper.SetDataSourceByName(Name);
            List<string> wordList = wordHelper.GetWordList(pattern);
            var list = wordList.Select(n => new WordItemInfo() { Word = n, WordSource = Name }).ToList();
            return list;
        }
    }
}
