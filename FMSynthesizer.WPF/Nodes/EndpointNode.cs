using FMSynthesizer.WPF.SampleSources;
using NodeNetwork.Views;
using ReactiveUI;

namespace FMSynthesizer.WPF.Nodes
{
    internal class EndpointNode : BaseNode
    {
        private AdapterSampleSource _input;
        public ISampleSource SampleSource => _input;
        static EndpointNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<EndpointNode>));
        }

        public EndpointNode()
        {
            Name = "Endpoint";
            _input = new AdapterSampleSource();
            AddInput<ISampleSource>("Input", input => _input.Assing(input));
        }
    }
}
