using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.Converter.Abstract;
using Telerik.Windows.Diagrams.Core;

namespace CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.Converter
{
  public class GraphVizGraphConverter : AbstractGraphConverter
  {
    public override string Convert(IEnumerable<IShape> shapes, IEnumerable<IConnection> connections)
    {
      var stb = new StringBuilder();
      stb.Append("digraph G {\r\n");

      foreach (var connection in connections)
      {
        var block = connection.Content as TextBlock;
        if (block != null)
          stb.AppendFormat(
            "\t{0} -> {1} [ label=\"{2}\" ];\r\n",
            Filter(connection.Source.Content),
            Filter(connection.Target.Content),
            block.Text);
        else
          stb.AppendFormat("\t{0} -> {1};\r\n", Filter(connection.Source.Content), Filter(connection.Target.Content));
      }

      stb.Append("\r\n}\r\n");
      return stb.ToString();
    }

    private string Filter(object content) { return "\"" + content.ToString().Replace("\"", "''") + "\""; }
  }
}