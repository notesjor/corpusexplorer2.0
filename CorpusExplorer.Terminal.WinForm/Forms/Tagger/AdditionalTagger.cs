using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;
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
      DictionaryBindingHelper.BindDictionary(tagger, combo_tagger);
    }

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

    public AbstractAdditionalTagger Result
    {
      get
      {
        var res = ((AbstractAdditionalTagger) combo_tagger.SelectedValue);
        res.ModelPath = _path;
        return res;
      }
    }
  }
}
