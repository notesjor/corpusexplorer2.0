#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

#endregion

namespace CorpusExplorer.Sdk.ViewModel
{
  /// <summary>
  ///   The ngram view model.
  /// </summary>
  public class NgramViewModel : AbstractViewModel, IUseSpecificLayer, IProvideDataTable, IProvideCorrespondingLayerValueFilter
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="NgramViewModel" /> class.
    /// </summary>
    public NgramViewModel()
    {
      NGramSize = 5;
      NGramPatternSize = 0;
      NGramPattern = "###";
      LayerDisplayname = "Wort";
      NGramMaxResults = 0;
    }

    /// <summary>
    ///   Gets or sets the n gram frequency.
    /// </summary>
    public Dictionary<string, double> NGramFrequency { get; set; }

    /// <summary>
    ///   Limitiert die Ausgabe von GetDataTable auf die TOP-N-Gramm Frequenzen. Wenn 0 - dann keine Limitierung.
    /// </summary>
    /// <value>The n gram maximum results.</value>
    public int NGramMaxResults { get; set; }

    /// <summary>
    ///   Gets or sets the n gram pattern.
    /// </summary>
    public string NGramPattern { get; set; }

    /// <summary>
    ///   Gets or sets the n gram pattern max.
    /// </summary>
    public int NGramPatternSize { get; set; }

    public int NGramSize { get; set; }

    /// <summary>
    ///   Eigenschaft kann gesetzt werden, um die Ausgabe von GetDataTable() zu filtern.
    ///   Zum Filter/Optimieren des Blocks sollte Configuration.MinimumFrequency gesetzt werden.
    /// </summary>
    /// <value>The n gram minimum frequency.</value>
    public int NGramMinFrequency { get; set; } = 0;

    /// <summary>
    ///   Gibt eine Datentabelle zur�ck
    /// </summary>
    /// <returns>Datentabelle</returns>
    public DataTable GetDataTable()
    {
      var res = new DataTable();
      res.Columns.Add(Resources.NGram, typeof(string));
      res.Columns.Add(Resources.Frequency, typeof(int));

      var data = NGramMaxResults == 0
                   ? NGramFrequency
                   : NGramFrequency.OrderByDescending(x => x.Value).Take(NGramMaxResults);

      res.BeginLoadData();
      var @lock = new object();

      Parallel.ForEach(data, x =>
      {
        if (x.Value < NGramMinFrequency)
          return;

        if (CorrespondingLayerValueFilter == null)
          lock (@lock)
            res.Rows.Add(x.Key, x.Value);
        else
        {
          var tokens = x.Key.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
          if (!CorrespondingLayerValueFilter.CustomFilter(tokens))
            return;

          lock (@lock)
            res.Rows.Add(x.Key, x.Value);
        }
      });
      res.EndLoadData();

      return res;
    }

    public string LayerDisplayname { get; set; }

    protected override void ExecuteAnalyse()
    {
      if (NGramPatternSize > 0)
      {
        var block = Selection.CreateBlock<Ngram1LayerPatternBlock>();
        block.NGramSize = NGramSize;
        block.NGramPattern = NGramPattern;
        block.NGramPatternSize = NGramPatternSize;
        block.LayerDisplayname = LayerDisplayname;
        block.Calculate();

        NGramFrequency = block.NGramFrequency;
      }
      else
      {
        var block = Selection.CreateBlock<Ngram1LayerBlock>();
        block.NGramSize = NGramSize;
        block.LayerDisplayname = LayerDisplayname;
        block.Calculate();

        NGramFrequency = block.NGramFrequency;
      }
    }

    protected override bool Validate()
    {
      return !string.IsNullOrEmpty(NGramPattern) &&
             !string.IsNullOrEmpty(LayerDisplayname)
          && NGramPatternSize < NGramSize && NGramSize > 0;
    }

    public CorrespondingLayerValueFilterViewModel CorrespondingLayerValueFilter { get; set; }
  }
}