using FMSynthesizer.Envelopes;
using FMSynthesizer.WPF.Nodes.ViewModels;
using FMSynthesizer.WPF.SampleSources;
using NodeNetwork.Views;
using ReactiveUI;

namespace FMSynthesizer.WPF.Nodes
{
    internal class ADSREnvelopeNode : BaseNode, IRetentionSampleSource
    {
        private ADSREnvelope _envelope;

        private IRetentionSampleSource _input;
        static ADSREnvelopeNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<ADSREnvelopeNode>));
        }
        public ADSREnvelopeNode(ITime time)
        {
            Name = "ADSR Envelope";

            _envelope = new ADSREnvelope(time);

            AddNodeValueInput("Attack",  attack  => _envelope.Attack  = attack);
            AddNodeValueInput("Decay",   decay   => _envelope.Decay   = decay);
            AddNodeValueInput("Sustain", sustain => _envelope.Sustain = sustain);
            AddNodeValueInput("Release", release => _envelope.Release = release);
            AddInput<IRetentionSampleSource>("Input", input => _input = input);

            AddOutput<IRetentionSampleSource>("Output", this);
        }

        public float RetainedValue => _input.RetainedValue;

        public float NextSample()
        {
            throw new System.NotImplementedException();
        }
    }
}
