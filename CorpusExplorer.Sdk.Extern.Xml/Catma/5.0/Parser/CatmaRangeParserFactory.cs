using CorpusExplorer.Sdk.Extern.Xml.Catma._5._0.Parser.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.Catma._5._0.Parser
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