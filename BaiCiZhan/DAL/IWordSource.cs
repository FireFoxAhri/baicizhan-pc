using BaiCiZhan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiCiZhan.DAL
{
    /// <summary>
    /// 单词源, 包括
    /// 1. 单词文件夹读取
    /// 2. 历史记录、收藏之类从文件里读取
    /// </summary>
    public interface IWordSource
    {
        string Name { get; set;}
        void Add(WordInfo wordInfo);
        List<WordItemInfo> GetAll(string pattern = "");
    }
}
