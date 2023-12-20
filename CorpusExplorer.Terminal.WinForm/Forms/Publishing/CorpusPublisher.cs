using CorpusExplorer.Sdk.Utils.Drm;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CorpusExplorer.Terminal.WinForm.Forms.Publishing
{
  public partial class CorpusPublisher : AbstractForm
  {
    public CorpusPublisher()
    {
      InitializeComponent();
    }

    public CorpusInfo Result =>
      new CorpusInfo
      {
        CorpusName = txt_corpusName.Text,
        CorpusDescription = txt_corpusInfo.Text,
        LicenceHolder = txt_licenceHolder.Text,
        LicenceName = txt_licenceName.Text,
        LicenceUrl = txt_licenceInfo.Text,
        AdditionalInfoUrl = txt_additionalInfo.Text,
        Version = txt_publishingVersion.Text,

        NeedAcceptance = chk_accecptLicenceText.Checked
      };

    public int ResultProtectionMode => int.Parse(pages_protectionMode.SelectedPage.Tag.ToString());

    private void btn_publish_Click(object sender, EventArgs e)
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
