using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAudio.Wave;
namespace BaiCiZhan.Helper
{
    public class AudioPlayer2 : IAudioPlayer
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        private bool _isPlaying;
        public bool IsPlaying
        {
            get
            {
                return _isPlaying;
            }
            private set
            {
                _isPlaying = value;
            }
        }

        public event Action<AudioFileReader> PlayTimeChanged;
        bool isForseStop = false;
        static AudioPlayer2 _instance;
        System.Timers.Timer timer;

        public static AudioPlayer2 GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AudioPlayer2();
            }
            return _instance;
        }

        protected AudioPlayer2()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 500;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (IsPlaying && audioFile != null && outputDevice.PlaybackState == PlaybackState.Playing)
            {
                if (PlayTimeChanged != null)
                {
                    PlayTimeChanged(audioFile);
                }
            }
        }
        public void Close()
        {
            this.IsPlaying = false;
            if (outputDevice != null)
            {
                outputDevice.Dispose();
            }
            outputDevice = null;

            if (audioFile != null)
            {
                audioFile.Dispose();
            }
            audioFile = null;
        }

        public void Play(string file, Action action = null, int percent = 0)
        {
            if (string.IsNullOrEmpty(file))
            {
                throw new ArgumentNullException("文件路径");
            }
            if (!System.IO.File.Exists(file))
            {
                throw new ArgumentException("文件不存在: " + file);
            }
            if (this.IsPlaying)
            {
                this.isForseStop = true;
                this.Close();
            }
            this.IsPlaying = true;

            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += (a, b) =>
                {
                    if (isForseStop)
                    {
                        this.isForseStop = false;
                        return;
                    }
                    this.Close();
                    if (action != null)
                    {
                        action();
                    }
                };
            }

            if (audioFile == null)
            {
                audioFile = new AudioFileReader(file);
                //audioFile.Position = (long)(audioFile.Length * percent / 100);
                audioFile.CurrentTime = TimeSpan.FromSeconds(audioFile.TotalTime.TotalSeconds * percent / 100);

                outputDevice.Init(audioFile);
            }
            outputDevice.Play();
        }

    }
}
