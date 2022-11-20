using FMSynthesizer.WPF.Midi.Events;
using System;

namespace FMSynthesizer.WPF.SampleSources
{
    public interface INodeValue
    {
        float Value { get; set; }
        event EventHandler<ValueEventArgs<float>>? ValueChanged;
    }

    public class NodeValue : INodeValue
    {
        private float _value;
        public float Value 
        { 
            get => _value;  
            set 
            {
                if(_value != value)
                {
                    _value = value;
                    ValueChanged?.Invoke(this, new ValueEventArgs<float>(Value));
                }
            }
        
        }

        public event EventHandler<ValueEventArgs<float>>? ValueChanged;
    }
}
