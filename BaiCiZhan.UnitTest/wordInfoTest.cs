using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaiCiZhan.Helper;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.IO;
using NAudio.MediaFoundation;
using System.Collections.Generic;
using BaiCiZhan.Model;
using BaiCiZhan.DAL;
using System.Linq;

namespace BaiCiZhan.UnitTest
{
    [TestClass]
    public class wordInfoTest
    {
        /*
!ffmpeg! -y -i 1.mp3 -i 2.aac -i 2.aac -filter_complex "aevalsrc=0:d=5[s],aevalsrc=0:d=5[s],[0:0][s][1:0][s][2:0]concat=n=5:v=0:a=1[out]" -map "[out]" output.MP3

         */

        [TestMethod]
        public void getWordInfo()
        {
            String sourceString = @"
formulate|2019-03-01 00:37:54|六级词汇
solution|2019-03-01 00:38:33|六级词汇
commercial|2019-03-01 00:38:39|六级词汇
retention|2019-03-01 00:38:48|六级词汇
vulnerable|2019-03-01 00:38:57|六级词汇
stroke|2019-03-01 00:39:06|六级词汇
invariably|2019-03-01 00:39:16|六级词汇
Jesus|2019-03-01 00:39:22|六级词汇
perfume|2019-03-01 00:39:27|六级词汇
quantify|2019-03-01 00:39:33|六级词汇
outermost|2019-03-01 00:39:38|六级词汇
overcome|2019-03-01 00:39:43|六级词汇
element|2019-03-01 00:39:47|六级词汇
superstition|2019-03-01 00:39:56|六级词汇
category|2019-03-01 00:40:12|六级词汇

";
            var words = sourceString.Split(new String[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            List<String> audios = new List<string>();
            List<String> texts = new List<string>();
            
            foreach (var wordString in words)
            {
                var wordItemInfo = WordItemInfo.DeSerialize(wordString);
                var wordInfo = WordHelper.GetWordByFolderName(wordItemInfo.WordSource, wordItemInfo.Word);
                audios.Add(" -i \"" + wordInfo.word_audio+"\"");
                audios.Add(" -i \""+wordInfo.sentence_audio+"\"");
                texts.Add(string.Format("[{0}] {1}",wordInfo.word,wordInfo.sentence));
            }
            String text = String.Join("\r\n", texts);

            //[0:0][1:0]concat=n=2:v=0:a=1[out]
            String audioString = String.Join("", audios);
           
            var array1 = audios.Select(n =>"aevalsrc=0:d=1[s]").ToList(); //中间1秒的空白
            array1.RemoveAt(0);
            String str1 = String.Join(",",array1);
          var indexArray  = audios.Select((n, i) => String.Format("[{0}:0]", i)).ToArray();
            String str2 = String.Join("[s]", indexArray);
            String finalString = String.Format("!ffmpeg! -y {0} -filter_complex \"{1},{2}concat=n={3}:v=0:a=1[out]\" -map \"[out]\" output.MP3", audioString,str1,str2,audios.Count*2-1);

            Console.WriteLine(finalString);
        }
    }
}
