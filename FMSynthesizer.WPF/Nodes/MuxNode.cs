using FMSynthesizer.WPF.SampleSources;
using NodeNetwork.Views;
using ReactiveUI;

namespace FMSynthesizer.WPF.Nodes
{
    internal class MuxNode : BaseNode, IRetentionSampleSource
    {
        IRetentionSampleSource _channelA;
        IRetentionSampleSource _channelB;

        static MuxNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<MuxNode>));
        }

        public MuxNode()
        {
            Name = "Mux";


            AddInput<IRetentionSampleSource>("Channel A", source => _channelA = source);
            AddInput<IRetentionSampleSource>("Channel B", source => _channelB = source);

            AddOutput<IRetentionSampleSource>("Output", this);
        }

        public float RetainedValue => (_channelA?.RetainedValue ?? 1.0f) * (_channelB?.RetainedValue ?? 1.0f);

        public float NextSample()
        {
            throw new System.NotImplementedException();
        }
    }
}
