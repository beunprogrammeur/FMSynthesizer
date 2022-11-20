using FMSynthesizer.WPF.SampleSources;
using NodeNetwork.Views;
using ReactiveUI;

namespace FMSynthesizer.WPF.Nodes
{
    internal class ConstantNode : BaseNode
    {
        INodeValue _nodeValue;
        static ConstantNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<ConstantNode>));
        }

        public ConstantNode()
        {
            Name = "Constant";

            _nodeValue = new NodeValue();
            var input = AddNodeValueInput("Value", value => _nodeValue.Value = value);
            AddOutput("Output", _nodeValue);

            input.Port.IsVisible = false;
        }
    }
}
