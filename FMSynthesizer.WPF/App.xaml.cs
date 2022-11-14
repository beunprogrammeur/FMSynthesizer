using FMSynthesizer.WPF.MVVM.ViewModels;
using NodeNetwork;
using System;
using System.Windows;

namespace FMSynthesizer.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindow? _window;
        private MainViewModel? _mainViewModel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            NNViewRegistrar.RegisterSplat();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _window = new MainWindow();
            _mainViewModel = new MainViewModel();

            _window.DataContext = _mainViewModel;
            _window.Closed += OnWindowClosed;

            _window.Show();
        }

        private void OnWindowClosed(object? sender, EventArgs e)
        {
            _mainViewModel?.Dispose();
        }
    }
}
