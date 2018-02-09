using System;
using System.Collections.Generic;
using Nest;

namespace CorpusExplorer.Sdk.Db.Addon.Elastic.Exporter.ElasticSearchFulltext.Model
{
  [ElasticsearchType(IdProperty = nameof(DocumentGuid), Name = "document")]
  public class Document
  {
    public Guid DocumentGuid { get; set; }
    public string Displayname { get; set; }

    [Nested]
    public List<Layer> Layers { get; set; }

    [Nested]
    public Dictionary<string, object> Metadata { get; set; }

    [Number(NumberType.Long, IgnoreMalformed = true)]
    public long SentenceCount { get; set; }

    [Number(NumberType.Long, IgnoreMalformed = true)]
    public long TokenCount { get; set; }
  }
}