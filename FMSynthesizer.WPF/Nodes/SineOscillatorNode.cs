using FMSynthesizer.Waveforms;
using NodeNetwork.Views;
using ReactiveUI;

namespace FMSynthesizer.WPF.Nodes
{
    internal class SineOscillatorNode : OscillatorNode
    {
        static SineOscillatorNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<SineOscillatorNode>));
        }

        public SineOscillatorNode() : base(new SineWaveformSource())
        {
            Name = "Sine Oscillator";
        }
    }
}
