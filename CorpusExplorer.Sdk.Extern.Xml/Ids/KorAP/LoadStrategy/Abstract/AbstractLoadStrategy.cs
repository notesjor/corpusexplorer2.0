using System;
using System.Collections.Generic;
using System.IO;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.LoadStrategy.Abstract
{
  public abstract class AbstractLoadStrategy : IDisposable
  {
    private HashSet<string> _entries;

    public abstract Stream GetEntry(string entry);
    public abstract void Dispose();
    public abstract AbstractLoadStrategy Create(string path, string ext);
    
    public bool Exists(string relPath) => EnsureEntries().Contains(relPath);
    public IEnumerable<string> Entries => EnsureEntries();

    private HashSet<string> EnsureEntries()
    {
      if (_entries != null)
        return _entries;

      _entries = new HashSet<string>(GetAllEntries());
      return _entries;
    }

    protected abstract IEnumerable<string> GetAllEntries();
  }
}
