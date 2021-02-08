namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP
{
  public class ImporterKorapOnlyMarmot : ImporterKorap
  {
    public ImporterKorapOnlyMarmot()
    {
      ImportCoreNlp = false;
      ImportMalt = false;
      ImportMarmot = true;
      ImportOpenNlp = false;
      ImportTreeTagger = false;
    }
  }
}