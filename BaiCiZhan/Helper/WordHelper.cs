using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BaiCiZhan.Model;
using Newtonsoft.Json;
using System.IO;
using System.Configuration;
using BaiCiZhan.Model;

namespace BaiCiZhan.Helper
{
    public class WordHelper
    {
        const string WORD_PRE = "WORDS_";
        // 单词的所在的文件夹
        protected string wordPath;
        protected string sourceName;

        #region WordSource相关

        public static List<WordSource> GetWordSources()
        {
            List<WordSource> sources = new List<WordSource>();
            //约定以WORDS_开头,例如WORDS_四级单词, 后面是单词源的名称
            var keys = ConfigurationManager.AppSettings.Keys.OfType<string>().Where(n => n.StartsWith(WORD_PRE));
            foreach (var key in keys)
            {
                WordSource ws = new WordSource();
                ws.Key = key;
                ws.Name = key.Split('_')[1];
                ws.Path = ConfigurationManager.AppSettings[key];
                sources.Add(ws);
            }
            return sources;
        }

        public static WordSource GetWordSourceByName(string name)
        {
            var wordSources = GetWordSources();
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

        #endregion

        #region 直接指定单词源
        /// <summary>
        /// 通过数据源的name获取wordlist
        /// </summary>
        /// <param name="wordSoureName"></param>
        /// <param name="wordPattern"></param>
        /// <returns></returns>
        public static List<string> GetWordListBySourceName(string wordSoureName, string wordPattern = "")
        {
            WordHelper helper = new WordHelper();
            helper.SetDataSourceByName(wordSoureName);
            return helper.GetWordList(wordPattern);
        }

        /// <summary>
        /// 通过数据源、单词获取单词信息
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static WordInfo GetWordBySourceName(string wordSoureName, string word)
        {
            WordHelper helper = new WordHelper();
            helper.SetDataSourceByName(wordSoureName);
            return helper.GetWord(word);
        }
        #endregion

        #region 获取单词信息
        public void SetDataSourceByName(string wordSourceName)
        {
            this.sourceName = wordSourceName;
            var ws = GetWordSourceByName(wordSourceName);
            this.wordPath = ws.Path;
        }

        public void CheckData()
        {
            if (!Directory.Exists(wordPath))
            {
                throw new Exception("单词文件夹不存在, 请在配置文件中正确配置");
            }
        }

        public WordInfo GetWord(string word)
        {
            #region 格式
            /*
{
    "topic_id": 5039,
    "word": "absence",
    "word_audio": "wa_1_5039_0_2_20150808123357.aac",
    "image_file": "i_1_5039_0_2_20150808123357.jpg",
    "accent": " [ˈæbsəns]",
    "mean_cn": "n: 缺席, 外出期, 缺乏, 心不在焉;  ",
    "mean_en": "a failure to be present at a usual or expected place",
    "word_etyma": "abs离去+ence名词后缀 → 缺席",
    "short_phrase": "the absence of people",
    "deformation_img": "d_1_5039_0_2_20150808123357.png",
    "sentence": "What is the reason for everyone\u0027s absence?",
    "sentence_trans": "为什么今天所有人都缺席？",
    "sentence_audio": "sa_1_5039_0_2_20150808123357.aac"
}
     */
            #endregion
            CheckData();
            var path = Path.Combine(wordPath, word);
            if (!Directory.Exists(path))
            {
                throw new ArgumentException("单词路径不存在:" + word);
            }
            var jsonFile = Path.Combine(path, "meta.json");
            var json = File.ReadAllText(jsonFile);
            WordInfo info = JsonConvert.DeserializeObject<WordInfo>(json);

            info.sentence_audio = Path.Combine(path, info.sentence_audio);
            info.word_audio = Path.Combine(path, info.word_audio);
            info.image_file = Path.Combine(path, info.image_file);

            info.source = this.sourceName;
            return info;
        }

        public List<string> GetWordList(string wordPattern = "")
        {
            CheckData();
            var pattern = string.IsNullOrEmpty(wordPattern) ? "*" : ("*" + wordPattern + "*");
            var arr = Directory.GetDirectories(wordPath, pattern).Select(n => Path.GetFileName(n));
            return arr.ToList();
        }

        #endregion

    }

}
