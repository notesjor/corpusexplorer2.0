using System.Linq;
using CorpusExplorer.Sdk.Db.Elastic.Sdk.Context;
using CorpusExplorer.Sdk.Db.ElasticSearch.Elastic.Exporter.ElasticSearchFulltext.Model;
using CorpusExplorer.Sdk.Db.ElasticSearch.Elastic.Exporter.ElasticSearchFulltext.Model.Context;
using CorpusExplorer.Sdk.Db.Gui;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;

namespace CorpusExplorer.Sdk.Db.ElasticSearch.Elastic.Exporter
{
  public class ExporterElasticSearchFulltext : AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
      FormHelper.Show("ElasticSearch",
                      "http://localhost",
                      9200,
                      (h, p, db, usr, psw) =>
                      {
                        ElasticSearchFulltextContextManager
                         .Initialize(
                                     new[] {$"{h}:{p}"},
                                     db.ToLower(),
                                     string.IsNullOrEmpty(usr)
                                       ? null
                                       : new
                                         ElasticSearchContextCredentials(usr, psw));
                        return ElasticSearchFulltextContextManager.GetContext() != null;
                      },
                      "CorpusExplorer >>> ElasticSearch (Kein CE-Reimport möglich)|*.elastic");

      var context = ElasticSearchFulltextContextManager.GetContext();
      foreach (var dsel in hydra.DocumentGuids)
      {
        var meta = hydra.GetDocumentMetadata(dsel);
        context.Add(new Document
        {
          DocumentGuid = dsel,
          SentenceCount = hydra.GetDocumentLengthInSentences(dsel),
          TokenCount = hydra.GetDocumentLengthInWords(dsel),
          Metadata = meta,
          Displayname = meta != null && meta.ContainsKey("Titel")
                          ? meta["Titel"].ToString()
                          : dsel.ToString(),
          Layers = hydra.GetReadableMultilayerDocument(dsel)
                        .Select(
                                x => new Layer
                                {
                                  Displayname = x.Key,
                                  Content = x.Value.ReduceDocumentToText()
                                })
                        .ToList()
        });
      }
    }
  }
}