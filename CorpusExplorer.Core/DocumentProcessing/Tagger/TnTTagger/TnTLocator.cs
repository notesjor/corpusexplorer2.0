using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Core.DocumentProcessing.Tagger.TnTTagger
{
  internal static class TnTLocator
  {
    public static string RootDirectory => Configuration.GetDependencyPath(@"tnt");

    public static string GetModelFile(string languageSelected)
    {
      switch (languageSelected)
      {
        case "Deutsch":
          return RootDirectory + @"\models\negra";
        case "Englisch":
          return RootDirectory + @"\models\wsj";
        default:
          return null;
      }
    }
  }
}