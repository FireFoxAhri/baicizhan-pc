using BaiCiZhan.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiCiZhan.DAL
{
    /// <summary>
    /// 读取wordFolder的配置信息
    /// </summary>
    public class WordFolderConfigHelper
    {
        const string WORD_PRE = "WORDS_";

        public static List<WordFolderInfo> GetWordFolders()
        {
            List<WordFolderInfo> sources = new List<WordFolderInfo>();
            //约定以WORDS_开头,例如WORDS_四级单词, 后面是单词源的名称
            var keys = ConfigurationManager.AppSettings.Keys.OfType<string>().Where(n => n.StartsWith(WORD_PRE));
            foreach (var key in keys)
            {
                WordFolderInfo wf = new WordFolderInfo();
                wf.Key = key;
                wf.Name = key.Split('_')[1];
                wf.Path = ConfigurationManager.AppSettings[key];
                sources.Add(wf);
            }
            return sources;
        }

        public static WordFolderInfo GetWordFolderByName(string name)
        {
            var wordSources = GetWordFolders();
            var key = WORD_PRE + name;
            var wd = wordSources.FirstOrDefault(n => n.Key == key);
            if (wd == null)
            {
                throw new Exception("不存在的单词源: " + name);
            }
            else
            {
                return wd;
            }
        }


    }
}
