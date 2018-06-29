using CorpusExplorer.Sdk.Extern.Xml.Catma.Parser.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.Catma.Parser
{
  public static class CatmaRangeParserFactory
  {
    public static AbstractCatmaRangeParser Create(string target)
    {
      if (target.StartsWith("catma:///"))
        return new CatmaV3RangeParser();

      if (target.Contains("#range("))
        return new CatmaV2RangeParser();

      return null;
    }
  }
}