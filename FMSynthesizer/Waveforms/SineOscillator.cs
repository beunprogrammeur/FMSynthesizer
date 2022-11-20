namespace FMSynthesizer.Waveforms
{
    public class SineOscillator : Oscillator
    {
        public SineOscillator(ITime time) : base(time)
        {
        }

        public override float NextSample()
        {
            return Amplitude * (float)Math.Sin(Math.Tau * Frequency * (Time.Time + (Phase * (1.0f / Frequency))));
        }
    }
}
