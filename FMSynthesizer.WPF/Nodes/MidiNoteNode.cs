using FMSynthesizer.WPF.Midi;
using FMSynthesizer.WPF.SampleSources;
using NodeNetwork.Views;
using ReactiveUI;
using System;

namespace FMSynthesizer.WPF.Nodes
{
    internal class MidiNoteNode : BaseNode, IDisposable
    {
        private IMidiSource _midiSource;
        private INodeValue _frequency;
        private INodeValue _amplitude;
        private INodeValue _channel;

        private float Channel 
        { 
            get => _channel.Value;
            set
            {
                int channel = (int)value;
                if (channel < 1 || channel > 16) return;
                _channel.Value = channel;
            }
        }
        
        static MidiNoteNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<MidiNoteNode>));
        }

        public MidiNoteNode(IMidiSource midiSource)
        {
            Name = "Midi note";
            _midiSource = midiSource;

            _frequency = new NodeValue();
            _amplitude = new NodeValue();
            _channel   = new NodeValue();

            AddOutput("Frequency", _frequency);
            AddOutput("Amplitude", _amplitude);
            AddNodeValueInput("Channel", channel => _channel.Value = channel);
            Channel = 1;

            _midiSource.NoteOn += OnNoteChanged;
            _midiSource.NoteOff += OnNoteChanged;
        }

        public void Dispose()
        {
            _midiSource.NoteOn -= OnNoteChanged;
            _midiSource.NoteOff -= OnNoteChanged;
        }

        private void OnNoteChanged(object? sender, Midi.Events.MidiNoteEventArgs e)
        {
            if (e.Channel != (int)Channel) return;

            _amplitude.Value = (1.0f / 128.0f * e.Velocity);
            _frequency.Value = e.Frequency;
        }
    }
}
