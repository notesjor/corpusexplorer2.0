using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using Nest;

namespace CorpusExplorer.Sdk.Db.Elastic.Model
{
  [ElasticsearchType(IdProperty = nameof(LayerId))]
  public class Layer
  {
    public Guid CorpusId { get; set; }

    [Object(Ignore = true)]
    public CeDictionary Dictionary { get; set; }

    [Nested]
    public Dictionary<int, string> DictionaryRaw { get; set; }

    public string Displayname { get; set; }
    public HashSet<Guid> LayerDocuments { get; set; }

    public Guid LayerId { get; set; }

    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
      if (DictionaryRaw != null)
        Dictionary = new CeDictionary(DictionaryRaw);
    }

    [OnSerializing]
    private void OnSerializing(StreamingContext context)
    {
      if (Dictionary != null)
        DictionaryRaw = Dictionary.ReciveRawIndexToValue().ToDictionary(x => x.Key, x => x.Value);
    }
  }
}