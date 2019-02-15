using System;
using Bcs.IO;

namespace CorpusExplorer.Sdk.Db.Gui
{
  public class DbSettingsReader
  {
    public DbSettingsReader(string path)
    {
      var lines = FileIO.ReadLines(path);
      if (lines.Length < 5)
        throw new IndexOutOfRangeException(
                                           "Die Datenbankeinstellungen müssen folgende Einstellungen enthalten: Host, Port, DB-Name, Nutzername und Passwort");

      Host = lines[0];
      Port = int.Parse(lines[1]);
      DbName = lines[2];
      Username = lines[3];
      Password = lines[4];
    }

    internal DbSettingsReader()
    {
    }

    public string DbName { get; set; }

    public string Host { get; set; }

    public string Password { get; set; }

    public int Port { get; set; }

    public string Username { get; set; }
  }
}