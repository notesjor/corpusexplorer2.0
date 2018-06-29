using System;
using System.Collections.Generic;
using Nest;

namespace CorpusExplorer.Sdk.Db.Elastic.Model
{
  [ElasticsearchType(IdProperty = nameof(CorpusId))]
  public class Corpus
  {
    public Guid CorpusId { get; set; }
    public string Displayname { get; set; }
    public HashSet<Guid> Documents { get; set; }

    [Nested] public Dictionary<Guid, string> Layers { get; set; }

    [Nested] public Dictionary<string, object> Metadata { get; set; }
  }
}