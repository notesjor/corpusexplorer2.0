using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Model.TaggerFeature.Morpho;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Model.Virtual;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Serializer.AnnoBase.Structure;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Serializer.AnnoBase.Tokens;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Serializer.TaggerFeature;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.ZipFileIndex;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP
{
  public class ImporterKorap : AbstractImporterBase
  {
    private AnnoBaseTokensSerializer _tokenizer = new AnnoBaseTokensSerializer();
    private AnnoBaseStructureSerializer _sentenizer = new AnnoBaseStructureSerializer();
    private TaggerFeatureConstituencySerializer _constituencySerializer = new TaggerFeatureConstituencySerializer();
    private TaggerFeatureDependencySerializer _dependencySerializer = new TaggerFeatureDependencySerializer();
    private TaggerFeatureMorphoSerializer _morphoSerializer = new TaggerFeatureMorphoSerializer();

    public bool Debug { get; set; } = false;

    public bool ImportCoreNlp { get; set; } = true;
    public bool ImportMalt { get; set; } = true;
    public bool ImportMarmot { get; set; } = true;
    public bool ImportOpenNlp { get; set; } = true;
    public bool ImportTreeTagger { get; set; } = true;

    protected override void ExecuteCall(string path)
    {
      if (Path.GetFileNameWithoutExtension(path).Contains("."))
        return;

      var rawText = GetRawText(path);
      if (rawText.Length == 0)
        return;

      var entries = new Dictionary<string, Guid>(); // ZIP-Path | GUID - Zur Orientierung in der ZIP-Datei
      var references = new Dictionary<Guid, List<TokenReference>>(); // GUID | Token - Zum Nachschlagen von Poistionen
      var skeleton = new Dictionary<Guid, int[]>(); // GUID | Length = Sätze / Value = Token pro Satz - Zum Aufbauen von Referenzdokumenten

      BuildWortLayer(path, rawText, ref entries, ref references, ref skeleton);

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

    private void BuildTreeTagger(string path, Dictionary<string, Guid> entries,
                                 Dictionary<Guid, List<TokenReference>> references, Dictionary<Guid, int[]> skeleton)
    {
      var dir = Path.Combine(Path.GetDirectoryName(path), $"{Path.GetFileNameWithoutExtension(path)}.tree_tagger.zip");
      var zip = new ZipFileIndex(dir);

      BuildTaggerFeatureMorpho(entries, references, skeleton, zip, "tree_tagger");
    }

    private void BuildCoreNlp(string path, Dictionary<string, Guid> entries,
                              Dictionary<Guid, List<TokenReference>> references, Dictionary<Guid, int[]> skeleton)
    {
      var dir = Path.Combine(Path.GetDirectoryName(path), $"{Path.GetFileNameWithoutExtension(path)}.corenlp.zip");
      var zip = new ZipFileIndex(dir);

      BuildTaggerFeatureMorpho(entries, references, skeleton, zip, "corenlp");
      BuildTaggerFeatureConstituency(entries, references, skeleton, zip, "corenlp");
    }

    private void BuildMalt(string path, Dictionary<string, Guid> entries,
                           Dictionary<Guid, List<TokenReference>> references, Dictionary<Guid, int[]> skeleton)
    {
      var dir = Path.Combine(Path.GetDirectoryName(path), $"{Path.GetFileNameWithoutExtension(path)}.malt.zip");
      var zip = new ZipFileIndex(dir);

      BuildTaggerFeatureDependency(entries, references, skeleton, zip, "malt");
    }

    private void BuildMarMoT(string path, Dictionary<string, Guid> entries,
                             Dictionary<Guid, List<TokenReference>> references, Dictionary<Guid, int[]> skeleton)
    {
      var dir = Path.Combine(Path.GetDirectoryName(path), $"{Path.GetFileNameWithoutExtension(path)}.marmot.zip");
      var zip = new ZipFileIndex(dir);

      BuildTaggerFeatureMorpho(entries, references, skeleton, zip, "marmot");
    }

    private void BuildOpenNlp(string path, Dictionary<string, Guid> entries,
                              Dictionary<Guid, List<TokenReference>> references, Dictionary<Guid, int[]> skeleton)
    {
      var dir = Path.Combine(Path.GetDirectoryName(path), $"{Path.GetFileNameWithoutExtension(path)}.opennlp.zip");
      var zip = new ZipFileIndex(dir);

      BuildTaggerFeatureMorpho(entries, references, skeleton, zip, "opennlp");
    }

    private void BuildTaggerFeatureDependency(Dictionary<string, Guid> entries, Dictionary<Guid, List<TokenReference>> references, Dictionary<Guid, int[]> skeleton, ZipFileIndex zip, string subfolder)
    {
      foreach (var entry in entries)
      {
        Model.TaggerFeature.Dependency.layer layer = null;
        zip.Extract($"{entry.Key}/{subfolder}/dependency.xml", ms => { layer = _dependencySerializer.Deserialize(ms); });
        if (layer == null)
        {
          if (Debug)
            throw new FileNotFoundException($"{entry.Key}/{subfolder}/dependency.xml");
          continue;
        }

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
          AddDocumet($"{l.Key} ({subfolder})", entry.Value, l.Value);
      }
    }

    private void BuildTaggerFeatureConstituency(Dictionary<string, Guid> entries, Dictionary<Guid, List<TokenReference>> references, Dictionary<Guid, int[]> skeleton, ZipFileIndex zip, string subfolder)
    {
      foreach (var entry in entries)
      {
        Model.TaggerFeature.Constituency.layer layer = null;
        zip.Extract($"{entry.Key}/{subfolder}/constituency.xml", ms => { layer = _constituencySerializer.Deserialize(ms); });
        if (layer == null)
        {
          if (Debug)
            throw new FileNotFoundException($"{entry.Key}/{subfolder}/constituency.xml");
          continue;
        }

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
          AddDocumet($"{l.Key} ({subfolder})", entry.Value, l.Value);
      }
    }

    private void BuildTaggerFeatureMorpho(Dictionary<string, Guid> entries, Dictionary<Guid, List<TokenReference>> references, Dictionary<Guid, int[]> skeleton, ZipFileIndex zip, string subfolder)
    {
      foreach (var entry in entries)
      {
        Model.TaggerFeature.Morpho.layer layer = null;
        zip.Extract($"{entry.Key}/{subfolder}/morpho.xml", ms => { layer = _morphoSerializer.Deserialize(ms); });
        if (layer == null)
        {
          if (Debug)
            throw new FileNotFoundException($"{entry.Key}/{subfolder}/morpho.xml");
          continue;
        }

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
          AddDocumet($"{l.Key} ({subfolder})", entry.Value, l.Value);
      }
    }

    private IEnumerable<TokenReference> FindTokens(ref List<TokenReference> refDoc, int from, int to)
      => refDoc.Where(x => x.From >= @from && x.From < to);

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
                                ref Dictionary<Guid, List<TokenReference>> references,
                                ref Dictionary<Guid, int[]> skeleton)
    {
      var zip = new ZipFileIndex(path);
      foreach (var text in rawText)
      {
        var textRoot = text["ZipPath"].ToString();
        var tokens = GetTokens(text["Text"].ToString(), textRoot, zip);
        if (tokens == null)
        {
          if (Debug)
            throw new FileNotFoundException($"{textRoot} - RawText");
          continue;
        }

        // GUID
        var dsel = Guid.NewGuid();
        entries.Add(textRoot, dsel);

        // Add Metadata
        text.Remove("Text");
        AddDocumentMetadata(dsel, text);

        Model.AnnoBase.Structure.layer sentenceData = null;
        zip.Extract(textRoot + "/struct/structure.xml", ms => { sentenceData = _sentenizer.Deserialize(ms); });
        if (sentenceData == null)
        {
          if (Debug)
            throw new FileNotFoundException($"{textRoot} - StructureXml");
          continue;
        }

        // Sätze werden über das Ende (to) erkannt
        var sentences = (from span in sentenceData.spanList where Reduce(span.fs?.f?[0].Text) == "s" select int.Parse(span.to)).ToArray();

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
        references.Add(dsel, refs);
        AddDocumet("Wort", dsel, doc.ToArray());
      }
    }

    private List<Token> GetTokens(string textContent, string textRoot, ZipFileIndex zip)
    {
      Model.AnnoBase.Tokens.layer tokenizeData = null;
      zip.Extract(textRoot + "/base/tokens.xml", ms => { tokenizeData = _tokenizer.Deserialize(ms); });
      if (tokenizeData == null)
        return null;

      return (from span
                in tokenizeData.spanList
              let @from = int.Parse(span.@from)
              let to = int.Parse(span.to)
              select new Token
              {
                From = @from,
                To = to,
                Content = textContent.Substring(@from, to - @from)
              }).ToList();
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
