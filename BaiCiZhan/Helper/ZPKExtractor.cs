using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BaiCiZhan.Helper
{

    /*
     * zpk文件构造:
zpk由头部,中部,尾部组成,中部和尾部之间有位置信息;
头部是zpk的文件头
中部是png,jpg,MP3,json等资源文件的二进制直接拼接起来的
尾部是文件列表:资源文件的文件名;
尾部正上方三行的位置(前68个字节的位置)是资源文件在zpk文件里的起始位置,起始位置下面(后28个字节的位置)是文件的大小; 
获取起始位置,获取文件大小,提取出来,二进制形式保存到文件,就把资源文件从zpk里提取出来了;
     */

    /// <summary>
    /// 使用方法: 
    /// 调用ExtractFiles方法
    /// </summary>
    class ZPKExtractor
    {
        #region 字段 初始化

        /// <summary>
        /// zpk处理进度信息
        /// </summary>
        public event Action<string, int> ShowProcessing;
        byte[] buffer;
        int endPosition;
        List<zpkMediaFileInfo> mediaFileInfos;
        private string zpkFile = "";
        private string saveToDirectory = "";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="zpkdir">zpk文件所在的DirectoryInfo</param>
        /// <param name="saveToDir">解压后保存的文件夹</param>
        public void ExtractFiles(DirectoryInfo zpkdir, string saveToDir)
        {
            if (!Directory.Exists(zpkdir.FullName))
            {
                throw new FileNotFoundException(zpkdir.FullName);
            }
            int i = 0;
            foreach (FileInfo file in zpkdir.GetFiles("*.zpk", SearchOption.AllDirectories))
            {
                showMessage((++i).ToString(), 2);
                ExtractFile(file.FullName, saveToDir);
            }
        }

        public void ExtractFile(string zpkFile, string saveToDir)
        {
            try
            {
                this.saveToDirectory = saveToDir;
                this.zpkFile = zpkFile;
                initBufferVarieties(zpkFile);
                writeMediaFiles();
                showMessage("success : " + zpkFile, 1);
            }
            catch (Exception ex)
            {
                showMessage("fail : " + zpkFile + ex.Message, 0);
            }
        }

        /// <summary>
        /// level: 0:error;1:info;2debug
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="level"></param>
        void showMessage(string msg, int level)
        {
            if (this.ShowProcessing != null)
            {
                ShowProcessing(msg, level);
            }
        }
        #endregion

        #region 核心流程
        //核心是得到mediaFileInfos,mediaFileInfos里有媒体文件的名称,在buffer里的起始位置和大小;
        //得到信息后从文件里提取字节信息,保存;

        //初始化变量
        void initBufferVarieties(string zpkFile)
        {
            FileStream fs = new FileStream(zpkFile, FileMode.Open);
            if (fs.Length < 10)
            {
                throw new FileLoadException("the file is empty");
            }
            this.buffer = new byte[fs.Length];
            fs.Position = 0;
            fs.Read(buffer, 0, buffer.Length);
            this.endPosition = getEndPosition();
            fs.Close();

            this.mediaFileInfos = getMediaFiles();
        }

        void writeMediaFiles()
        {
            string folderName = getWordName(mediaFileInfos);
            string dir = Path.Combine(this.saveToDirectory, folderName);
            Directory.CreateDirectory(dir);

            foreach (zpkMediaFileInfo media in mediaFileInfos)
            {
                string path = Path.Combine(dir, media.Name);
                var bs = getBytes(media.StartPostion, media.StartPostion + media.Size);
                File.WriteAllBytes(path, bs);
            }
        }

        List<zpkMediaFileInfo> getMediaFiles()
        {
            //从zpk文件末尾得到包含的文件的列表;
            var bs = getBytes(buffer, endPosition, buffer.Length);
            string s = Encoding.ASCII.GetString(bs).Trim();
            List<string> files = s.Split('\n').ToList();

            //得到zpk里media文件的信息;
            List<zpkMediaFileInfo> mediaFiles = new List<zpkMediaFileInfo>();
            for (int i = 0; i < files.Count(); i++)
            {
                zpkMediaFileInfo media = new zpkMediaFileInfo();
                media.Name = files[i];
                int posLeftStart = endPosition - 3 * 16 * (files.Count() - i);
                media.StartPostion = getTranslatePostion(posLeftStart);

                int posLeftSize = posLeftStart + 1 * 16;
                media.Size = getTranslatePostion(posLeftSize);
                mediaFiles.Add(media);
            }
            return mediaFiles;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 从json文件里获取单词的名字;
        /// </summary>
        /// <param name="mediaFiles"></param>
        /// <returns></returns>
        string getWordName(List<zpkMediaFileInfo> mediaFiles)
        {
            string wordName = "";

            var jsons = mediaFiles.Where(n => n.Name.EndsWith(".json"));
            if (jsons.Count() == 0)
            {
                string msg = string.Format(@"{0} 不存在json文件", this.zpkFile);
                throw new Exception(msg);
            }
            else
            {
                try
                {
                    //获取json字符串
                    var json = jsons.First();
                    var bs = getBytes(json.StartPostion, json.StartPostion + json.Size);
                    string jsonStr = Encoding.UTF8.GetString(bs);
                    //获得word名
                    JObject j = JObject.Parse(jsonStr);
                    wordName = j["word"].ToString();
                }
                catch (Exception)
                {

                    //throw;
                }
            }
            return wordName;
            //    folderName = DateTime.Now.ToString("yyyyMMddHHmmff");

        }

        int getTranslatePostion(int pos)
        {
            int p = buffer[pos] + 16 * 16 * buffer[pos + 1] + 16 * 16 * 16 * 16 * buffer[pos + 2];
            return p;
        }


        /// <summary>
        /// 得到尾部的第一个字符的位置;
        /// 尾部是文件列表;
        /// </summary>
        /// <returns></returns>
        int getEndPosition()
        {
            const int LastLen = 160;
            var bs = getBytes(buffer, buffer.Length - LastLen, buffer.Length);
            bs = bs.Reverse().ToArray();
            int i = getIndexOfSubArray(bs, "000000");  //得到的值是倒着从1数文件尾部的第一个字符的位置;
            if (i < 0)
            {
                throw new Exception("获取文件列表错误");
            }

            return buffer.Length - i;

        }
        /// <summary>
        /// 在十进制的数组bytes中找到16进制字符串hexString的位置;
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="hexString">16进制的字符串</param>
        /// <returns></returns>
        int getIndexOfSubArray(byte[] bytes, string hexString)
        {
            var inBytes = Hex2Oec(hexString);
            return getIndexOfSubArray(bytes, inBytes);

        }

        /// <summary>
        /// 得到数组inBytes在数组bytes里出现的位置; inBytes是bytes的子串;
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="inBytes"></param>
        /// <returns></returns>
        int getIndexOfSubArray(byte[] bytes, byte[] inBytes)
        {

            int comparePos = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                if (comparePos > inBytes.Length - 1)
                {
                    int pos = i - inBytes.Length;
                    return pos;
                }
                if (inBytes[comparePos] == bytes[i])
                {
                    comparePos += 1;
                }
                else
                {
                    comparePos = 0;
                }
            }
            return -1;
        }

        /// <summary>
        /// 把一串16进制数每两个一组,转换成int的数组;
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        byte[] Hex2Oec(string hex)
        {
            if (hex.Length % 2 == 1)
            {
                throw new ArgumentException();
            }
            List<byte> lstByte = new List<byte>();
            for (int i = 0; i < hex.Length; i += 2)
            {
                var hs = hex.Substring(i, 2);
                byte b = (byte)Convert.ToInt16(hs, 16);
                lstByte.Add(b);
            }
            return lstByte.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bs"></param>
        /// <param name="start">开始位置,包含这个位置</param>
        /// <param name="end">不包含结束位置的字符;</param>
        /// <returns></returns>
        byte[] getBytes(byte[] bs, int start, int end)
        {
            byte[] newbs = new byte[end - start];
            int j = 0;
            for (int i = start; i < end; i++)
            {
                newbs[j] = bs[i];
                j++;
            }
            return newbs;
        }
        byte[] getBytes(int start, int end)
        {
            return getBytes(buffer, start, end);
        }

        #endregion

    }
    class zpkMediaFileInfo
    {
        public string Name { set; get; }
        public int StartPostion { set; get; }
        public int Size { set; get; }
    }
}
