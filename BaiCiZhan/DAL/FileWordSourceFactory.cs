using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BaiCiZhan.Model;
namespace BaiCiZhan.DAL
{

    public class FileWordSourceFactory
    {
        public const string HISTORY = @"历史记录";
        public const string FAVORITE = @"收藏";

        static List<WordFileInfo> WordFileInfos = new List<WordFileInfo>() { 
            new WordFileInfo() {Name = HISTORY, FileName = "HISTORY_FILE.TXT"},
            new WordFileInfo() {Name = FAVORITE, FileName = "FAVORITE_FILE.TXT"},
        };
        public static IWordSource GetFileWordSource(string name)
        {
            var wordFile = WordFileInfos.FirstOrDefault(n => n.Name == name);
            if (wordFile != null)
            {
                return new FileWordSource(wordFile.FileName, wordFile.Name);
            }
            else
            {
                return null;
            }
        }

        public static List<string> GetAllFileWordSourceName()
        {
            return WordFileInfos.Select(n => n.Name).ToList();
        }
        public static IEnumerable<IWordSource> GetAllFileWordSource()
        {
            var list = WordFileInfos.Select(n => new FileWordSource(n.FileName, n.Name));
            return list;
        }
    }
}

