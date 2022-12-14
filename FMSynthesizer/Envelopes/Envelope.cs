namespace FMSynthesizer.Envelopes
{
    public abstract class Envelope : IEnvelope
    {
        protected ITime Time { get; }

        protected Envelope(ITime time)
        {
            Time = time;
        }

        public abstract float NextSample();
    }
}
