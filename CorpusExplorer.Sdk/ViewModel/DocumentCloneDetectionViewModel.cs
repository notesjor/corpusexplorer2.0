using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.ViewModel.Abstract;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class DocumentCloneDetectionViewModel : AbstractViewModel
  {
    private bool _done;

    public IEnumerable<Guid> IndividualDocuments { get; set; }

    public string SelectedLayerDisplayname { get; set; } = "Wort";

    public bool UseSpeedDetection { get; set; } = true;

    /// <summary>
    ///   Generates the clean selection.
    /// </summary>
    public void GenerateCleanSelection()
    {
      if (!_done)
        Analyse();

      Selection.Create(IndividualDocuments, $"{Selection.Displayname} (CLEAN)");
    }

    protected override void ExecuteAnalyse()
    {
      if (_done)
        return;

      if (UseSpeedDetection)
      {
        var block = Selection.CreateBlock<DocumentCloneQuickDetectionBlock>();
        block.Calculate();
        IndividualDocuments = block.IndividualDocuments.ToArray();
      }
      else
      {
        var block = Selection.CreateBlock<DocumentCloneDetectionBlock>();
        block.LayerDisplayname = SelectedLayerDisplayname;
        block.Calculate();
        IndividualDocuments = block.IndividualDocuments.ToArray();
      }

      _done = true;
    }

    protected override bool Validate()
    {
      return true;
    }
  }
}