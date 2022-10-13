#region

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using Newtonsoft.Json;

#endregion

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter
{
  public class ExporterJsonZip : AbstractExporter
  {
    public override void Export(IHydra hydra, string zipPath)
    {

      using (var fs = new FileStream(zipPath, FileMode.Create, FileAccess.Write))
      using (var zip = new ZipArchive(fs, ZipArchiveMode.Create, false, null))
        foreach (var csel in hydra.CorporaAndDocumentGuids)
        {
          // csel.Key.ToString() TODO
          var corpus = hydra.GetCorpus(csel.Key);
          if (corpus == null)
            continue;

          // Erzeuge Index.json (Guid > Dokumentnamen - Dictionary)
          Write(zip, $"{csel.Key:N}/doc.index.json", 
            JsonConvert.SerializeObject(
            csel.Value.ToDictionary(
              x => x.ToString("N"),
              hydra.GetDocumentDisplayname)));

          // Erzeuge Index.json (Guid > Layernamen - Dictionary)
          Write(zip, $"{csel.Key:N}/layer.index.json", 
            JsonConvert.SerializeObject(
            corpus.LayerGuidAndDisplaynames.ToDictionary(
              x => x.Key.ToString("N"),
              x => x.Value)));

          // Speichere alle Dokumente
          foreach (var dsel in csel.Value)
          {
            // (root, dsel.ToString("N")); TODO

            // Speichere die Dokument-Metadaten
            Write(zip, $"{csel.Key:N}/{dsel:N}/doc.meta.json", 
              JsonConvert.SerializeObject(corpus.GetDocumentMetadata(dsel)));

            // Gebe die Layerdaten des Dokuments aus
            foreach (var layer in corpus.Layers)
            {
              if (!layer.ContainsDocument(dsel))
                continue;

              //CombineAndEnsureDirectoryExsists(dpath, lguid.ToString()); TODO
              Write(zip, $"{csel.Key:N}/{dsel:N}/{layer.Guid:N}/doc.data.json", JsonConvert.SerializeObject(
                layer.GetReadableDocumentByGuid(dsel)
                  .Select(d => d.ToArray())
                  .ToArray()));
            }
          }
        }
    }

    private void Write(ZipArchive zip, string name, string content)
    {
      var entry = zip.CreateEntry(name);
      using (var stream = entry.Open())
      using (var writer = new StreamWriter(stream, Configuration.Encoding))
        writer.Write(content);
    }
  }
}