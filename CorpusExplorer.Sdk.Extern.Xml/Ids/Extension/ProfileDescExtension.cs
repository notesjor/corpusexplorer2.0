using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Ids.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.Extension
{
  public static class ProfileDescExtension
  {
    public static textClass GetTextClass(this profileDesc obj)
      => obj.Items.OfType<textClass>().FirstOrDefault();
  }
}