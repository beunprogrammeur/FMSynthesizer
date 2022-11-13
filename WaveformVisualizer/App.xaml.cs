using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WaveformVisualizer.MVVM.ViewModels;

namespace WaveformVisualizer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindow? _mainWindow;
        private MainViewModel? _mainViewModel;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _mainWindow = new MainWindow();
            _mainViewModel = new MainViewModel();
            _mainWindow.DataContext = _mainViewModel;

            _mainWindow.Closed += OnMainWindowClosed;

            _mainWindow.Show();
        }

        private void OnMainWindowClosed(object? sender, EventArgs e)
        {
            _mainViewModel?.Dispose();
        }
    }
}
