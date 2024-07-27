using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Helper
{
  public static class ReadableMultilayerDocumentExtension
  {
    public static Dictionary<string, IEnumerable<IEnumerable<string>>> ExtractLayer(this Dictionary<string, IEnumerable<IEnumerable<string>>> multilayerDocument, string layerDisplayname, out IEnumerable<IEnumerable<string>> extractedLayer)
    {
      extractedLayer = multilayerDocument[layerDisplayname];
      multilayerDocument.Remove(layerDisplayname);
      return multilayerDocument;
    }
  }
}
