using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class ValidateSelectionIntegrityViewModel : AbstractViewModel, IProvideDataTable
  {
    public Selection CleanSelection =>
      Selection.Project.CreateSelection(ValidDocumentGuids, $"{Selection.Displayname}_(VALID)");

    public HashSet<Guid> InvalidCorpusGuids { get; private set; }

    public HashSet<Guid> EmptyDocumentGuids { get; private set; }

    public HashSet<Guid> NoLayerMatchingDocumentGuids { get; private set; }

    public HashSet<Guid> SentenceErrorDocumentGuids { get; private set; }

    public bool HasError { get; private set; }

    public HashSet<Guid> ValidDocumentGuids { get; set; }

    public IEnumerable<string> EmptyDocuments
      => EmptyDocumentGuids.Select(x => Selection.GetDocumentDisplayname(x));

    public IEnumerable<string> NoLayerMatchingDocuments
      => NoLayerMatchingDocumentGuids.Select(x => Selection.GetDocumentDisplayname(x));

    public IEnumerable<string> SentenceErrorDocuments
      => SentenceErrorDocumentGuids.Select(x => Selection.GetDocumentDisplayname(x));

    public int All => Selection.CountDocuments;

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

    protected override bool Validate()
    {
      return true;
    }

    public DataTable GetDataTable()
    {
      var dt = new DataTable();

      dt.Columns.Add("Test", typeof(string));
      dt.Columns.Add("Result", typeof(string));
      dt.Columns.Add("Affected", typeof(long));
      dt.Columns.Add("Unit", typeof(string));

      dt.BeginLoadData();

      dt.Rows.Add("Invalid corpora", InvalidCorpusGuids.Count == 0, InvalidCorpusGuids.Count, "Corpora");
      dt.Rows.Add("Empty documents", EmptyDocumentGuids.Count == 0, EmptyDocumentGuids.Count, "Documents");
      dt.Rows.Add("Documents with different layers", NoLayerMatchingDocumentGuids.Count == 0, NoLayerMatchingDocumentGuids.Count, "Documents");
      dt.Rows.Add("Documents without sentences", SentenceErrorDocumentGuids.Count == 0, SentenceErrorDocumentGuids.Count, "Documents");
      dt.Rows.Add("Invalid documents", "-TOTAL-", Selection.CountDocuments - ValidDocumentGuids.Count, "Documents");
      dt.Rows.Add("Valid documents", "-TOTAL-", ValidDocumentGuids.Count, "Documents");

      dt.EndLoadData();

      return dt;
    }
  }
}