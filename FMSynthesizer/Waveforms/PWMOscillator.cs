namespace FMSynthesizer.Waveforms
{
    public class PWMOscillator : Oscillator
    {
        private float _dutyCycle;
        public float DutyCycle { get => _dutyCycle; set => _dutyCycle = Math.Clamp(value, 0.0f, 1.0f); }
        public PWMOscillator(ITime time) : base(time)
        {
        }

        public override float NextSample()
        {
            float waveTime = 1.0f / Frequency;
            float waves = Time.Time / waveTime;
            float rest = waves - (float)Math.Floor(waves);
            return Amplitude * (rest <= DutyCycle ? 1.0f : -1.0f);
        }
    }
}
