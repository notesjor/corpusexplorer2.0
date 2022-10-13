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
    private static void GetLogo(HttpContext obj)
    {
      obj.Response.SendFile(Path.Combine(PathHelper.PathBranding, "logo.svg"), "image/svg+xml");
    }

    private static void GetWelcome(HttpContext obj)
    {
      obj.Response.SendFile(Path.Combine(PathHelper.PathBranding, "welcome.html"), "text/html");
    }

    private static void GetLocalize(HttpContext obj)
    {
      obj.Response.SendFile(Path.Combine(PathHelper.PathLocalize, "data.json"), "application/json");
    }
  }
}
