using FMSynthesizer.Envelopes;
using NodeNetwork.Views;
using ReactiveUI;

namespace FMSynthesizer.WPF.Nodes
{
    internal class ADSREnvelopeNode : BaseNode
    {
        private ADSREnvelope _envelope;
        private ISampleSource _input;
        static ADSREnvelopeNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<ADSREnvelopeNode>));
        }
        public ADSREnvelopeNode()
        {
            Name = "ADSR Envelope";

            _envelope = new ADSREnvelope();

            AddInput<float>("Attack",  attack  => _envelope.Attack  = attack);
            AddInput<float>("Decay",   decay   => _envelope.Decay   = decay);
            AddInput<float>("Sustain", sustain => _envelope.Sustain = sustain);
            AddInput<float>("Release", release => _envelope.Release = release);
            AddInput<ISampleSource>("Input", input => _input = input);
            AddOutput<ISampleSource>("Amplitude", _envelope);
        }
    }
}
