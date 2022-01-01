using System;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.AdditionalTaggerWrapper;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using CorpusExplorer.Terminal.WinForm.Helper;

namespace CorpusExplorer.Terminal.WinForm.Forms.Tagger
{
  public partial class AdditionalTagger : AbstractDialog
  {
    private string _path;

    public AdditionalTagger()
    {
      InitializeComponent();

      var tagger = Configuration.AddonAdditionalTaggers.ToDictionary(x => x, x => x.DisplayName);
      foreach (var abstractTagger in Configuration.AddonTaggers)
        foreach (var language in abstractTagger.LanguagesAvailabel)
        {
          var clone = Activator.CreateInstance(abstractTagger.GetType()) as AbstractTagger;
          if (clone == null)
            continue;

          clone.LanguageSelected = language;

          tagger.Add(new AdditionalTaggerWrapper(clone), $"{clone.DisplayName} - {language}");
        }

      DictionaryBindingHelper.BindDictionary(tagger, combo_tagger);
    }

    public AbstractAdditionalTagger Result => (AbstractAdditionalTagger)combo_tagger.SelectedValue;

    private void btn_destination_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog
      {
        CheckFileExists = true,
        CheckPathExists = true,
        Multiselect = false
      };
      if (ofd.ShowDialog() == DialogResult.OK)
        _path = ofd.FileName;
    }
  }
}