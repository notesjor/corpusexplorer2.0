using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;

namespace CorpusExplorer.Terminal.WinForm.View.Cooccurrence
{
  public partial class CooccurrenceWordCloud : AbstractView
  {
    private string lastLayer = "";

    public CooccurrenceWordCloud()
    {
      InitializeComponent();
      wordBag1.AddToRow1(commandBarStripElement1);
      radCommandBar1.Parent.Controls.Remove(radCommandBar1);
    }

    private void commandBarButton1_Click(object sender, EventArgs e) { webHtml5Visualisation1.Print(); }

    // private void commandBarButton2_Click(object sender, EventArgs e) { webHtml5Visualisation1.ExportHtml(); }

    private void commandBarButton3_Click(object sender, EventArgs e) { webHtml5Visualisation1.ExportImage(); }

    private void commandBarButton4_Click(object sender, EventArgs e) { webHtml5Visualisation1.ExportPdf(); }

    private void radLabel1_Click(object sender, EventArgs e) { Process.Start(webHtml5Visualisation1.MainpageUrl); }

    private string ToJsonArray(IEnumerable<KeyValuePair<string, double>> search)
    {
      if (search == null)
        return null;

      var stb = new StringBuilder();
      var filter = new Dictionary<string, int>();
      var sum = search.Sum(pair => pair.Value);
      foreach (var pair in search)
      {
        var value = (int) (pair.Value/sum*1000d);
        if (value < 10)
          continue;
        filter.Add(pair.Key, value);
      }
      IEnumerable<KeyValuePair<string, int>> list = filter.OrderByDescending(x => x.Value).Take(30).ToArray();
      double max = list.Select(x => x.Value).Concat(new[] { 1 }).Max();

      list = list.Select(x => new KeyValuePair<string, int>(x.Key, (int) (x.Value/(max/120.0d))));
      list = list.Where(x => x.Value > 15);

      foreach (var pair in list)
        stb.AppendFormat("[\"{0}\", \"{1}\"], ", pair.Key, pair.Value);
      return stb.ToString();
    }

    private void wordBag1_ExecuteButtonClicked(object sender, EventArgs e)
    {
      var vm = ViewModelGet<CooccurrenceViewModel>();
      vm.Analyse();
      if (wordBag1.SelectedLayer != lastLayer)
      {
        vm.LayerDisplayname = wordBag1.SelectedLayer;
        vm.Analyse();
        lastLayer = wordBag1.SelectedLayer;
      }

      /*
      webHtml5Visualisation1.MainpageUrl = Configuration.GetDependencyPath("d3Templates/simpleTagCloud.html");
      webHtml5Visualisation1.TemplateVars = new Dictionary<string, string>
                                            {
                                              {
                                                "<!--#WIDTH/HEIGHT-->",
                                                string.Format("width=\"{0}\" height=\"{1}\"",
                                                              webHtml5Visualisation1.Width - 35,
                                                              webHtml5Visualisation1.Height - 35)
                                              },
                                              {"//#THELIST", ToJsonArray(vm.Search(wordBag1.Queries))}
                                            };
      webHtml5Visualisation1.GoToMainpage();
      */
    }

    private void wordBag1_Load(object sender, EventArgs e) { }

    private void WordCloudVisualisation_ShowVisualisation(object sender, EventArgs e)
    {
      wordBag1.Selection = Project.CurrentSelection;
    }
  }
}