using System;
using System.Diagnostics;
using System.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Sdk.Helper
{
  public class TemporaryDirectory : IDisposable
  {
    public TemporaryDirectory()
    {
      Path = System.IO.Path.Combine(Configuration.TempPath, Guid.NewGuid().ToString("N"));

      if (Directory.Exists(Path)) 
        return;

      Directory.CreateDirectory(Path);
      if (!Path.StartsWith("/tmp/")) 
        return; 
      
      // Unix
      try
      {
        var process = Process.Start(new ProcessStartInfo
        {
          FileName = "chmod",
          Arguments = "777 " + Path,
          UseShellExecute = false
        });
        process.WaitForExit();
      }
      catch
      {
        // ignore
      }
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