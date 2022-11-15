using DynamicData;
using FMSynthesizer.WPF.Nodes;
using FMSynthesizer.WPF.Shared.ViewModels;
using NodeNetwork.Toolkit.NodeList;
using NodeNetwork.ViewModels;

namespace FMSynthesizer.WPF.MVVM.ViewModels
{
    internal class GraphViewModel : BaseViewModel
    {
        public NetworkViewModel NetworkViewModel { get; }
        public NodeListViewModel NodeListViewModel { get; }

        public GraphViewModel()
        {
            NetworkViewModel = new NetworkViewModel();
            NodeListViewModel = new NodeListViewModel() { Title = string.Empty };

            NodeListViewModel.AddNodeType(() => new SineOscillatorNode());
            NodeListViewModel.AddNodeType(() => new ADSREnvelopeNode());
        }
    }
}
