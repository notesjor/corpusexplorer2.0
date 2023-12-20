using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model
{
  public class LayerValueState : AbstractLayerState
  {
    private readonly int _valueIndex;

    public LayerValueState(string displayname, int valueIndex, Dictionary<string, int> cache = null, Dictionary<Guid, int[][]> documents = null) : base(displayname, cache, documents)
    {
      _valueIndex = valueIndex;
    }

    public int MinimumDataLength { get; set; } = 1;

    /// <summary>
    /// Ändert ein Dokument komplett
    /// </summary>
    /// <param name="documentGuid">GUID des Dokuments (muss bereits vorhanden sein)</param>
    /// <param name="documentTokens">Tokens (DIM 0 - Satz / 1 - Token)</param>
    /// <param name="applyEmptyValues">Wenn true, dann werden auch leere Werte übernommen. Ansonsten verbleiben bisherige Werte für (i, j), wenn die documentTokens[i][j] == "" ist.</param>
    /// <returns></returns>
    public bool ChangeCompleteDocument(Guid documentGuid, string[][] documentTokens, bool applyEmptyValues = true)
    {
      if (!DocumentExists(documentGuid))
        return false;

      var old = DocumentGet(documentGuid);
      if (old.Length != documentTokens.Length)
        return false;
      if (old.Where((t, i) => t.Length != documentTokens[i].Length).Any())
        return false;

      if (applyEmptyValues) // Wenn die Werte wie gegeben übernommen werden sollen.
      {
        ChangeCompleteDocument(documentGuid, ConvertToLayer(documentTokens));
        return true;
      }

      // Wenn gewünscht ist, dass "" als keine Änderung zu interpretieren ist.
      if (!DocumentExists(documentGuid))
        return false;
      var oldDoc = DocumentGet(documentGuid);
      ChangeCompleteDocument(documentGuid, ConvertToLayer(documentTokens));
      var newDoc = DocumentGet(documentGuid);

      var idx = RequestIndex("");
      for (var s = 0; s < oldDoc.Length; s++)
        for (var w = 0; w < oldDoc[s].Length; w++)
          if (newDoc[s][w] != idx)
            oldDoc[s][w] = newDoc[s][w]; // Stelle Werte wieder her.

      DocumentAdd(documentGuid, oldDoc);
      return true;
    }

    public void AddCompleteDocument(Guid documentGuid, string[][] documentTokens)
    {
      AddCompleteDocument(documentGuid, ConvertToLayer(documentTokens));
    }

    public void AddCompleteDocument(Guid documentGuid, IEnumerable<IEnumerable<string>> documentTokens)
    {
      AddCompleteDocument(documentGuid, ConvertToLayer(documentTokens));
    }

    public override bool AllowAnnotation(string[] data)
    {
      return data.Length > MinimumDataLength;
    }

    public override bool AllowValueChange(string[] data)
    {
      return data.Length > MinimumDataLength;
    }

    public int[][] ConvertToLayer(IEnumerable<IEnumerable<string>> document)
    {
      return ConvertToLayer(document.Select(s => s.ToArray()).ToArray());
    }

    public int[][] ConvertToLayer(string[][] document)
    {
      var res = new int[document.Length][];

      for (var i = 0; i < document.Length; i++)
      {
        res[i] = new int[document[i].Length];
        for (var j = 0; j < document[i].Length; j++)
          res[i][j] = base.RequestIndex(document[i][j] ?? string.Empty);
      }

      return res;
    }

    public int ConvertToLayer(string layerValue)
    {
      return base.RequestIndex(layerValue);
    }

    public override int RequestIndex(string[] data, int lastIndex)
    {
      return RequestIndex(data[_valueIndex]);
    }

    public void AddCompleteDocument(Guid documentGuid, int[][] documentTokens)
    {
      if (!DocumentExists(documentGuid))
        DocumentAdd(documentGuid, documentTokens);
    }

    private void ChangeCompleteDocument(Guid documentGuid, int[][] documentTokens)
    {
      if (DocumentExists(documentGuid))
        DocumentAdd(documentGuid, documentTokens);
    }    
  }
}