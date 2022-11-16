namespace FMSynthesizer.WPF.SampleSources
{
    internal class MuxSampleSource : ISampleSource
    {
        public ISampleSource ChannelA { get; set; }
        public ISampleSource ChannelB { get; set; }

        public float NextSample(float dt)
        {
            return (ChannelA?.NextSample(dt) ?? 1.0f) * (ChannelB?.NextSample(dt) ?? 1.0f);
        }
    }
}
