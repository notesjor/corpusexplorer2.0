using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.LoadStrategy.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.LoadStrategy
{
  public class LoadStrategyFileStream : AbstractLoadStrategy
  {
    private FileStream _fs;
    private ZipArchive _zip;

    public LoadStrategyFileStream() { }
    private LoadStrategyFileStream(string path)
    {
      _fs = new FileStream(path, FileMode.Open, FileAccess.Read);
      _zip = new ZipArchive(_fs, ZipArchiveMode.Read, true);
    }

    public override AbstractLoadStrategy Create(string path, string ext)
    {
      if (!string.IsNullOrWhiteSpace(ext))
        path = Path.Combine(Path.GetDirectoryName(path), $"{Path.GetFileNameWithoutExtension(path)}.tree_tagger.zip");
      return File.Exists(path) ? new LoadStrategyFileStream(path) : null;
    }

    protected override IEnumerable<string> GetAllEntries() => _zip.Entries.Select(x=>x.FullName);

    public override Stream GetEntry(string entry) => _zip.GetEntry(entry)?.Open();

    public override void Dispose()
    {
      _zip?.Dispose();
      _fs?.Dispose();
    }
  }
}