using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.MachineLearning.Blocks.Abstract;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.Extern.MachineLearning.Blocks
{
  public class LdaDocumentTopicCompareBlock : AbstractLdaBlock
  {
    protected override void PostCalculate()
    {
      DocumentPredictions = new Dictionary<Guid, float[]>();

      Parallel.ForEach(SelectionToCompare.DocumentGuids, dsel =>
      {
        var text = SelectionToCompare.GetReadableDocument(dsel, LayerDisplayname).ReduceDocumentToText();
        var predict = Predict(text);
        DocumentPredictions.Add(dsel, predict);
      });
    }

    public Dictionary<Guid, float[]> DocumentPredictions { get; set; }

    public Selection SelectionToCompare { get; set; }
  }
}