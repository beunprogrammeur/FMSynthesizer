using FMSynthesizer.WPF.SampleSources;
using VisioForge.Libs.NAudio.Wave;

namespace FMSynthesizer.WPF.Audio
{
    internal class UniversalWaveProvider : IWaveProvider
    {
        private SynthesizerState _state;
        private TimeInfo _time;
        public WaveFormat WaveFormat { get; private set; }
        public ITime Time => _time;
        public UniversalWaveProvider(SynthesizerState state) : this(state, 44100)
        {
        }

        public UniversalWaveProvider(SynthesizerState state, int sampleRate)
        {
            WaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, 1);
            _state = state;
            _time = new TimeInfo() { SampleRate = sampleRate };
        }

        public int Read(byte[] buffer, int offset, int count)
        {
            var waveBuffer = new WaveBuffer(buffer);
            int samplesRequired = count / sizeof(float);

            float dt = 1.0f / WaveFormat.SampleRate;

            for (int i = 0; i < samplesRequired; i++)
            {
                _time.Time += dt;

                // TODO: update all nodes.

                waveBuffer.FloatBuffer[i] = _state.NextSample();
            }

            return samplesRequired * sizeof(float);
        }
    }
}
