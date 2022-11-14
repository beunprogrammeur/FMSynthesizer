using FMSynthesizer.WPF.Shared.ViewModels;

namespace WaveformVisualizer.MVVM.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        public ChartViewModel ChartViewModel { get; set; } 
        public MainViewModel()
        {
            ChartViewModel = new ChartViewModel();
        }
    }
}
