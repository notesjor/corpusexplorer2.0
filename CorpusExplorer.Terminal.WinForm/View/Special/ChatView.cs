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

      if (string.IsNullOrEmpty(speaker) || string.IsNullOrEmpty(utterance) || speaker == utterance)
        return;

      var bag = Project.CurrentSelection.DocumentGuids.Select(dsel =>
                                                                new KeyValuePair<Guid, object>(dsel,
                                                                 Project.CurrentSelection.GetDocumentMetadata(dsel, utterance, null))).ToArray();

      bag = bag.Where(x => x.Value != null).OrderBy(x => x.Value).ToArray();

      var list = new List<ListViewDataItem>();
      foreach (var pair in bag)
      {
        var doc = Project.CurrentSelection.GetReadableDocument(pair.Key, "Wort").ReduceDocumentToText();
        var usr = Project.CurrentSelection.GetDocumentMetadata(pair.Key, speaker, "");

        list.Add(new ListViewDataItem
        {
          BackColor = GetUserColor(usr),
          Text = $"<html>({pair.Value:D5}) <u>{usr}</u>: {doc}</html>",
          Font = new Font(radListView1.Font.FontFamily, 12, FontStyle.Bold),
          Key = pair.Key,
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
        (from item in radListView1.Items where item.CheckState == ToggleState.On select (Guid)item.Key).ToArray();

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