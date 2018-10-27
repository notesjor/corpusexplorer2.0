using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Abstract
{
  public abstract class AbstractService
  {
    public string OutputPath { get; set; }
    public IEnumerable<string> Queries { get; set; }
    protected abstract AbstractAuthentication Authentication { get; }

    public async void Run(Dictionary<string, object> settings)
    {
      var connection = Authentication.Signin();
      if (connection == null)
        return;

      Query(connection, Queries, OutputPath);
    }

    protected abstract void Query(object connection, IEnumerable<string> queries, string outputPath);
  }
}
