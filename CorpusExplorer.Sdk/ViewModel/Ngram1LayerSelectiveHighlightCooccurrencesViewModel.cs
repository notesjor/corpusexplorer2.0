using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class NgramHighlightCooccurrencesViewModel : AbstractViewModel, IUseSpecificLayer, IProvideDataTable
  {
    private NgramHighlightCooccurrencesBlock _block;

    public NgramHighlightCooccurrencesViewModel()
    {
      LayerDisplayname = "Wort";
      NGramSize = 5;
    }

    public int NGramSize { get; set; }

    /// <summary>
    /// Format:
    /// Key = NGram > Key = Token / Value = Signifikanz (max.)
    /// Value = Frequenz
    /// </summary>
    public KeyValuePair<KeyValuePair<string, double>[], double>[] NgramsSignificants => _block.NgramsSignificants;

    /// <summary>
    /// Format:
    /// Key = NGram > Key = Token / Value = Rang
    /// Value = Werte > [0] = Frequenz / [1] = Signifikanz (max.) / [2] = Signifikanz (Summe)
    /// </summary>
    public KeyValuePair<KeyValuePair<string, byte>[], double[]>[] NgramsWeighted => _block.NgramsWeighted;

    public Dictionary<string, KeyValuePair<string, double[]>> WeightedNgramsHtml
    {
      get
      {
        var d1 = new Dictionary<string, double[]>();
        var d2 = new Dictionary<string, string>();

        foreach (var ngram in NgramsWeighted)
        {
          var stb = new StringBuilder("<html>");

          foreach (var x in ngram.Key)
            switch (x.Value)
            {
              case 0:
                stb.Append("<color= 200, 200, 200>[...]&nbsp;");
                break;
              case 1:
                stb.Append($"<color= 150, 150, 150>{x.Key}&nbsp;");
                break;
              case 2:
                stb.Append($"<color= 0, 0, 0>{x.Key}&nbsp;");
                break;
              case 3:
                stb.Append($"<color= 0, 122, 204>{x.Key}&nbsp;");
                break;
            }

          stb.Append("</html>");

          var key = stb.ToString();

          if (d1.ContainsKey(key))
          {
            d1[key][0] += ngram.Value[0];
            d1[key][1] = d1[key][1] > ngram.Value[0] ? d1[key][1] : ngram.Value[0];
          }
          else
          {
            d1.Add(key, ngram.Value);
            d2.Add(key, string.Join(" ", ngram.Key.Select(x => x.Key)));
          }
        }

        return d1.ToDictionary(x => x.Key, x => new KeyValuePair<string, double[]>(d2[x.Key], x.Value));
      }
    }

    /// <summary>
    ///   Gibt eine Datentabelle zurück
    /// </summary>
    /// <returns>Datentabelle</returns>
    public DataTable GetDataTable()
    {
      var dt = new DataTable();

      dt.Columns.Add(Resources.Unit, typeof(string));
      dt.Columns.Add(Resources.Frequency, typeof(int));
      dt.Columns.Add(Resources.Significance, typeof(double));
      dt.Columns.Add(Resources.Query, typeof(string));

      dt.BeginLoadData();
      foreach (var ngram in WeightedNgramsHtml)
        dt.Rows.Add(ngram.Key, ngram.Value.Value[0], ngram.Value.Value[1], ngram.Value.Key);
      dt.EndLoadData();

      return dt;
    }

    public string LayerDisplayname { get; set; }

    protected override void ExecuteAnalyse()
    {
      _block = Selection.CreateBlock<NgramHighlightCooccurrencesBlock>();
      _block.LayerDisplayname = LayerDisplayname;
      _block.NGramSize = NGramSize;
      _block.Calculate();
    }

    protected override bool Validate()
    {
      return true;
    }
  }
}