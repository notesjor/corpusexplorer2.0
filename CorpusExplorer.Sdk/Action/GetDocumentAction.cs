using System;
using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Action
{
  public class GetDocumentAction : IAction
  {
    public string Action => "get-document";
    public string Description => "get-document [GUID] {LAYER} - get all layer-information for specific [GUID] document. Use {LAYER} to filter output.";

    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      if (args == null || args.Length < 1)
        return;

      var guid = Guid.Parse(args[0]);
      if (!selection.ContainsDocument(guid))
        return;

      var layers = selection.GetReadableMultilayerDocument(guid);

      var fArgs = new List<string>(args);
      fArgs.RemoveAt(0);
      var filter = new HashSet<string>();
      if (fArgs.Count == 0)
        foreach (var l in layers)
          filter.Add(l.Key);
      else
        filter = new HashSet<string>(fArgs);

      var dt = new DataTable();
      dt.Columns.Add("layer", typeof(string));
      dt.Columns.Add("content", typeof(string));

      dt.BeginLoadData();
      foreach (var pair in layers)
        if (filter.Contains(pair.Key))
          dt.Rows.Add(pair.Key, pair.Value.ReduceDocumentToText());

      dt.EndLoadData();

      writer.WriteTable(selection.Displayname, dt);
    }
  }
}