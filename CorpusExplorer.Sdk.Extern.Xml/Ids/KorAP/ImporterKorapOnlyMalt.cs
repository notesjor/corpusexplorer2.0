namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP
{
  public class ImporterKorapOnlyMalt : ImporterKorap
  {
    public ImporterKorapOnlyMalt()
    {
      ImportCoreNlp = false;
      ImportMalt = true;
      ImportMarmot = false;
      ImportOpenNlp = false;
      ImportTreeTagger = false;
    }
  }
}