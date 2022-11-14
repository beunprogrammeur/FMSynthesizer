using DynamicData;
using FMSynthesizer.WPF.Shared.ViewModels;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;

namespace FMSynthesizer.WPF.MVVM.ViewModels
{
    internal class GraphViewModel : BaseViewModel
    {
        public NetworkViewModel NetworkViewModel { get; }

        public GraphViewModel()
        {
            NetworkViewModel = new NetworkViewModel();

            var node1 = new NodeViewModel() { Name = "Node 1" };
            var node2 = new NodeViewModel() { Name = "Node 2" };

            node1.Inputs.Add(new NodeInputViewModel()   { Name = "Node 1 input" });
            node2.Outputs.Add(new NodeOutputViewModel() { Name = "Node 2 output" });
            node2.Inputs.Add(new NodeInputViewModel() { Name = "Node 2 input" });



            NetworkViewModel.Nodes.Add(node1);
            NetworkViewModel.Nodes.Add(node2);

            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<NodeViewModel>));
        }
    }
}
