using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Extern.Xml.Ids.Exceptions;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Model.AnnoBase.Tokens;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Model.Virtual;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.ZipFileIndex;
using HtmlAgilityPack;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP
{
  public class ImporterKorap : AbstractImporterBase
  {
    protected bool ImportCoreNlp { get; set; } = true;
    protected bool ImportMalt { get; set; } = true;
    protected bool ImportMarmot { get; set; } = true;
    protected bool ImportOpenNlp { get; set; } = true;
    protected bool ImportTreeTagger { get; set; } = true;

    public bool Debug { get; set; } = false;
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
      if (Path.GetFileNameWithoutExtension(path).Contains("."))
        return;

      var rawText = GetRawText(path);
      if (rawText.Length == 0)
        return;

      var entries = new Dictionary<string, Guid>(); // ZIP-Path | GUID - Zur Orientierung in der ZIP-Datei
      var references = new Dictionary<Guid, Dictionary<int, TokenReference[]>>(); // GUID | From & Token - Zum Nachschlagen von Poistionen
      var skeleton = new Dictionary<Guid, int[]>(); // GUID | Length = Sätze / Value = Token pro Satz - Zum Aufbauen von Referenzdokumenten

      BuildWortLayer(path, rawText, ref entries, ref references, ref skeleton);
      // ReSharper disable once RedundantAssignment
      rawText = null;

      var tasks = new List<Task>();
      if (ImportTreeTagger)
        tasks.Add(Task.Run(() => { BuildTreeTagger(path, entries, references, skeleton); }));
      if (ImportCoreNlp)
        tasks.Add(Task.Run(() => { BuildCoreNlp(path, entries, references, skeleton); }));
      if (ImportMalt)
        tasks.Add(Task.Run(() => { BuildMalt(path, entries, references, skeleton); }));
      if (ImportMarmot)
        tasks.Add(Task.Run(() => { BuildMarMoT(path, entries, references, skeleton); }));
      if (ImportOpenNlp)
        tasks.Add(Task.Run(() => { BuildOpenNlp(path, entries, references, skeleton); }));

      Task.WaitAll(tasks.ToArray());

      if (Debug)
        lock (_lockDebug)
          foreach (var x in _debug)
            InMemoryErrorConsole.Log(x);
    }

    private void BuildTreeTagger(string path, Dictionary<string, Guid> entries,
                                 Dictionary<Guid, Dictionary<int, TokenReference[]>> references, Dictionary<Guid, int[]> skeleton)
    {
      var dir = Path.Combine(Path.GetDirectoryName(path), $"{Path.GetFileNameWithoutExtension(path)}.tree_tagger.zip");
      using (var zip = new ZipFileIndex(dir))
        BuildTaggerFeatureMorpho(entries, references, skeleton, zip, "tree_tagger");
    }

    private void BuildCoreNlp(string path, Dictionary<string, Guid> entries,
                              Dictionary<Guid, Dictionary<int, TokenReference[]>> references, Dictionary<Guid, int[]> skeleton)
    {
      var dir = Path.Combine(Path.GetDirectoryName(path), $"{Path.GetFileNameWithoutExtension(path)}.corenlp.zip");
      using (var zip = new ZipFileIndex(dir))
      {
        BuildTaggerFeatureMorpho(entries, references, skeleton, zip, "corenlp");
        BuildTaggerFeatureConstituency(entries, references, skeleton, zip, "corenlp");
      }
    }

    private void BuildMalt(string path, Dictionary<string, Guid> entries,
                           Dictionary<Guid, Dictionary<int, TokenReference[]>> references, Dictionary<Guid, int[]> skeleton)
    {
      var dir = Path.Combine(Path.GetDirectoryName(path), $"{Path.GetFileNameWithoutExtension(path)}.malt.zip");
      using (var zip = new ZipFileIndex(dir))
        BuildTaggerFeatureDependency(entries, references, skeleton, zip, "malt");
    }

    private void BuildMarMoT(string path, Dictionary<string, Guid> entries,
                             Dictionary<Guid, Dictionary<int, TokenReference[]>> references, Dictionary<Guid, int[]> skeleton)
    {
      var dir = Path.Combine(Path.GetDirectoryName(path), $"{Path.GetFileNameWithoutExtension(path)}.marmot.zip");
      using (var zip = new ZipFileIndex(dir))
        BuildTaggerFeatureMorpho(entries, references, skeleton, zip, "marmot");
    }

    private void BuildOpenNlp(string path, Dictionary<string, Guid> entries,
                              Dictionary<Guid, Dictionary<int, TokenReference[]>> references, Dictionary<Guid, int[]> skeleton)
    {
      var dir = Path.Combine(Path.GetDirectoryName(path), $"{Path.GetFileNameWithoutExtension(path)}.opennlp.zip");
      using (var zip = new ZipFileIndex(dir))
        BuildTaggerFeatureMorpho(entries, references, skeleton, zip, "opennlp");
    }

    private void BuildTaggerFeatureDependency(Dictionary<string, Guid> entries, Dictionary<Guid, Dictionary<int, TokenReference[]>> references, Dictionary<Guid, int[]> skeleton, ZipFileIndex zip, string subfolder)
    {
      Parallel.ForEach(entries, entry =>
      {
        try
        {
          Model.TaggerFeature.Dependency.layer layer = null;
          try
          {
            zip.Read($"{entry.Key}/{subfolder}/dependency.xml",
                        ms => { layer = XmlSerializerHelper.Deserialize<Model.TaggerFeature.Dependency.layer>(ms); });
          }
          catch (Exception ex)
          {
            if (Debug)
              lock (_lockDebug)
                _debug.Add(new IdsException(zip.Path, $"{entry.Key}/{subfolder}/dependency.xml", ex));
          }

          if (layer == null)
            return;

          // Erstelle leeres Dokument
          var emptyDoc = new string[skeleton[entry.Value].Length][];
          for (var i = 0; i < skeleton[entry.Value].Length; i++)
            emptyDoc[i] = new string[skeleton[entry.Value][i]];

          var refDoc = references[entry.Value];

          var layers = new Dictionary<string, string[][]>();
          foreach (var span in layer.spanList)
          {
            var name = "DEP";
            if (!layers.ContainsKey(name))
              layers.Add(name, emptyDoc.Select(a => a.ToArray()).ToArray());

            var val = span.rel?.label ?? string.Empty;

            foreach (var t in FindTokens(ref refDoc, int.Parse(span.@from), int.Parse(span.to)))
              layers[name][t.Sentence][t.Token] = val;
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
      });
    }

    private void BuildTaggerFeatureConstituency(Dictionary<string, Guid> entries, Dictionary<Guid, Dictionary<int, TokenReference[]>> references, Dictionary<Guid, int[]> skeleton, ZipFileIndex zip, string subfolder)
    {
      Parallel.ForEach(entries, entry =>
      {
        try
        {
          Model.TaggerFeature.Constituency.layer layer = null;
          try
          {
            zip.Read($"{entry.Key}/{subfolder}/constituency.xml", ms =>
            {
              layer = XmlSerializerHelper.Deserialize<Model.TaggerFeature.Constituency.layer>(ms);
            });
          }
          catch (Exception ex)
          {
            if (Debug)
              lock (_lockDebug)
                _debug.Add(new IdsException(zip.Path, $"{entry.Key}/{subfolder}/constituency.xml", ex));
          }
          if (layer == null)
            return;

          // Erstelle leeres Dokument
          var emptyDoc = new string[skeleton[entry.Value].Length][];
          for (var i = 0; i < skeleton[entry.Value].Length; i++)
            emptyDoc[i] = new string[skeleton[entry.Value][i]];

          var refDoc = references[entry.Value];

          var layers = new Dictionary<string, string[][]>();
          foreach (var span in layer.spanList)
          {
            var x = span.fs.f;
            var name = FixLayerName(x.name);
            if (!layers.ContainsKey(name))
              layers.Add(name, emptyDoc.Select(a => a.ToArray()).ToArray());

            var val = Reduce(x.Text);

            foreach (var t in FindTokens(ref refDoc, int.Parse(span.@from), int.Parse(span.to)))
              layers[name][t.Sentence][t.Token] = val;
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
      });
    }

    private void BuildTaggerFeatureMorpho(Dictionary<string, Guid> entries, Dictionary<Guid, Dictionary<int, TokenReference[]>> references, Dictionary<Guid, int[]> skeleton, ZipFileIndex zip, string subfolder)
    {
      Parallel.ForEach(entries, entry =>
      {
        try
        {
          Model.TaggerFeature.Morpho.layer layer = null;
          try
          {
            zip.Read($"{entry.Key}/{subfolder}/morpho.xml", ms =>
            {
              layer = XmlSerializerHelper.Deserialize<Model.TaggerFeature.Morpho.layer>(ms);
            });
          }
          catch (Exception ex)
          {
            if (Debug)
              lock (_lockDebug)
                _debug.Add(new IdsException(zip.Path, $"{entry.Key}/{subfolder}/morpho.xml", ex));
          }
          if (layer == null)
            return;

          // Erstelle leeres Dokument
          var emptyDoc = new string[skeleton[entry.Value].Length][];
          for (var i = 0; i < skeleton[entry.Value].Length; i++)
            emptyDoc[i] = new string[skeleton[entry.Value][i]];

          var refDoc = references[entry.Value];

          var layers = new Dictionary<string, string[][]>();
          foreach (var span in layer.spanList)
            foreach (var f in span.fs.f)
              foreach (var fs in f.fs)
                foreach (var x in fs.f)
                {
                  if (x.name == "certainty")
                    continue;

                  var name = FixLayerName(x.name);
                  if (!layers.ContainsKey(name))
                    layers.Add(name, emptyDoc.Select(a => a.ToArray()).ToArray());

                  var val = Reduce(x.Text);

                  foreach (var t in FindTokens(ref refDoc, int.Parse(span.@from), int.Parse(span.to)))
                    layers[name][t.Sentence][t.Token] = val;
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
      });
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
      using (var zip = new ZipFileIndex(path))
        foreach (var text in rawText)
        {
          try
          {
            var textRoot = text["ZipPath"].ToString();
            var tokens = GetTokens(text["Text"].ToString(), textRoot, zip);
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

            Model.AnnoBase.Structure.layer sentenceData = null;
            try
            {
              zip.Read(textRoot + "/struct/structure.xml", ms =>
              {
                sentenceData = XmlSerializerHelper.Deserialize<Model.AnnoBase.Structure.layer>(ms);
              });
            }
            catch (Exception ex)
            {
              if (Debug)
                lock (_lockDebug)
                  _debug.Add(new IdsException(zip.Path, textRoot + "/struct/structure.xml", ex));
            }
            if (sentenceData == null)
              return;

            // Sätze werden über das Ende (to) erkannt
            var sentences = (from span in sentenceData.spanList
                             where Reduce(span.fs?.f?[0].Text) == "s"
                             select int.Parse(span.to)).ToArray();

            var skel = new List<int>();
            var refs = new List<TokenReference>();
            var doc = new List<string[]>();
            var sent = new List<string>();
            var i = 0;

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

    private List<Token> GetTokens(string textContent, string textRoot, ZipFileIndex zip)
    {
      var res = new List<Token>();
      try
      {
        zip.Read(textRoot + "/base/tokens.xml", ms =>
        {
          var xml = new HtmlDocument();
          xml.Load(ms);

          res.AddRange(from node in xml.DocumentNode.SelectNodes("//span") let f = int.Parse(node.GetAttributeValue("from", "-1")) let t = int.Parse(node.GetAttributeValue("to", "-1")) select new Token {From = f, To = t, Content = textContent.Substring(f, t - f)});
        });
      }
      catch (Exception ex)
      {
        if (Debug)
          lock (_lockDebug)
            _debug.Add(new IdsException(zip.Path, textRoot + "/base/tokens.xml", ex));
        return null;
      }

      return res.Count == 0 ? null : res;
    }

    private static Dictionary<string, object>[] GetRawText(string importFilePath)
    {
      var scraper = new KorapScraper();
      scraper.Input.Enqueue(importFilePath);
      scraper.Execute();
      return scraper.Output.ToArray();
    }

    private string Reduce(string[] text)
      => text == null ? "" : string.Join(" ", text);
  }
}
