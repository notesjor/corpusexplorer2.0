using Bcs.IO;
using CorpusExplorer.Sdk.Extern.Plaintext.RelAnnis.Helper;
using CorpusExplorer.Sdk.Extern.Plaintext.RelAnnis.NodeProcessor;
using CorpusExplorer.Sdk.Extern.Plaintext.RelAnnis.NodeProcessor.Abstract;
using CorpusExplorer.Sdk.Extern.Plaintext.RelAnnis.Stentenizer;
using CorpusExplorer.Sdk.Extern.Plaintext.RelAnnis.Stentenizer.Abstract;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.AdditionalTaggerWrapper.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Extern.Plaintext.RelAnnis
{
  public class ImporterRelAnnis : AbstractImporterBase
  {
    public AbstractRelAnnisSentenizer Sentenizer { get; set; } = new RelAnnisStentenizerSimpleDefault();
    public AbstractRelAnnisTokenValidator TokenValidator { get; set; } = new RelAnnisTokenValidatorDefault();

    protected override void ExecuteCall(string path)
    {
      path = Path.GetDirectoryName(path);

      var documentList = GetDocumentList(path);
      var documentMeta = GetDocumentMeta(path);
      var tokens = GetDocumentTokens(path);
      var sentences = Sentenizer.GetSentences(path);
      var layers = GetLayers(path);

      foreach (var doc in documentList)
      {
        var guid = Guid.NewGuid();
        var id = doc.Key;
        var name = doc.Value;
        var meta = documentMeta[id];

        AddDocumentMetadata(guid, meta);

        var sentence = sentences[id];

        var mask = AddAnnisLayerAndGetMask(guid, tokens[id], sentence);
        foreach (var layer in layers)
          AddAnnisLayer(guid, layer.Key, layer.Value, mask);
      }
    }

    private void AddAnnisLayer(Guid guid, string layerDisplayname, Dictionary<int, string> layerValues, int[][] mask)
    {
      var doc = new List<string[]>();
      foreach (var s in mask)
      {
        var sentence = new List<string>();
        foreach (var w in s)
          sentence.Add(layerValues.ContainsKey(w) ? layerValues[w] : "");

        doc.Add(sentence.ToArray());
      }

      AddDocument(layerDisplayname, guid, doc.ToArray());
    }

    private Dictionary<string, Dictionary<int, string>> GetLayers(string path)
    {
      var res = new Dictionary<string, Dictionary<int, string>>();

      var lines = FileIO.ReadLines(AnnisFileResolverHelper.ResolveAnnisEndings(path, "node_annotation"));
      if (lines != null)
        foreach (var line in lines)
        {
          var split = line.Split('\t');
          if (split.Length < 4)
            continue;

          var id = int.Parse(split[0]);
          var key = split[2];
          var value = split[3];

          if (!res.ContainsKey(key))
            res.Add(key, new Dictionary<int, string>());

          res[key].Add(id, value);
        }

      return res;
    }

    private int[][] AddAnnisLayerAndGetMask(Guid guid, Dictionary<int, string> tokens, List<KeyValuePair<int, int>> sentence)
    {
      var res = new List<int[]>();
      var doc = new List<string[]>();

      foreach (var s in sentence)
      {
        var start = s.Key;
        var end = s.Value;

        var ts = tokens.Where(x => x.Key >= start && x.Key <= end).OrderBy(x => x.Key).ToArray();

        doc.Add(ts.Select(x => x.Value).ToArray());
        res.Add(ts.Select(x => x.Key).ToArray());
      }

      AddDocument("Wort", guid, doc.ToArray());

      return res.ToArray(); // mask
    }

    private Dictionary<int, Dictionary<int, string>> GetDocumentTokens(string path)
    {
      var res = new Dictionary<int, Dictionary<int, string>>();

      var lines = FileIO.ReadLines(AnnisFileResolverHelper.ResolveAnnisEndings(path, "node"));
      if (lines != null)
        foreach (var line in lines)
        {
          var split = line.Split('\t');
          if (split.Length < 14)
            continue;

          var id = int.Parse(split[0]);
          var did = int.Parse(split[2]);
          var token = split[12];

          if (!TokenValidator.IsInvalid(split))
            continue;

          // FIX START
          if (token == "NULL")
            token = "";
          // FIX END

          if (!res.ContainsKey(did))
            res.Add(did, new Dictionary<int, string>());

          res[did].Add(id, token);
        }

      return res;
    }

    private Dictionary<int, Dictionary<string, object>> GetDocumentMeta(string path)
    {
      var res = new Dictionary<int, Dictionary<string, object>>();

      var lines = FileIO.ReadLines(AnnisFileResolverHelper.ResolveAnnisEndings(path, "corpus_annotation"));
      if (lines != null)
        foreach (var line in lines)
        {
          var split = line.Split('\t');
          if (split.Length < 4)
            continue;

          var id = int.Parse(split[0]);
          var key = split[2];
          var value = split[3];

          if (!res.ContainsKey(id))
            res.Add(id, new Dictionary<string, object>());

          res[id].Add(key, value);
        }

      return res;
    }

    private Dictionary<int, string> GetDocumentList(string path)
    {
      var res = new Dictionary<int, string>();

      var lines = FileIO.ReadLines(AnnisFileResolverHelper.ResolveAnnisEndings(path, "corpus"));
      if (lines != null)
        foreach (var line in lines)
        {
          var split = line.Split('\t');
          if (split.Length < 3)
            continue;

          if (split[2] != "DOCUMENT")
            continue;

          var id = int.Parse(split[0]);
          var name = split[1];

          res.Add(id, name);
        }

      return res;
    }
  }
}
