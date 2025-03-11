using CorpusExplorer.Sdk.Utils.CorpusManipulation.CorpusRandomizerStrategy;
using CorpusExplorer.Sdk.Utils.CorpusManipulation.CorpusRandomizerStrategy.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CorpusExplorer.Terminal.WinForm.Forms.Publishing
{
  public partial class CorpusRandomizer : AbstractForm
  {
    public CorpusRandomizer()
    {
      InitializeComponent();
    }

    public bool RandomizeSentences
    {
      get { return chk_sentences.IsChecked; }
    }

    public bool RandomizeSentencesAndTokens
    {
      get { return chk_sentences_and_words.IsChecked; }
    }

    public AbstractCorpusRandomizerStrategy RandomizeStrategy
    {
      get
      {
        if (chk_sentences.IsChecked == false)
          return new CorpusRandomizerStrategySentences();
        if (chk_words.IsChecked == false)
          return new CorpusRandomizerStrategyTokens();
        return new CorpusRandomizerStrategySentencesAndTokens();
      }
    }

    private void btn_abort_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Abort;
      Close();
    }

    private void btn_ok_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
      Close();
    }
  }
}
