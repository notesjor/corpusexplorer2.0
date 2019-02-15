using System;
using System.Windows.Forms;

namespace CorpusExplorer.Sdk.Db.Gui
{
  public static class FormHelper
  {
    public static DbSettingsReader Show(string providerName, string defaultHost, int defaultPort,
                                        ValidateConnectionAction validateAction, string fileFilter,
                                        string pathSaveSettings = null)
    {
      var form = new DbCredentialForm(providerName,
                                      defaultHost,
                                      defaultPort,
                                      validateAction,
                                      fileFilter,
                                      pathSaveSettings
                                     );
      if (form.ShowDialog() != DialogResult.OK)
        throw new Exception("Verbindung zur Datenbank durch Nutzer*in abgebrochen.");

      return new DbSettingsReader
      {
        Host = form.Host,
        Port = form.Port,
        DbName = form.DbName,
        Username = form.Username,
        Password = form.Password
      };
    }
  }
}