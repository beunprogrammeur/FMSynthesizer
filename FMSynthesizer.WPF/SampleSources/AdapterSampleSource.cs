namespace FMSynthesizer.WPF.SampleSources
{
    internal class AdapterSampleSource : ISampleSource
    {
        private ISampleSource _source;

        public void Assing(ISampleSource source)
        {
            _source = source;
        }


        public float NextSample(float dt)
        {
            return _source?.NextSample(dt) ?? 1.0f;
        }
    }
}
