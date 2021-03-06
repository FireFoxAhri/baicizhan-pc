using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiCiZhan.Model
{
    public class WordItemInfo
    {
        public string WordSource { set; get; }
        public string Word { set; get; }
        public DateTime AddTime { set; get; }

        public override string ToString()
        {
            return this.Word;
        }
        public string Serialize()
        {
            return string.Format("{0}|{1}|{2}", this.Word, this.AddTime.ToString("yyyy-MM-dd HH:mm:ss"), this.WordSource);
        }
        public static WordItemInfo DeSerialize(string wordSaveString)
        {
            var arr = wordSaveString.Split('|');
            WordItemInfo wh = new WordItemInfo();
            wh.Word = arr[0];
            wh.AddTime = Convert.ToDateTime(arr[1]);
            wh.WordSource = arr[2];
            return wh;
        }
    }
}
