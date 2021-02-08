namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP
{
  public class ImporterKorapOnlyTreeTagger : ImporterKorap
  {
    public ImporterKorapOnlyTreeTagger()
    {
      ImportCoreNlp = false;
      ImportMalt = false;
      ImportMarmot = false;
      ImportOpenNlp = false;
      ImportTreeTagger = true;
    }
  }
}
