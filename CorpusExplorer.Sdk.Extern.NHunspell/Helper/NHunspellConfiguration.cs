using CorpusExplorer.Sdk.Ecosystem.Model;
using NHunspell;

namespace CorpusExplorer.Sdk.Extern.NHunspell.Helper
{
  public static class NHunspellConfiguration
  {
    private static Hyphen _model = null;

    public static Hyphen Hyphen
    {
      get
      {
        if(_model != null)
          return _model;

        // Hypen
        try
        {
          Hyphen.NativeDllPath = Configuration.AppPath;
          _model = new Hyphen(Configuration.GetDependencyPath(@"NHunspell\hyphenation\hyph_de_DE.dic"));
        }
        catch
        {
          try
          {
            _model = new Hyphen();
          }
          catch
          {
            // ignore
          }
        }

        return _model;
      }
    }
  }
}
