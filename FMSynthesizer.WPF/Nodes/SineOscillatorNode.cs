using FMSynthesizer.Waveforms;
using FMSynthesizer.WPF.SampleSources;
using NodeNetwork.Views;
using ReactiveUI;

namespace FMSynthesizer.WPF.Nodes
{
    internal class SineOscillatorNode : OscillatorNode<SineOscillator>
    {
        static SineOscillatorNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<SineOscillatorNode>));
        }

        public SineOscillatorNode(ITime time, ISampleUpdaterClient updater) : base(new SineOscillator(time), updater)
        {
            Name = "Sine Oscillator";
        }
    }
}
