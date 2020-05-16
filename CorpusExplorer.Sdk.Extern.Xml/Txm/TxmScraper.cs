using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.Xml.Txm.Extension;
using CorpusExplorer.Sdk.Extern.Xml.Txm.Serializer;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.Txm
{
  public class TxmScraper : AbstractScraper
  {
    public override string DisplayName => "TEI-TXM";
    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var tei = (new TxmSerializer()).Deserialize(file);
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
