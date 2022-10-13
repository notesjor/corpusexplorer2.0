using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;

namespace CorpusExplorer.Sdk.Helper
{
  public class MultidimensionalDocumentAnalyzer
  {
    public T Analyze<T>(AbstractCorpusAdapter corpus, Guid documentGuid, int sentenceId, T defaultResult, AnalyzeFunction<T> func, bool respectSentenceBreak = true)
    {
      // TODO: Richtig?
      var session = new Session<T>(corpus.GetReadableMultilayerDocument(documentGuid, sentenceId, sentenceId)
        .ToDictionary(x => x.Key,
          x => x.Value.Select(y => y.ToArray()).ToArray()), defaultResult);
      return Calculate<T>(session, func, respectSentenceBreak);
    }

    public T Analyze<T>(AbstractCorpusAdapter corpus, Guid documentGuid, T defaultResult, AnalyzeFunction<T> func, bool respectSentenceBreak = true)
    {
      var session = new Session<T>(corpus.GetReadableMultilayerDocument(documentGuid)
        .ToDictionary(x => x.Key,
          x => x.Value.Select(y => y.ToArray()).ToArray()), defaultResult);
      return Calculate<T>(session, func, respectSentenceBreak);
    }

    public struct Session<T>
    {
      private Dictionary<string, string[][]> _mdoc;
      private int _storedSentenceId;
      private int _storedTokenId;
      private int _currentSentenceId;
      private int _currentTokenId;

      internal Session(Dictionary<string, string[][]> mdoc, T defaultResult)
      {
        _mdoc = mdoc;
        _storedSentenceId = 0;
        _storedTokenId = 0;
        _currentSentenceId = 0;
        _currentTokenId = 0;

        Info = 0;
        Result = defaultResult;
        Terminate = false;

        Lead = _mdoc.First().Value.Select(x => x.Length).ToArray();
      }

      public int[] Lead { get; set; }

      public void PositionStore(int addInfo)
      {
        if (addInfo < 1)
          throw new ArgumentOutOfRangeException(nameof(addInfo), "addInfo muss größer 0 sein.");
        
        Info += addInfo;

        if (Info > 1)
          return;

        _storedSentenceId = CurrentSentenceId;
        _storedTokenId = CurrentTokenId;
      }

      public void PositionRestore()
      {
        if (Info == 0)
          return;

        Info = 0;
        CurrentSentenceId = _storedSentenceId;
        CurrentTokenId = _storedTokenId;
      }

      /// <summary>
      /// Gespeicherter Info-Wert
      /// </summary>
      public int Info { get; private set; }
      public bool Terminate { get; set; }
      public T Result { get; set; }
      public int CurrentSentenceId
      {
        get => _currentSentenceId;
        set => _currentSentenceId = value;
      }

      public int CurrentTokenId
      {
        get => _currentTokenId;
        set => _currentTokenId = value;
      }

      public int StoredSentenceId => _storedSentenceId;
      public int StoredTokenId => _storedTokenId;

      /// <summary>
      /// Aktueller Wert
      /// </summary>
      public Dictionary<string, string> CurrentValue
      {
        get
        {
          var dictionary = new Dictionary<string, string>();
          // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
          foreach (var key in _mdoc.Keys)
            dictionary.Add(key, _mdoc[key][CurrentSentenceId][CurrentTokenId]);
          return dictionary;
        }
      }
    }

    private T Calculate<T>(Session<T> session, AnalyzeFunction<T> func, bool respectSentenceBreak)
    {
      for (session.CurrentSentenceId = 0; session.CurrentSentenceId < session.Lead.Length; session.CurrentSentenceId++)
      {
        for (session.CurrentTokenId = 0; session.CurrentTokenId < session.Lead[session.CurrentSentenceId]; session.CurrentTokenId++)
        {
          try
          {
            func(ref session);
          }
          catch
          {
            // ignore
          }

          if (session.Terminate)
            return session.Result;
        }

        if(respectSentenceBreak)
          session.PositionRestore();

      }
      return session.Result;
    }

    public delegate void AnalyzeFunction<T>(ref Session<T> mda);

  }
}