using FMSynthesizer.Waveforms;

namespace FMSynthesizer.WPF.Nodes
{
    internal abstract class OscillatorNode : BaseNode
    {
        private IWaveformSource _oscillator;

        public OscillatorNode(IWaveformSource oscillator)
        {
            _oscillator = oscillator;

            AddInput<float>("Frequency", frequency => _oscillator.Frequency = frequency);
            AddInput<float>("Phase",     phase     => _oscillator.Phase = phase);
            AddOutput<ISampleSource>("Waveform", _oscillator);
        }
    }
}
