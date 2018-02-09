using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;

namespace CorpusExplorer.Sdk.Model.Interface
{
  public interface IKarkinos
  {
    AbstractLayerAdapter Create(AbstractLayerState layerState);

    AbstractLayerState ToLayerState();
  }
}