using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bcs.IO;
using CorpusExplorer.Sdk.Db.Addon.Elastic.Exporter.ElasticSearchFulltext.Model.Context;
using CorpusExplorer.Sdk.Db.Elastic;
using CorpusExplorer.Sdk.Db.Elastic.Model.Context;
using CorpusExplorer.Sdk.Db.Elastic.Sdk.Context;
using CorpusExplorer.Sdk.Db.Gui;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;

namespace CorpusExplorer.Sdk.Db.Addon.Elastic.Backend
{
  public class CorpusBuilderElasticSearchLightweightGui : CorpusBuilderElasticSearch
  {
    private bool _initilized = false;

    protected override AbstractCorpusAdapter CreateCorpus(Dictionary<Guid, Dictionary<string, object>> documentMetadata, Dictionary<string, object> corpusMetadata, List<Concept> concepts)
    {
      if (_initilized)
        return base.CreateCorpus(documentMetadata, corpusMetadata, concepts);

      FormHelper.Show("ElasticSearch",
        "http://localhost",
        9200,        
        ((h, p, db, usr, psw) =>
        {
          ElasticSearchContextManager
            .Initialize(
              new[] {$"{h}:{p}"},
              db.ToLower(),
              string.IsNullOrEmpty(usr)
                ? null
                : new
                  ElasticSearchContextCredentials(usr, psw));
          return ElasticSearchContextManager.GetContext() != null;
        }),
        "CorpusExplorer <-> Elasticsearch Verbindungsdaten (*.elastic)|*.elastic");
      _initilized = true;

      return base.CreateCorpus(documentMetadata, corpusMetadata, concepts);
    }
  }
}
