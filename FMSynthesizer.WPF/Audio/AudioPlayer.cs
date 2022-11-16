using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioForge.Libs.NAudio.Wave;

namespace FMSynthesizer.WPF.Audio
{
    public class AudioPlayer : IDisposable
    {
        private WaveOut _waveOut;
        public AudioPlayer(ISampleSource source)
        {
            var waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(44100, 1);
            _waveOut = new WaveOut();


            _waveOut.Init(new UniversalWaveProvider(source));
        }

        public void Dispose()
        {
            _waveOut.Stop();
            _waveOut.Dispose();
        }

        public void Play()
        {
            _waveOut.Play();
        }

        public void Stop()
        {
            _waveOut.Stop();

        }
    }
}
