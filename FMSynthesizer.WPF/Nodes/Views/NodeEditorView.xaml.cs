using FMSynthesizer.WPF.Nodes.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows;
using System.Windows.Controls;

namespace FMSynthesizer.WPF.Nodes.Views
{
    /// <summary>
    /// Interaction logic for TextEditorViewModel.xaml
    /// </summary>
    public partial class NodeEditorView : UserControl, IViewFor<NodeValueEditorViewModel>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty
            .Register(nameof(ViewModel),
                      typeof(NodeValueEditorViewModel),
                      typeof(NodeEditorView),
                      new PropertyMetadata(null));

        public NodeValueEditorViewModel ViewModel
        {
            get => (NodeValueEditorViewModel)GetValue(ViewModelProperty);
            set { SetValue(ViewModelProperty, value); DataContext = value; }
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set { ViewModel = (NodeValueEditorViewModel)value; DataContext = value; }
        }

        #endregion

        public NodeEditorView()
        {
            InitializeComponent();
        }
    }
}
