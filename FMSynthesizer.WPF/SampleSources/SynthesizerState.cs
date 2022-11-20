using FMSynthesizer.WPF.Midi.Events;
using System;

namespace FMSynthesizer.WPF.SampleSources
{
    /// <summary>
    /// Updater for all subscribed (retention) sample sources.
    /// </summary>
    interface ISampleUpdater
    {
        /// <summary>
        /// Updates all clients to their next sample.
        /// </summary>
        /// <param name="time">time in seconds</param>
        void Update();
    }

    interface ISampleUpdaterClient
    {
        event EventHandler SampleUpdateRequired;
    }

    public class SynthesizerState : ISampleSource, ISampleUpdater, ISampleUpdaterClient
    {
        public event EventHandler? SampleUpdateRequired;

        IRetentionSampleSource _source;

        public SynthesizerState(IRetentionSampleSource source)
        {
            _source = source;
        }

        public void Update()
        {
            SampleUpdateRequired?.Invoke(this, EventArgs.Empty);
        }

        public float NextSample()
        {
            Update();
            return _source.RetainedValue;
        }
    }
}
