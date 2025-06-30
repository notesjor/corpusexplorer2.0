using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Abstract;

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  public partial class AddonAppInstallState : AbstractUserControl
  {
    private string _urlInfo;
    private string _urlInstall;
    private string _addonPath;
    private bool _state;
    private string _size;
    private string _label;

    public AddonAppInstallState(string label, string description, string size, string urlInfo, string urlInstall, string addonName, string directory)
    {
      InitializeComponent();

      lbl_label.Text = label;
      lbl_description.Text = description;
      
      lbl_size.Text = lbl_size.Text.Replace("{Size}", size);
      _label = label;
      _size = size;
      _urlInfo = urlInfo;
      _urlInstall = urlInstall;
      _addonPath = Path.Combine(directory, $"{addonName}.ceAddon");

      CheckAddOnInstallState();
    }

    private void CheckAddOnInstallState()
    {
      _state = File.Exists(_addonPath);
      btn_action.Text = _state ? "Deinstallieren" : "Installieren";
    }

    private void btn_info_Click(object sender, EventArgs e)
    {
      Process.Start(_urlInfo);
    }

    private void btn_action_Click(object sender, EventArgs e)
    {
      if (_state)
      {
        if (
          MessageBox.Show($"Möchten Sie das Add-on '{_label}' wirklich deinstallieren? Die Deinstallation wird vorgemerkt und erfolgt im Rahmen des nächsten Programm-Updates.",
                          "Add-on deinstallieren?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
          File.Delete(_addonPath);
      }
      else
      {
        if(MessageBox.Show($"Möchten Sie das Add-on '{_label}' wirklich installieren? Es werden zusätzlich ca. {_size} Festplattenspeicher belegt. Die Installation erfolgt beim nächsten Programmstart.",
                           "Add-on installieren?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
          using (var wc = new WebClient())
            wc.DownloadFile(_urlInstall, _addonPath);
      }

      CheckAddOnInstallState();
    }
  }
}
