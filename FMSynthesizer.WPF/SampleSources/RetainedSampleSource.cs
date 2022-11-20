namespace FMSynthesizer.WPF.SampleSources
{
    public interface IRetentionSampleSource : ISampleSource
    {
        float RetainedValue { get; }
    }
}
