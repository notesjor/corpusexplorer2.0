using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using Newtonsoft.Json.Linq;

namespace CorpusExplorer.Terminal.WinForm.View.Cooccurrence
{
  public partial class CooccurrenceTagPie : AbstractView
  {
    private string _lastSelectedLayer = "";
    private CooccurrenceViewModel _vm;
    private bool _firstRun = true;

    public CooccurrenceTagPie()
    {
      InitializeComponent();
      wordBag1.AddToRow1(commandBarStripElement1);
    }

    private void commandBarButton1_Click(object sender, EventArgs e) { webHtml5Visualisation1.Print(); }

    // private void commandBarButton2_Click(object sender, EventArgs e) { webHtml5Visualisation1.ExportHtml(); } 

    private void commandBarButton3_Click(object sender, EventArgs e) { webHtml5Visualisation1.ExportImage(); }

    private void commandBarButton4_Click(object sender, EventArgs e) { webHtml5Visualisation1.ExportPdf(); }

    private string ToJsonArray()
    {
      if (wordBag1.SelectedLayer != _lastSelectedLayer)
      {
        _vm = ViewModelGet<CooccurrenceViewModel>();
        _vm.LayerDisplayname = wordBag1.SelectedLayer;
        _vm.Analyse();
        _lastSelectedLayer = wordBag1.SelectedLayer;
      }

      var array = new JArray();

      foreach (var query in wordBag1.Queries)
      {
        var lim = 52.0;

        var cooc = _vm.Search(new[] { query }).ToDictionary(x => x.Key, x => x.Value[1] + 1);
        var max = (int)cooc.Select(x => x.Value).Concat(new[] { 1d }).Max();
        var fact = lim / max;

        var array2 = new JArray();
        foreach (var x in cooc)
          array2.Add(new JObject { { "key", x.Key }, { "value", (int)x.Value * fact } });

        var entry = new JObject { { "major", new JObject { { "key", query }, { "value", lim } } }, { "data", array2 } };
        array.Add(entry);
      }

      return array.ToString();
    }

    private void wordBag1_ExecuteButtonClicked(object sender, EventArgs e)
    {
      Processing.SplashShow("Erzeuge TagPie...");
      webHtml5Visualisation1.MainpageUrl = Configuration.GetDependencyPath("d3Templates/tagpies.html");
      webHtml5Visualisation1.TemplateVars = new Dictionary<string, string>
        {
          {
            "<!--#DATA#-->",
            ToJsonArray()
          }
        };
      webHtml5Visualisation1.GoToMainpage();
      if (!_firstRun)
      {
        Processing.SplashClose();
        return;
      }

      _firstRun = false;
      timer1.Start();
    }

    private void wordBag1_Load(object sender, EventArgs e) { }

    private void WordCloudVisualisation_ShowVisualisation(object sender, EventArgs e)
    {
      wordBag1.Selection = Project.CurrentSelection;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      timer1.Stop();
      wordBag1_ExecuteButtonClicked(null, null);
    }
  }
}