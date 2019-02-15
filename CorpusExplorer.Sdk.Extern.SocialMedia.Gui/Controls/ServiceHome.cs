using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Controls.Abstract;
using CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Helper;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Controls
{
  public partial class ServiceHome : AbstractUserControl
  {
    private AbstractAuthentication _authentication;

    [NonSerialized] private string[] _names;

    private string _serviceName;

    [NonSerialized] private RadPropertyStore _store;

    private string _urlCreateAccount;
    private string _urlCreateApiKey;

    public ServiceHome()
    {
      InitializeComponent();
      Load += (s, e) => { txt_path.Text = OutputPathHelper.OutputPath; };
    }

    public string ServiceName
    {
      get => _serviceName;
      set
      {
        _serviceName = value;
        ihdPanel1.IHDHeader = $"Bei {value} anmelden";
      }
    }

    public string UrlCreateAccount
    {
      get => _urlCreateAccount;
      set
      {
        _urlCreateAccount = value;
        link_createAccount.Enabled = !string.IsNullOrEmpty(value);
      }
    }

    public string UrlCreateApiKey
    {
      get => _urlCreateApiKey;
      set
      {
        _urlCreateApiKey = value;
        link_createApiKey.Enabled = !string.IsNullOrEmpty(value);
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public AbstractAuthentication Authentication
    {
      get => _authentication;
      set
      {
        _authentication = value;
        if (Authentication == null) return;

        Authentication.SettingsLoad();
        SetApiCredentials(Authentication.Settings);
        btn_validateAndSave_Click(null, null);
      }
    }

    public RadPageView PageView { get; set; }

    private void SetApiCredentials(Dictionary<string, string> credentials)
    {
      if (credentials == null) return;

      _store = new RadPropertyStore();
      foreach (var item in credentials)
        _store.Add(new PropertyStoreItem(typeof(string), item.Key, item.Value));
      radPropertyGrid1.SelectedObject = _store;
      _names = credentials.Keys.ToArray();
    }

    public Dictionary<string, string> GetApiCredentials()
    {
      return _names.ToDictionary(x => x, x => _store[x].Value.ToString().Trim());
    }

    private void link_createAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start(UrlCreateAccount);
    }

    private void link_createApiKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start(UrlCreateApiKey);
    }

    private void btn_validateAndSave_Click(object sender, EventArgs e)
    {
      Authentication.Settings = GetApiCredentials();
      var auth = Authentication.OpenConnection();
      if (auth == null)
      {
        panel_availableOptions.Visible = false;
        return;
      }

      Authentication.SettingsSave();
      panel_availableOptions.Visible = true;
    }

    public void AddEndpoint(Image image, string label, int pageIndex, AbstractEndpointRequest gui,
                            AbstractService service)
    {
      var control = new ServiceInformationButton
      {
        Image = image,
        Label = label
      };
      control.OnClick += (s, e) =>
      {
        if (PageView == null)
          return;

        PageView.SelectedPage = PageView.Pages[pageIndex];
        gui.Authentication = Authentication;
      };

      service.StatusUpdate = gui.PostStatusUpdate;

      gui.Size = PageView.Pages[pageIndex].Size;
      gui.Dock = DockStyle.Fill;
      gui.Execute += (a, p) => service.Run(a, p["queries"] as string[], OutputPathHelper.OutputPath);
      PageView.Pages[pageIndex].Controls.Add(gui);

      panel_endpoints.Controls.Add(control);
    }

    private void btn_outputPath_Click(object sender, EventArgs e)
    {
      var fbd = new FolderBrowserDialog
      {
        Description = "Bitte wähle Sie ein Ausgabeverzeichnis:"
      };
      if (fbd.ShowDialog() == DialogResult.OK)
        txt_path.Text = fbd.SelectedPath;
    }

    private void txt_path_TextChanged(object sender, EventArgs e)
    {
      OutputPathHelper.OutputPath = txt_path.Text;
    }
  }
}