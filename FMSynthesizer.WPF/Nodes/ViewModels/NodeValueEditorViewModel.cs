using FMSynthesizer.WPF.Nodes.Views;
using FMSynthesizer.WPF.SampleSources;
using NodeNetwork.Toolkit.ValueNode;
using ReactiveUI;

namespace FMSynthesizer.WPF.Nodes.ViewModels
{
    public class NodeValueEditorViewModel : ValueEditorViewModel<INodeValue>
    {
        private string _text;
        public string Text 
        { 
            get => _text;
            set 
            { 
                _text = value;
                if (float.TryParse(value, out float result)) 
                { 
                    Value.Value = result; 
                } 
            }
        }

        static NodeValueEditorViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeEditorView(), typeof(IViewFor<NodeValueEditorViewModel>));
        }

        public NodeValueEditorViewModel()
        {
            Value = new NodeValue();
            Text = Value.Value.ToString();
        }
    }
}
