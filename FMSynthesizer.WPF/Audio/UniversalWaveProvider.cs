using VisioForge.Libs.NAudio.Wave;

namespace FMSynthesizer.WPF.Audio
{
    internal class UniversalWaveProvider : IWaveProvider
    {
        private ISampleSource _source;

        public WaveFormat WaveFormat { get; private set; }

        public UniversalWaveProvider(ISampleSource source) : this(source, 44100)
        {
        }

        public UniversalWaveProvider(ISampleSource source, int sampleRate)
        {
            WaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, 1);
            _source = source;

        }

        public int Read(byte[] buffer, int offset, int count)
        {
            var waveBuffer = new WaveBuffer(buffer);
            int samplesRequired = count / sizeof(float);

            float dt = 1.0f / WaveFormat.SampleRate;

            for (int i = 0; i < samplesRequired; i++)
            {
                waveBuffer.FloatBuffer[i] = _source.NextSample(dt);
            }

            return samplesRequired * sizeof(float);
        }
    }
}
