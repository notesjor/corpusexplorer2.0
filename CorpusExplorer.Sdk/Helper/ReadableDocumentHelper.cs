#region

using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Helper
{
  public static class ReadableDocumentHelper
  {
    public static IEnumerable<string> ConvertAndReduceToReadableArray(
      this IEnumerable<IEnumerable<int>> document,
      AbstractLayerAdapter layer)
    {
      return ConvertToReadableArray(ReduceToSingleDimension(document), layer);
    }

    public static string ConvertToPlainText(this IEnumerable<IEnumerable<string>> readableDocument)
    {
      return ConvertToText(readableDocument).Replace(" . ", ". ")
        .Replace(" : ", "; ")
        .Replace(" ; ", ": ")
        .Replace(" , ", ", ")
        .Replace(" ! ", "! ")
        .Replace(" ? ", "? ")
        .Replace(" ) ", ") ")
        .Replace(" ] ", "] ")
        .Replace(" [ ", " [")
        .Replace(" ( ", " (");
    }

    public static IEnumerable<IEnumerable<string>> ConvertToReadableArray(
      this IEnumerable<IEnumerable<int>> document,
      AbstractLayerAdapter layer)
    {
      return document.Select(x => ConvertToReadableArray(x, layer));
    }

    public static IEnumerable<string> ConvertToReadableArray(this IEnumerable<int> document, AbstractLayerAdapter layer)
    {
      return document == null || layer == null ? null : document.Select(x => layer[x]);
    }

    public static string ConvertToText(this IEnumerable<IEnumerable<string>> readableDocument)
    {
      return ConvertToText(ReduceToSingleDimension(readableDocument));
    }

    public static string ConvertToText(this IEnumerable<IEnumerable<int>> document, AbstractLayerAdapter layer)
    {
      return ConvertToText(ConvertAndReduceToReadableArray(document, layer));
    }

    public static string ConvertToText(this IEnumerable<string> readableDocument)
    {
      if (readableDocument == null)
        return string.Empty;

      return string.Join(" ", readableDocument).Trim().Replace("  ", " ");
    }

    public static string ConvertToText(this IEnumerable<int> document, AbstractLayerAdapter layer)
    {
      return ConvertToText(ConvertToReadableArray(document, layer));
    }

    public static IEnumerable<int> ReduceToSingleDimension(this IEnumerable<IEnumerable<int>> document)
    {
      return document?.SelectMany(s => s);
    }

    public static IEnumerable<string> ReduceToSingleDimension(this IEnumerable<IEnumerable<string>> document)
    {
      return document?.SelectMany(s => s);
    }
  }
}