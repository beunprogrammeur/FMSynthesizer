using FMSynthesizer.WPF.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMSynthesizer.WPF.MVVM.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        public GraphViewModel TestGraphViewModel { get; }

        public MainViewModel()
        {
            TestGraphViewModel = new GraphViewModel();
        }
    }
}
