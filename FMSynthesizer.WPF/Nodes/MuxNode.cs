using FMSynthesizer.WPF.SampleSources;
using NodeNetwork.Views;
using ReactiveUI;

namespace FMSynthesizer.WPF.Nodes
{
    internal class MuxNode : BaseNode
    {
        private MuxSampleSource _source;
        static MuxNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<MuxNode>));
        }

        public MuxNode()
        {
            Name = "Mux";
            _source = new MuxSampleSource();
            AddInput<ISampleSource>("Channel A", source => _source.ChannelA = source);
            AddInput<ISampleSource>("Channel B", source => _source.ChannelB = source);

            AddOutput<ISampleSource>("Output", _source);
        }
    }
}
