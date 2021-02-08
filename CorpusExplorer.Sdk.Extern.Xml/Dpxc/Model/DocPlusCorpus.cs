using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dpxc.Model
{
  [XmlRoot]
  [Serializable]
  public class DocPlusCorpus
  {
    [OptionalField]
    private Dictionary<string, Type> _metadataSchema;

    public DocPlusCorpus()
    {
    }

    public DocPlusCorpus(IEnumerable<Dictionary<string, object>> docs)
    {
      Documents = new List<Dictionary<string, object>>(docs);
    }

    public List<Dictionary<string, object>> Documents { get; set; } = new List<Dictionary<string, object>>();

    [OnSerializing()]
    internal void OnSerializingMethod(StreamingContext context)
    {
      var list = new List<int>();
      for (var i = 0; i < Documents.Count; i++)
        if (Documents[i] == null || !Documents[i].ContainsKey("Text") || string.IsNullOrWhiteSpace(Documents[i]["Text"] as string))
          list.Add(i);

      for (var i = list.Count - 1; i >= 0; i--)
        Documents.RemoveAt(i);
    }

    [Obsolete]
    public string[] Metadata { get; set; }

    public Dictionary<string, Type> MetadataSchema
    {
      get
      {
        if (_metadataSchema != null)
          return _metadataSchema;

#pragma warning disable 612
        if (Metadata != null)
#pragma warning restore 612
          Fallback();

        // ReSharper disable once ConvertIfStatementToNullCoalescingExpression
        if (_metadataSchema == null)
          _metadataSchema = new Dictionary<string, Type> { { "Text", typeof(string) } };

        return _metadataSchema;
      }
      set => _metadataSchema = value;
    }

    /// <summary>
    /// Für die Unterstützung des v1.0 Dateiformats
    /// </summary>
    private void Fallback()
    {
      _metadataSchema = new Dictionary<string, Type>();
      foreach (var key in Metadata)
      {
        switch (key[0])
        {
          case '#':
            _metadataSchema.Add(key.Substring(1), typeof(int));
            break;
          case '?':
            _metadataSchema.Add(key.Substring(1), typeof(DateTime));
            break;
          case '~':
            _metadataSchema.Add(key.Substring(1), typeof(double));
            break;
          default:
            _metadataSchema.Add(key.Substring(1), typeof(string));
            break;
        }
      }
    }

    public void AddDocument()
    {
      var dic = new Dictionary<string, object>();
      foreach (var pair in MetadataSchema)
      {
        try
        {
          dic.Add(pair.Key, pair.Value == typeof(DateTime) ? DateTime.MinValue : Activator.CreateInstance(pair.Value));
        }
        catch
        {
          dic.Add(pair.Key, string.Empty);
        }
      }

      Documents.Add(dic);
    }

    public void ApplyMetadataSchema()
    {
      foreach (var doc in Documents)
      foreach (var x in MetadataSchema.Where(x => !doc.ContainsKey(x.Key)))
      {
        if(x.Value == typeof(DateTime))
          doc.Add(x.Key, DateTime.MinValue);
        else
          try
          {
            doc.Add(x.Key, Activator.CreateInstance(x.Value));
          }
          catch
          {
            doc.Add(x.Key, string.Empty);
          }
      }
    }
  }
}