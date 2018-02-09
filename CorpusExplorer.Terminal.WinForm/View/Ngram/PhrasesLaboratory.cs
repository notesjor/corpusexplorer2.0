using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media;
using CorpusExplorer.Sdk.Blocks.PhrasesLaboratory;
using CorpusExplorer.Sdk.Blocks.PhrasesLaboratory.GrammarRule;
using CorpusExplorer.Sdk.Blocks.PhrasesLaboratory.GrammarRule.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.SingleSentence;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.SingleSentence.Model;
using CorpusExplorer.Terminal.WinForm.Helper;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.View.Fulltext.PhrasenLaboratory.Model;
using Telerik.WinControls.UI;
using Color = System.Drawing.Color;
using PositionChangedEventArgs = Telerik.WinControls.UI.Data.PositionChangedEventArgs;

namespace CorpusExplorer.Terminal.WinForm.View.Ngram
{
  public partial class PhrasesLaboratory : AbstractView
  {
    private readonly string Filter = Resources.FileExtension_CEVG;
    private readonly SentenceView sentenceView1;
    private PhrasesLaboratoryViewModel _vm;

    public PhrasesLaboratory()
    {
      InitializeComponent();
      sentenceView1 = new SentenceView();
      elementHost1.Child = sentenceView1;
      ShowView += OnShowView;
    }

    public int SentenceIndex { get; set; }

    private void btn_calculate_Click(object sender, EventArgs e)
    {
      radGridView3.DataSource = _vm.GetPhrasesFrequencyTable();
    }

    private void btn_colors_Click(object sender, EventArgs e) { RefreshColors(); }

    private void btn_rules_load_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog
      {
        Filter = Filter,
        CheckFileExists = true
      };
      if (ofd.ShowDialog() != DialogResult.OK)
        return;
      var settings = Serializer.Deserialize<PhrasesLaboratorySettings>(ofd.FileName);

      radGridView1.Rows.Clear();
      foreach (var level in settings.Grammar.Rules)
        foreach (var rule in level.Value)
          radGridView1.Rows.Add(level.Key, rule.Label, rule is ExactGrammarRule ? ((ExactGrammarRule) rule).Body : "");

      radGridView2.Rows.Clear();
      foreach (var color in settings.Colorset)
        radGridView2.Rows.Add(color.Key, GetWinformColor(color.Value.Key), GetWinformColor(color.Value.Value));
    }

    private void btn_rules_new_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(
            Resources.PhrasesLaboratory_CreateNewRuleset,
            Resources.PhrasesLaboratory_CreateNewRulesetHead,
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      radGridView1.Rows.Clear();
      radGridView2.Rows.Clear();
    }

    private void btn_rules_save_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog
      {
        CheckPathExists = true,
        Filter = Filter
      };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;
      Serializer.Serialize(
        new PhrasesLaboratorySettings {Colorset = GetColorset(), Grammar = GetGrammar()},
        sfd.FileName,
        false);
    }

    private void btn_sentence_next_Click(object sender, EventArgs e)
    {
      SentenceIndex++;
      RefreshVisualisation();
    }

    private void btn_sentence_prev_Click(object sender, EventArgs e)
    {
      SentenceIndex--;
      RefreshVisualisation();
    }

    private void btn_update_Click(object sender, EventArgs e) { RefreshVisualisation(); }

    private void btn_update_phrases_Click(object sender, EventArgs e)
    {
      var rules = GetGrammar();
      //radgrid _vm.GetPhrasesFrequencyTable(rules);
    }

    private void BuildNodeRecursiv(
      SentenceViewItem parent,
      IEnumerable<Constituent> data,
      Dictionary<string, KeyValuePair<Brush, Brush>> colors)
    {
      if ((data == null) ||
          !data.Any())
        return;

      foreach (var d in data)
      {
        var node = new SentenceViewItem(d.Label);
        if (colors.ContainsKey(d.Label))
        {
          node.ForegroundColor = colors[d.Label].Key;
          node.BackgroundColor = colors[d.Label].Value;
        }

        parent.Items.Add(node);
        if (d.Childs.Any())
          BuildNodeRecursiv(node, d.Childs, colors);
      }
    }

    private void combo_document_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
    {
      if (combo_document.SelectedIndex == -1)
        return;
      SentenceIndex = 0;
      RefreshVisualisation();
    }

    private Brush GetBrush(object c)
    {
      var color = (Color) c;
      return new SolidColorBrush(System.Windows.Media.Color.FromRgb(color.R, color.G, color.B));
    }

    private Dictionary<string, KeyValuePair<Brush, Brush>> GetColorset()
    {
      return radGridView2.Rows.ToDictionary(
                           row => row.Cells["Terminal"].Value.ToString(),
                           row =>
                             new KeyValuePair<Brush, Brush>(
                               GetBrush(row.Cells["ForeColor"].Value),
                               GetBrush(row.Cells["BackColor"].Value)));
    }

    private PhraseGrammar GetGrammar()
    {
      var res = new PhraseGrammar();

      foreach (var row in radGridView1.Rows)
        try
        {
          // ReSharper disable once MergeConditionalExpression
          var level = row.Cells[Resources.Priority].Value == null
                        ? 0
                        : Convert.ToInt32(row.Cells[Resources.Priority].Value);

          if (!res.Rules.ContainsKey(level))
            res.Rules.Add(level, new List<AbstractGrammarRule>());

          res.Rules[level].Add(
               new ExactGrammarRule(
                 row.Cells["Terminal"].Value.ToString(),
                 row.Cells[Resources.Expression].Value.ToString()));
        }
        catch {}

      return res;
    }

    private Color GetWinformColor(Brush brush)
    {
      var color = ((SolidColorBrush) brush).Color;
      return Color.FromArgb(color.A, color.R, color.G, color.B);
    }

    private Color InvertColor(Color color)
    {
      var res = color.ToArgb() ^ 0xffffff;
      return Color.FromArgb(res);
    }

    private void OnShowView(object sender, EventArgs eventArgs)
    {
      _vm = ViewModelGet<PhrasesLaboratoryViewModel>();
      _vm.Analyse();
      DictionaryBindingHelper.BindDictionary(_vm.Documents, combo_document);
      combo_document.SelectedIndex = 0;
      SentenceIndex = 0;
      RefreshVisualisation();
    }

    private Color RandomColor()
    {
      return Color.FromArgb(
        Configuration.Random.Next(0, 255),
        Configuration.Random.Next(0, 255),
        Configuration.Random.Next(0, 255));
    }

    private void RefreshColors()
    {
      var terminals = _vm.GetPossiblesTermianls(GetGrammar());
      var delete = new List<GridViewRowInfo>();

      foreach (var row in radGridView2.Rows)
      {
        var key = row.Cells["Terminal"].Value.ToString();
        if (terminals.Contains(key))
          terminals.Remove(key);
        else
          delete.Add(row);
      }

      foreach (var row in delete)
        radGridView2.Rows.Remove(row);

      foreach (var terminal in terminals)
      {
        var color = RandomColor();
        radGridView2.Rows.Add(terminal, color, InvertColor(color));
      }
    }

    private void RefreshVisualisation()
    {
      if (SentenceIndex < 0)
        return;

      lbl_sentence.Text = $"{SentenceIndex + 1} / {_vm.GetSentenceMax((Guid) combo_document.SelectedValue)}";

      RefreshColors();

      var colors = GetColorset();
      _vm.Grammar = GetGrammar();
      var constituents = _vm.GetSpecificSentence((Guid) combo_document.SelectedValue, SentenceIndex);

      var nodes = new List<SentenceViewItem>();
      foreach (var constituent in constituents)
      {
        var node = new SentenceViewItem(constituent.Label);
        if (colors.ContainsKey(constituent.Label))
        {
          node.ForegroundColor = colors[constituent.Label].Key;
          node.BackgroundColor = colors[constituent.Label].Value;
        }

        BuildNodeRecursiv(node, constituent.Childs, colors);

        nodes.Add(node);
      }

      sentenceView1.SetItems(nodes);
    }
  }
}