#region

using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Helper;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using Telerik.WinControls.UI.Data;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.EditionTools
{
  /// <summary>
  ///   The text compare page.
  /// </summary>
  public partial class TextCompare : AbstractView
  {
    private Guid _guidA = Guid.Empty;
    private Guid _guidB = Guid.Empty;
    private DiffViewModel _vm;

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractView" /> class.
    /// </summary>
    public TextCompare()
    {
      InitializeComponent();
    }

    private void CompareTexts()
    {
      if (_guidA == Guid.Empty ||
          _guidB == Guid.Empty)
        return;

      _vm.DocumentAGuid = _guidA;
      _vm.DocumentBGuid = _guidB;

      _vm.Analyse();

      radLabel1.Text =
        $"<html>Notwendige Transformationen (A -&gt; B) - Hinzufügen: &nbsp;<strong>{_vm.ChangesInsert}</strong> - Entfernen: &nbsp;<strong>{_vm.ChangesRemove}</strong> - Distanz: &nbsp;<strong>{_vm.EditDistance}</strong></html>";

      webHtml5Visualisation1.MainpageUrl = Configuration.GetDependencyPath("d3Templates/diff.html");
      webHtml5Visualisation1.TemplateVars = new Dictionary<string, string>
      {
        {"#DIFFS", _vm.HtmlOutput}
      };
      webHtml5Visualisation1.GoToMainpage();
    }

    private void drop_textA_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
    {
      if (drop_textA.SelectedItem == null)
        return;
      _guidA = (Guid) drop_textA.SelectedValue;
      CompareTexts();
    }

    private void drop_textB_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
    {
      if (drop_textB.SelectedItem == null)
        return;
      _guidB = (Guid) drop_textB.SelectedValue;
      CompareTexts();
    }

    private void TextComparePage_ShowVisualisation_1(object sender, EventArgs e)
    {
      _vm = GetViewModel<DiffViewModel>();
      DictionaryBindingHelper.BindDictionary(_vm.DocumentGuidsAndDisplaynames, drop_textA);
      DictionaryBindingHelper.BindDictionary(_vm.DocumentGuidsAndDisplaynames, drop_textB);
    }
  }
}