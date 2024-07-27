using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Extern.Plaintext.RelAnnis.Helper
{
  public static class AnnisFileResolverHelper
  {
    public static string ResolveAnnisEndings(string path, string name)
    {
      var res = Path.Combine(path, $"{name}.annis");
      if (File.Exists(res))
        return res;
      return Path.Combine(path, $"{name}.tab");
    }
  }
}
