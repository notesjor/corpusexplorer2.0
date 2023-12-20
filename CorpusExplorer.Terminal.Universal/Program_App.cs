using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Terminal.Universal.Helper;
using Tfres;

namespace CorpusExplorer.Terminal.Universal
{
  public static partial class Program
  {
    private static Dictionary<string, string> _translation = new Dictionary<string, string>();

    private static void SetTranslation(HttpContext obj)
    {
      _translation = obj.Request.PostData<Dictionary<string, string>>();
      obj.Response.Send(System.Net.HttpStatusCode.OK);
    }

    private static string Translate(string key)
    {
      if(_translation.ContainsKey(key))
        return _translation[key];
      return key;
    }
  }
}
