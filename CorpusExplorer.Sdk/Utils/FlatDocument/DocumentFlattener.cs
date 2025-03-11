using System;
using System.Collections.Generic;

namespace CorpusExplorer.Sdk.Utils.FlatDocument
{
  public class DocumentFlattener : IDisposable
  {
    private List<KeyValuePair<int, int>> _index = new List<KeyValuePair<int, int>>();
    private int[] _flatDocument;

    public DocumentFlattener(int[][] document)
    {
      var flatDocument = new List<int>();
      for (var i = 0; i < document.Length; i++)
        if (document[i] != null)
          for (var j = 0; j < document[i].Length; j++)
          {
            flatDocument.Add(document[i][j]);
            _index.Add(new KeyValuePair<int, int>(i, j));
          }
      _flatDocument = flatDocument.ToArray();
    }

    public int[] FlatDocument => _flatDocument;
    public KeyValuePair<int, int> GetIndex(int index) => _index[index];
    public int GetSentenceStartIndex(int sentenceIndex)
    {
      for (var i = 0; i < _index.Count; i++)
        if (_index[i].Key == sentenceIndex)
          return i;
      return -1;
    }

    public void Dispose()
    {
      _flatDocument = Array.Empty<int>();
      _flatDocument = null;
      _index.Clear();
      _index = null;
    }
  }
}
