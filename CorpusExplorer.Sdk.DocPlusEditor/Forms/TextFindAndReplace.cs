#region

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Abstract;
using CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Text;
using CorpusExplorer.Tool4.DocPlusEditor.Forms.Abstract;

#endregion

namespace CorpusExplorer.Tool4.DocPlusEditor.Forms
{
  public partial class TextFindAndReplace : AbstractForm
  {
    public TextFindAndReplace(string query)
    {
      InitializeComponent();
      txt_query.Text = query;
    }

    public List<AbstractAutoFix> Result { get; private set; }

    private void btn_ok_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
      Result = new List<AbstractAutoFix>();
      if (chk_regex.Checked)
        Result.Add(new TextAutoFixReplaceRegex
        {
          ApplyOnText = chk_in_text.Checked,
          ApplyOnMeta = chk_in_meta.Checked,
          ApplyOnCompleteCorpus = chk_in_corpus.Checked,
          Find = new Regex(txt_query.Text),
          Replace = txt_replace.Text
        });
      else
        Result.Add(new TextAutoFixReplace
        {
          ApplyOnText = chk_in_text.Checked,
          ApplyOnMeta = chk_in_meta.Checked,
          ApplyOnCompleteCorpus = chk_in_corpus.Checked,
          Find = txt_query.Text,
          Replace = txt_replace.Text
        });
    }
  }
}