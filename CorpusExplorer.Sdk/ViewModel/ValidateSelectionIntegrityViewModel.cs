using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.ViewModel.Abstract;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class ValidateSelectionIntegrityViewModel : AbstractViewModel
  {
    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<ValidateSelectionIntegrityBlock>();
      block.Calculate();

      InvalidCorpusGuids = block.InvalidCorpusGuids;
      EmptyDocumentGuids = block.EmptyDocumentGuids;
      NoLayerMatchingDocumentGuids = block.NoLayerMatchingDocumentGuids;
      SentenceErrorDocumentGuids = block.SentenceErrorDocumentGuids;
      HasError = block.HasError;

      ValidDocumentGuids = block.ValidDocumentGuids;
    }

    public Selection CleanSelection =>
      Selection.Project.CreateSelection(ValidDocumentGuids, $"{Selection.Displayname}_(VALID)");

    public HashSet<Guid> InvalidCorpusGuids { get; private set; }

    public HashSet<Guid> EmptyDocumentGuids { get; private set; }

    public HashSet<Guid> NoLayerMatchingDocumentGuids { get; private set; }

    public HashSet<Guid> SentenceErrorDocumentGuids { get; private set; }

    public bool HasError { get; private set; }

    public HashSet<Guid> ValidDocumentGuids { get; set; }

    protected override bool Validate()
    {
      return true;
    }

    public IEnumerable<string> EmptyDocuments
      => EmptyDocumentGuids.Select(x => Selection.GetDocumentDisplayname(x));

    public IEnumerable<string> NoLayerMatchingDocuments
      => NoLayerMatchingDocumentGuids.Select(x => Selection.GetDocumentDisplayname(x));

    public IEnumerable<string> SentenceErrorDocuments
      => SentenceErrorDocumentGuids.Select(x => Selection.GetDocumentDisplayname(x));

    public int All => Selection.CountDocuments;
  }
}
