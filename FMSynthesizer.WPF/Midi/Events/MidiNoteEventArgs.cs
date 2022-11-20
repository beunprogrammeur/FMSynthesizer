using System;

namespace FMSynthesizer.WPF.Midi.Events
{
    enum NoteSignal
    {
        Off,
        On,
    }

    internal class MidiNoteEventArgs : EventArgs
    {
        public int Channel { get; set; }
        public int Velocity { get; set; }
        public float Frequency { get; set; }
        NoteSignal Signal { get; set; }

        public MidiNoteEventArgs(int channel, int velocity, float frequency, NoteSignal signal)
        {
            Channel = channel;
            Velocity = velocity;
            Frequency = frequency;
            Signal = signal;
        }
    }
}
