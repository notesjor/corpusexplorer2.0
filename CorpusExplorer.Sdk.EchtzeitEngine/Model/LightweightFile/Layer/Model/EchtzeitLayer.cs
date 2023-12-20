using System;
using System.Linq;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;

namespace CorpusExplorer.Sdk.EchtzeitEngine.Model.LightweightFile.Layer.Model
{
  [Serializable]
  public class EchtzeitLayer
  {
    public CeDictionary Dictionary { get; set; }
    public string Displayname { get; set; }
    public int[][] Document { get; set; }
    public Guid DocumentGuid { get; set; }
    public Guid Guid { get; set; }

    public static EchtzeitLayer Create(AbstractLayerState layer)
    {
      return new EchtzeitLayer
      {
        Guid = Guid.NewGuid(),
        Dictionary = new CeDictionary(layer.GetCache()),
        Displayname = layer.Displayname,
        DocumentGuid = layer.GetDocuments().FirstOrDefault().Key,
        Document = layer.GetDocuments().FirstOrDefault().Value
      };
    }
  }
}