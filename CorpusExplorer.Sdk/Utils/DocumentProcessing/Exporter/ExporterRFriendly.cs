using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter
{
  public class ExporterRFriendly : AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
      using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
      using (var writer = new StreamWriter(fs, Configuration.Encoding))
      {
        writer.WriteLine("Wort\tPOS\tLemma\tSID\tGUID\r\n");
        foreach (var csel in hydra.CorporaAndDocumentGuids)
          foreach (var dsel in csel.Value)
          {
            try
            {
              var layers = hydra.GetReadableMultilayerDocument(dsel)
                .ToDictionary(x => x.Key.Replace(" (tree_tagger)", ""),
                  x => x.Value.Select(y => y.ToArray()).ToArray());
              if (!layers.ContainsKey("Wort") || !layers.ContainsKey("Lemma") || !layers.ContainsKey("POS"))
                continue;

              var first = layers.First().Value;
              var wor = layers["Wort"];
              var lem = layers["Lemma"];
              var pos = layers["POS"];

              for (var i = 0; i < first.Length; i++)
                for (var j = 0; j < first[i].Length; j++)
                  writer.Write($"{wor[i][j]}\t{pos[i][j]}\t{lem[i][j]}\t{i}\t{dsel}\r\n");
            }
            catch
            {
              continue;
            }
          }
      }
    }
  }
}