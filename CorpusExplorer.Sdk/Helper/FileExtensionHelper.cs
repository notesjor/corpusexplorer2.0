using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Helper
{
  public static class FileExtensionHelper
  {
    private static readonly string[] _split01 = new[] { "|" };
    private static readonly string[] _split02 = new[] { ";" };

    public static string[] GetPreferredExtension(AbstractExporter exporter)
    {
      try
      {
        var name = Configuration.AddonExporters.Where(x => x.Value.GetType() == exporter.GetType()).FirstOrDefault().Key;
        var split = name.Split(_split01, StringSplitOptions.RemoveEmptyEntries)[1];
        return split.Split(_split02, StringSplitOptions.RemoveEmptyEntries);
      }
      catch
      {
        return null;
      }
    }
  }
}
