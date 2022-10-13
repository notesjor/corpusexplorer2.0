#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Binary.Abstract;
using CorpusExplorer.Sdk.Extern.Binary.Excel.Universal.Reader;
using CorpusExplorer.Sdk.Helper;

#endregion

namespace CorpusExplorer.Sdk.Extern.Binary.Excel.Czinglar
{
  // ReSharper disable once UnusedMember.Global
  public class CzinglarScraper : AbstractGenericBinaryFormatScraper<Dictionary<string, string>>
  {
    public override string DisplayName => "Czinglar-Excel";

    protected override AbstractGenericDataReader<Dictionary<string, string>> DataReader =>
      new ExcelUniversalDataReader(new[] { "Utterance_ID", "Person", "Utterance_cha", "Child_age", "Situation" });

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(
      IEnumerable<Dictionary<string, string>> model)
    {
      var dic = new Dictionary<string, Dictionary<string, object>>();

      foreach (var x in model)
      {
        var key = x["Utterance_ID"];

        if (dic.ContainsKey(key))
          continue;

        dic.Add(
          key,
          new Dictionary<string, object>
          {
            {"Id", key},
            {"Person", x["Person"]},
            {"Text", x["Utterance_cha"]},
            {"Alter", x["Child_age"].Split(Splitter.Semicolon, StringSplitOptions.None).FirstOrDefault()},
            {"Situation", x["Situation"]}
          });
      }

      return dic.Select(x => x.Value);
    }
  }
}