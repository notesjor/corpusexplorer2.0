using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.Xml.Bnc.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.Bnc.Extension
{
  public static class biblExtension
  {
    public static IEnumerable<author> Author(this bibl obj)
      => obj.Items?.OfType<author>();

    public static IEnumerable<editor> Editor(this bibl obj)
      => obj.Items?.OfType<editor>();
  }
}
