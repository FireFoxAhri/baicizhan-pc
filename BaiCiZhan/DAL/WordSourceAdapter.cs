using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiCiZhan.DAL
{
    /// <summary>
    /// 整合FileWordSource和FolderWordSource
    /// FolderWordSource的构造很简单, 就没有对应的factory
    /// </summary>
    public class WordSourceAdapter
    {

        public List<string> GetAllSourceName()
        {
            List<string> lstSource = WordFolderConfigHelper.GetWordFolders().Select(n => n.Name).ToList();
            lstSource.AddRange(FileWordSourceFactory.GetAllFileWordSourceName());
            return lstSource;
        }

        public IWordSource GetWordSource(string name)
        {
            var source = FileWordSourceFactory.GetFileWordSource(name);
            if (source == null)
            {
                source = new FolderWordSource(name);
            }
            return source;
        }
    }

}
