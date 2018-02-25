using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Un4seen.Bass;

namespace BaiCiZhan.Helper
{
    public class AudioHelper
    {
        public bool isPlaying { set; get; }
        bool isDeviceReady = false;

        static AudioHelper _instance;

        public static AudioHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AudioHelper();
            }
            return _instance;
        }

        protected AudioHelper()
        {
            // init BASS using the default output device
            isDeviceReady = Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
        }

        public void Close()
        {
            Bass.BASS_Free();
        }

        public void Play(string file, Action action = null)
        {
            if (string.IsNullOrEmpty(file))
            {
                return;
            }
            try
            {
                if (isDeviceReady)
                {
                    // create a stream channel from a file
                    int stream = Bass.BASS_StreamCreateFile(file, 0, 0, BASSFlag.BASS_STREAM_BLOCK);
                    if (stream != 0)
                    {
                        isPlaying = true;
                        // play the stream channel
                        Bass.BASS_ChannelPlay(stream, false);
                        //todo: 释放stream

                        SYNCPROC _mySync = new SYNCPROC((a, b, c, d) =>
                                               {
                                                   isPlaying = false;
                                                   if (action != null)
                                                   {
                                                       action();
                                                   }
                                               });

                        Bass.BASS_ChannelSetSync(stream, BASSSync.BASS_SYNC_END | BASSSync.BASS_SYNC_MIXTIME,
                         0, _mySync, IntPtr.Zero);
                    }
                    else
                    {
                        // error creating the stream
                        //Console.WriteLine("Stream error: {0}", Bass.BASS_ErrorGetCode());
                    }

                    // free the stream
                    //Bass.BASS_StreamFree(stream);
                    //// free BASS
                    //Bass.BASS_Free();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}
