#region

using CorpusExplorer.Sdk.Extern.Binary.Abstract;
using CorpusExplorer.Sdk.Extern.Binary.Excel.Universal.Reader;
using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace CorpusExplorer.Sdk.Extern.Binary.Excel.Czinglar
{
  // ReSharper disable once UnusedMember.Global
  public class CzinglarScraper : AbstractGenericBinaryFormatScraper<Dictionary<string, string>>
  {
    protected override AbstractGenericDataReader<Dictionary<string, string>> DataReader
    {
      get
      {
        return new ExcelUniversalDataReader(new[] { "Utterance_ID", "Person", "Utterance_cha", "Child_age", "Situation" });
      }
    }

    public override string DisplayName { get { return "Czinglar-Excel"; } }

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
            {"Alter", x["Child_age"].Split(new[] {";"}, StringSplitOptions.None).FirstOrDefault()},
            {"Situation", x["Situation"]}
          });
      }

      return dic.Select(x => x.Value);
    }
  }
}