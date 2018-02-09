using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bcs.IO;

namespace CorpusExplorer.Sdk.Db.Gui
{
  public partial class DbCredentialForm : AbstractForm
  {
    private ValidateConnectionAction _validateAction;
    private string _pathSaveSettings;
    private string _fileFilter;

    public DbCredentialForm(string provider, string defaultHost, int defaultPort, ValidateConnectionAction validateAction, string fileFilter, string pathSaveSettings)
    {
      InitializeComponent();

      txt_host.Text = defaultHost;
      txt_port.Value = defaultPort;

      Text = Text.Replace("{PROVIDER}", provider);
      radLabel1.Text = radLabel1.Text.Replace("{PROVIDER}", provider);

      _fileFilter = fileFilter;
      _pathSaveSettings = pathSaveSettings;
      _validateAction = validateAction;

      Load += (a, e) => Processing.SplashClose();
    }

    public string Host => txt_host.Text;
    public int Port => (int)txt_port.Value;
    public string DbName => txt_dbname.Text;
    public string Username => txt_user.Text;
    public string Password => txt_password.Text;
    public bool SaveSettings => chk_save.Checked;
    public string SaveFilePath => _pathSaveSettings;

    private void btn_test_Click(object sender, EventArgs e)
    {
      MessageBox.Show($"Die Verbindung zum Server war: {(_validateAction(Host, Port, DbName, Username, Password) ? "erfolgreich!" : "nicht erfolgreich!")}");
    }

    private void btn_ok_Click(object sender, EventArgs e)
    {
      if (!_validateAction(Host, Port, DbName, Username, Password))
      {
        MessageBox.Show("Bitte stellen Sie zunächst eine funktionierende Verbindung zum Datenbankserver her.");
        return;
      }

      if (SaveSettings)
      {
        if (string.IsNullOrEmpty(_pathSaveSettings))
        {
          var sfd = new SaveFileDialog {Filter = _fileFilter};
          if (sfd.ShowDialog() != DialogResult.OK)
          {
            MessageBox.Show("Sie müssen eine Datei angeben, in der die Verbindungseinstellungen gespeichert werden.");
            return;
          }
          _pathSaveSettings = sfd.FileName;
        }
        var lines = new[] {Host, Port.ToString(), DbName, Username, Password};
        FileIO.Write(_pathSaveSettings, string.Join("\r\n", lines));
      }

      DialogResult = DialogResult.OK;
      Close();
      Processing.SplashShow("Datenbank-Update läuft...");
    }

    private void btn_abort_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Abort;
      Close();
    }
  }
}
