using FMSynthesizer.Waveforms;
using FMSynthesizer.WPF.SampleSources;
using NodeNetwork.Views;
using ReactiveUI;

namespace FMSynthesizer.WPF.Nodes
{
    internal class PWMOscillatorNode : OscillatorNode<PWMOscillator>
    {
        static PWMOscillatorNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<PWMOscillatorNode>));
        }

        public PWMOscillatorNode(ITime time, ISampleUpdaterClient updater) : base(new PWMOscillator(time), updater)
        {
            Name = "PWM Oscillator";

            AddNodeValueInput("Duty cycle", duty => Oscillator.DutyCycle = duty);
        }
    }
}
