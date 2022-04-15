using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bcs.IO;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Scripter;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.View.Special.Html5DevLabForms;
using Telerik.WinControls.UI;
using Telerik.WinForms.Controls.SyntaxEditor.Taggers;
using Telerik.WinForms.SyntaxEditor.Core.Text;

namespace CorpusExplorer.Terminal.WinForm.View.Special
{
  public partial class Html5DevLab : AbstractView
  {
    private readonly TemporaryFile _file;

    private bool _firstRun = true;
    private string _path;

    public Html5DevLab()
    {
      InitializeComponent();
      _file = new TemporaryFile(Configuration.TempPath, ".html");
      Disposed += (s, e) => _file.Dispose();

      ConfigureEditor(editor_input);
      ConfigureEditor(editor_output);

      SetText(editor_input, "<!doctype html>\r\n<html>\r\n\t<head>\r\n\t\t<meta charset=\"utf-8\">\r\n\t\t<style>\r\n\t\t\tp {color: black;}\r\n\t\t\t.red {color: red;}\r\n\t\t</style>\r\n\t</head>\r\n\t<body>\r\n\t\t<h1>CorpusExplorer</h1>\r\n\t\t<p>HTML5-Labor</p><p class=\"red\">Beispiel</p>\r\n\t\tDer aktuelle Schnappschuss umfasst: \r\n\t\t/*CEC FNT:HTML basic-information */;\r\n\t</body>\r\n</html>");
    }

    private void SetText(RadSyntaxEditor editor, string text)
    {
      using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(text)))
      using (var reader = new StreamReader(ms))
        editor.Document = new TextDocument(reader);
    }

    private string GetText(RadSyntaxEditor editor)
    {
      editor.SelectAll();
      return editor.SyntaxEditorElement.Selection.GetSelectedText();
    }

    private void ConfigureEditor(RadSyntaxEditor editor)
    {
      var tagger = new XmlTagger(editor.SyntaxEditorElement);
      editor.TaggersRegistry.RegisterTagger(tagger);
      //editor.TaggersRegistry.RegisterTagger(new XmlFoldingTagger(editor_input.SyntaxEditorElement));
      editor.TextFormatDefinitions.AddLast(XmlSyntaxHighlightingHelper.XmlAttribute, XmlSyntaxHighlightingHelper.XmlAttributeFormatDefinition);
      editor.TextFormatDefinitions.AddLast(XmlSyntaxHighlightingHelper.XmlElement, XmlSyntaxHighlightingHelper.XmlElementFormatDefinition);
      editor.TextFormatDefinitions.AddLast(XmlSyntaxHighlightingHelper.XmlComment, XmlSyntaxHighlightingHelper.XmlCommentFormatDefinition);
      editor.TextFormatDefinitions.AddLast(XmlSyntaxHighlightingHelper.XmlContent, XmlSyntaxHighlightingHelper.XmlContentFormatDefinition);
      editor.TextFormatDefinitions.AddLast(XmlSyntaxHighlightingHelper.XmlString, XmlSyntaxHighlightingHelper.XmlStringFormatDefinition);
      editor.TextFormatDefinitions.AddLast(XmlSyntaxHighlightingHelper.XmlTag, XmlSyntaxHighlightingHelper.XmlTagFormatDefinition);
      editor.TaggersRegistry.RegisterTagger(new TextSearchHighlightTagger(editor.SyntaxEditorElement, TextSearchHighlightTagger.SearchFormatDefinition));

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
      var ofd = new OpenFileDialog { Filter = Resources.FileExtension_HTML, CheckFileExists = true };
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      _path = ofd.FileName;
      SetText(editor_input, FileIO.ReadText(_path));

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
      FileIO.Write(_path, GetText(editor_input));
    }

    private void BuildHtml5Output(Dictionary<string, string> vars)
    {
      try
      {
        var html = Html5Scripter.Parse(Project.CurrentSelection, TemplateTextGenerator.Generate(GetText(editor_input), vars));
        FileIO.Write(_file.Path, html);
        SetText(editor_output, html);
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
      }

      try
      {
        webHtml5LaboratoryVisualisation1.ShowFile(_file.Path);
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

      var text = GetText(editor_input);

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