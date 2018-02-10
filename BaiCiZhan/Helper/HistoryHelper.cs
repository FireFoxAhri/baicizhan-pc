using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using BaiCiZhan.Model;
namespace BaiCiZhan.Helper
{
    public interface IHistoryHelper
    {

        void Add(WordInfo wordInfo);
        List<WordHistory> GetAll();
    }

    public class HistoryHelper : IHistoryHelper
    {
        const string HISTORY_FILE = @"DATA\HISTORY_FILE.TXT";
        public void Add(WordInfo word)
        {
            //createFile();
            WordHistory wh = new WordHistory();
            wh.Word = word.word;
            wh.AddTime = DateTime.Now;
            wh.WordSource = word.source;
            File.AppendAllText(HISTORY_FILE, wh.Serialize() + "\r\n");
        }

        void createFile()
        {

            if (!File.Exists(HISTORY_FILE))
            {
                File.Create(HISTORY_FILE);
            }
        }

        public List<WordHistory> GetAll()
        {
            var lines = File.ReadAllLines(HISTORY_FILE);
            List<WordHistory> whs = new List<WordHistory>();
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }
                var wh = WordHistory.FromString(line);
                whs.Add(wh);
            }
            return whs;
        }
        public List<WordHistory> GetAll(string wordContain)
        {
            return GetAll().Where(n => n.Word.Contains(wordContain)).ToList();
        }
    }

}
