using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dpxc.Model
{
  [XmlRoot]
  [Serializable]
  public class DocPlusCorpus
  {
    public DocPlusCorpus() { }

    public DocPlusCorpus(IEnumerable<Dictionary<string, object>> docs)
    {
      Documents = new List<Dictionary<string, object>>(docs);

      var hash = new HashSet<string>();
      foreach (var x in docs.SelectMany(doc => doc))
        try
        {
          if (x.Value == null)
            continue;
          var type = x.Value.GetType();
          hash.Add(
            (type == typeof(double) ? "~" : type == typeof(int) ? "#" : type == typeof(DateTime) ? "?" : "") + x.Key);
        }
        catch {}

      Metadata = hash.ToArray();
    }

    public List<Dictionary<string, object>> Documents { get; set; } = new List<Dictionary<string, object>>();

    public string[] Metadata { get; set; } = new string[0];
  }
}