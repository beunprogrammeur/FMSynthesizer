using System;
using System.Collections.Generic;

namespace WaveformVisualizer.MVVM.Utilities
{
    internal class DisposeStack : IDisposable
    {
        private Stack<IDisposable> _stack;

        public DisposeStack()
        {
            _stack = new Stack<IDisposable>();
        }

        public void Dispose()
        {
            IDisposable? disposable = null;
            while(_stack.TryPop(out disposable))
            {
                disposable.Dispose();
            }
        }

        public void Add(IDisposable disposable)
        {
            _stack.Push(disposable);
        }
    }
}
