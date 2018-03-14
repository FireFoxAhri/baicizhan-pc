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

        #region 字段/属性

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
        Action action = null;
        System.Timers.Timer timer;

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
                if (_playTimeChanged == null && timer != null)
                {
                    timer.Stop();
                    timer.Dispose();
                }
            }
        }


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
        #endregion

        public AudioPlayer()
        {
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
                if (action != null)
                {
                    this.action = action;
                    outputDevice.PlaybackStopped += outputDevice_PlaybackStopped;
                }
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

        public void Close()
        {
            this.IsPlaying = false;
            if (outputDevice != null)
            {
                //要把事件清除掉, 不然dispose后会调用
                //todo: 直接清除可能也不是很合理;
                this.outputDevice.PlaybackStopped -= outputDevice_PlaybackStopped;
                this.outputDevice.Dispose();
            }
            this.outputDevice = null;

            if (this.audioFile != null)
            {
                this.audioFile.Dispose();
            }
            this.audioFile = null;
        }

        void outputDevice_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            this.Close();
            if (action != null)
            {
                action();
            }
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
    }
}
