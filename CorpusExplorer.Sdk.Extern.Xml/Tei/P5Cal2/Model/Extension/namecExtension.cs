using System.Linq;

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.P5Cal2.Model.Extension
{
  public static class namecExtension
  {
    public static string GetName(this name name)
    {
      return name?.Items == null ? "" : $"{(from x in name.Items where x is surname select (x as surname).Text).FirstOrDefault()}, {(from x in name.Items where x is string select x as string).FirstOrDefault()}";
    }
  }
}