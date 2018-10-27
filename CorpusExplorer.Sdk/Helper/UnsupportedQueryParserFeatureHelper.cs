using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Action;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;

namespace CorpusExplorer.Sdk.Helper
{
  public static class UnsupportedQueryParserFeatureHelper
  {
    public static IEnumerable<Selection> Handle(Selection selection, FilterQueryUnsupportedParserFeature query,
                                                string output = null, AbstractTableWriter writer = null)
    {
      return query.MetaLabel == "<:RANDOM:>"
               ? UnsupportedParserRandomFeature(selection, query, output, writer)
               : UnsupportedParserFeatureAutosplit(selection, query, output, writer);
    }

    private static IEnumerable<Selection> UnsupportedParserRandomFeature(
      Selection selection, FilterQueryUnsupportedParserFeature query, string output, AbstractTableWriter writer)
    {
      var values = query.MetaValues?.ToArray();
      if (values?.Length != 1)
        return null;

      var block = selection.CreateBlock<RandomSelectionBlock>();
      block.DocumentCount = int.Parse(values[0].ToString());
      block.Calculate();

      return string.IsNullOrEmpty(output)
               ? UnsupportedParserRandomFeatureToObject(block)
               : UnsupportedParserRandomFeatureToFile(writer, output, block);
    }

    private static IEnumerable<Selection> UnsupportedParserRandomFeatureToObject(RandomSelectionBlock block)
    {
      return new[] { block.RandomSelection, block.RandomInvertSelection };
    }

    private static IEnumerable<Selection> UnsupportedParserRandomFeatureToFile(
      AbstractTableWriter writer, string output, RandomSelectionBlock block)
    {
      var outputOptions = output.Split(new[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
      if (outputOptions.Length != 2)
        return null;

      var export = new ConvertAction();
      export.Execute(block.RandomSelection, new[] { output }, writer);

      var form = outputOptions[0];
      var path = outputOptions[1];
      var nam = Path.GetFileNameWithoutExtension(path);
      var ext = Path.GetExtension(path);
      var dir = Path.GetDirectoryName(path);
      if (dir != null && !Directory.Exists(dir))
        Directory.CreateDirectory(dir);

      export.Execute(block.RandomInvertSelection, new[] { $"{form}#\"{Path.Combine(dir, $"{nam}_inverse{ext}")}\"" },
                     writer);
      return null;
    }

    private static IEnumerable<Selection> UnsupportedParserFeatureAutosplit(
      Selection selection, FilterQueryUnsupportedParserFeature query, string output, AbstractTableWriter writer)
    {
      var values = query.MetaValues?.ToArray();
      if (values?.Length != 1)
        return null;

      var selections = AutoSplitBlockHelper.RunAutoSplit(selection, query, values);

      return string.IsNullOrEmpty(output) ? selections : UnsupportedParserFeatureAutosplitToFile(writer, output, selections);
    }

    private static IEnumerable<Selection> UnsupportedParserFeatureAutosplitToFile(
      AbstractTableWriter writer, string output, IEnumerable<Selection> selections)
    {
      var outputOptions = output.Split(new[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
      if (outputOptions.Length != 2)
        return null;

      var form = outputOptions[0];
      var path = outputOptions[1];
      var dir = Path.GetDirectoryName(path);
      var nam = Path.GetFileNameWithoutExtension(path);
      var ext = Path.GetExtension(path);

      if (dir != null && !Directory.Exists(dir))
        Directory.CreateDirectory(dir);

      var export = new ConvertAction();
      foreach (var cluster in selections)
        export.Execute(cluster, new[] { $"{form}#\"{Path.Combine(dir, $"{nam}_{cluster.Displayname.EnsureFileName()}{ext}")}\"" }, writer);

      return null;
    }
  }
}