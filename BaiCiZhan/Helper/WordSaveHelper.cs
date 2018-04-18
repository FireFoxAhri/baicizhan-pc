using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using BaiCiZhan.Model;
namespace BaiCiZhan.Helper
{
    public interface IWordSaveHelper
    {
        string Name { set; get; }
        void Add(WordInfo wordInfo);
        List<WordSaveInfo> GetAll(string pattern="");
    }

    public class WordSaveFactory
    {
        const string HISTORY_FILE = @"HISTORY_FILE.TXT";
        const string FAVORITE_FILE = @"FAVORITE_FILE.TXT";
        public enum WordSaveType
        {
            history,
            favorit
        }
        public static IWordSaveHelper GetWordSaveHelper(WordSaveType type)
        {
            IWordSaveHelper helper = null;
            switch (type)
            {
                case WordSaveType.history:
                    helper = new WordSaveHelper(HISTORY_FILE, "历史记录");
                    break;
                case WordSaveType.favorit:
                    helper = new WordSaveHelper(FAVORITE_FILE, "收藏");
                    break;
                default:
                    break;
            }
            return helper;
        }
    }

    public class WordSaveHelper : IWordSaveHelper
    {
        readonly string DATA_DIR;
        private string saveFile;
        string saveFilePath
        {
            get
            {
                createFile();
                return Path.Combine(DATA_DIR, saveFile);
            }
        }
        public string Name { set; get; }
        public WordSaveHelper(string saveFile, string name)
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
            this.saveFile = saveFile;
            this.Name = name;
        }
        public void Add(WordInfo word)
        {
            WordSaveInfo wh = new WordSaveInfo();
            wh.Word = word.word;
            wh.AddTime = DateTime.Now;
            wh.WordSource = word.source;
            File.AppendAllText(saveFilePath, wh.Serialize() + "\r\n");
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
            var path = Path.Combine(DATA_DIR, saveFile);
            if (!File.Exists(path))
            {
                File.WriteAllText(path, "");
            }
        }

        /// <summary>
        /// 降序排序
        /// </summary>
        /// <returns></returns>
        public List<WordSaveInfo> GetAll()
        {
            var lines = File.ReadAllLines(saveFilePath);
            List<WordSaveInfo> whs = new List<WordSaveInfo>();
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }
                var wh = WordSaveInfo.DeSerialize(line);
                whs.Add(wh);
            }
            return whs.OrderByDescending(n => n.AddTime).ToList();
        }
        /// <summary>
        /// 如果以'/'结尾, 精确匹配,  否则模糊匹配
        /// </summary>
        /// <param name="wordContain"></param>
        /// <returns></returns>
        public List<WordSaveInfo> GetAll(string wordContain)
        {
            if (wordContain.EndsWith("/"))
            {
                return GetAll().Where(n => n.Word == wordContain.Trim("/".ToArray())).ToList();
            }
            return GetAll().Where(n => n.Word.Contains(wordContain)).ToList();
        }
    }

}
