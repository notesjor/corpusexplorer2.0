using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.MachineLearning.Blocks.Abstract;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Extern.MachineLearning.Blocks
{
  public class LdaDocumentTopicBlock : AbstractLdaBlock
  {
    protected override void PostCalculate()
    {
      DocumentPredictions = new Dictionary<Guid, float[]>();

      Parallel.ForEach(Selection.DocumentGuids, dsel =>
      {
        var text = Selection.GetReadableDocument(dsel, LayerDisplayname).ReduceDocumentToText();
        var predict = Predict(text);
        DocumentPredictions.Add(dsel, predict);
      });
    }

    public Dictionary<Guid, float[]> DocumentPredictions { get; set; }
  }
}