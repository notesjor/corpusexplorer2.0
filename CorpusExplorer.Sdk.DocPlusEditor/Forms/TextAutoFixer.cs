#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Abstract;
using CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Text;
using CorpusExplorer.Tool4.DocPlusEditor.Forms.Abstract;

#endregion

namespace CorpusExplorer.Tool4.DocPlusEditor.Forms
{
  public partial class TextAutoFixer : AbstractForm
  {
    public TextAutoFixer()
    {
      InitializeComponent();
      DialogResult = DialogResult.Abort;
    }

    public List<AbstractAutoFix> Result { get; private set; }

    private void btn_ok_Click(object sender, EventArgs e)
    {
      Result = new List<AbstractAutoFix>();
      if (chk_remove_htmlecoding.Checked)
        Result.Add(new TextAutoFixHtmlEncodingFragments { ApplyOnCompleteCorpus = true });
      if (chk_remove_xmlstuff.Checked)
        Result.Add(new TextAutoFixXmlFragments());
      if (chk_remove_linebreak.Checked)
        Result.Add(new TextAutoFixLineBreaks());
      if (chk_remove_linebreakPdf.Checked)
        Result.Add(new TextAutoFixPdfLineBreaks());
      if (chk_remove_space.Checked)
        Result.Add(new TextAutoFixSpace());

      foreach (var r in Result.OfType<AbstractTextAutoFix>())
      {
        r.ApplyOnCompleteCorpus = chk_in_corpus.Checked;
        r.ApplyOnMeta = chk_in_meta.Checked;
        r.ApplyOnText = chk_in_text.Checked;
      }

      DialogResult = DialogResult.OK;
    }
  }
}