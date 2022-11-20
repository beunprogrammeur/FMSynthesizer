namespace FMSynthesizer.Waveforms
{
    public abstract class Oscillator : SampleSource, IOscillator
    {
        public float Phase     { get; set; }
        public float Frequency { get; set; }
        public float Amplitude { get; set; }
        
        public Oscillator(ITime time) : base(time)
        {
            Amplitude = 1.0f;
        }
    }
}
