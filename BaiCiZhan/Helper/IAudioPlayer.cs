﻿using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiCiZhan.Helper
{
    interface IAudioPlayer
    {
        bool IsPlaying { get; }
        void Close();
        void Play(string file, Action action = null, int percent = 0);

        event Action<AudioFileReader> PlayTimeChanged;
    }
}