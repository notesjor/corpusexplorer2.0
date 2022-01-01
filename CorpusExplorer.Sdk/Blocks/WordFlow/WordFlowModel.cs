#region

using System.Collections.Generic;

#endregion

namespace CorpusExplorer.Sdk.Blocks.WordFlow
{
  public class WordFlowModel<T>
  {
    public delegate T ConflicAggregationDelegate(T valueOld, T valueNew);

    private readonly Dictionary<string, Dictionary<string, T>> _brain;
    private readonly ConflicAggregationDelegate _func;

    public WordFlowModel(ConflicAggregationDelegate func)
    {
      _brain = new Dictionary<string, Dictionary<string, T>>();
      _func = func;
    }

    public void Add(string wordSource, string wordTarget, T obj)
    {
      if (_brain.ContainsKey(wordSource))
        if (_brain[wordSource].ContainsKey(wordTarget))
          _brain[wordSource][wordTarget] = _func(_brain[wordSource][wordTarget], obj);
        else
          _brain[wordSource].Add(wordTarget, obj);
      else
        _brain.Add(wordSource, new Dictionary<string, T> { { wordTarget, obj } });
    }
  }
}