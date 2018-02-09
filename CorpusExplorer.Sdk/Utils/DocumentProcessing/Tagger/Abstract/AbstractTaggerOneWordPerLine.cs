﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Core.DocumentProcessing.Tokenizer;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract
{
  public abstract class AbstractTaggerOneWordPerLine : AbstractTagger
  {
    protected ConcurrentQueue<Dictionary<string, object>[]> InternQueue =
      new ConcurrentQueue<Dictionary<string, object>[]>();

    private readonly Dictionary<string, AbstractLayerState> _layers =
      new Dictionary<string, AbstractLayerState>();

    private readonly object _parseDocumentLock = new object();

    /// <summary>
    ///   Überschreitet der Tagger diese Länge, dann wird die Runde abgeschlossen.
    ///   Wird dynamisch bestimmt. Empfohlener Startwert: 200000
    /// </summary>
    protected virtual int TaggerContentLengthMax => 200000;

    /// <summary>
    ///   Unterschreitet der Tagger diese Länge, wird die Verarbeitung abgebrochen.
    ///   Empfohlener Wert: 10
    /// </summary>
    protected virtual int TaggerContentLengthMin => 10;

    protected virtual string TaggerFileSeparator => "\r\n<ENDOFCORPUSEXPLORERFILE>\r\n";

    protected virtual string[] TaggerValueSeparator => new[] {"\t"};

    public AbstractTokenizer Tokenizer { get; set; }

    protected LayerRangeState AddRangeLayer(string displayname)
    {
      var res = new LayerRangeState(displayname);
      _layers.Add(displayname, res);
      return res;
    }

    protected void AddValueLayer(string displayname, int valueIndex, int minimumLength = 1)
    {
      var res = new LayerValueState(displayname, valueIndex) {MinimumDataLength = minimumLength};
      _layers.Add(displayname, res);
    }

    public override void Execute()
    {
      Initialize();

      var meta = ParseMetadata();

      StartTaggingProcess();

      Output.Enqueue(
        CorpusBuilder.Create(
          _layers.Select(x => x.Value),
          meta,
          new Dictionary<string, object>(),
          null));
    }

    protected abstract string ExecuteTagger(string text);

    protected string GenerateText(ref Dictionary<string, object>[] docs)
    {
      var stb = new StringBuilder();

      foreach (var doc in docs)
      {
        var m = doc;
        var t = m.Get("Text", string.Empty);
        if (string.IsNullOrEmpty(t) || t.Length < TaggerContentLengthMin)
          continue;

        stb.Append(TextPreMergerCleanup(t, ref m));
        stb.Append(TaggerFileSeparator);
      }

      string text;
      if (Tokenizer == null)
      {
        text = (new HighSpeedSpaceTokenizer()).Execute(TextPreTokenizerCleanup(stb.ToString()));
      }
      else
      {
        Tokenizer.Language = LanguageSelected;
        text = Tokenizer.Execute(TextPreTokenizerCleanup(stb.ToString()));
      }

      stb.Clear();
      return TextPostTokenizerPreTaggerCleanup(text);
    }

    protected void GetDocumentClusters(int act)
    {
      var cluster = new List<Dictionary<string, object>>();
      var sum = 0;

      while (Input.Count > 0)
        try
        {
          Dictionary<string, object> doc;
          if (!Input.TryDequeue(out doc))
            continue;
          var text = doc?.Get("Text") as string;
          if (text == null)
            continue;

          sum += text.Length;
          cluster.Add(doc);
          if (sum <= act)
            continue;

          InternQueue.Enqueue(cluster.ToArray());
          cluster.Clear();
          sum = 0;
        }
        catch (Exception ex)
        {
          InMemoryErrorConsole.Log(ex);
        }

      if (cluster.Count == 0)
        return;

      InternQueue.Enqueue(cluster.ToArray());
      cluster.Clear();
    }

    // ReSharper disable once VirtualMemberNeverOverridden.Global
    protected virtual void Initialize() { }
    protected abstract bool IsEndOfSentence(string[] data);

    private void ParseDocument(string[] keys, Guid guid, ref string text)
    {
      var sentences = keys.ToDictionary(x => x, x => new List<int>());
      var document = keys.ToDictionary(x => x, x => new List<int[]>());
      var values = keys.ToDictionary(x => x, x => 0);

      var lines = text.Split(new[] {"\r\n", "\r", "\n"}, StringSplitOptions.RemoveEmptyEntries);
      foreach (var line in lines)
      {
        var entries = line.Split(TaggerValueSeparator, StringSplitOptions.RemoveEmptyEntries);
        foreach (var key in keys)
        {
          lock (_parseDocumentLock)
          {
            if (_layers[key].AllowValueChange(entries))
              values[key] = _layers[key].RequestIndex(entries, values[key]);

            if (_layers[key].AllowAnnotation(entries))
              sentences[key].Add(values[key]);
          }

          // ReSharper disable once InvertIf
          if (IsEndOfSentence(entries))
          {
            document[key].Add(sentences[key].ToArray());
            sentences[key].Clear();
            values[key] = 0;
          }
        }
      }

      foreach (var sent in sentences)
        if (sent.Value.Count > 0)
          document[sent.Key].Add(sent.Value.ToArray());

      lock (_parseDocumentLock)
      {
        foreach (var x in document)
          _layers[x.Key].Documents.Add(guid, x.Value.ToArray());
      }
    }

    private Dictionary<Guid, Dictionary<string, object>> ParseMetadata()
    {
      var meta = new ConcurrentDictionary<Guid, Dictionary<string, object>>();

      Parallel.ForEach(
        Input,
        sdm =>
        {
          var dic = sdm.GetMetaDictionary().ToDictionary(entry => entry.Key, entry => entry.Value);
          var guid = sdm.Get("GUID", Guid.NewGuid());
          dic.Add("GUID", guid);
          meta.TryAdd(guid, dic);
        });

      return meta.ToDictionary(x => x.Key, x => x.Value);
    }

    private void StartTaggingProcess()
    {
      // act definiert wieviele Tokens maximal pro Turn gewählt werden.
      var act = TaggerContentLengthMax;

      while (Input.Count > 0)
      {
        // Überprüfe den Überlauf von act - ggf. setze die Grenzen neu
        act = act < TaggerContentLengthMin
                ? TaggerContentLengthMin
                : act > TaggerContentLengthMax
                  ? TaggerContentLengthMax
                  : act;

        GetDocumentClusters(act);

        var count = InternQueue.Count;
        while (count > 0)
        {
          Parallel.For(
            0,
            count,
            i =>
            {
              Dictionary<string, object>[] turn;
              if (!InternQueue.TryDequeue(out turn))
                return;

              // TreeTagger
              var text = TextPostTaggerCleanup(ExecuteTagger(GenerateText(ref turn)));
              var tmp = text.Split(new[] {TaggerFileSeparator}, StringSplitOptions.RemoveEmptyEntries);
              // mkpt - maximal korrekt geparste texte
              var correct = text.EndsWith(TaggerFileSeparator) ? tmp.Length : tmp.Length - 1;

              if (turn.Length == 1 && correct == 0)
                correct = 1;

              // Vor der Parallelisierung
              var keys = _layers.Select(x => x.Key).ToArray();
              var @lock = new object();

              Parallel.For(
                0,
                correct,
                j =>
                {
                  try
                  {
                    ParseDocument(keys, turn[j].Get("GUID", Guid.NewGuid()), ref tmp[j]);
                    lock (@lock)
                    {
                      tmp[j] = null; // wichtig zu Error-Erkennung
                      turn[j].Clear();
                      turn[j] = null; // wichtig zu Error-Erkennung
                    }
                  }
                  catch (Exception ex)
                  {
                    InMemoryErrorConsole.Log(ex);
                  }
                });

              // Aktualisiere act je nach Fall - Wenn kein Fehler (==) dann vergrößere den Wert.
              // Wenn ein Fehler auftritt, dann reduziere ihn ( /= 3 )
              if (correct == turn.Length)
              {
                // ReSharper disable once AccessToModifiedClosure
                act *= 2;
                return;
              }
              act /= 3;

              // Wenn Tagger total versagt, breche das Dokument ab.
              // Wenn nur ein Dokument in der Queue und dieses nicht bearbeitbar ist, verwerfe es.
              if (act <= TaggerContentLengthMin ||
                  turn.Length == 1 && correct < 1)
                return;

              // Fehlerhafte Dokumente werden zurück in die Queue gestellt.        
              for (var j = correct; j < turn.Length && j > 0; j++)
                Input.Enqueue(turn[j]);
              // Fehlerhafte Dokumente werden zurück in die Queue gestellt.        
              foreach (var t in turn.Where(t => t != null))
                Input.Enqueue(t);
            });
          count = InternQueue.Count;
        }
      }
    }

    protected virtual string TextPostTaggerCleanup(string text) { return text; }

    protected virtual string TextPostTokenizerPreTaggerCleanup(string text)
    {
      return text.Replace("<\r\nENDOFCORPUSEXPLORERFILE\r\n>", TaggerFileSeparator).Replace("\r\n\r\n", "\r\n");
    }

    // ReSharper disable once VirtualMemberNeverOverridden.Global
    protected virtual string TextPreTokenizerCleanup(string text) { return text; }
    
    // ReSharper disable once VirtualMemberNeverOverridden.Global
    protected virtual string TextPreMergerCleanup(string text, ref Dictionary<string, object> doc) { return text; }
  }
}