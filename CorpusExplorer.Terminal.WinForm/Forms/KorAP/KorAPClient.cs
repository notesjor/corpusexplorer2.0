using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using DotNetKorAPClient;
using DotNetKorAPClient.Sampler;
using DotNetKorAPClient.Sampler.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.Forms.KorAP
{
  public partial class KorAPClient : AbstractForm
  {
    private string _token;

    private Dictionary<string, KwicSearch.QueryLanguage> _ql = new Dictionary<string, KwicSearch.QueryLanguage>
    {
      { "Poliqarp", KwicSearch.QueryLanguage.poliqarp },
      { "Cosmas 2", KwicSearch.QueryLanguage.cosmas2 },
      { "AnnisQL", KwicSearch.QueryLanguage.annisql },
      { "CQL", KwicSearch.QueryLanguage.cql },
      { "FCSQL", KwicSearch.QueryLanguage.fcsql }
    };

    public KorAPClient(string token)
    {
      InitializeComponent();
      Token = token;

      foreach (var ql in _ql)
        combo_query_language.Items.Add(new RadListDataItem(ql.Key) { Tag = ql.Value });

      combo_query_language.SelectedIndex = 0;
    }

    private void btn_abort_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Abort;
      Close();
    }

    private void btn_ok_Click(object sender, EventArgs e)
    {
      Hide();
      Processing.SplashShow("KorAP-Abfrage läuft...");

      DialogResult = DialogResult.OK;

      var auth = Auth.Create(Token);
      var ql = GetQueryLanguage();
      var cq = string.IsNullOrWhiteSpace(txt_query_corpus.Text) ? null : txt_query_corpus.Text;

      var take = int.Parse(txt_sample.Text);
      if (take < 0)
        take = 10;
      if (take > 10000)
        take = 10000;

      var results = new List<MatchInfo>();
      if (radio_sample_normal.IsChecked)
        foreach (var query in txt_queries.Lines)
          results.AddRange(new FristResultsSamplerStrategy(KwicSearch.Create(auth, query, ql, corpusQuery: cq)).GetMatchInfos(take));
      if(radio_sample_fisheryates.IsChecked)
        foreach (var query in txt_queries.Lines)
          results.AddRange(new FisherYatesSamplerStrategy(KwicSearch.Create(auth, query, ql, corpusQuery: cq)).GetMatchInfos(take));

      var importer = new KorapApiImporter();
      Result = importer.BypassData(results);

      Processing.SplashClose();

      Close();
    }

    private KwicSearch.QueryLanguage GetQueryLanguage()
    {
      return (KwicSearch.QueryLanguage)combo_query_language.SelectedItem.Tag;
    }

    public string Token
    {
      get => _token;
      set
      {
        _token = value;
        panel_2.Visible = panel_3.Visible = panel_4.Visible = btn_ok.Visible = !string.IsNullOrEmpty(_token);
      }
    }

    private void btn_signin_Click(object sender, EventArgs e)
    {
      Hide();
      Processing.SplashShow("KorAP-Authentifizierung läuft...");
      var form = new KorAPSignin();
      var res = form.ShowDialog();

      Show();
      if (res != DialogResult.OK)
        return;

      using (var wc = new WebClient())
        Token = wc.DownloadString("https://api.corpusexplorer.de/oauth2/fetch?" + form.State);
    }

    public AbstractCorpusAdapter Result { get; private set; }

    private void txt_queries_TextChanged(object sender, EventArgs e)
    {
      btn_ok.Enabled = !string.IsNullOrWhiteSpace(txt_queries.Text);
    }
  }
}
