using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Extern.Xml.Txm.Extension;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.Txm.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.Txm
{
  public class TxmScraper : AbstractScraper
  {
    public override string DisplayName => "TEI-TXM";
    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var tei = XmlSerializerHelper.Deserialize<TEI>(file);
      return new[]
      {
        new Dictionary<string, object>
        {
          {"Datei", Path.GetFileNameWithoutExtension(file)},
          {"Text", string.Join(" ", (from p in tei.text.p from s in p.s from w in s.GetW() select w.form))}
        }
      };
    }
  }
}
