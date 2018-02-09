using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Sdk.Extern.Plaintext.WET.Forms
{
  public partial class LanguageSelectionForm : AbstractForm
  {
    private List<string> _list;

    public LanguageSelectionForm()
    {
      InitializeComponent();
    }

    private void LanguageSelectionForm_Load(object sender, EventArgs e)
    {
      _list = FileIO.ReadLines(Configuration.GetDependencyPath("NTextCat/ntextcat.list"), stringSplitOptions: StringSplitOptions.RemoveEmptyEntries).ToList();
      _list.Add("Alle Sprachen / Kein Filter");
      combo_languages.DataSource = _list;
    }

    private void btn_abort_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Abort;
      Close();
    }

    private void btn_ok_Click(object sender, EventArgs e)
    {
      if (combo_languages.SelectedIndex == -1)
      {
        MessageBox.Show("Bitte wählen Sie zuerst eine Sprache aus!", "CorpusExplorer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
      }
      if (radAutoCompleteBox1.Text.Length > 0 && !radAutoCompleteBox1.Text.Contains(";"))
      {
        MessageBox.Show("Bitte trennen Sie Domains mittels Semikolon (;). Nur grün hinterlegte Domains werden gefiltert");
        return;
      }
      if (radAutoCompleteBox1.Text.Length > 0 && !radAutoCompleteBox1.Text.Contains("."))
      {
        MessageBox.Show("Bitte verwenden Sie keine Punkte (.) im TLD-Domainnamen.");
        return;
      }
      
      DialogResult = DialogResult.OK;
      Close();
    }

    public string SelectedLanguage => _list[combo_languages.SelectedIndex];

    public bool UseLanguageFilter => combo_languages.SelectedIndex != _list.Count - 1;

    public bool UseDomainFilter => radAutoCompleteBox1.Text.Length != 0;

    public HashSet<string> SelectedDomains =>
      new HashSet<string>(radAutoCompleteBox1.Text.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries));
  }
}
