using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiCiZhan.Model
{

    public class WordSource
    {
        public string Name { set; get; }
        public string Path { set; get; }
        public string Key { set; get; }
        public List<string> Words { set; get; }
    }
}
