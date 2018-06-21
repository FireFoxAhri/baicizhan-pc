using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiCiZhan.DAL
{
    public class WordSourceHelper
    {

        public List<string> GetAllSource()
        {
            List<string> lstSource = WordFolderConfigHelper.GetWordFolders().Select(n => n.Name).ToList();
            lstSource.Add(FileWordSourceFactory.HISTORY);
            lstSource.Add(FileWordSourceFactory.FAVORITE);
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
