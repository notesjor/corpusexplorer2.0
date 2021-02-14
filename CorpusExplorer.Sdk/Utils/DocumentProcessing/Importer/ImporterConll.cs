using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer
{
  public class ImporterConll : AbstractImporterSimple3Steps<string[]>
  {
    internal static string[] _layerNames =
      {"ID", "Wort", "Lemma", "UPOS", "POS", "FEATS", "HEAD", "DEPREL", "DEPS", "MISC"};

    protected override string[] ImportStep_1_ReadFile(string path)
    {
      return File.ReadAllLines(path, Configuration.Encoding);
    }

    protected override void ImportStep_2_ImportMetadata(Guid documentGuid, ref string[] data)
    {
      AddCorpusMetadata("IMPORT_FROM", "CoNLL");
      AddDocumentMetadata(documentGuid, new Dictionary<string, object>());
    }

    protected override void ImportStep_3_ImportContent(Guid documentGuid, ref string[] data)
    {
      var docs = _layerNames.ToDictionary(x => x, x => new List<string[]>());
      var sent = _layerNames.ToDictionary(x => x, x => new List<string>());

      foreach (var line in data)
      {
        if (line.StartsWith("#"))
          continue;

        if (string.IsNullOrWhiteSpace(line))
        {
          if (sent[_layerNames[0]].Count > 0)
            foreach (var s in sent)
            {
              docs[s.Key].Add(s.Value.ToArray());
              s.Value.Clear();
            }

          continue;
        }

        var items = line.Split(new[] {"\t", " "}, StringSplitOptions.RemoveEmptyEntries);
        if (items.Length != _layerNames.Length)
          continue;

        for (var i = 0; i < items.Length; i++)
          sent[_layerNames[i]].Add(items[i]);
      }

      if (sent[_layerNames[0]].Count > 0)
        foreach (var s in sent)
        {
          docs[s.Key].Add(s.Value.ToArray());
          s.Value.Clear();
        }

      foreach (var doc in docs)
        AddDocument(doc.Key, documentGuid, doc.Value.ToArray());
    }
  }
}