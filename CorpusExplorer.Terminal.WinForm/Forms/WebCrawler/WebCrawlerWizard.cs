using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Crawler;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Webbrowser;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using CorpusExplorer.Terminal.WinForm.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using PositionChangedEventArgs = Telerik.WinControls.UI.Data.PositionChangedEventArgs;

namespace CorpusExplorer.Terminal.WinForm.Forms.WebCrawler
{
  public partial class WebCrawlerWizard : AbstractForm
  {
    private readonly List<string> _linkResults = new List<string>();
    private readonly List<string> _linkResultsCompleted = new List<string>();
    private readonly WebXpathVisualizer page_3_browser;
    private readonly WebXpathVisualizer page_4_browser;

    private bool _page3Alert = true;

    private bool _page4Alert = true;

    public WebCrawlerWizard()
    {
      InitializeComponent();

      radWizard1.BackButton.Text = "< Zurück";
      radWizard1.CancelButton.Text = "Abbrechen";
      radWizard1.Cancel += (s, e) => Close();
      radWizard1.FinishButton.Text = "Fertigstellen";
      radWizard1.HelpButton.Visibility = ElementVisibility.Collapsed;
      radWizard1.NextButton.Text = "Weiter >";

      page_3_browser = new WebXpathVisualizer
      {
        Size = page_3_cnt_browser.Size,
        Location = new Point(0, 0),
        Dock = DockStyle.Fill
      };
      page_3_browser.XPathChanged += Page_3_browser_XPathChanged;
      page_3_webbrowser.Controls.Add(page_3_browser);
      page_4_browser = new WebXpathVisualizer
      {
        Size = page_4_cnt_browser.Size,
        Location = new Point(0, 0),
        Dock = DockStyle.Fill
      };
      page_4_browser.XPathChanged += Page_4_browser_XPathChanged;
      page_4_webbrowser.Controls.Add(page_4_browser);

      page_0_check_sampledata.CheckStateChanged += (s, e) =>
      {
        if (page_0_check_sampledata.Checked)
          page_0_txt_name.Text = "Beispieldaten";
      };
    }

    private void btn_showBrowser_Click(object sender, EventArgs e)
    {
      var browser = new XpathBrowser();
      browser.Show();
    }

    private Dictionary<string, string> GetMappings()
    {
      var res = new Dictionary<string, string>();

      foreach (var row in grid_mappings.Rows)
      {
        var key = row.Cells["col_key"].Value.ToString();
        if (string.IsNullOrEmpty(key))
          continue;
        res.Add(row.Cells["col_xpath"].Value.ToString(), key);
      }

      return res;
    }

    private void Page_3_browser_XPathChanged(object sender, EventArgs e)
    {
      if (radWizard1.SelectedPage != radWizard1.Pages[2])
        return;

      page_3_txt_xpathresult.Invoke((MethodInvoker) delegate { page_3_txt_xpathresult.Text = page_3_browser.XPath; });
      var selectionContainsNoLinks = false;
      _linkResults.Clear();

      foreach (var n in page_3_browser.SelectedNodesByXPath)
      {
        if (n.Name != "a")
        {
          selectionContainsNoLinks = true;
          continue;
        }

        _linkResults.Add(n.GetAttributeValue("link", ""));
      }

      if (selectionContainsNoLinks)
        MessageBox.Show(
                        "Scheinbar selektiert der von Ihnen angebene XPath-Ausdruck mehr als nur Ergebnislinks. Bitte passen Sie den XPath-Ausdruck an.");

      RefreshLinkResults();
    }

    private void page_3_btn_testquery_Click(object sender, EventArgs e)
    {
      page_3_browser.Url = txt_search_url.Text
                                         .Replace("[QUERY]", page_3_txt_testquery.Text)
                                         .Replace("[PAGE]", ((int) num_search_min.Value).ToString());
    }

    private void page_3_btn_xpathrefresh_Click(object sender, EventArgs e)
    {
      page_3_browser.XPath = page_3_txt_xpathresult.Text;
      RefreshLinkResults();
    }

    private void page_3_txt_prefix_TextChanged(object sender, EventArgs e)
    {
      RefreshLinkResults();
    }

    private void page_3_txt_xpathresult_TextChanged(object sender, EventArgs e)
    {
      if (!_page3Alert)
        return;

      _page3Alert = false;
      radDesktopAlert1.Show();
    }

    private void Page_4_browser_XPathChanged(object sender, EventArgs e)
    {
      if (radWizard1.SelectedPage != radWizard1.Pages[3])
        return;

      page_4_txt_xpath.Invoke((MethodInvoker) delegate { page_4_txt_xpath.Text = page_4_browser.XPath; });
    }

    private void page_4_btn_loadUrl_Click(object sender, EventArgs e)
    {
      page_4_drop_example_SelectedIndexChanged(null, null);
    }

    private void page_4_btn_xpathrefresh_Click(object sender, EventArgs e)
    {
      page_4_browser.XPath = page_4_txt_xpath.Text;
    }

    private void page_4_btn_xpathToList_Click(object sender, EventArgs e)
    {
      page_4_grid_xpath.Rows.Add(string.Empty, page_4_txt_xpath.Text);
      page_4_txt_xpath.Text = string.Empty;
    }

    private void page_4_drop_example_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
    {
      if (page_4_drop_example.SelectedIndex == -1)
        return;

      page_4_browser.Url = _linkResultsCompleted[page_4_drop_example.SelectedIndex];
    }

    private void page_4_txt_xpath_TextChanged(object sender, EventArgs e)
    {
      if (!_page4Alert)
        return;

      _page4Alert = false;
      radDesktopAlert1.Show();
    }

    private void radWizard1_Finish(object sender, EventArgs e)
    {
      var mappings = GetMappings();
      if (!mappings.ContainsKey("Text"))
      {
        MessageBox.Show(Resources.SieBenötigenMindestensEinMappingMitDemKeyText);
        return;
      }

      XpathWebCrawler.Create(
                             txt_name.Text,
                             txt_search_url.Text,
                             (int) num_search_min.Value,
                             (int) num_search_increment.Value,
                             txt_result_xpath.Text,
                             txt_result_prefix.Text,
                             txt_result_limmit.Text,
                             mappings);
      Close();
    }

    private void radWizard1_Next(object sender, WizardCancelEventArgs e)
    {
      // Überschreibe Standardlogik
      e.Cancel = true;

      // // SEITE - START // //

      if (radWizard1.SelectedPage == wizardWelcomePage1)
      {
        // Überprüfe ob Name gesetzt
        if (string.IsNullOrEmpty(page_0_txt_name.Text))
        {
          MessageBox.Show("Bitte tragen Sie einen individuellen Namen für den zu erstellenden WebCrawler ein.");
          return;
        }

        txt_name.Text = page_0_txt_name.Text;

        if (page_0_check_sampledata.Checked)
        {
          if (string.IsNullOrEmpty(txt_name.Text))
            txt_name.Text = "notes.jan-oliver-ruediger.de";

          page_2_num_start.Value = 1;
          page_2_num_incr.Value = 1;
          page_2_txt_url.Text = "http://notes.jan-oliver-ruediger.de/page/[PAGE]/?s=[QUERY]";

          page_3_txt_testquery.Text = "CorpusExplorer";
          page_3_txt_prefix.Text = "";
          page_3_txt_xpathresult.Text = ".//*[@id='recent-posts']/article/div/div/div/div/h1/a";

          page_4_grid_xpath.Rows.Add("Text", ".//*[@id='recent-posts']/article/div[1]/div/div/div[2]/p");
          page_4_grid_xpath.Rows.Add("Datum", ".//*[@id='recent-posts']/article/div[1]/div/div/div[1]/span");
          page_4_grid_xpath.Rows.Add("Titel", ".//*[@id='recent-posts']/article/div[1]/div/div/div[1]/h1");
        }

        if (page_0_chk_mode_2.IsChecked)
          radWizard1.SelectedPage = wizardPage2;
        if (page_0_chk_mode_3.IsChecked)
          radWizard1.SelectedPage = wizardCompletionPage1;
        return;
      }

      // // SEITE 2 - Fortgeschrittenen-Modus // //

      if (radWizard1.SelectedPage == wizardPage2)
      {
        if (string.IsNullOrEmpty(page_2_txt_url.Text) || !page_2_txt_url.Text.Contains("[QUERY]") ||
            !page_2_txt_url.Text.Contains("[PAGE]"))
          MessageBox.Show(
                          "Bitte geben Sie die URL für die seitenspezifische Suche an. Außerdem ersetzen Sie bitte den Suchausdruck durch [QUERY] sowie den Seitenindex durch [PAGE].");

        txt_search_url.Text = page_2_txt_url.Text;
        num_search_min.Value = page_2_num_start.Value;
        num_search_increment.Value = page_2_num_incr.Value;

        radWizard1.SelectedPage = wizardPage3;
        return;
      }

      // // SEITE 3 - Fortgeschrittenen-Modus - Suchergebnisse // //

      if (radWizard1.SelectedPage == wizardPage3)
      {
        txt_result_xpath.Text = page_3_txt_xpathresult.Text;
        txt_result_prefix.Text = page_3_txt_prefix.Text;
        txt_result_limmit.Text = page_3_txt_limit.Text;

        radWizard1.SelectedPage = wizardPage4;
        return;
      }

      // // SEITE 4 - XPath-Mapping // //

      if (radWizard1.SelectedPage == wizardPage4)
      {
        grid_mappings.Rows.Clear();
        foreach (var row in page_4_grid_xpath.Rows) grid_mappings.Rows.Add(row.Cells[0].Value, row.Cells[1].Value);

        radWizard1.SelectedPage = wizardCompletionPage1;
      }
    }

    private void radWizard1_Previous(object sender, WizardCancelEventArgs e)
    {
      // Überschreibe Standardlogik
      e.Cancel = true;

      /*
      // // SEITE 1 - Einsteiger-Modus // //

      if (radWizard1.SelectedPage == wizardPage1)
      {
        radWizard1.SelectedPage = wizardWelcomePage1;
        return;
      }
      */

      // // SEITE 2 - Fortgeschrittenen-Modus // //

      if (radWizard1.SelectedPage == wizardPage2)
      {
        radWizard1.SelectedPage = wizardWelcomePage1;
        return;
      }

      // // SEITE 3 - Fortgeschrittenen-Modus - Suchergebnisse // //

      if (radWizard1.SelectedPage == wizardPage3)
      {
        radWizard1.SelectedPage = wizardPage2;
        return;
      }

      // // SEITE 4 - XPath-Mapping // //

      if (radWizard1.SelectedPage == wizardPage4)
      {
        radWizard1.SelectedPage = page_0_chk_mode_2.IsChecked ? wizardPage3 : wizardWelcomePage1;
        return;
      }

      // // SEITE 5 - Überischt UND Fertigstellen // //

      if (radWizard1.SelectedPage == wizardCompletionPage1)
      {
        page_0_txt_name.Text = txt_name.Text;

        page_2_txt_url.Text = txt_search_url.Text;
        page_2_num_start.Value = num_search_min.Value;
        page_2_num_incr.Value = num_search_increment.Value;

        page_3_txt_prefix.Text = txt_result_prefix.Text;
        page_3_txt_limit.Text = txt_result_limmit.Text;
        page_3_txt_xpathresult.Text = txt_result_xpath.Text;

        page_4_grid_xpath.Rows.Clear();
        foreach (var row in grid_mappings.Rows) page_4_grid_xpath.Rows.Add(row.Cells[0].Value, row.Cells[1].Value);

        radWizard1.SelectedPage = wizardPage4;
      }
    }

    private void RefreshLinkResults()
    {
      _linkResultsCompleted.Clear();
      page_3_list_testresults.Items.Clear();
      page_4_drop_example.Items.Clear();

      foreach (var l in _linkResults)
      {
        var complete = (page_3_txt_prefix.Text ?? string.Empty) + l;
        page_3_list_testresults.Items.Add(complete);
        page_4_drop_example.Items.Add(complete);
        _linkResultsCompleted.Add(complete);
      }
    }
  }
}