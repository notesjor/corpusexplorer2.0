using System;
using System.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Sdk.Helper
{
  public class TemporaryFile : IDisposable
  {
    public TemporaryFile(string directory, string fileExtension = ".temp")
    {
      if (string.IsNullOrEmpty(directory))
        directory = Configuration.TempPath;

      if (!Directory.Exists(directory))
        Directory.CreateDirectory(directory);

      Path = System.IO.Path.Combine(directory, Guid.NewGuid().ToString("N") + fileExtension).Replace("\\", "/");
    }

    public string Path { get; }

    /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
    public void Dispose()
    {
      try
      {
        File.Delete(Path);
      }
      catch
      {
        // ignore
      }
    }

    public override string ToString() => Path;
  }
}