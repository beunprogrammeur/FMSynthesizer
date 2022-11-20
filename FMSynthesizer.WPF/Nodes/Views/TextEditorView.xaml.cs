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
    public partial class TextEditorView : UserControl, IViewFor<TextEditorViewModel>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty
            .Register(nameof(ViewModel),
                      typeof(TextEditorViewModel),
                      typeof(TextEditorView),
                      new PropertyMetadata(null));

        public TextEditorViewModel ViewModel
        {
            get => (TextEditorViewModel)GetValue(ViewModelProperty);
            set { SetValue(ViewModelProperty, value); DataContext = value; }
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (TextEditorViewModel)value;
        }

        #endregion

        public TextEditorView()
        {
            InitializeComponent();
        }
    }
}
