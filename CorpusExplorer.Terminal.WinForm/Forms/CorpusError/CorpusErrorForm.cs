using System;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;

namespace CorpusExplorer.Terminal.WinForm.Forms.CorpusError
{
  public partial class CorpusErrorForm : AbstractDialog
  {
    private readonly ValidateSelectionIntegrityViewModel _vm;

    public CorpusErrorForm(ValidateSelectionIntegrityViewModel vm)
    {
      InitializeComponent();

      _vm = vm;
      double all = vm.All;
      InMemoryErrorConsole.Log(new
                                 Exception($"CorpusError: {all} documents / {vm.ValidDocumentGuids.Count} valid / {vm.EmptyDocumentGuids.Count} empty / {vm.SentenceErrorDocumentGuids.Count} sentenceError / {vm.NoLayerMatchingDocumentGuids.Count} layerError"));

      if (vm.SentenceErrorDocumentGuids.Count == 0)
      {
        radPageView1.Pages.Remove(page_sentenceError);
        chk_senteceError.Checked = false;
      }
      else
      {
        grp_senteceError.Text =
          $"{vm.SentenceErrorDocumentGuids.Count} von {all} Dokumente ({Math.Round(vm.SentenceErrorDocumentGuids.Count / all * 100, 2)}%) betroffen";
        list_senteceError.DataSource = vm.SentenceErrorDocuments;
      }

      if (vm.EmptyDocumentGuids.Count == 0)
      {
        radPageView1.Pages.Remove(page_emptyDocument);
        chk_emptyDocuments.Checked = false;
      }
      else
      {
        grp_emptyDocuments.Text =
          $"{vm.EmptyDocumentGuids.Count} von {all} Dokumente ({Math.Round(vm.EmptyDocumentGuids.Count / all * 100, 2)}%) betroffen";
        list_emptyDocuments.DataSource = vm.EmptyDocuments;
      }

      if (vm.NoLayerMatchingDocumentGuids.Count == 0)
      {
        radPageView1.Pages.Remove(page_diffLayer);
        chk_DiffLayer.Checked = false;
      }
      else
      {
        grp_DiffLayer.Text =
          $"{vm.NoLayerMatchingDocumentGuids.Count} von {all} Dokumente ({Math.Round(vm.NoLayerMatchingDocumentGuids.Count / all * 100, 2)}%) betroffen";
        list_DiffLayer.DataSource = vm.NoLayerMatchingDocuments;
      }
    }

    public Selection ResultSelection { get; set; }

    private void CorpusErrorForm_ButtonOkClick(object sender, EventArgs e)
    {
      if (chk_emptyDocuments.Checked || chk_DiffLayer.Checked || chk_senteceError.Checked)
      {
        Hide();
        Processing.SplashShow("Korpus wird überarbeitet...");
        ResultSelection = _vm.CleanSelection;
      }
      else
      {
        ResultSelection = null; // Gebe unmodifizierte Auswahl zurück
      }
    }

    private void CorpusErrorForm_ButtonAbortClick(object sender, EventArgs e)
    {
      ResultSelection = null; // Gebe unmodifizierte Auswahl zurück
    }
  }
}