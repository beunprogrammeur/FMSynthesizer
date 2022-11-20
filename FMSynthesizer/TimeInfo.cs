namespace FMSynthesizer
{
    public interface ITime
    {
        public float SampleRate { get; }
        public float SampleTime { get; }
        public float Time { get; }
    }

    public class TimeInfo : ITime
    {
        /// <summary>
        /// The duration of a single sample
        /// </summary>
        public float SampleTime => 1.0f / SampleRate;
        /// <summary>
        /// The amount of samples per second
        /// </summary>
        public float SampleRate { get; set; }
        /// <summary>
        /// The current time (aka timestamp of sample) in seconds
        /// </summary>
        public float Time { get; set; }
    }
}
