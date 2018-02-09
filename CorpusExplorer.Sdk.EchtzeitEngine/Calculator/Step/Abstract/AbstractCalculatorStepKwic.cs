using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.EchtzeitEngine.Calculator.Step.Interface;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.ViewModel;

namespace CorpusExplorer.Sdk.EchtzeitEngine.Calculator.Step.Abstract
{
  public abstract class AbstractCalculatorStepKwic : AbstractCalculatorStep, ICalculatorStepHasMultiQueries
  {
    protected AbstractCalculatorStepKwic()
    {
      Queries = new string[0];
    }

    protected DataTable RequestDataTableViaTextLive(Selection selection, AbstractFilterQuery query)
    {
      var vm = new TextLiveSearchViewModel { Selection = selection };
      vm.AddQuery(query);
      vm.Analyse();

      var dt = new DataTable();
      dt.Columns.Add("Pre");
      dt.Columns.Add("Match");
      dt.Columns.Add("Post");
      dt.Columns.Add("GUID");
      dt.BeginLoadData();

      foreach (var entry in vm.GetUniqueData())
        foreach (var sentence in entry.Sentences)
          dt.Rows.Add(entry.Pre, entry.Match, entry.Post, sentence.Key);

      dt.EndLoadData();

      return dt;
    }

    public IEnumerable<string> Queries { get; set; }
  }
}