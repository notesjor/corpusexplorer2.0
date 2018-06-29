using System;
using System.Windows.Forms;
using Bcs.IO;

namespace CorpusExplorer.Sdk.Db.Gui
{
  public partial class DbCredentialForm : AbstractForm
  {
    private readonly string _fileFilter;
    private readonly ValidateConnectionAction _validateAction;

    public DbCredentialForm(string provider, string defaultHost, int defaultPort,
      ValidateConnectionAction validateAction, string fileFilter, string pathSaveSettings)
    {
      InitializeComponent();

      txt_host.Text = defaultHost;
      txt_port.Value = defaultPort;

      Text = Text.Replace("{PROVIDER}", provider);
      radLabel1.Text = radLabel1.Text.Replace("{PROVIDER}", provider);

      _fileFilter = fileFilter;
      SaveFilePath = pathSaveSettings;
      _validateAction = validateAction;

      Load += (a, e) => Processing.SplashClose();
    }

    public string DbName => txt_dbname.Text;

    public string Host => txt_host.Text;
    public string Password => txt_password.Text;
    public int Port => (int) txt_port.Value;
    public string SaveFilePath { get; private set; }

    public bool SaveSettings => chk_save.Checked;
    public string Username => txt_user.Text;

    private void btn_abort_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Abort;
      Close();
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
        if (string.IsNullOrEmpty(SaveFilePath))
        {
          var sfd = new SaveFileDialog {Filter = _fileFilter};
          if (sfd.ShowDialog() != DialogResult.OK)
          {
            MessageBox.Show("Sie müssen eine Datei angeben, in der die Verbindungseinstellungen gespeichert werden.");
            return;
          }

          SaveFilePath = sfd.FileName;
        }

        var lines = new[] {Host, Port.ToString(), DbName, Username, Password};
        FileIO.Write(SaveFilePath, string.Join("\r\n", lines));
      }

      DialogResult = DialogResult.OK;
      Close();
      Processing.SplashShow("Datenbank-Update läuft...");
    }

    private void btn_test_Click(object sender, EventArgs e)
    {
      MessageBox.Show(
        $"Die Verbindung zum Server war: {(_validateAction(Host, Port, DbName, Username, Password) ? "erfolgreich!" : "nicht erfolgreich!")}");
    }
  }
}