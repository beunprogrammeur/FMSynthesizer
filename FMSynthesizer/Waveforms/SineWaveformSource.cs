namespace FMSynthesizer.Waveforms
{
    internal class SineWaveformSource : WaveformSource
    {
        protected override float GenerateWaveform(float dt)
        {
            float sample_rate = 1.0f / dt;
            return Amplitude * (float)Math.Sin(Math.Tau * Frequency * (Time + Phase));
        }
    }
}
