using FMSynthesizer.WPF.Shared.Utilities;

namespace FMSynthesizer.WPF.Shared.Models
{
    public class BaseModel : IDisposable
    {
        private DisposeStack _disposeStack;
        
        public BaseModel()
        {
            _disposeStack = new DisposeStack();
        }
        public virtual void Dispose()
        {
            _disposeStack.Dispose();
        }

        protected T AddDisposable<T>(T disposable) where T : IDisposable
        {
            _disposeStack.Add(disposable);
            return disposable;
        }
    }
}
