using System.Collections.Generic;
using System.Linq;
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

      var cs = connections.ToArray();
      foreach (var connection in cs)
        if (connection.Content is TextBlock block)
          stb.Append($"\t{Filter(connection.Source.Content)} -> {Filter(connection.Target.Content)} [ label=\"{Filter(block.Text)}\" ];\r\n");
        else
          stb.Append($"\t{Filter(connection.Source.Content)} -> {Filter(connection.Target.Content)};\r\n");

      stb.Append("\r\n}\r\n");
      return stb.ToString();
    }

    private string Filter(object content)
    {
      return "\"" + content.ToString().Replace("\"", "''") + "\"";
    }
  }
}