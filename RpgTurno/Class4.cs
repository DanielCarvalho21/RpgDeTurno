using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace RpgTurno
{
    internal class BackgroundMusicPlayer
    {
        private IWavePlayer waveOutDevice;
        private AudioFileReader audioFile;

        public void PlayBackgroundMusic(string filePath)
        {
            waveOutDevice = new WaveOutEvent();
            audioFile = new AudioFileReader(filePath);

            waveOutDevice.Init(audioFile);
            waveOutDevice.Play();
        }

        public void StopBackgroundMusic()
        {
            waveOutDevice.Stop();
            waveOutDevice.Dispose();
            audioFile.Dispose();
        }
    }
}
