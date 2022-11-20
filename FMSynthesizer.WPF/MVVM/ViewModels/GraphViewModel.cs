using DynamicData;
using FMSynthesizer.WPF.MVVM.Models;
using FMSynthesizer.WPF.Nodes;
using FMSynthesizer.WPF.Shared.ViewModels;
using NodeNetwork.Toolkit.NodeList;
using NodeNetwork.ViewModels;
using NAudio.Midi;
using FMSynthesizer.WPF.Midi;
using FMSynthesizer.WPF.SampleSources;

namespace FMSynthesizer.WPF.MVVM.ViewModels
{
    internal class GraphViewModel : BaseViewModel
    {
        private SoundModel _soundModel;
        private MidiSource _midiSource;
        public NetworkViewModel NetworkViewModel { get; }
        public NodeListViewModel NodeListViewModel { get; }
        public GraphViewModel()
        {
            int samplerate = 44100;

            NetworkViewModel = new NetworkViewModel();
            NodeListViewModel = new NodeListViewModel() { Title = string.Empty };

            var endpoint = new EndpointNode { CanBeRemovedByUser = false, IsCollapsed = false, Resizable = ResizeOrientation.None };
            NetworkViewModel.Nodes.Add(endpoint);
            var synthesizerState = new SynthesizerState(endpoint);

            _soundModel = new SoundModel(synthesizerState);

            _midiSource = new MidiSource();

            // add node types to the collection so we can drag them into the node network graph.
            NodeListViewModel.AddNodeType(() => new SineOscillatorNode(_soundModel.Time, synthesizerState));
            NodeListViewModel.AddNodeType(() => new PWMOscillatorNode(_soundModel.Time, synthesizerState));
            NodeListViewModel.AddNodeType(() => new ADSREnvelopeNode(_soundModel.Time));
            NodeListViewModel.AddNodeType(() => new MuxNode());
            NodeListViewModel.AddNodeType(() => new MidiNoteNode(_midiSource));
            NodeListViewModel.AddNodeType(() => new ConstantNode());
            _soundModel.Start();
            
            if(MidiIn.NumberOfDevices > 0)
            {
                var port = AddDisposable(new MidiIn(0));
                port.MessageReceived += OnMidiMessageReceived;
                port.Start();
            }
        }

        private void OnMidiMessageReceived(object? sender, MidiInMessageEventArgs e)
        {
            switch (e.MidiEvent.CommandCode)
            {
                case MidiCommandCode.NoteOn:   _midiSource.RaiseNoteOn(e.MidiEvent.Channel, ((NoteEvent)e.MidiEvent).Velocity, ((NoteEvent)e.MidiEvent).NoteNumber); break;
                case MidiCommandCode.NoteOff: _midiSource.RaiseNoteOff(e.MidiEvent.Channel, ((NoteEvent)e.MidiEvent).Velocity, ((NoteEvent)e.MidiEvent).NoteNumber); break;
            }
        }
    }
}
