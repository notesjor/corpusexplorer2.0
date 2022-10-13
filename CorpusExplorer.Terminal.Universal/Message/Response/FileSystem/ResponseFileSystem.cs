namespace CorpusExplorer.Terminal.Universal.Message.Response.FileSystem
{
  public class ResponseFileSystem
  {
    public char DirectorySeparatorChar { get; set; }
    public string[] DriveLetters { get; set; }
    public string CurrentDrive { get; set; }
    public string[] CurrentPath { get; set; }
    public string[] Directories { get; set; }
    public ResponseFileInfo[] Files { get; set; }
  }
}
