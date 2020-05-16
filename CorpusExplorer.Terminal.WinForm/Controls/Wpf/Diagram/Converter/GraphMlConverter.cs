using System.Collections.Generic;
using System.Linq;
using System.Text;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.Converter.Abstract;
using Telerik.Windows.Controls;
using Telerik.Windows.Diagrams.Core;

namespace CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.Converter
{
  public class GraphMlConverter : AbstractGraphConverter
  {
    public override string Convert(IEnumerable<IShape> shapes, IEnumerable<IConnection> connections)
    {
      var stb = new StringBuilder();
      stb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?><graphml xmlns=\"http://graphml.graphdrawing.org/xmlns\"><key attr.name=\"label\" attr.type=\"string\" for=\"node\" id=\"label\"/><key attr.name=\"Edge Label\" attr.type=\"string\" for=\"edge\" id=\"edgelabel\"/><key attr.name=\"weight\" attr.type=\"double\" for=\"edge\" id=\"weight\"/><key attr.name=\"size\" attr.type=\"float\" for=\"node\" id=\"size\"/><graph edgedefault=\"directed\">");

      var dic = new Dictionary<string, int>();

      foreach (var node in shapes)
      {
        var key = Filter(node.Content.ToString());
        if (key == null)
          continue;

        if (dic.ContainsKey(key))
          continue;

        var idx = dic.Count;
        dic.Add(key, idx);

        stb.AppendFormat("<node id=\"{0}\"><data key=\"label\">{1}</data><data key=\"size\">{2}.0</data></node>", idx, key, key.Length);
      }

      var cnt = 0;
      foreach (var connection in connections)
      {
        var k1 = Filter(connection.Source.Content.ToString());
        var k2 = Filter(connection.Target.Content.ToString());
        if (k1 == null || k2 == null)
          continue;

        if (dic.ContainsKey(k1) && dic.ContainsKey(k2))
          stb.AppendFormat("<edge id=\"{0}\" source=\"{1}\" target=\"{2}\"><data key=\"weight\">{3}</data></edge>",
                           cnt++,
                           dic[k1],
                           dic[k2],
                           System.Convert.ToSingle((double)((RadDiagramConnection)connection).Tag).ToString().Replace(",", "."));
      }

      stb.Append("</graph></graphml>");
      return stb.ToString();
    }

    private string Filter(object content)
    {
      try
      {
        return content.ToString().Replace("\"", "''").Replace("&", "&amp;");
      }
      catch
      {
        return null;
      }
    }
  }
}