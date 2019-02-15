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
  public partial class AddonCorpusInstallState : AbstractUserControl
  {
    private string _url;
    private string _addonPath;
    private bool _state;
    private string _label;
    private string _size;

    public AddonCorpusInstallState(string label, string size, string documents, string sentences, string token, string layer, string url, string description)
    {
      InitializeComponent();
      lbl_label.Text = label;
      radRichTextEditor1.Text = $"<html>{description}<br/><strong>Benötigt: {size}</strong><br/><i>ca. {documents} Dokumente - ca. {sentences} Sätze - ca. {token} Token - Layer: {layer}</i></html>";
      radRichTextEditor1.Document.Selection.SelectAll();
      radRichTextEditor1.ChangeFontSize(10);
      radRichTextEditor1.ChangeFontFamily(new Telerik.WinControls.RichTextEditor.UI.FontFamily("Segoe UI"));
      radRichTextEditor1.Document.Selection.Clear();

      _label = label;
      _size = size;
      _url = url;
      _addonPath = Path.Combine(Configuration.MyAddons, _url.Substring(_url.LastIndexOf("/") + 1));

      CheckAddOnInstallState();
    }

    private void CheckAddOnInstallState()
    {
      _state = File.Exists(_addonPath);
      btn_action.Text = _state ? "Abbestellen" : "Abonnieren";
    }

    private void btn_action_Click(object sender, EventArgs e)
    {
      if (_state)
      {
        if (
          MessageBox.Show($"Möchten Sie das Korpus '{_label}' wirklich abbestellen? Das Korpus wird zukünftig nicht mehr aktualisiert.",
                          "Korpus abbestellen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
          File.Delete(_addonPath);
      }
      else
      {
        if(MessageBox.Show($"Möchten Sie das Korpus '{_label}' wirklich abonnieren? Es werden zusätzlich ca. {_size} Festplattenspeicher belegt. Der Download erfolgt beim nächsten Programmstart.",
                           "Korpus abonnieren?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
          using (var wc = new WebClient())
            wc.DownloadFile(_url, _addonPath);
      }

      CheckAddOnInstallState();
    }
  }
}
