using System;

namespace FMSynthesizer.WPF.Midi.Events
{
    public class ValueEventArgs<T> : EventArgs
    {
        public T Value { get; set; }

        public ValueEventArgs(T value)
        {
            Value = value;
        }
    }
}
