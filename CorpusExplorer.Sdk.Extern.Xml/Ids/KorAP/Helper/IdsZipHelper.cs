using CorpusExplorer.Sdk.Ecosystem.Model;
using ICSharpCode.SharpZipLib.Zip;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Helper
{
  public static class IdsZipHelper
  {
    public static void Write(ZipOutputStream zip, string name, string content)
    {
      var entry = new ZipEntry(name);
      zip.PutNextEntry(entry);
      var buffer = Configuration.Encoding.GetBytes(content);
      zip.Write(buffer, 0, buffer.Length);
    }
  }
}
