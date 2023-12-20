using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Extern.Xml.Ids.Exceptions;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.LoadStrategy;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.LoadStrategy.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP
{
  public class ImporterKorap : AbstractImporterBase
  {
    private static readonly HashSet<string>
      _sentenceEndings = new HashSet<string> { ".", "!", "?", ";", ":" }; // STTS 2.0

    private static readonly Dictionary<string, string> _layerNameFixes = new Dictionary<string, string>
    {
      { "ctag", "POS" },
      { "msd", "MSD" },
      { "pos", "POS" },
      { "lemma", "Lemma" }
    };

    private readonly List<Exception> _debug = new List<Exception>();

    private readonly object _lockDebug = new object();
    public bool ImportCoreNlp { get; set; } = true;
    public bool ImportMalt { get; set; } = true;
    public bool ImportMarmot { get; set; } = true;
    public bool ImportOpenNlp { get; set; } = true;
    public bool ImportTreeTagger { get; set; } = true;

    public bool ReadTaxonomy { get; set; } = false;
    public bool ReadLanguage { get; set; } = false;

    public bool Debug { get; set; } = false;
    public int HtmlDecodeRounds { get; set; } = 0;
    public AbstractKorapLoadStrategy LoadStrategy { get; set; }

    public IEnumerable<Exception> DebugLog
    {
      get
      {
        lock (_lockDebug)
        {
          return _debug;
        }
      }
    }

    private Regex _corpusRegex = new Regex(@"^[a-zA-Z0-9]*\/header\.xml$", RegexOptions.Compiled);
    private Regex _dataRegex = new Regex(@"^[a-zA-Z0-9]*\/[a-zA-Z0-9]*\/[a-zA-Z0-9]*\/data\.xml$", RegexOptions.Compiled);

    private void DefalutLoadStrategy(string path)
    {
      LoadStrategy = KorapLoadStrategyZipFile.AddonInitialize();
      LoadStrategy.Initialize(path);
    }

    protected override void ExecuteCall(string path)
    {
      if(LoadStrategy == null)
        DefalutLoadStrategy(path);

      ImportCoreNlp = ValidateFeature(ImportCoreNlp, path, "corenlp", out var corenlp);
      ImportMalt = ValidateFeature(ImportMalt, path, "malt", out var malt);
      ImportMarmot = ValidateFeature(ImportMarmot, path, "marmot", out var marmot);
      ImportOpenNlp = ValidateFeature(ImportOpenNlp, path, "opennlp", out var opennlp);
      ImportTreeTagger = ValidateFeature(ImportTreeTagger, path, "tree_tagger", out var tree_tagger);

      using (var zip = LoadStrategy.Initialize(path))
      {
        var helper = new KorapScraper { ReadTaxonomy = ReadTaxonomy, ReadLanguage = ReadLanguage, HtmlDecodeRounds = HtmlDecodeRounds, LoadStrategy = LoadStrategy }; // Helper

        // -- siehe ScraperKorap --> --> --> --> --> --> --> --> --> --> --> --> --> --> --> --> --> --> --> --> --> --> --> --> --> 
        var mainHeader = zip.Entries.Single(x => _corpusRegex.IsMatch(x));

        if (string.IsNullOrWhiteSpace(mainHeader))
          return;

        var header = helper.GetZipHeader(path, zip, mainHeader);
        if (header == null)
          return;

        var tDatas = zip.Entries.Where(x => _dataRegex.IsMatch(x)).ToArray();
        // <-- siehe ScraperKorap <-- <-- <-- <-- <-- <-- <-- <-- <-- <-- <-- <-- <-- <-- <-- <-- <-- <-- <-- <-- <-- <-- <-- <-- <-- 

        Parallel.ForEach(tDatas, Configuration.ParallelOptions, tData =>
        {
          try
          {
            // GUID
            var dsel = Guid.NewGuid();

            var textRoot = tData.Replace("data.xml", "");
            if (textRoot.EndsWith("/"))
              textRoot = textRoot.Substring(0, textRoot.Length - 1);

            // Add Metadata
            AddDocumentMetadata(dsel, helper.GetMetadata(zip, textRoot, header));

            var entryPath = FindEntryPath(zip, textRoot);

            if (!BuildWordLayer(path, zip, entryPath, ref helper, tData, textRoot, dsel, out var skeleton,
                  out var references))
              return;

            if (ImportCoreNlp)
            {
              BuildTaggerFeatureMorpho(corenlp, textRoot, "corenlp", dsel, skeleton, references, path);
              BuildTaggerFeatureConstituency(corenlp, textRoot, "corenlp", dsel, skeleton, references, path);
            }

            if (ImportMalt)
              BuildTaggerFeatureDependency(malt, textRoot, "malt", dsel, skeleton, references, path);
            if (ImportMarmot)
              BuildTaggerFeatureMorpho(marmot, textRoot, "marmot", dsel, skeleton, references, path);
            if (ImportOpenNlp)
              BuildTaggerFeatureMorpho(opennlp, textRoot, "opennlp", dsel, skeleton, references, path);
            if (ImportTreeTagger)
              BuildTaggerFeatureMorpho(tree_tagger, textRoot, "tree_tagger", dsel, skeleton, references, path);
          }
          catch (Exception ex)
          {
            if (Debug)
              lock (_lockDebug)
              {
                _debug.Add(ex);
              }
          }
        });
      }

      corenlp?.Dispose();
      malt?.Dispose();
      marmot?.Dispose();
      opennlp?.Dispose();
      tree_tagger?.Dispose();
    }

    private static string FindEntryPath(AbstractKorapLoadStrategy zip, string textRoot)
    {
      var entryPath = zip.Exists(textRoot + "/base/tokens.xml") ? textRoot + "/base/tokens.xml" : null;
      // Fallback Kaskade
      // ReSharper disable ConvertIfStatementToNullCoalescingExpression
      if (entryPath == null)
        entryPath = zip.Exists(textRoot + "/base/tokens_conservative.xml")
          ? textRoot + "/base/tokens_conservative.xml"
          : null;
      if (entryPath == null)
        entryPath = textRoot + "/base/tokens_aggr.xml";
      // ReSharper restore ConvertIfStatementToNullCoalescingExpression
      return entryPath;
    }

    private bool BuildWordLayer(string path, AbstractKorapLoadStrategy zip, string zipPath, ref KorapScraper helper, string tData,
      string textRoot, Guid dsel, out int[] skelOut, out Dictionary<int, int[][]> refsOut)
    {
      var currentText = helper.GetText(path, zip, tData);
      if (string.IsNullOrEmpty(currentText))
      {
        skelOut = null;
        refsOut = null;

        return false;
      }

      string[][] doc;
      var sentences = DetectSentences(zip, path, textRoot);
      if (sentences.Length > 0)
        GenerateText(zip, zipPath, currentText, out refsOut, out doc, out skelOut, sentences);
      else // Fals Korap keine Sätze erkannt hat, erkenne Satzgrenzen mit Hilfe der Token
        GenerateTextFallback(zip, zipPath, currentText, out refsOut, out doc, out skelOut);

      AddDocument("Wort", dsel, doc);

      return true;
    }

    private static int[] DetectSentences(AbstractKorapLoadStrategy zip, string path, string textRoot)
    {
      try
      {
        var xml = zip.ReadXml(textRoot + "/struct/structure.xml");

        var res = new List<int>();
        var spans = xml.SelectNodes("//*[local-name()='span']");
        foreach (XmlNode span in spans)
          if (span.ChildNodes == null || span.ChildNodes.Count == 0)
          {
            res.Add(int.Parse(span.GetAttribute("to", "0")));
          }
          else
          {
            if (span.GetFirstSubNodeRecursive("f").InnerText == "s")
              res.Add(int.Parse(span.GetAttribute("to", "0")));
          }

        return res.ToArray();
      }
      catch
      {
        return Array.Empty<int>();
      }
    }

    private static void GenerateText(AbstractKorapLoadStrategy zip, string zipPath, string currentText,
      out Dictionary<int, int[][]> refsOut, out string[][] docOut, out int[] skelOut, int[] sentences)
    {
      var xml = zip.ReadXmlClean(zipPath);
      var nodes = xml.SelectNodes("//*[local-name()='span']");

      var tmpRefs = new List<int[]>();
      var tmpDoc = new List<string[]>();
      var tmpSkel = new List<int>();

      var sent = new List<string>();

      var i = 0;

      foreach (var s in sentences)
        for (; i < nodes.Count; i++)
        {
          var n = nodes[i];

          var f = int.Parse(n.GetAttribute("from", "-1"));
          var t = int.Parse(n.GetAttribute("to", "-1"));

          if (f >= s)
          {
            tmpSkel.Add(sent.Count);
            tmpDoc.Add(sent.ToArray());
            sent.Clear();
            break;
          }

          tmpRefs.Add(new[] { f, t, tmpDoc.Count, sent.Count }); // from, to, sentence, token
          sent.Add(currentText.Substring(f, t - f));
        }

      if (sent.Count > 0)
      {
        tmpSkel.Add(sent.Count);
        tmpDoc.Add(sent.ToArray());
        sent.Clear();
      }

      refsOut = TokenReferenceIndexBuilder(tmpRefs);
      docOut = tmpDoc.ToArray();
      skelOut = tmpSkel.ToArray();
    }

    private static void GenerateTextFallback(AbstractKorapLoadStrategy zip, string zipPath, string currentText,
      out Dictionary<int, int[][]> refsOut, out string[][] docOut, out int[] skelOut)
    {
      var tmpRefs = new List<int[]>();
      var tmpDoc = new List<string[]>();
      var tmpSkel = new List<int>();

      var sent = new List<string>();

      var xml = zip.ReadXmlClean(zipPath);

      foreach (XmlNode n in xml.SelectNodes("//*[local-name()='span']"))
      {
        var f = int.Parse(n.GetAttribute("from", "-1"));
        var t = int.Parse(n.GetAttribute("to", "-1"));
        var token = currentText.Substring(f, t - f);

        tmpRefs.Add(new[] { f, t, tmpDoc.Count, sent.Count }); // from, to, sentence, token
        sent.Add(token);

        if (_sentenceEndings.Contains(token))
        {
          tmpSkel.Add(sent.Count);
          tmpDoc.Add(sent.ToArray());
          sent.Clear();
        }
      }

      if (sent.Count > 0)
      {
        tmpSkel.Add(sent.Count);
        tmpDoc.Add(sent.ToArray());
        sent.Clear();
      }

      refsOut = TokenReferenceIndexBuilder(tmpRefs);
      docOut = tmpDoc.ToArray();
      skelOut = tmpSkel.ToArray();
    }

    private bool ValidateFeature(bool featureSwitch, string path, string feature, out AbstractKorapLoadStrategy zip)
    {
      if (!featureSwitch)
      {
        zip = null;
        return false;
      }

      try
      {
        zip = LoadStrategy.Initialize(Path.Combine(Path.GetDirectoryName(path),
          $"{Path.GetFileNameWithoutExtension(path)}.{feature}.zip"));
        return true;
      }
      catch
      {
        zip = null;
        return false;
      }
    }

    private void BuildTaggerFeatureDependency(AbstractKorapLoadStrategy zip, string textRoot, string subfolder, Guid dsel,
      int[] skeleton, Dictionary<int, int[][]> references, string path)
    {
      try
      {
        XmlNodeList spans = null;
        try
        {
          XmlDocument xml;
          xml = zip.ReadXml($"{textRoot}/{subfolder}/dependency.xml");

          spans = xml.SelectNodes("//*[local-name()='span']");
        }
        catch (Exception ex)
        {
          if (Debug)
            lock (_lockDebug)
            {
              _debug.Add(new IdsException(path, $"{textRoot}/{subfolder}/dependency.xml", ex));
            }
        }

        if (spans == null)
          return;

        // Erstelle leeres Dokument
        var emptyDoc = new string[skeleton.Length][];
        for (var i = 0; i < skeleton.Length; i++)
          emptyDoc[i] = new string[skeleton[i]];

        var name = "DEP";
        var layers = new Dictionary<string, string[][]>
        {
          { name, emptyDoc.Select(a => a.ToArray()).ToArray() }
        };
        foreach (XmlNode span in spans)
        {
          var rel = span.GetSimpleXpathFirst("/rel")?.GetAttribute("label", "");
          if (string.IsNullOrEmpty(rel))
            continue;

          var idxF = int.Parse(span.GetAttribute("from", "-1"));
          var idxT = int.Parse(span.GetAttribute("to", "-1"));
          if (idxF == -1 || idxT == -1 || idxT < idxF)
            continue;

          foreach (var t in FindTokens(ref references, idxF, idxT))
            layers[name][t[2]][t[3]] = rel; // t[2] = sentence / t[3] = token
        }

        foreach (var l in layers)
          AddDocument($"{l.Key} ({subfolder})", dsel, l.Value.Where(x => x.Length > 0).ToArray());
      }
      catch (Exception ex)
      {
        if (Debug)
          lock (_lockDebug)
          {
            _debug.Add(ex);
          }
      }
    }

    private void BuildTaggerFeatureConstituency(AbstractKorapLoadStrategy zip, string textRoot, string subfolder, Guid dsel,
      int[] skeleton, Dictionary<int, int[][]> references, string path)
    {
      try
      {
        XmlNodeList spans = null;
        try
        {
          XmlDocument xml;
          xml = zip.ReadXml($"{textRoot}/{subfolder}/constituency.xml");

          spans = xml.SelectNodes("//*[local-name()='span']");
        }
        catch (Exception ex)
        {
          if (Debug)
            lock (_lockDebug)
            {
              _debug.Add(new IdsException(path, $"{textRoot}/{subfolder}/constituency.xml", ex));
            }
        }

        if (spans == null)
          return;

        // Erstelle leeres Dokument
        var emptyDoc = new string[skeleton.Length][];
        for (var i = 0; i < skeleton.Length; i++)
          emptyDoc[i] = new string[skeleton[i]];

        var layers = new Dictionary<string, string[][]>();
        foreach (XmlNode span in spans)
        {
          var idxF = int.Parse(span.GetAttribute("from", "-1"));
          var idxT = int.Parse(span.GetAttribute("to", "-1"));
          if (idxF == -1 || idxT == -1 || idxT < idxF)
            continue;

          var fs = span.GetSimpleXpath("/fs/f");
          foreach (var f in fs)
          {
            var name = f.GetAttribute("name", "");
            if (string.IsNullOrEmpty(name)) // kein certainty-Filter nötig
              continue;

            // name = FixLayerName(name); - nicht nötig
            if (!layers.ContainsKey(name))
              layers.Add(name, emptyDoc.Select(a => a.ToArray()).ToArray());

            foreach (var t in FindTokens(ref references, idxF, idxT))
              layers[name][t[2]][t[3]] = f.InnerText; // t[2] = sentence / t[3] = token
          }
        }

        foreach (var l in layers)
          AddDocument($"{l.Key} ({subfolder})", dsel, l.Value.Where(x => x.Length > 0).ToArray());
      }
      catch (Exception ex)
      {
        if (Debug)
          lock (_lockDebug)
          {
            _debug.Add(ex);
          }
      }
    }

    private void BuildTaggerFeatureMorpho(AbstractKorapLoadStrategy zip, string textRoot, string subfolder, Guid dsel, int[] skeleton,
      Dictionary<int, int[][]> references, string path)
    {
      try
      {
        XmlNodeList spans = null;
        try
        {
          XmlDocument xml;
          xml = zip.ReadXml($"{textRoot}/{subfolder}/morpho.xml");

          spans = xml.DocumentElement.SelectNodes("//*[local-name()='span']");
        }
        catch (Exception ex)
        {
          if (Debug)
            lock (_lockDebug)
            {
              _debug.Add(new IdsException(path, $"{textRoot}/{subfolder}/morpho.xml", ex));
            }
        }

        if (spans == null)
          return;

        // Erstelle leeres Dokument
        var emptyDoc = new string[skeleton.Length][];
        for (var i = 0; i < skeleton.Length; i++)
          emptyDoc[i] = new string[skeleton[i]];

        var layers = new Dictionary<string, string[][]>();
        foreach (XmlNode span in spans)
        {
          var idxF = int.Parse(span.GetAttribute("from", "-1"));
          var idxT = int.Parse(span.GetAttribute("to", "-1"));
          if (idxF == -1 || idxT == -1 || idxT < idxF)
            continue;

          var fs = span.GetSimpleXpath("/fs/f/fs/f");
          foreach (var f in fs)
          {
            var name = f.GetAttribute("name", "");
            if (string.IsNullOrEmpty(name) || name == "certainty")
              continue;

            name = FixLayerName(name);
            if (!layers.ContainsKey(name))
              layers.Add(name, emptyDoc.Select(a => a.ToArray()).ToArray());

            foreach (var t in FindTokens(ref references, idxF, idxT))
              layers[name][t[2]][t[3]] = f.InnerText; // t[2] = sentence / t[3] = token
          }
        }

        foreach (var l in layers)
          AddDocument($"{l.Key} ({subfolder})", dsel, l.Value.Where(x => x.Length > 0).ToArray());
      }
      catch (Exception ex)
      {
        if (Debug)
          lock (_lockDebug)
          {
            _debug.Add(ex);
          }
      }
    }

    private static IEnumerable<int[]> FindTokens(ref Dictionary<int, int[][]> refDoc, int from, int to)
    {
      var res = new List<int[]>();
      for (var i = from; i < to; i++)
        if (refDoc.ContainsKey(i))
          res.AddRange(refDoc[i]);
      return res;
    }

    private static string FixLayerName(string name)
    {
      return _layerNameFixes.ContainsKey(name) ? _layerNameFixes[name] : name;
    }

    private static Dictionary<int, int[][]> TokenReferenceIndexBuilder(List<int[]> refs)
    {
      var tmp = new Dictionary<int, List<int[]>>();
      foreach (var x in refs)
        if (tmp.ContainsKey(x[0]))
          tmp[x[0]].Add(x);
        else
          tmp.Add(x[0], new List<int[]> { x });

      return tmp.ToDictionary(x => x.Key, x => x.Value.ToArray());
    }
  }
}