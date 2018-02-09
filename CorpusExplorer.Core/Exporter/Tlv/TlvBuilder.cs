using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using CorpusExplorer.Core.Exporter.Tlv.Model;

namespace CorpusExplorer.Core.Exporter.Tlv
{
  [Serializable]
  public class TlvBuilder
  {
    private readonly string _text;
    private Regex _regex = new Regex(@"<[^>]*>");
    private List<TlvEntry> _entries = new List<TlvEntry>();

    private TlvBuilder() { }
    public TlvBuilder(string text) => _text = text;

    public void Add(TlvEntry entry) => _entries.Add(entry);
    public IEnumerable<TlvEntry> Get() => _entries;
    public void Remove(TlvEntry entry) => _entries.Remove(entry);
    public Dictionary<string, object> Metadata { get; set; } = new Dictionary<string, object>();

    public string GetXmlOutput()
    {
      #region <layers>

      var layer = new Dictionary<string, int>();
      var lDict = new Dictionary<string, Dictionary<string, int>>();
      foreach (var x in _entries)
        if (!layer.ContainsKey(x.Layer))
        {
          layer.Add(x.Layer, layer.Count);
          lDict.Add(x.Layer, new Dictionary<string, int> { { x.Value, 0 } });
        }
        else if (!lDict[x.Layer].ContainsKey(x.Value))
          lDict[x.Layer].Add(x.Value, lDict[x.Layer].Count);

      var layers = new StringBuilder();
      foreach (var l in lDict)
      {
        layers.AppendLine($"<layer name=\"{l.Key}\" l=\"{layer[l.Key]}\">");
        foreach (var v in l.Value)
          layers.AppendLine($"<value label=\"{v.Key}\" v=\"{v.Value}\"/>");
        layers.AppendLine("</layer>");
      }

      #endregion

      #region <text>

      var points = new Dictionary<int, string>();
      // Erzeuge Punkte
      foreach (var x in _entries)
      {
        // Startpunkt
        var start = $"<t l=\"{layer[x.Layer]}\" v=\"{lDict[x.Layer][x.Value]}\">";
        if (points.ContainsKey(x.Start))
          points[x.Start] = points[x.Start] + start;
        else
          points.Add(x.Start, start);

        // Endpunkt
        var stop = x.Stop + 1;
        if (points.ContainsKey(stop))
          points[stop] = "</t>" + points[stop];
        else
          points.Add(stop, "</t>");
      }

      var sortedPoints = points.OrderByDescending(x => x.Key).ToArray();
      var text = new StringBuilder(_text);
      foreach (var x in sortedPoints)
      {
        text.Insert(x.Key, x.Value);
      }

      #endregion

      #region <meta>
      var meta = new StringBuilder();
      foreach (var x in Metadata)
        if (x.Value != null)
          meta.Append($"<entry category=\"{x.Key}\" type=\"{x.Value.GetType()}\">{HttpUtility.HtmlEncode(_regex.Replace(HttpUtility.HtmlDecode(x.Value.ToString()), string.Empty))}</entry>");
      #endregion
      
      return $"<xml><meta><entry category=\"generator\" type=\"System.String\">CorpusExplorer v2.0 - TlvBuilder</entry></meta><layers>{layers}</layers><docs><doc id=\"0\"><meta>{meta}</meta><body>{text}</body></doc></docs></xml>";
    }
  }
}
