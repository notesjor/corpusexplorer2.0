using CorpusExplorer.Sdk.Utils.Drm;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CorpusExplorer.Terminal.WinForm.Forms.Publishing
{
  public partial class PublishingInfo : AbstractForm
  {
    private string _urlInfo;
    private string _urlLicence;

    public PublishingInfo(CorpusLicenceInfo cli)
    {
      InitializeComponent();

      txt_corpusName.Text = cli.CorpusName;
      txt_version.Text = cli.Version;
      txt_corpusInfo.Text = cli.CorpusDescription;
      txt_licenceHolder.Text = cli.LicenceHolder;
      txt_licenceName.Text = cli.LicenceName;

      _urlInfo = cli.AdditionalInfoUrl;
      _urlLicence = cli.LicenceUrl;

      if (string.IsNullOrEmpty(cli.AdditionalInfoUrl))
        link_info.Visible = false;
      else
        link_info.Text = cli.AdditionalInfoUrl;

      if(string.IsNullOrEmpty(cli.LicenceUrl))
        link_licence.Visible = false;
      else
        link_licence.Text = cli.LicenceUrl;
    }

    private void link_info_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start(_urlInfo);
    }

    private void link_licence_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start(_urlLicence);
    }

    private void btn_ok_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
      Close();
    }

    private void btn_abort_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Abort;
      Close();
    }
  }
}
