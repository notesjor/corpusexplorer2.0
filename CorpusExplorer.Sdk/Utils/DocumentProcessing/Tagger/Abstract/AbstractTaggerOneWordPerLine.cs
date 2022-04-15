using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract
{
  public abstract class AbstractTaggerOneWordPerLine : AbstractTagger
  {
    private const string _guidKey = "GUID";

    private readonly Dictionary<string, AbstractLayerState> _layers =
      new Dictionary<string, AbstractLayerState>();

    private readonly object _parseDocumentLock = new object();

    protected ConcurrentQueue<Dictionary<string, object>[]> InternQueue =
      new ConcurrentQueue<Dictionary<string, object>[]>();

    public AbstractTokenizer Tokenizer { get; set; }

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

    /// <summary>
    /// Gets the foundry name.
    /// </summary>
    /// <value>The foundry name.</value>
    protected abstract string Foundry { get; }

    /// <summary>
    /// Gets the foundry layer information.
    /// </summary>
    /// <example>pos lemma</example>
    /// <value>The foundry layer information.</value>
    protected abstract string FoundryLayerInfo { get; }

    protected virtual string TaggerFileSeparator => "\r\n<ENDOFCORPUSEXPLORERFILE>\r\n";

    protected virtual string[] TaggerValueSeparator => new[] { "\t" };

    public override void Execute()
    {
      Initialize();

      FixMissingGuid();

      var meta = ParseMetadata();

      StartTaggingProcess();

      Output.Enqueue(
                     CorpusBuilder.Create(
                                          _layers.Select(x => x.Value),
                                          meta,
                                          new Dictionary<string, object>
                                          {
                                            { "Foundry", Foundry },
                                            { "FoundryLayerInfo", FoundryLayerInfo }
                                          },
                                          null));
    }

    private void FixMissingGuid()
    {
      foreach (var i in Input)
      {
        if (i.ContainsKey(_guidKey))
        {
          var g = i[_guidKey];
          if (g is string gs && Guid.TryParse(gs, out var guid))
            i[_guidKey] = guid;
          else
            i[_guidKey] = Guid.NewGuid();
        }
        else
          i[_guidKey] = Guid.NewGuid();
      }
    }

    protected LayerRangeState AddRangeLayer(string displayname)
    {
      var res = new LayerRangeState(displayname);
      _layers.Add(displayname, res);
      return res;
    }

    protected void AddValueLayer(string displayname, int valueIndex, int minimumLength = 1)
    {
      var res = new LayerValueState(displayname, valueIndex) { MinimumDataLength = minimumLength };
      _layers.Add(displayname, res);
    }

    protected abstract string ExecuteTagger(string text);

    protected string GenerateText(ref Dictionary<string, object>[] docs, out Guid[] guids)
    {
      var stb = new StringBuilder();
      var gsl = new List<Guid>();

      foreach (var d in docs)
      {
        var doc = d;
        var t = doc.Get("Text", string.Empty);
        if (string.IsNullOrEmpty(t) || t.Length < 1)
          continue;

        gsl.Add((Guid)doc[_guidKey]);

        stb.Append(TextPreMergerCleanup(t, ref doc));
        stb.Append(TaggerFileSeparator);
      }

      string text;
      if (Tokenizer == null)
      {
        text = new HighSpeedSpaceTokenizer().Execute(TextPreTokenizerCleanup(stb.ToString()));
      }
      else
      {
        Tokenizer.Language = LanguageSelected;
        text = Tokenizer.Execute(TextPreTokenizerCleanup(stb.ToString()));
      }

      stb.Clear();
      guids = gsl.ToArray();
      return TextPostTokenizerPreTaggerCleanup(text);
    }

    protected void GetDocumentClusters(int act)
    {
      var cluster = new List<Dictionary<string, object>>();
      var sum = 0;

      while (Input.Count > 0)
        try
        {
          if (!Input.TryDequeue(out var doc))
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
    protected virtual void Initialize()
    {
    }

    protected abstract bool IsEndOfSentence(string[] data);

    protected virtual void ParseDocument(string[] keys, Guid guid, ref string text)
    {
      var sentences = keys.ToDictionary(x => x, x => new List<int>());
      var document = keys.ToDictionary(x => x, x => new List<int[]>());
      var values = keys.ToDictionary(x => x, x => 0);

      var lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
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
          if (_layers[x.Key].Documents.ContainsKey(guid))
            _layers[x.Key].Documents[guid] = x.Value.ToArray();
          else
            _layers[x.Key].Documents.Add(guid, x.Value.ToArray());
      }
    }

    protected virtual string TextPostTaggerCleanup(string text)
    {
      return text;
    }

    protected virtual string TextPostTokenizerPreTaggerCleanup(string text)
    {
      return text.Replace("<\r\nENDOFCORPUSEXPLORERFILE\r\n>", TaggerFileSeparator).Replace("\r\n\r\n", "\r\n");
    }

    // ReSharper disable once VirtualMemberNeverOverridden.Global
    protected virtual string TextPreMergerCleanup(string text, ref Dictionary<string, object> doc)
    {
      return text;
    }

    // ReSharper disable once VirtualMemberNeverOverridden.Global
    protected virtual string TextPreTokenizerCleanup(string text)
    {
      return text;
    }

    private Dictionary<Guid, Dictionary<string, object>> ParseMetadata()
    {
      var res = new Dictionary<Guid, Dictionary<string, object>>();

      foreach (var sdm in Input)
      {
        res.Add((Guid)sdm[_guidKey], sdm.GetMetaDictionary().ToDictionary(entry => entry.Key, entry => entry.Value));
      }

      return res;
    }

    private void StartTaggingProcess()
    {
      // Gibt die Layer (Namen) in der korrekten Reihenfolge vor.
      var layerKeys = _layers.Select(x => x.Key).ToArray();
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
                       Configuration.ParallelOptions,
                       i =>
                       {
                         if (!InternQueue.TryDequeue(out var turn))
                           return;

                         // TreeTagger
                         var text = TextPostTaggerCleanup(ExecuteTagger(GenerateText(ref turn, out var guids)));
                         var tmp = text.Split(new[] { TaggerFileSeparator }, StringSplitOptions.RemoveEmptyEntries);
                         // mkpt - maximal korrekt geparste texte
                         var correct = text.EndsWith(TaggerFileSeparator) ? tmp.Length : tmp.Length - 1;

                         if (turn.Length == 1 && correct == 0)
                           correct = 1;

                         var @lock = new object();
                         Parallel.For(
                                      0,
                                      correct,
                                      Configuration.ParallelOptions,
                                      j =>
                                      {
                                        try
                                        {
                                          ParseDocument(layerKeys, guids[j], ref tmp[j]);
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
  }
}