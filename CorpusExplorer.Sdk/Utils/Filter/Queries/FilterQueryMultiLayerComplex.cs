using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.Filter.Parser.FilterMultiLayerComplex;

namespace CorpusExplorer.Sdk.Utils.Filter.Queries
{
  [XmlRoot]
  [Serializable]
  public class FilterQueryMultiLayerComplex : AbstractFilterQuery
  {
    private KeyValuePair<string, HashSet<string>>[] _query;
    public override string Verbal => "Hochkomplexe Abfrage";
    private MultidimensionalDocumentAnalyzer _mda = new MultidimensionalDocumentAnalyzer();

    public void Load(string path, string separator = "\t")
    {
      Parser4FilterQueryMultiLayerComplex.Separator = separator;
      _query = Parser4FilterQueryMultiLayerComplex.Read(path);
    }

    public override object Clone()
    {
      return new FilterQueryMultiLayerComplex
      {
        _query = _query
      };
    }

    public override IEnumerable<int> GetWordIndices(AbstractCorpusAdapter corpus, Guid documentGuid, int sentence)
    {
      return _mda.Analyze<List<int>>(corpus, documentGuid, sentence, new List<int>(), GetWordIndicesFunc);
    }

    protected override int GetSentenceFirstIndexCall(AbstractCorpusAdapter corpus, Guid documentGuid, int sentence)
    {
      return _mda.Analyze<int>(corpus, documentGuid, sentence, -1, GetSentenceFirstIndexCallFunc);
    }

    protected override IEnumerable<int> GetSentencesCall(AbstractCorpusAdapter corpus, Guid documentGuid)
    {
      return _mda.Analyze<List<int>>(corpus, documentGuid, new List<int>(), GetSentencesCallFunc);
    }

    protected override bool ValidateCall(AbstractCorpusAdapter corpus, Guid documentGuid)
    {
      return _mda.Analyze<int>(corpus, documentGuid, -1, ValidateCallFunc) > -1;
    }

    private void GetWordIndicesFunc(ref MultidimensionalDocumentAnalyzer.Session<List<int>> session)
    {
      if (session.Info == _query.Length) // Mehrfach gefunden
      {
        session.Result.Add(session.StoredTokenId);
        session.Result.Add(session.CurrentTokenId - 1);
        session.PositionRestore();
        return;
      }

      var query = _query[session.Info];
      if (query.Key == "BLANK")
      {
        session.PositionStore(1);
        // TODO: Flexible BLANK ermöglichen - nutze: session.Info(x)
      }
      else
      {
        if (session.CurrentValue.ContainsKey(query.Key) && query.Value.Contains(session.CurrentValue[query.Key]))
          session.PositionStore(1);
        else
          session.PositionRestore();
      }
    }

    private void GetSentenceFirstIndexCallFunc(ref MultidimensionalDocumentAnalyzer.Session<int> session)
    {
      if (session.Info == _query.Length) // Einmalig gefunden
      {
        session.Result = session.StoredTokenId;
        session.Terminate = true;
        return;
      }

      var query = _query[session.Info];
      if (query.Key == "BLANK")
      {
        session.PositionStore(1);
        // TODO: Flexible BLANK ermöglichen - nutze: session.Info(x)
      }
      else
      {
        if (session.CurrentValue.ContainsKey(query.Key) && query.Value.Contains(session.CurrentValue[query.Key]))
          session.PositionStore(1);
        else
          session.PositionRestore();
      }
    }

    private void GetSentencesCallFunc(ref MultidimensionalDocumentAnalyzer.Session<List<int>> session)
    {
      if (session.Info == _query.Length) // Mehrfach gefunden
      {
        session.Result.Add(session.StoredSentenceId);
        session.PositionRestore();
        return;
      }

      var query = _query[session.Info];
      if (query.Key == "BLANK")
      {
        session.PositionStore(1);
        // TODO: Flexible BLANK ermöglichen - nutze: session.Info(x)
      }
      else
      {
        if (session.CurrentValue.ContainsKey(query.Key) && query.Value.Contains(session.CurrentValue[query.Key]))
          session.PositionStore(1);
        else
          session.PositionRestore();
      }
    }

    private void ValidateCallFunc(ref MultidimensionalDocumentAnalyzer.Session<int> session)
    {
      if (session.Info == _query.Length) // Einmalig gefunden
      {
        session.Result = session.StoredSentenceId;
        session.Terminate = true;
        return;
      }

      var query = _query[session.Info];
      if (query.Key == "BLANK")
      {
        session.PositionStore(1);
        // TODO: Flexible BLANK ermöglichen - nutze: session.Info(x)
      }
      else
      {
        if (session.CurrentValue.ContainsKey(query.Key) && query.Value.Contains(session.CurrentValue[query.Key]))
          session.PositionStore(1);
        else
          session.PositionRestore();
      }
    }
  }
}
