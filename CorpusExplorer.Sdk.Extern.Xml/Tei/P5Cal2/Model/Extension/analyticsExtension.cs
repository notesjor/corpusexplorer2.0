using System.Collections.Generic;
using System.Linq;

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.P5Cal2.Model.Extension
{
  public static class analyticsExtension
  {
    public static IEnumerable<author> GetAuthors(this analytic an)
      => an?.Items == null ? null : (from x in an.Items where x is author select x as author);

    public static respStmt GetRespStmt(this analytic an)
      => an?.Items == null ? null : (from x in an.Items where x is respStmt select x as respStmt).FirstOrDefault();
  }
}