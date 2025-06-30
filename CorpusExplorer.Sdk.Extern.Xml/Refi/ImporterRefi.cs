using CorpusExplorer.Sdk.Extern.Xml.Refi.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Extern.Xml.Refi.Strategy.Abstract;
using Telerik.Windows.Zip;
using CorpusExplorer.Sdk.Extern.Xml.Refi.Strategy;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Helper;

namespace CorpusExplorer.Sdk.Extern.Xml.Refi
{
  public class ImporterRefi : AbstractImporter
  {
    AbstractRefiLayerStrategy Strategy { get; set; } = new RefiLayerStrategyTop();

    protected override IEnumerable<AbstractCorpusAdapter> Execute(string importFilePath)
    {
      var importer = new ImporterInternalStandoffHelper();

      using (var fs = new FileStream(importFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
      using (var zip = ZipArchive.Read(fs))
      {
        var entry = zip.Entries.FirstOrDefault(e => e.Name.Equals("project.qde", StringComparison.OrdinalIgnoreCase));
        if (entry == null)
          return null;

        Project project = null;
        using (var stream = entry.Open())
        using (var reader = new StreamReader(stream, Encoding.UTF8))
        {
          var serializer = new XmlSerializer(typeof(Project));
          project = (Project)serializer.Deserialize(reader);
        }

        if (project == null)
          return null;

        var layerInfo = Strategy.GetLayerInfo(project.CodeBook.Codes);
        if (layerInfo == null || layerInfo.Count == 0)
          return null;

        foreach (var t in project.Sources)
        {
          try
          {
            string text = null;
            var textEntry = zip.Entries.FirstOrDefault(e => e.FullName.Equals($"sources/{t.guid}.txt", StringComparison.OrdinalIgnoreCase));

            if (textEntry == null)
              continue;

            using (var stream = textEntry.Open())
            using (var reader = new StreamReader(stream, Encoding.UTF8))
              text = reader.ReadToEnd() + " ";

            var meta = new Dictionary<string, object>
          {
            { "Titel", t.name },
            { "Guid", t.guid },
            { "Datum (zuletzt bearbeitet)", t.modifiedDateTime },
            { "Datum (erstellt)", t.creationDateTime }
          };

            var annotations = (from x in t.PlainTextSelection let info = layerInfo[x.Coding.CodeRef.targetGUID] select new ImporterInternalStandoffHelper.Annotation { Layer = info.Key, Value = info.Value, Start = int.Parse(x.startPosition), Stop = int.Parse(x.endPosition) }).ToArray();

            importer.AddText(text, meta, annotations);
          }
          catch (Exception ex)
          {
            InMemoryErrorConsole.Log(ex);
          }
        }

        return importer.Execute();
      }
    }
  }
}