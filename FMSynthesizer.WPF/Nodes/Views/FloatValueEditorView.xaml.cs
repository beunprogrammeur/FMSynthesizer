using FMSynthesizer.WPF.Nodes.ViewModels;
using ReactiveUI;
using System;
using System.Reactive.Disposables;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FMSynthesizer.WPF.Nodes.Views
{
    /// <summary>
    /// Interaction logic for FloatValueEditorView.xaml
    /// </summary>
    public partial class FloatValueEditorView : UserControl, IViewFor<FloatValueEditorViewModel>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty
            .Register(nameof(ViewModel),
                      typeof(FloatValueEditorViewModel),
                      typeof(FloatValueEditorView),
                      new PropertyMetadata(null));

        public FloatValueEditorViewModel ViewModel
        {
            get => (FloatValueEditorViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (FloatValueEditorViewModel)value;
        }
        #endregion

        public float Value
        {
            get 
            {
                float.TryParse(TextBox.Text, out float result);
                return result;
            }
        }

        public FloatValueEditorView()
        {
            InitializeComponent();

            this.WhenActivated(d => 
            {
                this.Bind(ViewModel, vm => vm.Value, v => v.TextBox.Text).DisposeWith(d);
            });
        }
    }
}
