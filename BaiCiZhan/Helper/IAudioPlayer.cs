using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiCiZhan.Helper
{
    interface IAudioPlayer
    {
        int PlayState { get; }
        void Close();
        void Play(string file, Action action = null, int percent = 0);
        void Pause();
        event Action<AudioFileReader> PlayTimeChanged;
    }
}
