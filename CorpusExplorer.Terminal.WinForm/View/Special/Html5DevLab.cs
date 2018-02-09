using Bcs.IO;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.View.Html.Html5;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.View.Special.Html5DevLabForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.CodeEditor;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;

namespace CorpusExplorer.Terminal.WinForm.View.Special
{
  public partial class Html5DevLab : AbstractView
  {
    private CodeEditor editor_input = new CodeEditor
                                      {
                                        HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch,
                                        VerticalAlignment = System.Windows.VerticalAlignment.Stretch
                                      };
    private CodeEditor editor_output = new CodeEditor
                                       {
                                         HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch,
                                         VerticalAlignment = System.Windows.VerticalAlignment.Stretch
                                       };
    private readonly Html5Builder _html;
    private TemporaryFile _file;
    private string _path;
    private bool _firstRun = true;

    public Html5DevLab()
    {
      InitializeComponent();
      _html = new Html5Builder();
      _file = new TemporaryFile(Configuration.TempPath, ".html");
      Disposed += (s, e) => _file.Dispose();

      elementHost1.Child = editor_input;
      elementHost2.Child = editor_output;
    }

    // private void btn_export_html_Click(object sender, EventArgs e) { webHtml5LaboratoryVisualisation1.ExportHtml(); }

    private void btn_export_image_Click(object sender, EventArgs e) { webHtml5LaboratoryVisualisation1.ExportImage(); }

    private void btn_export_pdf_Click(object sender, EventArgs e) { webHtml5LaboratoryVisualisation1.ExportPdf(); }

    private void btn_help_Click(object sender, EventArgs e)
    {
      var form = new Html5DevLabHelp();
      form.ShowDialog();
    }

    private void btn_load_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog { Filter = Resources.FileExtension_HTML, CheckFileExists = true };
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      _path = ofd.FileName;
      editor_input.Text = FileIO.ReadText(_path);

      RefreshHtml5();
    }

    private void btn_print_Click(object sender, EventArgs e) { webHtml5LaboratoryVisualisation1.Print(); }

    private void btn_refresh_Click(object sender, EventArgs e)
    {
      Processing.SplashShow("Generiere HTML5-Ausgabe...");
      RefreshHtml5();
      if (!_firstRun)
      {
        Processing.SplashClose();
        return;
      }
      _firstRun = false;
      timer1.Start();
    }

    private void btn_save_Click(object sender, EventArgs e) { FileIO.Write(_path, editor_input.Text); }

    private void BuildHtml5Output(Dictionary<string, string> vars)
    {
      var html = TemplateTextGenerator.Generate(editor_input.Text, vars);
      FileIO.Write(_file.Path, html);
      webHtml5LaboratoryVisualisation1.MainpageUrl = _file.Path;
      webHtml5LaboratoryVisualisation1.GoToMainpage();      
      editor_output.Text = html;
    }

    private Dictionary<string, string> GenerateRequests()
    {
      var items = new Dictionary<string, Func<string>>
      {
        {
          "#FREQU", () =>
          {
            var vm = ViewModelGet<FrequencyViewModel>();
            vm.Analyse();
            return vm.GetDataTable().ToJson();
          }
        },
        {
          "#CFREQ", () =>
          {
            var vm = ViewModelGet<FrequencyCrossViewModel>();
            vm.Analyse();
            return vm.GetDataTable().ToJson();
          }
        },
        {
          "#COOCC",
          () =>
          {
            var vm = ViewModelGet<CooccurrenceViewModel>();
            vm.Analyse();
            return vm.GetDataTable().ToJson();
          }
        },
        {
          "#METAD",
          () =>
          {
            var vm = ViewModelGet<CorpusWeightUnlimmitedViewModel>();
            vm.Analyse();
            return vm.GetDataTable().ToJson();
          }
        }
      };

      var text = editor_input.Text;

      return items.Where(item => text.Contains(item.Key)).ToDictionary(item => item.Key, item => item.Value());
    }

    private void RefreshHtml5() { BuildHtml5Output(GenerateRequests()); }

    private void timer1_Tick(object sender, EventArgs e)
    {
      timer1.Stop();
      RefreshHtml5();   
      Processing.SplashClose();
    }
  }
}