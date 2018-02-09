#region

using System.Collections.Generic;
using CorpusExplorer.Sdk.Extern.Binary.Abstract;
using CorpusExplorer.Sdk.Helper;

#endregion

namespace CorpusExplorer.Sdk.Extern.Binary.ListOfScrapDocuments.Reader
{
  internal sealed class ListOfScrapDocumentsReader : AbstractGenericDataReader<Dictionary<string, object>>
  {
    public override IEnumerable<Dictionary<string, object>> ReadData(string path)
    {
      IEnumerable<Dictionary<string, object>> res;

      try
      {
        res = Serializer.Deserialize<Dictionary<string, object>[]>(path);
      }
      catch
      {
        res = null;
      }

      return res ?? Serializer.Deserialize<IEnumerable<Dictionary<string, object>>>(path);
    }
  }
}