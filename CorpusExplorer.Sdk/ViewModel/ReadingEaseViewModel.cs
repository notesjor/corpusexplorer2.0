using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.ReadingEase;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class ReadingEaseViewModel : AbstractViewModel, IProvideDataTable
  {
    public string LayerDisplayname { get; set; } = "Wort";

    public Dictionary<string, Dictionary<Guid, double>> ReadingEaseIndices { get; set; }

    /// <summary>
    ///   Gibt eine Datentabelle zurück
    /// </summary>
    /// <returns>Datentabelle</returns>
    public DataTable GetDataTable()
    {
      var proto = Selection.GetDocumentMetadataPrototypeOnlyProperties().ToArray();

      var res = new DataTable();
      res.Columns.Add(Resources.Index, typeof(string));
      foreach (var x in proto)
        res.Columns.Add(x, typeof(string));
      res.Columns.Add(Resources.Wert, typeof(double));

      res.BeginLoadData();

      var row = new object[proto.Length + 2];
      var lst = row.Length - 1;

      foreach (var x in ReadingEaseIndices)
      {
        row[0] = x.Key;
        foreach (var y in x.Value)
        {
          var meta = Selection.GetDocumentMetadata(y.Key);
          if (meta == null)
            continue;

          for (var i = 0; i < proto.Length; i++)
            row[i + 1] = meta.ContainsKey(proto[i]) ? meta[proto[i]] == null ? "" : meta[proto[i]].ToString() : "";
          row[lst] = y.Value;

          res.Rows.Add(row);
        }
      }

      res.EndLoadData();
      return res;
    }

    /// <summary>
    ///   Gibt eine einfache Datentabelle ohne Metadaten zurück
    /// </summary>
    /// <returns>Datentabelle</returns>
    public DataTable GetDataTableSimple()
    {
      var res = new DataTable();
      res.Columns.Add(Resources.Index, typeof(string));
      res.Columns.Add(Resources.DokumentGUID, typeof(string));
      res.Columns.Add(Resources.Wert, typeof(double));

      res.BeginLoadData();

      foreach (var x in ReadingEaseIndices)
        foreach (var y in x.Value)
          res.Rows.Add(x.Key, y.Key.ToString(), y.Value);

      res.EndLoadData();
      return res;
    }

    protected override void ExecuteAnalyse()
    {
      try
      {
        var block = Selection.CreateBlock<ReadingEaseBlock>();
        block.LayerDisplayname = LayerDisplayname;

        ReadingEaseIndices = new Dictionary<string, Dictionary<Guid, double>>();

        foreach (var index in Configuration.GetSideloadFeature<AbstractReadingEaseIndex>())
        {
          block.ReadingEaseAlgorithm = index;
          block.Calculate();

          ReadingEaseIndices.Add(index.Displayname, block.ReadingEaseIndices);
        }
      }
      catch (Exception ex)
      {
      }
    }

    protected override bool Validate()
    {
      return true;
    }
  }
}