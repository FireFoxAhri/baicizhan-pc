using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BaiCiZhan.Helper;
namespace BaiCiZhan
{
    class AudioPlayerFactory
    {
        static List<IAudioPlayer> audioPlayerList = new List<IAudioPlayer>();
        public static IAudioPlayer GetNewAudioPlayer()
        {
            var a = new AudioPlayer();
            audioPlayerList.Add(a);
            return a;
        }

        public static void CloseAllAudioPlayer()
        {
            foreach (var item in audioPlayerList)
            {
                item.Close();
            }
        }
    }
}
