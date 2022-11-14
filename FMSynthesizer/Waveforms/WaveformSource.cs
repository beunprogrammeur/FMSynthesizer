namespace FMSynthesizer.Waveforms
{
    internal abstract class WaveformSource : IWaveformSource
    {
        public float Phase     { get; set; }
        public float Frequency { get; set; }
        public float Amplitude { get; set; }
        
        protected float Time { get; set; }

        public WaveformSource()
        {
            Amplitude = 1.0f;
        }
        
        public float NextSample(float dt)
        {
            Time += dt;
            return GenerateWaveform(dt);
        }

        protected abstract float GenerateWaveform(float dt);
    }
}
