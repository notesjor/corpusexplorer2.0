using System.Collections.Generic;

namespace CorpusExplorer.Sdk.Utils.ZipFileIndex
{
  public class ZipDirectoryEntry
  {
    public string NameDirectory { get; set; }
    public string NamePath { get; set; }
    public List<ZipDirectoryEntry> ZipDirectories { get; set; } = new List<ZipDirectoryEntry>();
    public List<ZipFileEntry> ZipFiles { get; set; } = new List<ZipFileEntry>();
  }
}