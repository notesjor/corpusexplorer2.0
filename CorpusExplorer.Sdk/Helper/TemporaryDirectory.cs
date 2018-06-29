using System;
using System.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Sdk.Helper
{
  public class TemporaryDirectory : IDisposable
  {
    public TemporaryDirectory()
    {
      var directory = System.IO.Path.Combine(Configuration.TempPath, Guid.NewGuid().ToString("N"));

      if (!Directory.Exists(directory))
        Directory.CreateDirectory(directory);

      Path = directory;
    }

    public string Path { get; }

    /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
    public void Dispose()
    {
      try
      {
        Directory.Delete(Path, true);
      }
      catch
      {
        // ignore
      }
    }
  }
}