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
    public static string[] GetPreferredExtension(AbstractExporter exporter)
    {
      try
      {
        var name = Configuration.AddonExporters.Where(x => x.Value.GetType() == exporter.GetType()).FirstOrDefault().Key;
        var split = name.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries)[1];
        return split.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
      }
      catch
      {
        return null;
      }
    }
  }
}
