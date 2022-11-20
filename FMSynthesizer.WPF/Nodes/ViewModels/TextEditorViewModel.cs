using FMSynthesizer.WPF.Nodes.Views;
using NodeNetwork.Toolkit.ValueNode;
using ReactiveUI;

namespace FMSynthesizer.WPF.Nodes.ViewModels
{
    public class TextEditorViewModel : ValueEditorViewModel<string>
    {
        public virtual string Text { get; set; }
        static TextEditorViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new TextEditorView(), typeof(IViewFor<TextEditorViewModel>));
        }

        public TextEditorViewModel()
        {
            Text = string.Empty;
        }
    }
}
