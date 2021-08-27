using CorpusExplorer.Terminal.Console.Xml.Model;

namespace CorpusExplorer.Terminal.Automate.Helper
{
  public static class QueryNameHelper
  {
    public static string GetName(this query q)
      => q.name;
    public static string GetName(this queryBuilder q)
      => q.name;
    public static string GetName(this queryGroup q)
      => q.name;

    public static string GetName(object obj)
    {
      switch (obj)
      {
        case query q:
          return q.GetName();
        case queryBuilder b:
          return b.GetName();
        case queryGroup g:
          return g.GetName();
      }

      return "";
    }
  }
}
