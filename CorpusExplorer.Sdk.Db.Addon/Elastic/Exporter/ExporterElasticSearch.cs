using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Db.Addon.Elastic.Backend;
using CorpusExplorer.Sdk.Db.Elastic;
using CorpusExplorer.Sdk.Db.Elastic.Model.Context;
using CorpusExplorer.Sdk.Db.Elastic.Sdk.Context;
using CorpusExplorer.Sdk.Db.Gui;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Export;
using CorpusExplorer.Sdk.Model.Export.Abstract;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.CorpusManipulation;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;

namespace CorpusExplorer.Sdk.Db.Addon.Elastic.Exporter
{
  public class ExporterElasticSearch : AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
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

      var merger = new CorpusMerger {CorpusBuilder = new CorpusBuilderElasticSearch()};
      merger.Input(hydra.ToCorpus());
      merger.Execute();
    }
  }
}
