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

        bool isForseStop = false;
        static AudioPlayer2 _instance;

        public static AudioPlayer2 GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AudioPlayer2();
            }
            return _instance;
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

        public void Play(string file, Action action = null)
        {
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
                outputDevice.Init(audioFile);
            }
            outputDevice.Play();
        }

    }
}
