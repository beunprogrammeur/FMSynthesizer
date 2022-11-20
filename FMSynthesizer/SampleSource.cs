namespace FMSynthesizer
{
    public abstract class SampleSource : ISampleSource
    {
        protected ITime Time { get; }

        protected SampleSource(ITime time)
        {
            Time = time;
        }

        public abstract float NextSample();
    }
}
