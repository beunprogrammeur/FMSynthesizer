using FMSynthesizer.WPF.Midi.Events;
using System;

namespace FMSynthesizer.WPF.Midi
{
    interface IMidiSource
    {
        event EventHandler<MidiNoteEventArgs>? NoteOn;
        event EventHandler<MidiNoteEventArgs>? NoteOff;
    }
    internal class MidiSource : IMidiSource
    {
        public event EventHandler<MidiNoteEventArgs>? NoteOn;
        public event EventHandler<MidiNoteEventArgs>? NoteOff;

        public void RaiseNoteOn(int channel, int velocity, int pitch)
        {
            var frequency = PitchToFrequency(pitch);
            NoteOn?.Invoke(this, new MidiNoteEventArgs(channel, velocity, frequency, NoteSignal.On));
        }

        public void RaiseNoteOff(int channel, int velocity, int pitch)
        {
            var frequency = PitchToFrequency(pitch);
            NoteOff?.Invoke(this, new MidiNoteEventArgs(channel, velocity, frequency, NoteSignal.Off));
        }

        private float PitchToFrequency(int pitch)
        {
            return (float)(440.0f * Math.Pow(2.0f, (pitch - 69.0f) / 12.0f));
        }
    }
}
