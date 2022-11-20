using FMSynthesizer.WPF.SampleSources;
using System;
using VisioForge.Libs.NAudio.Wave;

namespace FMSynthesizer.WPF.Audio
{
    public class AudioPlayer : IDisposable
    {
        private WaveOut _waveOut;
        private UniversalWaveProvider _waveProvider;
        public ITime Time => _waveProvider.Time;
        public AudioPlayer(SynthesizerState state)
        {
            var waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(44100, 1);
            _waveOut = new WaveOut();

            _waveProvider = new UniversalWaveProvider(state);
            _waveOut.Init(_waveProvider);
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
