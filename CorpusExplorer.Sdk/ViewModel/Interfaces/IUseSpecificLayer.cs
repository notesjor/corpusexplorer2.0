namespace CorpusExplorer.Sdk.ViewModel.Interfaces
{
  public interface IUseSpecificLayer : IViewModel, IProvideLayerDisplaynames
  {
    string LayerDisplayname { get; set; }
  }
}