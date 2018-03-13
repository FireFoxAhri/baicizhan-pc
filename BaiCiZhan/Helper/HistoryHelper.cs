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
        const string DATA_DIR = "DATA";
        const string HISTORY_FILE = @"HISTORY_FILE.TXT";
        string historyFile
        {
            get
            {
                createFile();
                return Path.Combine(DATA_DIR, HISTORY_FILE);
            }
        }
        public void Add(WordInfo word)
        {
            WordHistory wh = new WordHistory();
            wh.Word = word.word;
            wh.AddTime = DateTime.Now;
            wh.WordSource = word.source;
            File.AppendAllText(historyFile, wh.Serialize() + "\r\n");
        }

        void createFile()
        {
            if (!Directory.Exists(DATA_DIR))
            {
                Directory.CreateDirectory(DATA_DIR);
            }

            var path = Path.Combine(DATA_DIR, HISTORY_FILE);
            if (!File.Exists(path))
            {
                File.WriteAllText(path,"");
            }
        }

        /// <summary>
        /// 降序排序
        /// </summary>
        /// <returns></returns>
        public List<WordHistory> GetAll()
        {
            var lines = File.ReadAllLines(historyFile);
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
            return whs.OrderByDescending(n => n.AddTime).ToList();
        }
        public List<WordHistory> GetAll(string wordContain)
        {
            return GetAll().Where(n => n.Word.Contains(wordContain)).ToList();
        }
    }

}
