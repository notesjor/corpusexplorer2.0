using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer
{
  public class ImporterCorpusWorkBench : AbstractImporterBase
  {
    private string[] _ignoreLine = new[] { "<?xml", "<corpus", "</corpus", "<seg_", "</seg_", "<s>", "<seg>", "<sentence" };

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
        if (low.StartsWith("</s>") || low.StartsWith("</seg>") || low.StartsWith("</sentence>"))
        {
          FlushSentence(sent, docu);
          continue;
        }

        // Wenn Dokument zuende, füge das Dokument zum Korpus hinzu
        if (low.StartsWith("</text>"))
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

        // Zusätzliche Metadaten in CWB (zulässig in alten Versionen)
        // Bsp. 1: <text_collection historical>
        // Bsp. 2: <text_period 1700-1750>
        if (low.StartsWith("<text_"))
        {
          AddMetadataStyleOld(line, meta);
          continue;
        }

        // Basismetadaten in CWB
        if (low.StartsWith("<text "))
        {
          AddMetadataStyleNew(line, meta);
          continue;
        }

        if(low.StartsWith("<"))
          continue;

        var tokens = line.Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
        if(tokens.Length < 2)
          continue;

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

    private static void AddMetadataStyleNew(string line, Dictionary<string, object> meta)
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

    private static void AddMetadataStyleOld(string line, Dictionary<string, object> meta)
    {
      try
      {
        var oldMeta = line.Replace("<text_", "").Replace("/>", "").Replace(">", "");
        var split = oldMeta.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

        var label = split[0];
        
        split.RemoveAt(0);

        if (meta.ContainsKey(label))
          meta[label] = string.Join(" ", split);
        else
          meta.Add(label, string.Join(" ", split));
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
      }
    }
  }
}
