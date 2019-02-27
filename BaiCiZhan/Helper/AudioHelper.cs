using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NAudio.MediaFoundation;

namespace BaiCiZhan.Helper
{
    public class AudioHelper
    {
        public String TempDir { set; get; }

        public AudioHelper()
        {
            TempDir = @"C:\Users\qxxx\AppData\Local\Temp";
        }
        public void MergeWavs(IEnumerable<string> sourceFiles,string outputFile)
        {
            byte[] buffer = new byte[1024];
            WaveFileWriter waveFileWriter = null;

            try
            {
                foreach (string sourceFile in sourceFiles)
                {
                    using (WaveFileReader reader = new WaveFileReader(sourceFile))
                    {
                        if (waveFileWriter == null)
                        {
                            // first time in create new Writer
                            waveFileWriter = new WaveFileWriter(outputFile, reader.WaveFormat);
                        }
                        else
                        {
                            if (!reader.WaveFormat.Equals(waveFileWriter.WaveFormat))
                            {
                                throw new InvalidOperationException("Can't concatenate WAV Files that don't share the same format");
                            }
                        }

                        int read;
                        while ((read = reader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            waveFileWriter.WriteData(buffer, 0, read);
                        }
                    }
                }
            }
            finally
            {
                if (waveFileWriter != null)
                {
                    waveFileWriter.Dispose();
                }
            }

        }

        WaveFormat newFormat = new WaveFormat(8000, 16, 2);

        public String Mp3ToWav(String infile, String outFile = "")
        {
            if (String.IsNullOrEmpty(outFile))
            {
                Guid guid = Guid.NewGuid();
                outFile = Path.Combine(TempDir, guid.ToString() + ".wav");
            }
           

            using (var reader = new Mp3FileReader(infile))
            using (var conversionStream = new WaveFormatConversionStream(newFormat, reader))

            {
                WaveFileWriter.CreateWaveFile(outFile, conversionStream);
            }
            return outFile;
        }

        public String AacToWav(String infile, String outFile = "")
        {
            MediaFoundationApi.Startup();
            if (String.IsNullOrEmpty(outFile))
            {
                Guid guid = Guid.NewGuid();
                outFile = Path.Combine(TempDir, guid.ToString() + ".wav");
            }
            using (var reader = new MediaFoundationReader(infile))
            using (var conversionStream = new WaveFormatConversionStream(newFormat, reader))
            {
                //MediaFoundationEncoder.EncodeToWma(reader, outFile);
                WaveFileWriter.CreateWaveFile(outFile, conversionStream);
            }

            return outFile;
        }


    }
}
