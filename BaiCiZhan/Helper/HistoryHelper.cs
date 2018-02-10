using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BaiCiZhan.Helper
{
    public interface IHistoryHelper
    {

        void Add(string word);
        List<WordHistory> GetAll();
    }
    public class WordHistory
    {
        public string Word { set; get; }
        public DateTime AddTime { set; get; }

        public override string ToString()
        {
            return string.Format("{0}|{1}", this.Word, this.AddTime.ToString("yyyy-MM-dd HH:mm:ss"));
        }
        public static WordHistory FromString(string historyString)
        {
            var arr = historyString.Split('|');
            WordHistory wh = new WordHistory();
            wh.Word = arr[0];
            wh.AddTime = Convert.ToDateTime(arr[1]);
            return wh;
        }
    }
    public class HistoryHelper : IHistoryHelper
    {
        const string HISTORY_FILE = @"DATA\HISTORY_FILE.TXT";
        public void Add(string word)
        {
            //createFile();
            WordHistory wh = new WordHistory();
            wh.Word = word;
            wh.AddTime = DateTime.Now;
            File.AppendAllText(HISTORY_FILE, wh.ToString()+"\r\n");
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
