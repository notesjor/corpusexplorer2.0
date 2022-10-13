using System;
using System.Linq;
using CorpusExplorer.Sdk.EchtzeitEngine.Calculator.Step;
using CorpusExplorer.Sdk.EchtzeitEngine.Reporting;
using CorpusExplorer.Sdk.EchtzeitEngine.Reporting.Forms;
using CorpusExplorer.Sdk.EchtzeitEngine.Reporting.Forms.Model;
using CorpusExplorer.Sdk.EchtzeitEngine.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;

namespace CorpusExplorer.Terminal.WinForm.View.Special
{
  public partial class PaperLinguist : AbstractView
  {
    private string[] _pos;
    private string[] _words;

    public PaperLinguist()
    {
      InitializeComponent();
      ShowView += PaperLinguist_ShowView;
    }

    private static char[] _separator = {';', ' '};

    private void btn_execute_Click(object sender, EventArgs e)
    {
      ReportTreeItem report = null;

      Processing.Invoke(
                        "Erstelle Analysebericht...",
                        () =>
                        {
                          var vm = GetViewModel<EchtzeitEngineViewModel>();
                          vm.CalculatorSteps.Add(new CalculatorStepCorpusBaseInfo());
                          if (chk_overview_analy_corpusDistribution.Checked)
                            vm.CalculatorSteps.Add(new CalculatorStepDistribution
                            {
                              Top = (int) num_overview_analy_corpusDistribution.Value
                            });
                          if (chk_overview_analy_cooccurrences.Checked)
                            vm.CalculatorSteps.Add(new CalculatorStepCooccurreces
                            {
                              Top = (int) num_overview_analy_cooccurrences.Value
                            });

                          var posFilter =
                            txt_overview_analy_posFilter.Text.Split(_separator,
                                                                    StringSplitOptions.RemoveEmptyEntries);

                          if (chk_overview_analy_frequency.Checked)
                            vm.CalculatorSteps.Add(new CalculatorStepFrequency3LayerPosFilter
                            {
                              Top = (int) num_overview_analy_frequency.Value,
                              PosTags = posFilter
                            });
                          if (chk_overview_analy_kwic.Checked)
                            vm.CalculatorSteps.Add(
                                                   new CalculatorStepKwicTopFrequencyPosFilter
                                                   {
                                                     Top = (int) num_overview_analy_frequency.Value,
                                                     PosTags = posFilter
                                                   });

                          var queries = txt_query_kwicRequests.Text.Split(_separator,
                                                                          StringSplitOptions.RemoveEmptyEntries);

                          if (chk_query_kwic.Checked)
                            vm.CalculatorSteps.Add(
                                                   new CalculatorStepKwicAnyMatch
                                                   {
                                                     Queries = queries
                                                   });
                          if (chk_query_cooccurrences.Checked)
                            vm.CalculatorSteps.Add(
                                                   new CalculatorStepCooccurrecesSelective
                                                   {
                                                     Queries = queries
                                                   });

                          vm.Execute();

                          var generator = new ReportingGenerator();
                          report = generator.Execute(vm.ResultStorage);
                        });
      var form = new ReportView(report);
      form.ShowDialog();
    }

    private void PaperLinguist_ShowView(object sender, EventArgs e)
    {
      _pos = Project.CurrentSelection.GetLayerValues(Resources.POS).ToArray();
      txt_overview_analy_posFilter.AutoCompleteDataSource = _pos;

      _words = Project.CurrentSelection.GetLayerValues("Wort").ToArray();
      txt_query_kwicRequests.AutoCompleteDataSource = _words;
    }
  }
}