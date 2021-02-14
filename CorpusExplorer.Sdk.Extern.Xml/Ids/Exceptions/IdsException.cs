namespace CorpusExplorer.Sdk.Extern.Xml.Ids.Exceptions
{
  public class IdsException : System.Exception
  {
    public IdsException(string path, string zipPath, System.Exception ex) : base(ex.Message, ex)
    {
      Path = path;
      ZipPath = zipPath;
    }

    public string ZipPath { get; set; }

    public string Path { get; set; }
  }
}
