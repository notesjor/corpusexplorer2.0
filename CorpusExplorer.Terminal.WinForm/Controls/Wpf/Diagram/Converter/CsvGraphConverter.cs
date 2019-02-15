using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.Converter.Abstract;
using Telerik.Windows.Diagrams.Core;

namespace CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.Converter
{
  public class CsvGraphConverter : AbstractGraphConverter
  {
    public override string Convert(IEnumerable<IShape> shapes, IEnumerable<IConnection> connections)
    {
      var stb = new StringBuilder();
      stb.AppendLine("source\tconnection\ttarget");

      foreach (var connection in connections)
        stb.AppendLine(
                       connection.Content is TextBlock block
                         ? $"{connection.Source.Content}\t{block.Text}\t{connection.Target.Content}"
                         : $"{connection.Source.Content}\t \t{connection.Target.Content}");

      return stb.ToString();
    }
  }
}