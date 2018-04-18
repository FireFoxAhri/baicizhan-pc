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
        readonly string DATA_DIR;
        const string HISTORY_FILE = @"HISTORY_FILE.TXT";
        string historyFile
        {
            get
            {
                createFile();
                return Path.Combine(DATA_DIR, HISTORY_FILE);
            }
        }
        public HistoryHelper()
        {
            var key = "DATA_DIR";
            string dir = System.Configuration.ConfigurationManager.AppSettings[key];
            if (!string.IsNullOrEmpty(dir))
            {
                DATA_DIR = dir;
            }
            else
            {
                DATA_DIR = "data";
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
                try
                {
                    Directory.CreateDirectory(DATA_DIR);
                }
                catch (Exception ex)
                {
                    throw new IOException("创建数据文件夹错误 -> " + DATA_DIR + " -> " + ex.Message);
                }

            }
            var path = Path.Combine(DATA_DIR, HISTORY_FILE);
            if (!File.Exists(path))
            {
                File.WriteAllText(path, "");
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
        /// <summary>
        /// 如果以'/'结尾, 精确匹配,  否则模糊匹配
        /// </summary>
        /// <param name="wordContain"></param>
        /// <returns></returns>
        public List<WordHistory> GetAll(string wordContain)
        {
            if (wordContain.EndsWith("/"))
            {
                return GetAll().Where(n => n.Word == wordContain).ToList();
            }
            return GetAll().Where(n => n.Word.Contains(wordContain)).ToList();
        }
    }

}
