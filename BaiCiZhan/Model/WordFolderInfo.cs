using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiCiZhan.Model
{
    /// <summary>
    /// 单词文件夹, 解压百词斩数据文件得到的文件夹
    /// 在app.config里的配置是: <add key="WORDS_四级词汇2" value="D:\source\Release\baicizhan\data\四级词汇_解压"/>
    /// </summary>
    public class WordFolderInfo
    {
        /// <summary>
        /// 名称, WORDS_后面的部分
        /// </summary>
        public string Name { set; get; }
        public string Path { set; get; }
        /// <summary>
        /// 在AppSetting里的key
        /// </summary>
        public string Key { set; get; }
        public List<string> Words { set; get; }
    }
}
