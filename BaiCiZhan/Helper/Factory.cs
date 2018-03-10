using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BaiCiZhan.Helper;
namespace BaiCiZhan
{
    class Factory
    {

        public static IAudioPlayer GetAudioPlayer()
        {
            return AudioPlayer2.GetInstance();
        }
    }
}
