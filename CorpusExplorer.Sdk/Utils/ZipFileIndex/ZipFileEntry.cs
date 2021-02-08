using System.IO;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;

namespace CorpusExplorer.Sdk.Utils.ZipFileIndex
{
  public class ZipFileEntry
  {
    private ZipFileIndex _zip;

    public ZipFileEntry(ZipFileIndex zip, string namePath, string nameFile)
    {
      _zip = zip;
      NamePath = namePath;
      NameFile = nameFile;
    }

    public string NameFile { get; private set; }
    public string NamePath { get; private set; }

    public void Extract(ZipFileEntryExtractionDelegate func)
    {
      using (var fs = new FileStream(_zip._path, FileMode.Open, FileAccess.Read, FileShare.Read))
      using (var zip = new ZipInputStream(fs, 1024 * 16))
      {
        do
        {
          var entry = zip.GetNextEntry();
          if (entry == null)
            break;
          if (entry.Name == NamePath)
          {
            byte[] data;
            using (var ms = new MemoryStream())
            {
              var buffer = new byte[4096];
              StreamUtils.Copy(zip, ms, buffer);
              ms.Seek(0, SeekOrigin.Begin);

              data = ms.ToArray();
            }

            func(ref data);
            return;
          }
        } while (true);
      }
    }

    public void Extract(ZipFileEntryExtractionStreamDelegate func)
    {
      using (var fs = new FileStream(_zip._path, FileMode.Open, FileAccess.Read, FileShare.Read))
      using (var zip = new ZipInputStream(fs, 1024 * 16))
      {
        do
        {
          var entry = zip.GetNextEntry();
          if (entry == null)
            break;
          if (entry.Name == NamePath)
          {
            using (var ms = new MemoryStream())
            {
              var buffer = new byte[4096];
              StreamUtils.Copy(zip, ms, buffer);
              ms.Seek(0, SeekOrigin.Begin);

              func(ms);
            }
            return;
          }
        } while (true);
      }
    }
  }
}