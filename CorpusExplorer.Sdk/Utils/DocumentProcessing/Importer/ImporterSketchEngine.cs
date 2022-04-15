using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer
{
  public class ImporterSketchEngine : AbstractImporterBase
  {
    private string[] _ignoreLine = new[] { "<?xml", "<corpus", "</corpus", "<doc ", "<s>", "<g/>", "<p ", "<p>", "</p>" };

    public List<string> PredefinedLayerDisplaynames { get; set; } = new List<string>
    {
      "Wort", "POS", "Lemma"
    };

    public string AdditionalLayerDisplaynamePattern { get; set; } = "Zusätzlicher Layer {0}";

    protected override void ExecuteCall(string path)
    {
      var lines = File.ReadAllLines(path, Configuration.Encoding);

      // Lade ggf. existierende Layernamen
      LoadLayerNames(path);

      var meta = new Dictionary<string, object>();
      var sent = new List<List<string>>(); // Layer / Token
      var docu = new List<List<string[]>>(); // Layer / Sentence / Token

      foreach (var line in lines)
      {
        if (_ignoreLine.Any(x => line.StartsWith(x.ToLower())))
          continue;

        var low = line.ToLower();

        // Wenn Satz zuende, füge den Satz dem Dokument hinzu
        if (low.StartsWith("</s>"))
        {
          FlushSentence(sent, docu);
          continue;
        }

        // Wenn Dokument zuende, füge das Dokument zum Korpus hinzu
        if (low.StartsWith("</text>") || low.StartsWith("</archive_file>") || low.StartsWith("</doc>"))
        {
          var guid = Guid.NewGuid();
          AddDocumentMetadata(guid,
                              meta.ToDictionary(
                                                x => x.Key,
                                                x => x.Value));

          if (sent.Count > 0)
            FlushSentence(sent, docu);

          for (var i = 0; i < docu.Count; i++)
          {
            var name = i < PredefinedLayerDisplaynames.Count
                         ? PredefinedLayerDisplaynames[i]
                         : string.Format(AdditionalLayerDisplaynamePattern, i - PredefinedLayerDisplaynames.Count + 1);

            AddDocument(name, guid, docu[i].ToArray());
          }

          meta.Clear();
          docu.Clear();

          continue;
        }

        if (low.StartsWith("<archive_file "))
        {
          AddMetadata(line, meta);
          continue;
        }

        if (low.StartsWith("<"))
          continue;

        var tokens = line.Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
        for (var i = 0; i < tokens.Length; i++)
        {
          if (sent.Count == i)
            sent.Add(new List<string>());

          sent[i].Add(tokens[i]);
        }
      }
    }

    private static void FlushSentence(List<List<string>> sent, List<List<string[]>> docu)
    {
      for (var i = 0; i < sent.Count; i++)
      {
        // Stelle sicher, dass Layer verfügbar ist.
        if (docu.Count == i)
          docu.Add(new List<string[]>());

        docu[i].Add(sent[i].ToArray());
      }

      sent.Clear();
    }

    private void LoadLayerNames(string path)
    {
      var fn = path + ".layer";
      if (!File.Exists(fn))
        return;

      try
      {
        PredefinedLayerDisplaynames = File.ReadAllLines(fn, Configuration.Encoding).ToList();
      }
      catch
      {
        // ignore
      }
    }

    private static void AddMetadata(string line, Dictionary<string, object> meta)
    {
      try
      {
        var fixedLine = !line.EndsWith("/>") ? line.Replace(">", "/>") : line;
        var docHead = XDocument.Parse(fixedLine);

        foreach (var x in docHead.Root.Attributes())
        {
          if (meta.ContainsKey(x.Name.LocalName))
            meta[x.Name.LocalName] = x.Value;
          else
            meta.Add(x.Name.LocalName, x.Value);
        }
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
      }
    }
  }
}
