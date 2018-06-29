#region

using System;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using CorpusExplorer.Terminal.WinForm.Helper;
using Telerik.WinControls.UI.Data;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Forms.Tagger
{
  public partial class SelectTagger : AbstractDialog
  {
    private readonly int _index;
    private string[] _languages;

    public SelectTagger(AbstractTagger tagger)
    {
      Tagger = tagger;
      Tagger.CorpusBuilder = new CorpusBuilderWriteDirect();
      InitializeComponent();
      radCollapsiblePanel1.Collapse();

      var parsers = Configuration.AddonTaggers.ToDictionary(x => x, x => x.DisplayName);
      DictionaryBindingHelper.BindDictionary(parsers, combo_tagger);

      var backends = Configuration.AddonBackends.ToDictionary(x => x.Value, x => x.Key);
      DictionaryBindingHelper.BindDictionary(backends, combo_backends);

      // Notwendig für reset des Backends
      var array = backends.ToArray();
      _index = 0;
      for (var i = 0; i < array.Length; i++)
        if (array[i].Value == "CorpusExplorer v6")
        {
          _index = i;
          break;
        }

      combo_tagger.SelectedValue = parsers.FirstOrDefault(x => x.Key.DisplayName == Tagger.DisplayName).Key;
      ParserSettinngsToUi();
    }

    public AbstractTagger Tagger { get; private set; }

    private void btn_destination_Click(object sender, EventArgs e)
    {
      var fbd = new OpenFileDialog();
      if (fbd.ShowDialog() != DialogResult.OK)
        return;
      Tagger.InstallationPath = fbd.FileName;

      _languages = Tagger.LanguagesAvailabel.ToArray();
      DictionaryBindingHelper.BindDictionary(_languages, combo_language);
      combo_language.SelectedIndex = 0;
    }

    private void combo_backends_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
    {
      Tagger.CorpusBuilder = combo_backends.SelectedValue as AbstractCorpusBuilder;
    }

    private void combo_language_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
    {
      if (Tagger == null)
        return;

      var lang = combo_language.SelectedValue as string;
      if (string.IsNullOrEmpty(lang))
        return;
      Tagger.LanguageSelected = lang;
    }

    private void combo_tagger_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
    {
      if (Tagger == null)
        return;

      Tagger = Activator.CreateInstance(combo_tagger.SelectedValue.GetType()) as AbstractTagger;
      ParserSettinngsToUi();
    }

    private void ParserSettinngsToUi()
    {
      if (Tagger == null)
        return;

      _languages = Tagger.LanguagesAvailabel.ToArray();
      DictionaryBindingHelper.BindDictionary(_languages, combo_language);

      combo_language.SelectedValue = Tagger.LanguageSelected;

      lbl_destination.Text = Tagger.InstallationPath;
      btn_destination.Enabled = !Tagger.InstallationPath.StartsWith("(");

      combo_backends.SelectedIndex = _index;
    }
  }
}