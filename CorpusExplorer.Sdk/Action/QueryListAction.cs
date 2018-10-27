using System;
using System.IO;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter;
using CorpusExplorer.Sdk.Utils.Filter.Queries;

namespace CorpusExplorer.Sdk.Action
{
  public class QueryListAction : IAction
  {
    public string Action => "query-list";
    public string Description => "query-list [QUERY] [NAME] - works like query, but returns a [NAME]ed list of document GUIDs.";

    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      if (args == null || args.Length != 3)
        return;

      var s = args[0].Split(new[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
      if (s.Length != 2)
        return;

      var query = QueryParser.Parse(args[0]);
      if (query is FilterQueryUnsupportedParserFeature feature)
      {
        UnsupportedQueryParserFeatureHelper.Handle(selection, feature, args[1], writer);
        return;
      }

      var sub = selection.Create(new[] { query }, Path.GetFileNameWithoutExtension(args[1]));

      writer.WriteTable(args[2], sub.GetDocumentGuidAndDisplaynamesAsDataTable());
    }
  }
}