using System.Collections.Generic;
using System.Linq;
using System.Text;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.Converter.Abstract;
using Telerik.Windows.Controls;
using Telerik.Windows.Diagrams.Core;

namespace CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.Converter
{
  public class GexfXmlGraphConverter : AbstractGraphConverter
  {
    public override string Convert(IEnumerable<IShape> shapes, IEnumerable<IConnection> connections)
    {
      var stb = new StringBuilder();
      stb.Append(
                 "<gexf xmlns=\"http://www.gexf.net/1.2draft\" version=\"1.2\"><meta lastmodifieddate=\"2009-03-20\"><creator>CorpusExplorer by J.O.Rüdiger</creator><description>For more information please visit www.CorpusExplorer.de</description></meta><graph mode=\"static\" defaultedgetype=\"directed\"><nodes>");

      var dic = new Dictionary<string, int>();

      foreach (var node in shapes)
      {
        if (dic.ContainsKey(node.Content.ToString()))
          continue;

        var key = Filter(node.Content.ToString());
        var idx = dic.Count;
        dic.Add(key, idx);

        stb.AppendFormat("<node id=\"{0}\" label=\"{1}\" />", idx, key);
      }

      stb.Append("</nodes><edges>");

      var cnt = 0;
      foreach (
        var connection in
        connections.Where(
                          connection =>
                            dic.ContainsKey(connection.Source.Content.ToString()) &&
                            dic.ContainsKey(connection.Target.Content.ToString())))
        stb.AppendFormat(
                         "<edge id=\"{0}\" source=\"{1}\" target=\"{2}\" weight=\"{3}\" />",
                         cnt++,
                         dic[connection.Source.Content.ToString()],
                         dic[connection.Target.Content.ToString()],
                         System.Convert.ToSingle((double)((RadDiagramConnection)connection).Tag));

      stb.Append("</edges></graph></gexf>");
      return stb.ToString();
    }

    private string Filter(object content)
    {
      return content.ToString().Replace("\"", "''").Replace("&", "&amp;");
    }
  }
}