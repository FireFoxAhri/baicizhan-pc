using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiCiZhan.Model
{

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
    public class WordInfo
    {
        public int topic_id { get; set; }
        public string word { get; set; }
        public string word_audio { get; set; }
        public string word_variants { get; set; }
        public string image_file { get; set; }
        public string accent { get; set; }
        public string mean_cn { get; set; }
        public string mean_en { get; set; }
        public string word_etyma { get; set; }
        public string short_phrase { get; set; }
        public string deformation_img { get; set; }
        public string sentence { get; set; }
        public string sentence_trans { get; set; }
        public string sentence_audio { get; set; }
        /// <summary>
        /// 单词源,四级单词,高考单词之类;
        /// </summary>
        public string source { get; set; }
        
    }
}
