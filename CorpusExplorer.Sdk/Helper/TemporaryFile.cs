using System;
using System.Diagnostics;
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

      Path = System.IO.Path.Combine(directory, Guid.NewGuid().ToString("N") + fileExtension).Replace("\\", "/");

      if (Directory.Exists(directory)) 
        return;

      Directory.CreateDirectory(directory);

      if (!directory.StartsWith("/tmp/")) 
        return;
      
      // Unix
      try
      {
        var process = Process.Start(new ProcessStartInfo
        {
          FileName = "chmod",
          Arguments = "777 " + directory,
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