using FMSynthesizer.Waveforms;
using FMSynthesizer.WPF.Nodes.ViewModels;

namespace FMSynthesizer.WPF.Nodes
{
    internal abstract class OscillatorNode : BaseNode
    {
        private IWaveformSource _oscillator;

        public OscillatorNode(IWaveformSource oscillator)
        {
            _oscillator = oscillator;

            AddInput<float, FloatValueEditorViewModel>("Frequency", frequency => _oscillator.Frequency = frequency);
            AddInput<float, FloatValueEditorViewModel>("Phase",     phase     => _oscillator.Phase = phase);
            AddOutput<ISampleSource>("Output", _oscillator);
        }
    }
}
