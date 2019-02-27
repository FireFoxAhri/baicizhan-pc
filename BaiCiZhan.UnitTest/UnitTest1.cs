using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaiCiZhan.Helper;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.IO;
using NAudio.MediaFoundation;

namespace BaiCiZhan.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetWord()
        {
            //string word = "abandon";
            //var a = WordHelper.GetInstance().GetWord(word);
            //Assert.IsTrue(word == a.word);
        }

        [TestMethod]
        public void TestIHistoryHelper()
        {
            //IHistoryHelper hisHelper = new HistoryHelper();
            //hisHelper.Add("test");
            //var a = hisHelper.GetAll();
        }
        [TestMethod]
        public void TestCreateFile()
        {
            //mixing 同时播放了;
            using (var reader1 = new AudioFileReader(@"D:\desktop\wav\1.mp3"))
            using (var reader2 = new AudioFileReader(@"D:\desktop\wav\2.mp3"))
            {
                var mixer = new MixingSampleProvider(new[] { reader1, reader2 });
                WaveFileWriter.CreateWaveFile16(@"D:\desktop\wav\12.mp3", mixer);
            }
        }

        [TestMethod]
        public void TestCombineFile()
        {
            FileStream fileStream = new FileStream(@"D:\desktop\wav\12.mp3", FileMode.OpenOrCreate);
            var files = new String[] { @"D:\desktop\wav\1.mp3",
                @"D:\desktop\wav\2.mp3",
                 @"D:\desktop\wav\2.aac"};
            Combine(files, fileStream);
        }


        [TestMethod]
        public void testConvert()
        {
            MediaFoundationApi.Startup();
            String aacfile = @"D:\desktop\wav\2.aac";
            String mp3file = @"D:\desktop\wav\1.mp3";
            var wmafile = @"D:\desktop\wav\123.wma";
            using (var reader = new MediaFoundationReader(aacfile))
            {
                MediaFoundationEncoder.EncodeToWma(reader, wmafile);
            }
        }
        [TestMethod]
        public void testConvert1()
        {
            //qxx cant convert MP3 file by this way       
            MediaFoundationApi.Startup();
            String aacfile = @"D:\desktop\wav\2.aac";
            String mp3file = @"D:\desktop\wav\1.mp3";
            String outfile = @"D:\desktop\wav\123.aac";
            using (var reader = new MediaFoundationReader(mp3file))
            {
                MediaFoundationEncoder.EncodeToMp3(reader, outfile);
            }
        }

        [TestMethod]
        public void testConvertMp3()
        {
            var infile = @"D:\desktop\wav\1.mp3";
            var outfile = @"D:\desktop\wav\14.wav";
            using (var reader = new Mp3FileReader(infile))
            {
                WaveFileWriter.CreateWaveFile(outfile, reader);
            }
        }


        public static void Combine(string[] inputFiles, Stream output)
        {
            foreach (string file in inputFiles)
            {
                Mp3FileReader reader = new Mp3FileReader(file);
                if ((output.Position == 0) && (reader.Id3v2Tag != null))
                {
                    output.Write(reader.Id3v2Tag.RawData, 0, reader.Id3v2Tag.RawData.Length);
                }

                Mp3Frame frame;
                while ((frame = reader.ReadNextFrame()) != null)
                {
                    output.Write(frame.RawData, 0, frame.RawData.Length);
                }
            }
        }

        [TestMethod]
        public void testMerge()
        {
            AudioHelper audiohelper = new AudioHelper();
            audiohelper.TempDir = @"D:\desktop\wav\output";
            //Directory.Delete(audiohelper.TempDir,true);
            Directory.CreateDirectory(audiohelper.TempDir);

            var file1 = audiohelper.Mp3ToWav(@"D:\desktop\wav\1.mp3");
            var file2 = audiohelper.AacToWav(@"D:\desktop\wav\2.aac");
            var files = new String[] { file1, file2 };
            audiohelper.MergeWavs(files, @"D:\desktop\wav\output\1.wav");


        }
    }
}
