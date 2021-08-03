using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.Json.SimpleStandoff.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Sentenizer;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Sentenizer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer.Abstract;
using CorpusExplorer.Sdk.Utils.ReMapper;
using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.SimpleStandoff
{
  public class SimpleJsonStandoffImporter : AbstractImporterBase
  {
    public AbstractTokenizer Tokenizer { get; set; } = new HighSpeedSpaceTokenizer();
    public AbstractSentenizer Sentenizer { get; set; } = new QuickSentenizer();

    protected override void ExecuteCall(string path)
    {
      var document = JsonConvert.DeserializeObject<Document>(File.ReadAllText(path, Configuration.Encoding));

      if (document?.Annotations == null)
        return;

      var guid = Guid.NewGuid();
      AddDocumentMetadata(guid, document.Metadata ?? new Dictionary<string, object>());
      var layers = SplitLayer(document);

      if (!string.IsNullOrEmpty(document.Text))
        StrategyPlaintext(guid, document.Text, layers);

      if (document.TextToken != null)
        StrategyTokenized(guid, document.TextToken, layers);

      if (document.TextSentenceToken != null)
        StrategySentenceToken(guid, document.TextSentenceToken, layers);
    }

    private void StrategyPlaintext(Guid guid, string text, Dictionary<string, List<Annotation>> layers)
    {
      var sentenceToken = Sentenizer.Execute(Tokenizer.ExecuteToArray(text));
      StrategySentenceToken(guid, sentenceToken, TransformAnnotationsCharToToken(layers, text, sentenceToken));
    }

    private void StrategyTokenized(Guid guid, string[] tokens, Dictionary<string, List<Annotation>> layers)
    {
      var sentenceToken = Sentenizer.Execute(tokens);
      StrategySentenceToken(guid, sentenceToken, TransformAnnotationsTokenToSentenceToken(layers, sentenceToken));
    }

    private void StrategySentenceToken(Guid guid, string[][] sentenceToken, Dictionary<string, List<Annotation>> layers)
    {
      AddDocument("Wort", guid, sentenceToken);

      foreach (var layer in layers)
      {
        var lDoc = CloneDocument(ref sentenceToken);

        foreach (var a in layer.Value)
          for (var s = a.FromSentence; s <= a.ToSentence; s++)
          for (var t = (s == a.FromSentence ? a.From : 0); t < (s == a.ToSentence ? (a.To > lDoc[s].Length ? lDoc[s].Length : a.To) : lDoc[s].Length); t++)
          {
            try
            {
              lDoc[s][t] = a.LayerValue;
            }
            catch
            {
              // ignore
            }
          }

        AddDocument(layer.Key, guid, lDoc);
      }
    }

    private Dictionary<string, List<Annotation>> TransformAnnotationsCharToToken(Dictionary<string, List<Annotation>> layers, string origText, string[][] refToken)
    {
      var remapper = new ReMapperStandoff();
      var alignment = remapper.ExtractAlignment(origText, refToken);

      foreach (var layer in layers)
      {
        foreach (var a in layer.Value)
        {
          try
          {
            var matches = alignment.Where(x => x.TextCharFrom >= a.From && x.TextCharTo <= a.To).Select(x=> alignment.IndexOf(x)).ToArray();
            var min = matches.Min(x => x);
            var max = matches.Max(x => x);

            a.From = alignment[min].TokenIndex;
            a.To = alignment[max].TokenIndex + 1;
            a.FromSentence = alignment[min].SentenceIndex;
            a.ToSentence = alignment[max].SentenceIndex;
          }
          catch
          {
            // ignore
          }
        }
      }

      return layers;
    }

    private Dictionary<string, List<Annotation>> TransformAnnotationsTokenToSentenceToken(Dictionary<string, List<Annotation>> layers, string[][] refSentenceToken)
    {
      var tokens = new List<AnnotationSentenceMark>();
      for (var s = 0; s < refSentenceToken.Length; s++)
      {
        for (var t = 0; t < refSentenceToken[s].Length; t++)
        {
          tokens.Add(new AnnotationSentenceMark
          {
            Token = t,
            Index = tokens.Count,
            Sentence = s
          });
        }
      }

      foreach (var layer in layers)
        foreach (var a in layer.Value)
        {
          var matches = tokens.Where(x => x.Index >= a.From && x.Index <= a.To).OrderBy(x => x.Index).ToArray();
          var min = matches.First();
          var max = matches.Last();

          a.From = min.Token;
          a.FromSentence = min.Sentence;
          a.To = max.Token;
          a.ToSentence = max.Sentence;
        }

      return layers;
    }

    private struct AnnotationSentenceMark
    {
      public int Index;
      public int Token;
      public int Sentence;
    }

    private string[][] CloneDocument(ref string[][] document)
    {
      var list = new List<string[]>();
      foreach (var s in document)
      {
        var arr = new string[s.Length];
        for (var i = 0; i < arr.Length; i++)
          arr[i] = string.Empty;
        list.Add(arr);
      }

      return list.ToArray();
    }

    private Dictionary<string, List<Annotation>> SplitLayer(Document document)
    {
      var res = new Dictionary<string, List<Annotation>>();
      foreach (var anno in document.Annotations)
      {
        if (!res.ContainsKey(anno.Layer))
          res.Add(anno.Layer, new List<Annotation>());

        res[anno.Layer].Add(anno);
      }

      return res;
    }
  }
}
