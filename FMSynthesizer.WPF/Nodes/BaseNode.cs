using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using System;
using System.Reactive.Linq;

namespace FMSynthesizer.WPF.Nodes
{
    internal abstract class BaseNode : NodeViewModel
    {
        

        protected ValueNodeInputViewModel<T> AddInput<T, U>(string name, Action<T> predicate) where U : ValueEditorViewModel<T>, new()
        {
            var input = AddInput(name, predicate);
            input.Editor = new U();
            return input;
        }

        protected ValueNodeInputViewModel<T> AddInput<T>(string name, Action<T> predicate)
        {
            var input = new ValueNodeInputViewModel<T>() { Name = name };
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
    }
}
