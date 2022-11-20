using FMSynthesizer.WPF.SampleSources;
using NodeNetwork.Views;
using ReactiveUI;
using System;

namespace FMSynthesizer.WPF.Nodes
{
    internal class EndpointNode : BaseNode, IRetentionSampleSource
    {
        IRetentionSampleSource? _source;
        public float RetainedValue => _source?.RetainedValue ?? 0.0f;

        static EndpointNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<EndpointNode>));
        }

        public EndpointNode()
        {
            Name = "Endpoint";
            AddInput<IRetentionSampleSource>("Input", input => _source = input);
        }

        public float NextSample() => throw new NotImplementedException();
    }
}
