using System;
using System.Collections.Generic;
using Nest;

namespace CorpusExplorer.Sdk.Db.Elastic.Model
{
  [ElasticsearchType(IdProperty = nameof(DocumentId))]
  public class Document
  {
    public Guid CorpusId { get; set; }

    public Guid DocumentId { get; set; }

    [Nested] public Dictionary<string, object> Metadata { get; set; }

    [Number(NumberType.Long, IgnoreMalformed = true)]
    public long SentenceCount { get; set; }

    [Number(NumberType.Long, IgnoreMalformed = true)]
    public long TokenCount { get; set; }
  }
}