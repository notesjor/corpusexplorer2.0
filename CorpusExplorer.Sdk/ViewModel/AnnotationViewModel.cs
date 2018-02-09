#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.ViewModel.Abstract;

#endregion

namespace CorpusExplorer.Sdk.ViewModel
{
  /// <summary>
  ///   The tagger view model.
  /// </summary>
  public class AnnotationViewModel : AbstractViewModel
  {
    private Guid _documentGuid;
    private Guid _layerGuid;
    private Guid _maskLayerGuid;
    private string _maskLayerValue;

    public Dictionary<string, object> DocumentMetadata
    {
      get => Selection.GetDocumentMetadata(_documentGuid);
      set => Selection.SetDocumentMetadata(_documentGuid, value);
    }

    public Dictionary<Guid, string> Documents { get; private set; }
    public Dictionary<Guid, string> Layers { get; private set; }

    public void CopyLayer(string layerDisplaynameOriginal, string layerDisplaynameCopy)
    {
      Selection.LayerCopy(layerDisplaynameOriginal, layerDisplaynameCopy);
      RefrehDocumentLayers();
    }

    public void DeleteLayer(string layerDisplayname)
    {
      Selection.LayerDelete(layerDisplayname);
      RefrehDocumentLayers();
    }

    public void DeleteLayerValue(string layerDisplayname, string layerValue)
    {
      foreach (var layer in Selection.GetLayers(layerDisplayname))
        layer.ValueRemove(layerValue);
    }

    protected override void ExecuteAnalyse()
    {
      Documents = Selection.DocumentGuidsAndDisplaynames.ToDictionary(x => x.Key, x => x.Value);
      SelectDocument(Documents.FirstOrDefault().Key);
    }

    public void ExportLayer(string layerDisplayname) { Selection.ExportDocumentLayer(_documentGuid, layerDisplayname); }

    public IEnumerable<IEnumerable<string>> GetDocument(Guid? documentGuid = null, Guid? layerGuid = null)
    {
      return Selection.GetReadableDocument(
        documentGuid ?? _documentGuid,
        layerGuid ?? _layerGuid);
    }

    public Dictionary<string, IEnumerable<IEnumerable<string>>> GetDocumentMultilayer(Guid? documentGuid = null)
    {
      return Selection.GetReadableMultilayerDocument(documentGuid ?? _documentGuid);
    }

    public IEnumerable<IEnumerable<bool>> GetDocumentOverlay(Guid documentGuid, Guid layerGuid, string value)
    {
      return Selection.GetReadableDocument(documentGuid, layerGuid).Select(x => x.Select(y => y == value));
    }

    public IEnumerable<IEnumerable<bool>> GetLayerValueMask(Guid layerGuid, string layerValue)
    {
      _maskLayerGuid = layerGuid;
      _maskLayerValue = layerValue;

      return Selection.GetDocumentLayerValueMask(_documentGuid, _maskLayerGuid, _maskLayerValue);
    }

    public IEnumerable<string> GetLayerValues(Guid layerGuid) { return Selection.GetLayerValues(layerGuid); }

    public void NewLayer(string layerName)
    {
      Selection.LayerNew(layerName);
      RefrehDocumentLayers();
    }

    public void NewLayerValue(string layerDisplayname, string layerValue)
    {
      foreach (var layer in Selection.GetLayers(layerDisplayname))
        layer.ValueAdd(layerValue);         
    }

    public void QuickAnnotation(
      Guid documentGuid,
      Guid layerGuid,
      HashSet<string> newValues,
      IEnumerable<string> streamDocument)
    {
      var layer = Selection.GetLayer(layerGuid); // Wichtig: layerGuid NICHT _layerGuid
      if (layer == null)
        return;

      foreach (var value in newValues)
        layer.ValueAdd(value);

      layer.SetQuickStreamDocumentAnnotation(documentGuid, streamDocument);
    }

    private void RefrehDocumentLayers()
    {
      Layers = Selection.GetLayerGuidAndDisplaynamesOfDocument(_documentGuid).ToDictionary(x => x.Key, x => x.Value);
    }

    public void RenameLayer(string layerDisplaynameOld, string layerDisplaynameNew)
    {
      Selection.LayerRename(layerDisplaynameOld, layerDisplaynameNew);
      RefrehDocumentLayers();
    }

    public void RenameLayerValue(string layerDisplayname, string layerValueOld, string layerValueNew)
    {
      foreach (var layer in Selection.GetLayers(layerDisplayname))
        layer.ValueChange(layerValueOld, layerValueNew);
    }

    public void SelectDocument(Guid documentGuid)
    {
      _documentGuid = documentGuid;
      RefrehDocumentLayers();

      foreach (var layer in Layers.Where(layer => layer.Value == "Wort"))
      {
        _layerGuid = layer.Key;
        break;
      }
    }

    public Selection SelectDocumentAsSelection() { return Selection.CreateTemporary(new[] {_documentGuid}); }

    public IEnumerable<IEnumerable<bool>> SetLayerValueMask(int sentenceIndex, int wordIndex)
    {
      return Selection.SetDocumentLayerValueMask(
               _documentGuid,
               _maskLayerGuid,
               sentenceIndex,
               wordIndex,
               _maskLayerValue)
               ? Selection.GetDocumentLayerValueMask(_documentGuid, _maskLayerGuid, _maskLayerValue)
               : null;
    }

    public void SetNewDocumentMetadata(KeyValuePair<string, Type> property)
    {
      Selection.Project.SetNewDocumentMetadata(property.Key, property.Value);
    }

    protected override bool Validate() { return true; }
  }
}