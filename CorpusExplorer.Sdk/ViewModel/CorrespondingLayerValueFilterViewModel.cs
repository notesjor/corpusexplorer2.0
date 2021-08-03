using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.ViewModel.Abstract;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class CorrespondingLayerValueFilterViewModel : AbstractViewModel
  {
    private int[] _cid;
    public string Layer1Displayname { get; set; } = "Wort";
    public string Layer2Displayname { get; set; } = "POS";

    public HashSet<string> Layer2ValueFilters { get; set; }

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<CorrespondingLayerValueFilterBlock>();
      block.Layer2ValueFilters = Layer2ValueFilters;
      block.Layer1Displayname = Layer1Displayname;
      block.Layer2Displayname = Layer2Displayname;
      block.Calculate();

      Layer1FilterValueResults = block.Layer1FilterValueResults;
    }

    public HashSet<string> Layer1FilterValueResults { get; private set; } = new HashSet<string>();
    /// <summary>
    /// Wenn true, reicht es, wenn eine token aus tokens einen CorrespondendLayerValue beinhaltet - ansonsten müssen alle tokens correspondieren.
    /// </summary>
    public bool AnyMatch { get; set; }

    /// <summary>
    /// Erlaubt eine manuelle Überprüfung
    /// </summary>
    /// <param name="tokens">Liste beliebiger Token</param>
    /// <returns>Filter ok?</returns>
    public bool CustomFilter(params string[] tokens)
    {
      if (AnyMatch)
      {
        if (tokens.Any(token => Layer1FilterValueResults.Contains(token)))
          return true;
      }
      else
      {
        if (tokens.All(token => Layer1FilterValueResults.Contains(token)))
          return true;
      }

      return false;
    }

    /// <summary>
    /// Erlaubt eine manuelle Überprüfung
    /// </summary>
    /// <param name="token">ein beliebiges Token (z. B. key)</param>
    /// <returns>Filter ok?</returns>
    public bool CustomFilter(string token) 
      => Layer1FilterValueResults.Contains(token);

    /// <summary>
    /// Bereitet den DataTableFilter vor
    /// </summary>
    /// <param name="table">Tabelle - muss bereits alle Spalten mit Namen enthalten.</param>
    /// <param name="filterColumnNames">Auflsitung der zu filternden Spalten</param>
    public void DataTableFilterInit(ref DataTable table, IEnumerable<string> filterColumnNames)
    {
      var filter = new HashSet<string>(filterColumnNames);
      
      var cid = new List<int>();
      for (var i = 0; i < table.Columns.Count; i++)
        if(filter.Contains(table.Columns[i].ColumnName))
          cid.Add(i);
      _cid = cid.ToArray();
    }

    /// <summary>
    /// Wenn DataTableFilterInit verwendet wurde, kann eine Zeile automatisch überprüft werden.
    /// </summary>
    /// <param name="row">Zeile</param>
    /// <returns>Filter ok?</returns>
    public bool DataTableFilter(object[] row)
    {
      try
      {
        if (AnyMatch)
        {
          foreach (var i in _cid)
          {
            if (Layer1FilterValueResults.Contains(row[i]?.ToString())) 
              return true;
          }

          return false;
        }
        // ReSharper disable once RedundantIfElseBlock
        else
        {
          foreach (var i in _cid)
          {
            if (Layer1FilterValueResults.Contains(row[i]?.ToString()))
              continue;
            return false;
          }

          return true;
        }
      }
      catch
      {
        return false;
      }
    }

    protected override bool Validate() 
      => !string.IsNullOrEmpty(Layer1Displayname) && !string.IsNullOrEmpty(Layer2Displayname);
  }
}
