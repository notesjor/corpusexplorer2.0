using System.Collections.Generic;

namespace CorpusExplorer.Sdk.Utils.Filter.Interface
{
  public interface IFilterQueryWithLayerValues
  {
    IEnumerable<string> LayerQueries { get; set; }
  }
}