#region

using System;
using CorpusExplorer.Sdk.Aspect;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Forms.Snapshot
{
  public partial class AddRandomSnapshot : AbstractDialog
  {
    private readonly Selection _selection;

    public AddRandomSnapshot(Project project, Selection selection) : base(project)
    {
      InitializeComponent();
      _selection = selection;
      count_docs.Maximum = selection.CountDocuments;
    }

    public Selection Selection { get; set; }

    private void AddRandomSnapshot_ButtonOkClick(object sender, EventArgs e)
    {
      var block = _selection.CreateBlock<RandomSelectionBlock>();
      block.DocumentCount = (int) count_docs.Value;
      block.Calculate();
      Selection = block.RandomSelection;
    }

    [NamedSynchronizedLock("CountLock")]
    private void count_docs_ValueChanged(object sender, EventArgs e)
    {
      count_percent.Value = count_docs.Value/count_docs.Maximum*(decimal) 100.0;
    }

    [NamedSynchronizedLock("CountLock")]
    private void count_percent_ValueChanged(object sender, EventArgs e)
    {
      count_docs.Value = (decimal) ((double) count_docs.Maximum/100.0d)*count_percent.Value;
    }
  }
}