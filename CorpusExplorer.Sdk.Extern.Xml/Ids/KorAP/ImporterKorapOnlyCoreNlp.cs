namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP
{
  public class ImporterKorapOnlyCoreNlp : ImporterKorap
  {
    public ImporterKorapOnlyCoreNlp()
    {
      ImportCoreNlp = true;
      ImportMalt = false;
      ImportMarmot = false;
      ImportOpenNlp = false;
      ImportTreeTagger = false;
    }
  }
}