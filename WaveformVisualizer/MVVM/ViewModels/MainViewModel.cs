namespace WaveformVisualizer.MVVM.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        public ChartViewModel ChartViewModel { get; set; } 
        public MainViewModel()
        {
            ChartViewModel = new ChartViewModel();
        }
    }
}
