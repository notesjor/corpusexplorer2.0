#region

using System;
using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Properties;

#endregion

namespace CorpusExplorer.Sdk.Helper
{
  /// <summary>
  ///   The multidimensional document extension.
  /// </summary>
  public static class MultidimensionalDocumentExtension
  {
    #region Public Methods and Operators

    /// <summary>
    ///   The get multidimensional document.
    /// </summary>
    /// <param name="layers">
    ///   The layers.
    /// </param>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <returns>
    ///   The MultidimensionalDocument int[][][]
    /// </returns>
    /// <exception cref="NoNullAllowedException">
    /// </exception>
    public static int[][][] GetMultidimensionalDocument(
      this IEnumerable<AbstractLayerAdapter> layers,
      Guid documentGuid)
    {
      // ReSharper restore NoParameterNullCheckForPublicFunctions
      var res = new List<int[][]>();
      foreach (var layer in layers)
      {
        if (layer == null)
          throw new NoNullAllowedException(Resources.LayerValueNullError);

        res.Add(layer[documentGuid]);
      }

      return res.ToArray();
    }

    #endregion // ReSharper disable NoParameterNullCheckForPublicFunctions
  }
}