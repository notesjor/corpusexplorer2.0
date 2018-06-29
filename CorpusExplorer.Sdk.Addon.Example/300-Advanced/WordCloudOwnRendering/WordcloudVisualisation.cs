#region

using System;
using CorpusExplorer.Sdk.Addon.Example.Abstract;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.ViewModel;

#endregion

namespace CorpusExplorer.Sdk.Addon.Example.WordCloudOwnRendering
{
  public partial class WordcloudVisualisation : AbstractWinformControlBase
  {
    private Selection _selection;

    public WordcloudVisualisation()
    {
      InitializeComponent();
    }

    public void Refresh(Selection selection)
    {
      _selection = selection;
    }

    private void btn_go_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(txt_query.Text))
        return;

      var vm = new CooccurrenceViewModel {Selection = _selection};
      vm.Analyse();

      /*
      var dic = vm.Search(txt_query.Text.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries));
      if (dic == null || !dic.Any())
        return;

      cloudControl1.Items = dic.Select(x => new WordCloudItem {Label = x.Key, Occurrences = (int) (x.Value*100)});
      */
    }
  }
}