#region

using CorpusExplorer.Sdk.Addon.Example.Abstract;
using CorpusExplorer.Sdk.Model.Interface;

#endregion

namespace CorpusExplorer.Sdk.Addon.Example.CorpusMeasures
{
  public partial class DisplayValues : AbstractWinformControlBase
  {
    public DisplayValues()
    {
      InitializeComponent();
    }

    public void Refresh(IHydra iHydra)
    {
      lbl_count_corpora.Text = iHydra.CountCorpora.ToString();
      lbl_count_documents.Text = iHydra.CountDocuments.ToString();
    }
  }
}