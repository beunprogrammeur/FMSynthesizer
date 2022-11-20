using DynamicData;
using FMSynthesizer.WPF.Midi.Events;
using FMSynthesizer.WPF.Nodes.ViewModels;
using FMSynthesizer.WPF.SampleSources;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using System;
using System.Reactive.Linq;
using System.Windows.Input;

namespace FMSynthesizer.WPF.Nodes
{
    internal abstract class BaseNode : NodeViewModel, IDisposable
    {
        protected BaseNode(string name = "unknown")
        {
            Name = name;
        }

        public virtual void Dispose() { }

        

        protected ValueNodeInputViewModel<INodeValue> AddNodeValueInput(string name, Action<float> predicate)
        {
            var binding = new NodeValueBinding(predicate);
            var input = AddInput<INodeValue, NodeValueEditorViewModel>(name, value => binding.NodeValue = value);
            binding.Default = ((NodeValueEditorViewModel)input.Editor).Value;
            binding.NodeValue = binding.Default;

            return input;
        }

        protected ValueNodeInputViewModel<T> AddInput<T, U>(string name, Action<T> predicate) where U : ValueEditorViewModel<T>, new()
        {
            var input = AddInput(name, predicate);
            input.Editor = new U();
            return input;
        }

        protected ValueNodeInputViewModel<T> AddInput<T>(string name, Action<T> predicate, EndpointVisibility visibility = EndpointVisibility.AlwaysVisible)
        {
            var input = new ValueNodeInputViewModel<T>() { Name = name, Visibility = visibility };
            input.ValueChanged.Subscribe(predicate);
            Inputs.Add(input);
            return input;
        }

        protected void AddOutput<T>(string name, T value)
        {
            var output = new ValueNodeOutputViewModel<T>
            {
                Name = name,
                Value = Observable.Return(value)
            };

            Outputs.Add(output);
        }

        protected void EventBind(INodeValue value, ref INodeValue oldValue, EventHandler<ValueEventArgs<float>> callback)
        {
            if (oldValue != null) oldValue.ValueChanged -= callback;
            oldValue = value;
            if (value != null) value.ValueChanged += callback;
        }
    }
}
