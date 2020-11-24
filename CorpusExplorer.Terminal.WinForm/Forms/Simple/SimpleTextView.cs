using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.ViewModel.QuickInfoText;
using CorpusExplorer.Terminal.WinForm.Forms.Simple.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Properties;

namespace CorpusExplorer.Terminal.WinForm.Forms.Simple
{
  public partial class SimpleTextView : AbstractMetadata
  {
    private readonly QuickInfoTextResult[] _docs;
    private int _index;
    private int _lastIndex = -1;

    public SimpleTextView(IEnumerable<QuickInfoTextResult> docs, Project project) : base(project)
    {
      InitializeComponent();
      RegisterMetadataEditor(metadataEditor1);
      _docs = docs.ToArray();
      Index = 0;
      RefreshMetadata(_docs[Index].DocumentMetadata);
    }

    public IEnumerable<QuickInfoTextResult> Documents => _docs;

    public int Index
    {
      get => _index;
      set
      {
        _index = value;
        if (_index >= _docs.Length)
          _index = _docs.Length - 1;
        if (_index < 0)
          _index = 0;
        RefreshData();
        _lastIndex = _index;
      }
    }

    private void btn_clipboard_Click(object sender, EventArgs e)
    {
      Clipboard.SetText(_docs[Index].Text.ReduceDocumentToText());
    }

    private void btn_export_Click(object sender, EventArgs e)
    {
      var sub = Project.CurrentSelection.CreateTemporary(_docs.Select(x => x.DocumentGuid));
      var dic = Configuration.AddonExporters.ToArray();
      var sfd = new SaveFileDialog
      {
        CheckPathExists = true,
        Filter = string.Join("|", dic.Select(x => x.Key))
      };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      var exporter = dic[sfd.FilterIndex - 1].Value;

      Processing.Invoke(Resources.GutDingWillWeileHaben, () => exporter.Export(sub, sfd.FileName));
    }

    private void btn_next_Click(object sender, EventArgs e)
    {
      Index++;
    }

    private void btn_prev_Click(object sender, EventArgs e)
    {
      Index--;
    }

    private void RefreshData()
    {
      if (_lastIndex > -1)
        _docs[_lastIndex].DocumentMetadata = DocumentMetadata;

      lbl_index.Text = $"{Index + 1} / {_docs.Length}";

      var stb = new StringBuilder();
      stb.AppendLine("<!DOCTYPE html><html lang=\"de\"><head><meta charset=\"utf-8\" /><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" /><script>window.onload = function () {document.getElementById(\"firstKwic\").scrollIntoView();};</script></head><body style=\"font-family: Arial, Helvetica, sans-serif;\"><p>");

      var entry = _docs[Index];
      var sents = entry.Text.ToArray();
      var first = true;

      for (var i = 0; i < sents.Length; i++)
      {
        if (entry.HighlightedSentences.Contains(i))
        {
          string val;
          if (first)
          {
            val = $"<strong id=\"firstKwic\" style=\"border-bottom: 2px solid red; margin-bottom: 2px;\">{string.Join(" ", sents[i])}</strong>";
            first = false;
          }
          else
          {
            val = $"<strong style=\"border-bottom: 2px solid red; margin-bottom: 2px;\">{string.Join(" ", sents[i])}</strong>";
          }

          stb.AppendLine(val);
        }
        else
          stb.AppendLine(string.Join(" ", sents[i]));
      }

      stb.AppendLine("</p></body></html>");
      webHtml5Visualisation1.LoadHtml(stb.ToString());

      RefreshMetadata(_docs[Index].DocumentMetadata);
    }
  }
}