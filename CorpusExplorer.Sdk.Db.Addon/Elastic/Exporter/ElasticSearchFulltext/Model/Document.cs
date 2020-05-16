#region

using System;
using System.Collections.Generic;
using Nest;

#endregion

namespace CorpusExplorer.Sdk.Db.ElasticSearch.Elastic.Exporter.ElasticSearchFulltext.Model
{
  [ElasticsearchType(IdProperty = nameof(DocumentGuid), Name = "document")]
  public class Document
  {
    public string Displayname { get; set; }
    public Guid DocumentGuid { get; set; }

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