using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WaveformVisualizer.MVVM.Utilities;

namespace WaveformVisualizer.MVVM.ViewModels
{
    internal class ViewModelBase : IDisposable, INotifyPropertyChanged
    {
        private DisposeStack _disposeStack;

        public event PropertyChangedEventHandler? PropertyChanged;
        
        public ViewModelBase()
        {
            _disposeStack = new DisposeStack();
        }
        public virtual void Dispose()
        {
            _disposeStack.Dispose();
        }

        protected T AddDisposable<T>(T disposable) where T: IDisposable
        {
            _disposeStack.Add(disposable);
            return disposable;
        }

        public void OnPropertyChanged([CallerMemberName]string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected bool SetProperty<T>(ref T property, T value, [CallerMemberName]string? name = null)
        {
            if(Comparer.Default.Compare(property, value) != 0)
            {
                property = value;
                OnPropertyChanged(name);
                return true;
            }

            return false;
        }
    }
}
