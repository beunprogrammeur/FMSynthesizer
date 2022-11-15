using FMSynthesizer.WPF.Nodes.Views;
using NodeNetwork.Toolkit.ValueNode;
using ReactiveUI;

namespace FMSynthesizer.WPF.Nodes.ViewModels
{
    public class FloatValueEditorViewModel : ValueEditorViewModel<float>
    {
        static FloatValueEditorViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new FloatValueEditorView(), typeof(IViewFor<FloatValueEditorViewModel>));
        }

        public FloatValueEditorViewModel()
        {
            Value = 0.0f;
        }
    }
}
