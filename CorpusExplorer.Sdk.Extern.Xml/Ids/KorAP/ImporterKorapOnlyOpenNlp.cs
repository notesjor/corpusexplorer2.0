namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP
{
  public class ImporterKorapOnlyOpenNlp : ImporterKorap
  {
    public ImporterKorapOnlyOpenNlp()
    {
      ImportCoreNlp = false;
      ImportMalt = false;
      ImportMarmot = false;
      ImportOpenNlp = true;
      ImportTreeTagger = false;
    }
  }
}