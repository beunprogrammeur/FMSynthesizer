using FMSynthesizer.WPF.Midi.Events;
using System;

namespace FMSynthesizer.WPF.SampleSources
{
    internal class NodeValueBinding
    {
        private Action<float> _setter;
        private INodeValue? _nodeValue;

        public INodeValue? NodeValue { get => _nodeValue; set => UpdateNodeValue(value); }
        public INodeValue? Default { get; set; }
        public NodeValueBinding(Action<float> setter)
        {
            _setter = setter;
        }

        private void UpdateNodeValue(INodeValue? value)
        {
            if(_nodeValue == null)
            {
                _nodeValue = value ?? Default;
                if(_nodeValue != null) _nodeValue.ValueChanged += NodeValueValueChanged;
            }
            else
            {
                _nodeValue.ValueChanged -= NodeValueValueChanged;
                _nodeValue = value ?? Default;

                if (_nodeValue != null)
                {
                    _nodeValue.ValueChanged += NodeValueValueChanged;
                    _setter?.Invoke(_nodeValue.Value);
                }
            }

        }

        private void NodeValueValueChanged(object? sender, ValueEventArgs<float> e)
        {
            _setter?.Invoke(e.Value);
        }
    }
}
