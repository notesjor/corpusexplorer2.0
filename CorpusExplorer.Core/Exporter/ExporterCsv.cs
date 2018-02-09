using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Export.Abstract;
using CorpusExplorer.Sdk.Model.Interface;

namespace CorpusExplorer.Core.Exporter
{
  public class ExporterCsv : AbstractExporter
  {
    public string LineSeparator { get; set; } = "\r\n";
    public string ValueSeparator { get; set; } = "\t";

    public override void Export(IHydra hydra, string path)
    {
      var labels = hydra.GetDocumentMetadataPrototypeOnlyProperties().ToArray();
      var stb = new StringBuilder($"{GenerateHeader(labels)}{LineSeparator}");
      var meta = hydra.DocumentMetadata;

      foreach (var x in meta)
      {
        var values = new List<string>();
        foreach (var y in labels)
          try
          {
            if (x.Value.ContainsKey(y) && x.Value[y] != null)
              values.Add(x.Value[y].ToString());
            else
              values.Add(string.Empty);
          }
          catch
          {
            values.Add(string.Empty);
          }
        values.Add(hydra.GetReadableDocument(x.Key, "Wort").ConvertToPlainText());
        stb.Append($"{string.Join(ValueSeparator, values)}{LineSeparator}");
      }

      FileIO.Write(path, stb.ToString(), Configuration.Encoding);
    }

    private string GenerateHeader(string[] labels)
    {
      return string.Join(ValueSeparator, new List<string>(labels) {"Text"});
    }
  }
}