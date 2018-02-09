using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Db.Gui
{
  public delegate bool ValidateConnectionAction(string host, int port, string dbName, string user, string password);
}
