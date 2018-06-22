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

namespace BaiCiZhan.DAL
{
    /// <summary>
    /// 读取解压之后的百词斩单词文件
    /// 两种方法：
    /// 1. 实例方法先指定文件夹数据源名称(SetDataSourceByName), 再调用获取数据的方法;
    /// 2. 静态方法直接在方法中指定文件夹数据源名称
    /// </summary>
    public class WordHelper
    {

        // 单词的所在的文件夹信息
        protected WordFolderInfo wordFolder;

        public void SetDataSourceByName(string wordSourceName)
        {
            var wf = WordFolderConfigHelper.GetWordFolderByName(wordSourceName);
            this.wordFolder = wf;
        }
        #region 获取数据

        /// <summary>
        /// 通过数据源的name获取wordlist
        /// </summary>
        /// <param name="wordFolderName"></param>
        /// <param name="wordPattern"></param>
        /// <returns></returns>
        public static List<string> GetWordListByFolderName(string wordFolderName, string wordPattern = "")
        {
            WordHelper helper = new WordHelper();
            helper.SetDataSourceByName(wordFolderName);
            return helper.GetWordList(wordPattern);
        }

        /// <summary>
        /// 如果以'/'结尾, 精确匹配, 否则模糊匹配
        /// </summary>
        /// <param name="wordPattern"></param>
        /// <returns></returns>
        public List<string> GetWordList(string wordPattern = "")
        {
            CheckData();
            var pattern = "";
            if (wordPattern.EndsWith("/"))
            {
                pattern = wordPattern.TrimEnd("/".ToArray());
            }
            else
            {
                pattern = string.IsNullOrEmpty(wordPattern) ? "*" : ("*" + wordPattern + "*");
            }

            var arr = Directory.GetDirectories(wordFolder.Path, pattern).Select(n => Path.GetFileName(n));
            return arr.ToList();
        }

        /// <summary>
        /// 通过数据源、单词获取单词信息
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static WordInfo GetWordByFolderName(string wordSoureName, string word)
        {
            WordHelper helper = new WordHelper();
            helper.SetDataSourceByName(wordSoureName);
            return helper.GetWord(word);
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
            var path = Path.Combine(wordFolder.Path, word);
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

            info.source = this.wordFolder.Name;
            return info;
        }

        #endregion

        #region 方法


        public void CheckData()
        {
            if (!Directory.Exists(wordFolder.Path))
            {
                throw new Exception("单词文件夹不存在, 请在配置文件中正确配置: " + wordFolder.Path);
            }
        }

        #endregion

    }

}
