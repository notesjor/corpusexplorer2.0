using System.IO;

namespace CorpusExplorer.Sdk.Utils.ZipFileIndex
{
  public delegate void ZipFileEntryExtractionDelegate(ref byte[] data);
  public delegate void ZipFileEntryExtractionStreamDelegate(MemoryStream ms);
}