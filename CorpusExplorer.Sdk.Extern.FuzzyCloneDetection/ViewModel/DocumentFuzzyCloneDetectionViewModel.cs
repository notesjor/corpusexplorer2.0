using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.FuzzyCloneDetection.Blocks;
using CorpusExplorer.Sdk.ViewModel.Abstract;

namespace CorpusExplorer.Sdk.Extern.FuzzyCloneDetection.ViewModel
{
  public class DocumentFuzzyCloneDetectionViewModel : AbstractViewModel
  {
    private bool _done;

    public IEnumerable<Guid> IndividualDocuments { get; set; }

    /// <summary>
    ///   Generates the clean selection.
    /// </summary>
    public void GenerateCleanSelection()
    {
      if (!_done)
        Execute();

      Selection.Create(IndividualDocuments, $"{Selection.Displayname} (CLEAN)", false);
    }

    protected override void ExecuteAnalyse()
    {
      if (_done)
        return;

      var block = Selection.CreateBlock<DocumentCloneFuzzyDetectionBlock>();
      block.Calculate();
      IndividualDocuments = block.IndividualDocuments.ToArray();

      _done = true;
    }

    protected override bool Validate()
    {
      return true;
    }
  }
}