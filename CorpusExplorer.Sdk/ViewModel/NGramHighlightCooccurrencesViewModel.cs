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
  public class NGramHighlightCooccurrencesViewModel : AbstractViewModel, IUseSpecificLayer, IProvideDataTable
  {
    public NGramHighlightCooccurrencesViewModel()
    {
      LayerDisplayname = "Wort";
      NGramSize = 5;
    }

    public int NGramSize { get; set; }

    public Dictionary<KeyValuePair<string, byte>[], double> WeightedNgrams { get; set; }

    public Dictionary<string, KeyValuePair<string, double>> WeightedNgramsHtml
    {
      get
      {
        var d1 = new Dictionary<string, double>();
        var d2 = new Dictionary<string, string>();

        foreach (var ngram in WeightedNgrams)
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
            d1[key] += ngram.Value;
          }
          else
          {
            d1.Add(key, 1);
            d2.Add(key, string.Join(" ", ngram.Key.Select(x => x.Key)));
          }
        }

        return d1.ToDictionary(x => x.Key, x => new KeyValuePair<string, double>(d2[x.Key], x.Value));
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
      dt.Columns.Add(Resources.Query, typeof(string));

      dt.BeginLoadData();
      foreach (var ngram in WeightedNgramsHtml)
        dt.Rows.Add(ngram.Key, ngram.Value.Value, ngram.Value.Key);
      dt.EndLoadData();

      return dt;
    }

    public IEnumerable<string> LayerDisplaynames => Selection.LayerDisplaynames;

    public string LayerDisplayname { get; set; }

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<NGramHighlightCooccurrencesBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.NGramSize = NGramSize;
      block.Calculate();

      WeightedNgrams = block.WeightedNgrams;
    }

    protected override bool Validate()
    {
      return true;
    }
  }
}