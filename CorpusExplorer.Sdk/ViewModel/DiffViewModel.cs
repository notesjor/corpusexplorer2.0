using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.Diff;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class DiffViewModel : AbstractViewModel, IUseSpecificLayer, IProvideHtmlOutput
  {
    private int[] _docA;

    private int[] _docB;

    public DiffViewModel()
    {
      DocumentAGuid = Guid.Empty;
      DocumentBGuid = Guid.Empty;
      LayerDisplayname = "Wort";
    }

    public int ChangesInsert
    {
      get { return DiffDeltas.Sum(x => x.InsertedB); }
    }

    public int ChangesRemove
    {
      get { return DiffDeltas.Sum(x => x.DeletedA); }
    }

    [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
    public DiffDelta[] DiffDeltas { get; set; }

    public Guid DocumentAGuid { get; set; }
    public Guid DocumentBGuid { get; set; }

    public IEnumerable<KeyValuePair<Guid, string>> DocumentGuidsAndDisplaynames => Selection
      .DocumentGuidsAndDisplaynames;

    public int EditDistance
    {
      get { return DiffDeltas.Sum(x => x.EditDistance); }
    }

    public IEnumerable<KeyValuePair<string, int>> MergeOutput
    {
      get
      {
        if (DiffDeltas == null || DiffDeltas.Length == 0)
          return null;

        var res = new List<KeyValuePair<string, int>>();
        var idx = 0;

        foreach (var delta in DiffDeltas)
        {
          if (delta.StartA > idx)
          {
            res.Add(new KeyValuePair<string, int>(IntArrayToStringArray(_docA.CutArray(idx, delta.StartA), false), 0));
            idx = delta.StartA + 1;
          }

          if (delta.DeletedA > 0)
          {
            res.Add(new KeyValuePair<string, int>(
              IntArrayToStringArray(_docA.CutArray(delta.StartA, delta.StartA + delta.DeletedA), false), -1));
            idx = delta.StartA + delta.DeletedA;
          }

          if (delta.InsertedB > 0)
            res.Add(new KeyValuePair<string, int>(
              IntArrayToStringArray(_docB.CutArray(delta.StartB, delta.StartB + delta.InsertedB), true), 1));
        }

        if (idx < _docA.Length)
          res.Add(new KeyValuePair<string, int>(IntArrayToStringArray(_docA.CutArray(idx, _docA.Length), false), 0));

        return res;
      }
    }

    public string HtmlOutput
    {
      get
      {
        if (DiffDeltas == null)
          return "<div class=\"label label-danger\">Der Vergleich wurde aufgrund eines Fehlers abgebrochen.</div>";
        if (DiffDeltas.Length == 0)
          return
            "<div class=\"label label-danger\">Beide Texte sind absolut identisch.</div><div class=\"label label-default\">"
            +
            IntArrayToStringArray(ReciveDocumentAsArray(DocumentAGuid), false);

        var stb = new StringBuilder();
        var idx = 0;

        foreach (var delta in DiffDeltas)
        {
          if (delta.StartA > idx)
          {
            stb.AppendFormat(
              "<div class=\"label label-default\" style=\"float:left\">{0}</div>",
              IntArrayToStringArray(_docA.CutArray(idx, delta.StartA), false));
            idx = delta.StartA + 1;
          }

          if (delta.DeletedA > 0)
          {
            stb.AppendFormat(
              "<div class=\"label label-danger\" style=\"float:left\">{0}</div>",
              IntArrayToStringArray(_docA.CutArray(delta.StartA, delta.StartA + delta.DeletedA), false));
            idx = delta.StartA + delta.DeletedA + 1;
          }

          if (delta.InsertedB > 0)
            stb.AppendFormat(
              "<div class=\"label label-success\" style=\"float:left\">{0}</div>",
              IntArrayToStringArray(_docB.CutArray(delta.StartB, delta.StartB + delta.InsertedB), true));
        }

        if (idx < _docA.Length)
          stb.AppendFormat(
            "<div class=\"label label-default\" style=\"float:left\">{0}</div>",
            IntArrayToStringArray(_docA.CutArray(idx, _docA.Length), false));

        return stb.ToString();
      }
    }

    public IEnumerable<string> LayerDisplaynames => Selection.LayerUniqueDisplaynames;

    public string LayerDisplayname { get; set; }

    protected override void ExecuteAnalyse()
    {
      _docA = ReciveDocumentAsArray(DocumentAGuid);
      _docB = ReciveDocumentAsArray(DocumentBGuid);

      DiffDeltas = null;

      if (_docA == null ||
          _docB == null)
        return;

      DiffDeltas = Diff.DiffInt(_docA, _docB);
    }

    protected override bool Validate()
    {
      return DocumentAGuid != Guid.Empty && DocumentBGuid != Guid.Empty;
    }

    private string IntArrayToStringArray(IEnumerable<int> array, bool useB)
    {
      if (DocumentAGuid == Guid.Empty ||
          DocumentBGuid == Guid.Empty ||
          string.IsNullOrEmpty(LayerDisplayname))
        return null;

      var layer = useB
        ? Selection.GetLayerOfDocument(DocumentBGuid, LayerDisplayname)
        : Selection.GetLayerOfDocument(DocumentAGuid, LayerDisplayname);

      return layer == null ? null : array.ConvertToText(layer);
    }

    private int[] ReciveDocumentAsArray(Guid guid)
    {
      return
        Selection.GetDocument(guid, LayerDisplayname)?
          .ReduceToSingleDimension()
          .ToArray();
    }
  }
}