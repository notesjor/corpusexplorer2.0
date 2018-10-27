using Nest;

namespace CorpusExplorer.Sdk.Db.ElasticSearch.Elastic.Exporter.ElasticSearchFulltext.Model
{
  [ElasticsearchType(IdProperty = nameof(Displayname), Name = "layer")]
  public class Layer
  {
    public string Content { get; set; }
    public string Displayname { get; set; }
  }
}