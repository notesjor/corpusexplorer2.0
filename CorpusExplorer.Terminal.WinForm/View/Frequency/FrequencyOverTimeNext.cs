using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CorpusExplorer.Sdk.Extern.Xml.Bnc.Model;
using CorpusExplorer.Sdk.View.Html;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CorpusExplorer.Terminal.WinForm.View.Frequency
{
  public partial class FrequencyOverTimeNext : AbstractView
  {
    private bool _firstRun = true;
    private string _lastSelectedLayer;
    private CooccurrenceViewModel _vm;

    public FrequencyOverTimeNext()
    {
      InitializeComponent();
    }

    private void commandBarButton1_Click(object sender, EventArgs e)
    {
      webHtml5Visualisation1.Print();
    }

    // private void commandBarButton2_Click(object sender, EventArgs e) { webHtml5Visualisation1.ExportHtml(); } 

    private void commandBarButton3_Click(object sender, EventArgs e)
    {
      webHtml5Visualisation1.ExportImage();
    }

    private void commandBarButton4_Click(object sender, EventArgs e)
    {
      webHtml5Visualisation1.ExportPdf();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      timer1.Stop();
      wordBag1_ExecuteButtonClicked(null, null);
    }

    private class yitem
    {
      public string name {get; set; }
      public string type {get; set; } = "line";
      public string stack {get; set; } = "Total";
      public double[] data {get; set; }
    }

    private void ToJsonArray(out string[] xaxis, out yitem[] yaxis)
    {
      _vm = GetViewModel<CooccurrenceViewModel>();
      _vm.LayerDisplayname = wordBag1.ResultSelectedLayerDisplayname;
      if (!_vm.Execute())
      {
        xaxis = new string[] { };
        yaxis = new yitem[] { };
        return;
      }
      _lastSelectedLayer = wordBag1.ResultSelectedLayerDisplayname;

      xaxis = new string[] { };
      yaxis = new yitem[] { };
    }

    private void wordBag1_ExecuteButtonClicked(object sender, EventArgs e)
    {
      Processing.SplashShow("Erzeuge Chart...");

      ToJsonArray(out var xaxis, out var yaxis);

      webHtml5Visualisation1.ShowFile(EasyWebBuilder
                                     .Create()
                                     .SetIndexByDependencyFile("ECharts/LineChart.html")
                                     .ReplaceTemplateVars(new Dictionary<string, string>
                                      {
                                        {
                                          "###X-AXIS###",
                                          JsonConvert.SerializeObject(xaxis)
                                        },
                                        {
                                          "###Y-AXIS###",
                                          JsonConvert.SerializeObject(yaxis)
                                         }
                                      })
                                     .Finalize());
      if (!_firstRun)
      {
        Processing.SplashClose();
        return;
      }

      _firstRun = false;
      timer1.Start();
    }

    private void wordBag1_Load(object sender, EventArgs e)
    {
    }

    private void WordCloudVisualisation_ShowVisualisation(object sender, EventArgs e)
    {
    }
  }
}