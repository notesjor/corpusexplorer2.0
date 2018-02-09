using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using CorpusExplorer.Sdk.Extern.Xml.Dpxc.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.Dpxc
{
  public class DpxcScraper : AbstractScraper
  {
    public override string DisplayName => "DPXCorpus";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
      {
        var bf = new NetDataContractSerializer();
        var corpus = bf.Deserialize(fs) as DocPlusCorpus;
        return corpus?.Documents;
      }
    }
  }
}