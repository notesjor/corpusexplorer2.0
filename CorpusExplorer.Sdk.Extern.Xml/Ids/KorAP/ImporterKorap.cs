using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Ids.Exceptions;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.LoadStrategy;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.LoadStrategy.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Model.Virtual;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using HtmlAgilityPack;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP
{
  public class ImporterKorap : AbstractImporterBase
  {
    public bool ImportCoreNlp { get; set; } = true;
    public bool ImportMalt { get; set; } = true;
    public bool ImportMarmot { get; set; } = true;
    public bool ImportOpenNlp { get; set; } = true;
    public bool ImportTreeTagger { get; set; } = true;

    public bool Debug { get; set; } = false;
    public AbstractLoadStrategy Strategy { get; set; } = new LoadStrategyFileStream();

    private object _lockDebug = new object();
    private List<Exception> _debug = new List<Exception>();
    public IEnumerable<Exception> DebugLog
    {
      get
      {
        lock (_lockDebug)
          return _debug;
      }
    }

    protected override void ExecuteCall(string path)
    {
      var rawText = GetRawText(path);
      if (rawText.Length == 0)
        return;

      var entries = new Dictionary<string, Guid>(); // ZIP-Path | GUID - Zur Orientierung in der ZIP-Datei
      var references = new Dictionary<Guid, Dictionary<int, TokenReference[]>>(); // GUID | From & Token - Zum Nachschlagen von Poistionen
      var skeleton = new Dictionary<Guid, int[]>(); // GUID | Length = Sätze / Value = Token pro Satz - Zum Aufbauen von Referenzdokumenten

      BuildWortLayer(path, rawText, ref entries, ref references, ref skeleton);
      // ReSharper disable once RedundantAssignment
      rawText = null;
      GC.Collect();

      if (ImportTreeTagger)
        BuildTreeTagger(path, entries, references, skeleton);
      if (ImportCoreNlp)
        BuildCoreNlp(path, entries, references, skeleton);
      if (ImportMalt)
        BuildMalt(path, entries, references, skeleton);
      if (ImportMarmot)
        BuildMarMoT(path, entries, references, skeleton);
      if (ImportOpenNlp)
        BuildOpenNlp(path, entries, references, skeleton);
    }

    private AbstractLoadStrategy GetStrategy(string path, string ext) => Strategy.Create(path, ext);

    private void BuildTreeTagger(string path, Dictionary<string, Guid> entries,
                                 Dictionary<Guid, Dictionary<int, TokenReference[]>> references, Dictionary<Guid, int[]> skeleton)
    {
      try
      {
        using (var cache = GetStrategy(path, "tree_tagger"))
          if (cache != null)
            BuildTaggerFeatureMorpho(path, entries, references, skeleton, cache, "tree_tagger");
      }
      catch (Exception ex)
      {
        if (Debug)
          lock (_lockDebug)
            _debug.Add(new IdsException("tree_tagger", "/", ex));
      }
    }

    private void BuildCoreNlp(string path, Dictionary<string, Guid> entries,
                              Dictionary<Guid, Dictionary<int, TokenReference[]>> references, Dictionary<Guid, int[]> skeleton)
    {
      try
      {
        using (var cache = GetStrategy(path, "corenlp"))
        {
          if (cache == null)
            return;

          BuildTaggerFeatureMorpho(path, entries, references, skeleton, cache, "corenlp");
          BuildTaggerFeatureConstituency(path, entries, references, skeleton, cache, "corenlp");
        }
      }
      catch (Exception ex)
      {
        if (Debug)
          lock (_lockDebug)
            _debug.Add(new IdsException("corenlp", "/", ex));
      }
    }

    private void BuildMalt(string path, Dictionary<string, Guid> entries,
                           Dictionary<Guid, Dictionary<int, TokenReference[]>> references, Dictionary<Guid, int[]> skeleton)
    {
      try
      {
        using (var cache = GetStrategy(path, "malt"))
          if (cache != null)
            BuildTaggerFeatureDependency( path, entries, references, skeleton, cache, "malt");
      }
      catch (Exception ex)
      {
        if (Debug)
          lock (_lockDebug)
            _debug.Add(new IdsException("malt", "/", ex));
      }
    }

    private void BuildMarMoT(string path, Dictionary<string, Guid> entries,
                             Dictionary<Guid, Dictionary<int, TokenReference[]>> references, Dictionary<Guid, int[]> skeleton)
    {
      try
      {
        using (var cache = GetStrategy(path, "marmot"))
          if (cache != null)
            BuildTaggerFeatureMorpho(path, entries, references, skeleton, cache, "marmot");
      }
      catch (Exception ex)
      {
        if (Debug)
          lock (_lockDebug)
            _debug.Add(new IdsException("marmot", "/", ex));
      }
    }

    private void BuildOpenNlp(string path, Dictionary<string, Guid> entries,
                              Dictionary<Guid, Dictionary<int, TokenReference[]>> references, Dictionary<Guid, int[]> skeleton)
    {
      try
      {
        using (var cache = GetStrategy(path, "opennlp"))
          if (cache != null)
            BuildTaggerFeatureMorpho(path, entries, references, skeleton, cache, "opennlp");
      }
      catch (Exception ex)
      {
        if (Debug)
          lock (_lockDebug)
            _debug.Add(new IdsException("opennlp", "/", ex));
      }
    }

    private void BuildTaggerFeatureDependency(string path, Dictionary<string, Guid> entries, Dictionary<Guid, Dictionary<int, TokenReference[]>> references, Dictionary<Guid, int[]> skeleton, AbstractLoadStrategy als, string subfolder)
    {
      foreach (var entry in entries)
      {
        try
        {
          IEnumerable<HtmlNode> spans = null;
          try
          {
            var xml = new HtmlDocument();
            xml.Load(als.GetEntry($"{entry.Key}/{subfolder}/dependency.xml"));

            spans = xml.DocumentNode.SelectNodes("//span");
          }
          catch (Exception ex)
          {
            if (Debug)
              lock (_lockDebug)
                _debug.Add(new IdsException(path, $"{entry.Key}/{subfolder}/dependency.xml", ex));
          }

          if (spans == null)
            return;

          // Erstelle leeres Dokument
          var emptyDoc = new string[skeleton[entry.Value].Length][];
          for (var i = 0; i < skeleton[entry.Value].Length; i++)
            emptyDoc[i] = new string[skeleton[entry.Value][i]];

          var refDoc = references[entry.Value];

          var name = "DEP";
          var layers = new Dictionary<string, string[][]>
          {
            {name, emptyDoc.Select(a => a.ToArray()).ToArray()}
          };
          foreach (var span in spans)
          {
            var rel = span.SelectSingleNode("./rel")?.GetAttributeValue("label", "");
            if (string.IsNullOrEmpty(rel))
              continue;

            var idxF = int.Parse(span.GetAttributeValue("from", "-1"));
            var idxT = int.Parse(span.GetAttributeValue("to", "-1"));
            if (idxF == -1 || idxT == -1 || idxT < idxF)
              continue;

            foreach (var t in FindTokens(ref refDoc, idxF, idxT))
              layers[name][t.Sentence][t.Token] = rel;
          }

          foreach (var l in layers)
            AddDocument($"{l.Key} ({subfolder})", entry.Value, l.Value.Where(x => x.Length > 0).ToArray());
        }
        catch (Exception ex)
        {
          if (Debug)
            lock (_lockDebug)
              _debug.Add(ex);
        }
      }
    }

    private void BuildTaggerFeatureConstituency(string path, Dictionary<string, Guid> entries, Dictionary<Guid, Dictionary<int, TokenReference[]>> references, Dictionary<Guid, int[]> skeleton, AbstractLoadStrategy als, string subfolder)
    {
      foreach (var entry in entries)
      {
        try
        {
          IEnumerable<HtmlNode> spans = null;
          try
          {
            var xml = new HtmlDocument();
            xml.Load(als.GetEntry($"{entry.Key}/{subfolder}/constituency.xml"));

            spans = xml.DocumentNode.SelectNodes("//span");
          }
          catch (Exception ex)
          {
            if (Debug)
              lock (_lockDebug)
                _debug.Add(new IdsException(path, $"{entry.Key}/{subfolder}/constituency.xml", ex));
          }
          if (spans == null)
            return;

          // Erstelle leeres Dokument
          var emptyDoc = new string[skeleton[entry.Value].Length][];
          for (var i = 0; i < skeleton[entry.Value].Length; i++)
            emptyDoc[i] = new string[skeleton[entry.Value][i]];

          var refDoc = references[entry.Value];

          var layers = new Dictionary<string, string[][]>();
          foreach (var span in spans)
          {
            var idxF = int.Parse(span.GetAttributeValue("from", "-1"));
            var idxT = int.Parse(span.GetAttributeValue("to", "-1"));
            if (idxF == -1 || idxT == -1 || idxT < idxF)
              continue;

            var fs = span.SelectNodes("./fs/f");
            foreach (var f in fs)
            {
              var name = f.GetAttributeValue("name", "");
              if (string.IsNullOrEmpty(name)) // kein certainty-Filter nötig
                continue;

              // name = FixLayerName(name); - nicht nötig
              if (!layers.ContainsKey(name))
                layers.Add(name, emptyDoc.Select(a => a.ToArray()).ToArray());

              foreach (var t in FindTokens(ref refDoc, idxF, idxT))
                layers[name][t.Sentence][t.Token] = f.InnerText;
            }
          }

          foreach (var l in layers)
            AddDocument($"{l.Key} ({subfolder})", entry.Value, l.Value.Where(x => x.Length > 0).ToArray());
        }
        catch (Exception ex)
        {
          if (Debug)
            lock (_lockDebug)
              _debug.Add(ex);
        }
      }
    }

    private void BuildTaggerFeatureMorpho(string path, Dictionary<string, Guid> entries, Dictionary<Guid, Dictionary<int, TokenReference[]>> references, Dictionary<Guid, int[]> skeleton, AbstractLoadStrategy als, string subfolder)
    {
      foreach (var entry in entries)
      {
        try
        {
          IEnumerable<HtmlNode> spans = null;
          try
          {
            var xml = new HtmlDocument();
            xml.Load(als.GetEntry($"{entry.Key}/{subfolder}/morpho.xml"));

            spans = xml.DocumentNode.SelectNodes("//span");
          }
          catch (Exception ex)
          {
            if (Debug)
              lock (_lockDebug)
                _debug.Add(new IdsException(path, $"{entry.Key}/{subfolder}/morpho.xml", ex));
          }
          if (spans == null)
            return;

          // Erstelle leeres Dokument
          var emptyDoc = new string[skeleton[entry.Value].Length][];
          for (var i = 0; i < skeleton[entry.Value].Length; i++)
            emptyDoc[i] = new string[skeleton[entry.Value][i]];

          var refDoc = references[entry.Value];

          var layers = new Dictionary<string, string[][]>();
          foreach (var span in spans)
          {
            var idxF = int.Parse(span.GetAttributeValue("from", "-1"));
            var idxT = int.Parse(span.GetAttributeValue("to", "-1"));
            if (idxF == -1 || idxT == -1 || idxT < idxF)
              continue;

            var fs = span.SelectNodes("./fs/f/fs/f");
            foreach (var f in fs)
            {
              var name = f.GetAttributeValue("name", "");
              if (string.IsNullOrEmpty(name) || name == "certainty")
                continue;

              name = FixLayerName(name);
              if (!layers.ContainsKey(name))
                layers.Add(name, emptyDoc.Select(a => a.ToArray()).ToArray());

              foreach (var t in FindTokens(ref refDoc, idxF, idxT))
                layers[name][t.Sentence][t.Token] = f.InnerText;
            }
          }

          foreach (var l in layers)
            AddDocument($"{l.Key} ({subfolder})", entry.Value, l.Value.Where(x => x.Length > 0).ToArray());
        }
        catch (Exception ex)
        {
          if (Debug)
            lock (_lockDebug)
              _debug.Add(ex);
        }
      }
    }

    private IEnumerable<TokenReference> FindTokens(ref Dictionary<int, TokenReference[]> refDoc, int from, int to)
    {
      var res = new List<TokenReference>();
      for (var i = from; i < to; i++)
        if (refDoc.ContainsKey(i))
          res.AddRange(refDoc[i]);
      return res;
    }

    private static string FixLayerName(string name)
    {
      if (name == "ctag")
        name = "POS";
      if (name == "msd")
        name = "MSD";
      if (name == "pos")
        name = "POS";
      if (name == "lemma")
        name = "Lemma";
      return name;
    }

    private void BuildWortLayer(string path, Dictionary<string, object>[] rawText, ref Dictionary<string, Guid> entries,
                                ref Dictionary<Guid, Dictionary<int, TokenReference[]>> references,
                                ref Dictionary<Guid, int[]> skeleton)
    {
      try
      {
        using (var cache = GetStrategy(path, null))
          if (cache != null)
            foreach (var text in rawText)
            {
              try
              {
                var textRoot = text["ZipPath"].ToString();
                if (textRoot.EndsWith("/"))
                  textRoot = textRoot.Substring(0, textRoot.Length - 1);

                var entry = cache.GetEntry(textRoot + "/base/tokens.xml");
                // Fallback Kaskade
                // ReSharper disable ConvertIfStatementToNullCoalescingExpression
                if (entry == null)
                  entry = cache.GetEntry(textRoot + "/base/tokens_conservative.xml");
                if (entry == null)
                  entry = cache.GetEntry(textRoot + "/base/tokens_aggr.xml");
                // ReSharper restore ConvertIfStatementToNullCoalescingExpression

                var tokens = GetTokens(path, entry, text["Text"].ToString());
                if (tokens == null)
                {
                  if (Debug)
                    lock (_lockDebug)
                      _debug.Add(new FileNotFoundException($"{textRoot} - RawText"));
                  continue;
                }

                // GUID
                var dsel = Guid.NewGuid();
                entries.Add(textRoot, dsel);

                // Add Metadata
                text.Remove("Text");
                AddDocumentMetadata(dsel, text);

                var sentences = new List<int>();
                try
                {
                  var xml = new HtmlDocument();
                  xml.Load(cache.GetEntry(textRoot + "/struct/structure.xml"));

                  var spans = xml.DocumentNode.SelectNodes("//span");
                  foreach (var span in spans)
                  {
                    if (span.ChildNodes == null || span.ChildNodes.Count == 0)
                      sentences.Add(int.Parse(span.GetAttributeValue("to", "0")));
                    else
                    {
                      if (span.SelectSingleNode("./fs/f").InnerText == "s")
                        sentences.Add(int.Parse(span.GetAttributeValue("to", "0")));
                    }
                  }
                }
                catch (Exception ex)
                {
                  if (Debug)
                    lock (_lockDebug)
                      _debug.Add(new IdsException(path, textRoot + "/struct/structure.xml", ex));
                }

                var skel = new List<int>();
                var refs = new List<TokenReference>();
                var doc = new List<string[]>();
                var sent = new List<string>();
                var i = 0;

                if (sentences.Count == 0) // Fals Korap keine Sätze erkannt hat, erkenne Satzgrenzen mit Hilfe der Token
                {
                  var sentenceEndings = new HashSet<string> { ".", "!", "?", ";", ":" }; // STTS 2.0

                  for (; i < tokens.Count; i++)
                  {
                    refs.Add(new TokenReference(tokens[i].From, tokens[i].To, doc.Count, sent.Count));
                    sent.Add(tokens[i].Content);

                    if (sentenceEndings.Contains(tokens[i].Content))
                    {
                      skel.Add(sent.Count);
                      doc.Add(sent.ToArray());
                      sent.Clear();
                    }
                  }
                }
                else
                {
                  foreach (var s in sentences)
                  {
                    for (; i < tokens.Count; i++)
                    {
                      if (tokens[i].From >= s)
                      {
                        skel.Add(sent.Count);
                        doc.Add(sent.ToArray());
                        sent.Clear();
                        break;
                      }

                      refs.Add(new TokenReference(tokens[i].From, tokens[i].To, doc.Count, sent.Count));
                      sent.Add(tokens[i].Content);
                    }
                  }
                }

                if (sent.Count > 0)
                {
                  skel.Add(sent.Count);
                  doc.Add(sent.ToArray());
                  sent.Clear();
                }

                skeleton.Add(dsel, skel.ToArray());
                references.Add(dsel, TokenReferenceIndexBuilder(refs));
                AddDocument("Wort", dsel, doc.Where(x => x.Length > 0).ToArray());
              }
              catch (Exception ex)
              {
                if (Debug)
                  lock (_lockDebug)
                    _debug.Add(ex);
              }
            }
      }
      catch (Exception ex)
      {
        if (Debug)
          lock (_lockDebug)
            _debug.Add(new IdsException(path, "/", ex));
      }
    }

    private Dictionary<int, TokenReference[]> TokenReferenceIndexBuilder(List<TokenReference> refs)
    {
      var tmp = new Dictionary<int, List<TokenReference>>();
      foreach (var x in refs)
      {
        if (tmp.ContainsKey(x.From))
          tmp[x.From].Add(x);
        else
          tmp.Add(x.From, new List<TokenReference> { x });
      }

      return tmp.ToDictionary(x => x.Key, x => x.Value.ToArray());
    }

    private List<Token> GetTokens(string path, Stream entry, string textContent)
    {
      var res = new List<Token>();
      int f, t;
      try
      {
        var xml = new HtmlDocument();
        xml.Load(entry);

        var items = new List<Token>();
        foreach (var node in xml.DocumentNode.SelectNodes("//span"))
        {
          f = int.Parse(node.GetAttributeValue("from", "-1"));
          t = int.Parse(node.GetAttributeValue("to", "-1"));
          items.Add(new Token { From = f, To = t, Content = textContent.Substring(f, t - f) });
        }

        res.AddRange(items);
      }
      catch (Exception ex)
      {
        if (Debug)
          lock (_lockDebug)
            _debug.Add(new IdsException(path, "", ex));
        return null;
      }

      return res.Count == 0 ? null : res;
    }

    private Dictionary<string, object>[] GetRawText(string importFilePath)
    {
      var scraper = new KorapScraper { Debug = Debug, Strategy = Strategy };
      scraper.Input.Enqueue(importFilePath);
      scraper.Execute();

      // ReSharper disable once InvertIf
      if (Debug && scraper.DebugLog != null)
        lock (_lockDebug)
          _debug.AddRange(scraper.DebugLog);

      return scraper.Output.ToArray();
    }

    private string Reduce(string[] text)
      => text == null ? "" : string.Join(" ", text);
  }
}