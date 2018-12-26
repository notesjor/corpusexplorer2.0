using System;
using System.Collections.Generic;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using CorpusExplorer.Terminal.WinForm.Helper;

namespace CorpusExplorer.Terminal.WinForm.Forms.Snapshot
{
  public partial class SetTheorySelectSnapshot : AbstractDialog
  {
    public SetTheorySelectSnapshot(
      string header,
      string description,
      Dictionary<Guid, string> selectionsAndDisplaynames)
    {
      InitializeComponent();
      header1.HeaderHead = header;
      header1.HeaderDescription = description;

      DictionaryBindingHelper.BindDictionary(selectionsAndDisplaynames, radDropDownList1);
    }

    public Guid Result { get; set; }

    private void SetTheorySelectSnapshot_ButtonOkClick(object sender, EventArgs e)
    {
      try
      {
        Result = (Guid) radDropDownList1.SelectedValue;
      }
      catch
      {
        Error = "Bitte wählen Sie einen Schnappschuss aus!";
      }
    }
  }
}