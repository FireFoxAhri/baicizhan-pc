using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAudio.Wave;
namespace BaiCiZhan.Helper
{
    public class AudioPlayer : IAudioPlayer
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
        private Action<AudioFileReader> _playTimeChanged;

        public event Action<AudioFileReader> PlayTimeChanged
        {
            add
            {
                if (_playTimeChanged == null)
                {
                    timer = new System.Timers.Timer();
                    timer.Interval = 500;
                    timer.Elapsed += timer_Elapsed;
                    timer.Start();
                }
                _playTimeChanged += value;
            }
            remove
            {
                _playTimeChanged -= value;
                if (_playTimeChanged == null)
                {
                    timer.Stop();
                    timer.Dispose();
                }
            }
        }
        //是否在播放中被强制停止; 被强制停止的播放结束后的事件不触发;
        bool isForseStop = false;
        System.Timers.Timer timer;

        //单实例用不成, 因为PlayTimeChanged的问题, 一个位置注册, 各个位置都会被触发;
        #region 单实例

        //static AudioPlayer2 _instance;
        //public static AudioPlayer2 GetInstance()
        //{
        //    if (_instance == null)
        //    {
        //        _instance = new AudioPlayer2();
        //    }
        //    return _instance;
        //}
        #endregion

        public AudioPlayer()
        {
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (IsPlaying && audioFile != null && outputDevice.PlaybackState == PlaybackState.Playing)
            {
                if (_playTimeChanged != null)
                {
                    _playTimeChanged(audioFile);
                }
            }
        }
        public void Close()
        {
            //todo: 出问题了
            if (this.IsPlaying)
            {
                this.isForseStop = true;
            }
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

            //把正在播放的声音关闭;
            this.Close();
            this.IsPlaying = true;

            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += (a, b) =>
                {
                    //todo: 直接跳过也不是很合理;
                    //解决播放A时播放B无法播放; 因为停止A时会再调用这个方法里的close();
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
