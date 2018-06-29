using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.ViewModel.QuickInfoText;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Helper;
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
      Clipboard.SetText(_docs[Index].Text.ConvertToPlainText());
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
      wpfTagger1.Text = _docs[Index].Text;

      var palette = UniversalColor.Palette;
      var idx = 0;

      foreach (var s in _docs[Index].HighlightedSentences)
        wpfTagger1.SetItemColor(s, palette[idx++].ToWpfColor(), string.Empty);

      RefreshMetadata(_docs[Index].DocumentMetadata);
    }
  }
}