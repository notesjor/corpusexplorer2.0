using System;
using System.IO;
using System.Linq;

namespace CorpusExplorer.Terminal.Universal.Message.Response.FileSystem
{
  public class ResponseFileInfo
  {
    private static string[] _units = new[] { "Bytes", "KB", "MB", "GB", "TB" };

    public string Path { get; set; }
    public string FileName { get; set; }
    public string Extension { get; set; }
    public long Size { get; set; }
    public string Date { get; set; }

    private ResponseFileInfo() { }

    public ResponseFileInfo(string path)
    {
      Path = path;
      FileName = System.IO.Path.GetFileName(path);
      Extension = System.IO.Path.GetFileName(path).Replace(System.IO.Path.GetFileNameWithoutExtension(path), "");

      var info = new FileInfo(path);

      Size = info.Length;
      Date = info.LastWriteTime.ToString("yyyy-MM-dd");
    }
  }
}
