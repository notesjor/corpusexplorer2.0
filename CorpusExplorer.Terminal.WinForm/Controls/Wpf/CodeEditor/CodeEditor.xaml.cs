using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CorpusExplorer.Terminal.WinForm.Controls.Wpf.CodeEditor
{
  /// <summary>
  /// Interaktionslogik für CodeEditor.xaml
  /// </summary>
  public partial class CodeEditor : UserControl
  {
    public CodeEditor()
    {
      InitializeComponent();
      editor1.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.CSharp.CSharpIndentationStrategy(editor1.Options);
      editor1.ShowLineNumbers = true;
      editor1.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("ASP/XHTML");
    }

    public string Text
    {
      get => editor1.Text;
      set => editor1.Text = value;
    }
  }
}
