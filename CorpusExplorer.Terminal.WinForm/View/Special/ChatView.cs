using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Terminal.WinForm.Forms.Simple;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.View.Special
{
  public partial class ChatView : AbstractView
  {
    private readonly Color[] _colors =
      UniversalColor.Palette.Select(color => Color.FromArgb(color.R, color.G, color.B)).ToArray();

    private readonly Dictionary<string, Color> _userColors = new Dictionary<string, Color>();
    private ListViewDataItem[] _items;

    public ChatView()
    {
      InitializeComponent();
      ShowView += ChatView_ShowView;
    }

    private void btn_go_Click(object sender, EventArgs e)
    {
      radListView1.Items.Clear();

      var speaker = combo_speaker.SelectedValue as string;
      var utterance = combo_utteranche.SelectedValue as string;

      if (string.IsNullOrEmpty(speaker) ||
          string.IsNullOrEmpty(utterance) ||
          speaker == utterance)
        return;

      var order = new Dictionary<int, KeyValuePair<Guid, string>>();
      foreach (var dsel in Project.CurrentSelection.DocumentGuids)
      {
        var meta = Project.CurrentSelection.GetDocumentMetadata(dsel);
        if (meta == null ||
            !meta.ContainsKey(utterance))
          continue;

        if (!int.TryParse(meta[utterance].ToString(), out var x) ||
            order.ContainsKey(x))
          continue;

        order.Add(
          x,
          new KeyValuePair<Guid, string>(dsel, meta.ContainsKey(speaker) ? meta[speaker].ToString() : string.Empty));
      }

      var array = order.OrderBy(x => x.Key);

      var tokens = new Dictionary<string, int>();
      var types = new Dictionary<string, HashSet<string>>();

      List<ListViewDataItem> list = new List<ListViewDataItem>();
      foreach (var pair in array)
      {
        var doc = Project.CurrentSelection.GetReadableDocument(pair.Value.Key, "Wort").Select(x => x.ToArray())
          .ToArray();
        if (!tokens.ContainsKey(pair.Value.Value))
        {
          tokens.Add(pair.Value.Value, 0);
          types.Add(pair.Value.Value, new HashSet<string>());
        }

        var token = 0;
        foreach (var s in doc)
        {
          token += s.Length;
          foreach (var w in s) types[pair.Value.Value].Add(w);
        }

        tokens[pair.Value.Value] += token;

        list.Add(
          new ListViewDataItem
          {
            BackColor = GetUserColor(pair.Value.Value),
            Text =
              $"<html>({types[pair.Value.Value].Count:D5} / {tokens[pair.Value.Value]:D5}) <u>{pair.Value.Value}</u>: {doc.ReduceDocumentToText()}</html>",
            Font = new Font(radListView1.Font.FontFamily, 12, FontStyle.Bold),
            Key = pair.Value.Key
          });
      }

      _items = list.ToArray();

      radListView1.Items.AddRange(_items);
    }

    private void ChatView_ShowView(object sender, EventArgs e)
    {
      combo_speaker.DataSource = Project.CurrentSelection.GetDocumentMetadataPrototypeOnlyProperties();
      combo_utteranche.DataSource = Project.CurrentSelection.GetDocumentMetadataPrototypeOnlyProperties();
    }

    private Color GetUserColor(string sprecher)
    {
      if (string.IsNullOrEmpty(sprecher))
        return Color.Transparent;
      if (_userColors.ContainsKey(sprecher))
        return _userColors[sprecher];

      var color = _colors[_userColors.Count % _colors.Length];
      _userColors.Add(sprecher, color);

      return color;
    }

    private void radButton1_Click(object sender, EventArgs e)
    {
      var guids =
        (from item in radListView1.Items where item.CheckState == ToggleState.On select (Guid) item.Key).ToArray();

      if (guids.Length == 0)
        return;

      var form = new SimpleTextInput(
        Resources.NeuerSchnappschuss,
        Resources.GebenSieDemNeuenSchnappschussEinenNamen,
        Resources.camera,
        Resources.NameHierEintragen);
      if (form.ShowDialog() != DialogResult.OK)
        return;

      Project.CreateSelection(guids, form.Result);
    }

    private void txt_filter_TextChanged(object sender, EventArgs e)
    {
      radListView1.Items.Clear();
      radListView1.Items.AddRange((from x in _items where x.Text.Contains(txt_filter.Text) select x).ToArray());
    }
  }
}