using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.LoadStrategy.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.LoadStrategy
{
  public class LoadStrategyMemory : AbstractLoadStrategy
  {
    private MemoryStream _ms;
    private ZipArchive _zip;

    public LoadStrategyMemory() { }
    private LoadStrategyMemory(string path)
    {
      _ms = new MemoryStream(File.ReadAllBytes(path));
      _zip = new ZipArchive(_ms, ZipArchiveMode.Read, true);
    }

    public override AbstractLoadStrategy Create(string path, string ext)
    {
      if (!string.IsNullOrWhiteSpace(ext))
        path = Path.Combine(Path.GetDirectoryName(path), $"{Path.GetFileNameWithoutExtension(path)}.tree_tagger.zip");
      return File.Exists(path) ? new LoadStrategyMemory(path) : null;
    }

    protected override IEnumerable<string> GetAllEntries() => _zip.Entries.Select(x => x.FullName);

    public override Stream GetEntry(string entry) => _zip.GetEntry(entry)?.Open();

    public override void Dispose()
    {
      _zip?.Dispose();
      _ms?.Dispose();
    }
  }
}
