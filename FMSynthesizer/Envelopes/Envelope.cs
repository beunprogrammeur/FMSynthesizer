namespace FMSynthesizer.Envelopes
{
    public abstract class Envelope : IEnvelope
    {
        protected float Time { get; private set; }

        public float NextSample(float dt)
        {
            Time += dt;
            return CalculateAmplitude();
        }

        protected abstract float CalculateAmplitude();
    }
}
