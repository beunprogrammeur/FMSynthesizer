using DynamicData;
using FMSynthesizer.Waveforms;
using FMSynthesizer.WPF.MVVM.Models;
using FMSynthesizer.WPF.Nodes;
using FMSynthesizer.WPF.Shared.ViewModels;
using NodeNetwork.Toolkit.NodeList;
using NodeNetwork.ViewModels;

namespace FMSynthesizer.WPF.MVVM.ViewModels
{
    internal class GraphViewModel : BaseViewModel
    {
        private SoundModel _soundModel;

        public NetworkViewModel NetworkViewModel { get; }
        public NodeListViewModel NodeListViewModel { get; }
        public GraphViewModel()
        {
            NetworkViewModel = new NetworkViewModel();
            NodeListViewModel = new NodeListViewModel() { Title = string.Empty };

            NodeListViewModel.AddNodeType(() => new SineOscillatorNode());
            NodeListViewModel.AddNodeType(() => new ADSREnvelopeNode());
            NodeListViewModel.AddNodeType(() => new MuxNode());


            var endpoint = new EndpointNode { CanBeRemovedByUser = false };
            NetworkViewModel.Nodes.Add(endpoint);

            _soundModel = new SoundModel(endpoint.SampleSource);
            _soundModel.Start();
        }
    }
}
