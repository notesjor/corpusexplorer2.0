using System.Collections.Generic;

namespace CorpusExplorer.Sdk.ViewModel.Interfaces
{
  public interface IProvideLayerDisplaynames
  {
    IEnumerable<string> LayerDisplaynames { get; }
  }
}