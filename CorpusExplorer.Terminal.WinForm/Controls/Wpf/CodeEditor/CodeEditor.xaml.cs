using System.Windows.Controls;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Helper;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Indentation.CSharp;

namespace CorpusExplorer.Terminal.WinForm.Controls.Wpf.CodeEditor
{
  /// <summary>
  ///   Interaktionslogik für CodeEditor.xaml
  /// </summary>
  public partial class CodeEditor : UserControl
  {
    public CodeEditor()
    {
      XamlHighDpiExceptionHelper.Ensure(InitializeComponent);

      editor1.TextArea.IndentationStrategy = new CSharpIndentationStrategy(editor1.Options);
      editor1.ShowLineNumbers = true;
      editor1.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("ASP/XHTML");
    }

    public string Text
    {
      get => editor1.Text;
      set => editor1.Text = value;
    }
  }
}