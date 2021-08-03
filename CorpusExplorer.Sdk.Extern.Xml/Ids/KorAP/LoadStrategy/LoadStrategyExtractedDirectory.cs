using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.LoadStrategy.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.LoadStrategy
{
  public class LoadStrategyExtractedDirectory : AbstractLoadStrategy
  {
    private readonly string _path;
    private Stream _last;

    public LoadStrategyExtractedDirectory() { }
    private LoadStrategyExtractedDirectory(string path)
    {
      _path = path;
      if (!_path.EndsWith("/"))
        _path += "/";
    }

    public override AbstractLoadStrategy Create(string path, string ext)
    {
      return Directory.Exists(path) ? new LoadStrategyExtractedDirectory(path) : null;
    }

    protected override IEnumerable<string> GetAllEntries() 
      => Directory.GetFiles(_path, "*.*", SearchOption.AllDirectories).Select(x => x.Replace(_path, "").Replace("\\","/"));

    public override Stream GetEntry(string entry)
    {
      if (entry.StartsWith("/"))
        entry = entry.Substring(1);

      var path = Path.Combine(_path, entry);

      DisposeLastStream();

      _last = new FileStream(path, FileMode.Open, FileAccess.Read);
      return _last;
    }

    private void DisposeLastStream()
    {
      try
      {
        if (_last != null && _last.CanRead)
          _last.Close();
      }
      catch
      {
        // ignore
      }
    }

    public override void Dispose()
    {
      DisposeLastStream();
    }
  }
}