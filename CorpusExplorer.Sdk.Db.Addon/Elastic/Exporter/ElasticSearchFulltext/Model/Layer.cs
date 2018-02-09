using System;
using System.Linq;
using System.Runtime.Serialization;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using Nest;

namespace CorpusExplorer.Sdk.Db.Addon.Elastic.Exporter.ElasticSearchFulltext.Model
{
  [ElasticsearchType(IdProperty = nameof(Displayname), Name = "layer")]
  public class Layer
  {
    public string Displayname { get; set; }

    public string Content { get; set; }
  }
}