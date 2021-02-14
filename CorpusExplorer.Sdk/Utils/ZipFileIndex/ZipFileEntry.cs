namespace CorpusExplorer.Sdk.Utils.ZipFileIndex
{
  public class ZipFileEntry
  {
    private ZipFileIndex _zip;

    public ZipFileEntry(ZipFileIndex zip, string namePath, string nameFile)
    {
      _zip = zip;
      NamePath = namePath;
      NameFile = nameFile;
    }

    public string NameFile { get; private set; }
    public string NamePath { get; private set; }


    public void Read(ZipFileEntryDelegate func) => _zip.Read(NamePath, func);
    public void Update(ZipFileEntryDelegate func) => _zip.Update(NamePath, func);
  }
}