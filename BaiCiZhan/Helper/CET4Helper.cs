using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BaiCiZhan.Model;
using Newtonsoft.Json;
using System.IO;
using System.Configuration;

namespace BaiCiZhan.Helper
{
    public class CET4Helper
    {
        static CET4Helper _instance;
        public static CET4Helper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CET4Helper();
            }
            return _instance;
        }

        public static string DATA_ROOT;

        static CET4Helper()
        {
            DATA_ROOT = ConfigurationManager.AppSettings["DATA_ROOT"];
        }
        public void CheckData()
        {
            if (!Directory.Exists(DATA_ROOT))
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
            var path = Path.Combine(DATA_ROOT, word);
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

            return info;
        }


        public List<string> GetWordList(string wordPattern = "")
        {
            CheckData();
            var pattern = string.IsNullOrEmpty(wordPattern) ? "*" : ("*" + wordPattern + "*");
            var arr = Directory.GetDirectories(DATA_ROOT, pattern).Select(n => Path.GetFileName(n));
            return arr.ToList();
        }


    }
}
