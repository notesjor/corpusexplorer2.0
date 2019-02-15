using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using Bcs.IO;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Scripter;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.CodeEditor;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.View.Special.Html5DevLabForms;
using HorizontalAlignment = System.Windows.HorizontalAlignment;

namespace CorpusExplorer.Terminal.WinForm.View.Special
{
  public partial class Html5DevLab : AbstractView
  {
    private readonly TemporaryFile _file;

    private readonly CodeEditor editor_input = new CodeEditor
    {
      HorizontalAlignment = HorizontalAlignment.Stretch,
      VerticalAlignment = VerticalAlignment.Stretch
    };

    private readonly CodeEditor editor_output = new CodeEditor
    {
      HorizontalAlignment = HorizontalAlignment.Stretch,
      VerticalAlignment = VerticalAlignment.Stretch
    };

    private bool _firstRun = true;
    private string _path;

    public Html5DevLab()
    {
      InitializeComponent();
      _file = new TemporaryFile(Configuration.TempPath, ".html");
      Disposed += (s, e) => _file.Dispose();

      elementHost1.Child = editor_input;
      elementHost2.Child = editor_output;
    }

    // private void btn_export_html_Click(object sender, EventArgs e) { webHtml5LaboratoryVisualisation1.ExportHtml(); }

    private void btn_export_image_Click(object sender, EventArgs e)
    {
      webHtml5LaboratoryVisualisation1.ExportImage();
    }

    private void btn_export_pdf_Click(object sender, EventArgs e)
    {
      webHtml5LaboratoryVisualisation1.ExportPdf();
    }

    private void btn_help_Click(object sender, EventArgs e)
    {
      var form = new Html5DevLabHelp();
      form.ShowDialog();
    }

    private void btn_load_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog {Filter = Resources.FileExtension_HTML, CheckFileExists = true};
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      _path = ofd.FileName;
      editor_input.Text = FileIO.ReadText(_path);

      RefreshHtml5();
    }

    private void btn_print_Click(object sender, EventArgs e)
    {
      webHtml5LaboratoryVisualisation1.Print();
    }

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

    private void btn_save_Click(object sender, EventArgs e)
    {
      FileIO.Write(_path, editor_input.Text);
    }

    private void BuildHtml5Output(Dictionary<string, string> vars)
    {
      try
      {
        var html = Html5Scripter.Parse(Project.CurrentSelection,
                                       TemplateTextGenerator.Generate(editor_input.Text, vars));
        FileIO.Write(_file.Path, html);
        webHtml5LaboratoryVisualisation1.MainpageUrl = _file.Path;
        webHtml5LaboratoryVisualisation1.GoToMainpage();
        editor_output.Text = html;
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
      }
    }

    private Dictionary<string, string> GenerateRequests()
    {
      var items = new Dictionary<string, Func<string>>
      {
        {
          "#FREQU", () =>
          {
            var vm = GetViewModel<FrequencyViewModel>();
            vm.Execute();
            return vm.GetDataTable().ToJson();
          }
        },
        {
          "#CFREQ", () =>
          {
            var vm = GetViewModel<FrequencyCrossViewModel>();
            vm.Execute();
            return vm.GetDataTable().ToJson();
          }
        },
        {
          "#COOCC",
          () =>
          {
            var vm = GetViewModel<CooccurrenceViewModel>();
            vm.Execute();
            return vm.GetDataTable().ToJson();
          }
        },
        {
          "#METAD",
          () =>
          {
            var vm = GetViewModel<CorpusWeightUnlimmitedViewModel>();
            vm.Execute();
            return vm.GetDataTable().ToJson();
          }
        }
      };

      var text = editor_input.Text;

      return items.Where(item => text.Contains(item.Key)).ToDictionary(item => item.Key, item => item.Value());
    }

    private void RefreshHtml5()
    {
      BuildHtml5Output(GenerateRequests());
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      timer1.Stop();
      RefreshHtml5();
      Processing.SplashClose();
    }
  }
}