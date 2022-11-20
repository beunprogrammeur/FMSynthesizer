using FMSynthesizer.Waveforms;
using FMSynthesizer.WPF.Nodes.ViewModels;
using FMSynthesizer.WPF.SampleSources;
using System;

namespace FMSynthesizer.WPF.Nodes
{
    internal abstract class OscillatorNode<T> : BaseNode, IRetentionSampleSource where T : IOscillator
    {
        private T _oscillator;
        private ISampleUpdaterClient _updater;
        
        protected T Oscillator => _oscillator;

        /// <summary>
        /// Used by the node that is connected to the output
        /// </summary>
        public float RetainedValue { get; private set; }

        public OscillatorNode(T oscillator, ISampleUpdaterClient updater)
        {
            _oscillator = oscillator;
            
            _updater = updater;
            _updater.SampleUpdateRequired += OnUpdateRequired;

            AddNodeValueInput("Frequency", frequency => _oscillator.Frequency = frequency);
            AddNodeValueInput("Phase",     phase     => _oscillator.Phase     = phase);

            AddOutput<IRetentionSampleSource>("Output", this);
        }

        public override void Dispose()
        {
            base.Dispose();
            _updater.SampleUpdateRequired -= OnUpdateRequired;
        }

        private void OnUpdateRequired(object? sender, EventArgs e)
        {
            RetainedValue = _oscillator.NextSample();
        }

        public float NextSample() => throw new NotImplementedException();
    }
}
