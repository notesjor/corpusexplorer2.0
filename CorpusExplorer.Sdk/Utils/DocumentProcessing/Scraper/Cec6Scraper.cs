using System.Collections.Generic;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper
{
  public sealed class Cec6Scraper : AbstractScraper
  {
    public override string DisplayName => "CEC6-ReAnnotate";
    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var res = new List<Dictionary<string, object>>();

      AbstractCorpusAdapter corpus = CorpusAdapterWriteDirect.Create(file) as AbstractCorpusAdapter ?? CorpusAdapterSingleFile.Create(file);
      foreach (var guid in corpus.DocumentGuids)
      {
        var doc = corpus.GetDocumentMetadata(guid);

        // Stelle sicher, das GUID vorhanden ist und als string vorliegt.
        if (doc.ContainsKey("GUID"))
          doc["GUID"] = guid.ToString();
        else
          doc.Add("GUID", guid.ToString());

        doc.Add("Text", corpus.GetReadableDocument(guid, "Wort").ReduceDocumentToText());

        res.Add(doc);
      }

      return res;
    }
  }
}