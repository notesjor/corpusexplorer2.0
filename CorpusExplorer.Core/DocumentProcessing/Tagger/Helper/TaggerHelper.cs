using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Core.DocumentProcessing.Tagger.Helper
{
  public static class TaggerHelper
  {
    public static ListOptimized<string> SetEmptyValue(ListOptimized<string> list)
    {
      list.Add(" ");
      return list;
    }

    internal static ListOptimized<string> SetStandardPhraseLayerValues(ListOptimized<string> listPhrase)
    {
      listPhrase.Add("NC");
      listPhrase.Add("PC");
      listPhrase.Add("VC");
      return listPhrase;
    }

    public static ListOptimized<string> SetStandardSentenceLayerValues(ListOptimized<string> list)
    {
      list.Add(" ");
      list.Add(",");
      list.Add(".");
      list.Add("?");
      list.Add("!");
      list.Add(";");
      list.Add(":");
      list.Add("-");
      list.Add("[");
      list.Add("]");
      list.Add("(");
      list.Add(")");
      return list;
    }
  }
}