using CorpusExplorer.Sdk.Extern.Json.OpenLegalData.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Extern.Json.OpenLegalData
{
  public class OpenLegalDataScraper : AbstractScraper
  {
    public override string DisplayName => "OpenLegalData";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var res = new List<Dictionary<string, object>>();

      using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
      using (var reader = new StreamReader(fs, Encoding.UTF8))
      {
        while (!reader.EndOfStream)
        {
          var json = reader.ReadLine();
          if (string.IsNullOrWhiteSpace(json))
            continue;
          var entry = JsonConvert.DeserializeObject<OpenLegalDataEntry>(json);

          var tmp = (new Dictionary<string, object>
          {
            { "ID", entry.Id },
            { "ECLI", entry.Ecli },
            { "Titel", entry.Slug },
            { "Datum", entry.Date },
            { "Datum (erstellt)", entry.CreatedDate },
            { "Datum (aktualisiert)", entry.UpdatedDate },
            { "Text", GetCleanText(entry.Content) }
          });

          if (entry.Court != null)
          {
            tmp.Add("Court.ID", entry.Court.Id);
            tmp.Add("Court.City", entry.Court.City);
            tmp.Add("Court.Name", entry.Court.Name);
            tmp.Add("Court.State", entry.Court.State);
            tmp.Add("Court.Jurisdiction", entry.Court.Jurisdiction);
            tmp.Add("Court.LevelOfAppeal", entry.Court.LevelOfAppeal);
          }

          res.Add(tmp);
        }

      }

      return res;
    }

    private object GetCleanText(string content)
    {
      var html = new HtmlDocument();
      html.LoadHtml(content);

      return html.DocumentNode.InnerText;
    }
  }
}
