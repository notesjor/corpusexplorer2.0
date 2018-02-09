using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bcs.IO;

namespace CorpusExplorer.Sdk.Db.Gui
{
  public class DbSettingsReader
  {
    internal DbSettingsReader(){}
    
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

    public string Password { get; set; }

    public string Username { get; set; }

    public string DbName { get; set; }

    public int Port { get; set; }

    public string Host { get; set; }
  }
}

