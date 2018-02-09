#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Model.Extension.Obsolete
{
  public static class ObsoleteProjectExtension
  {
    [Obsolete]
    public static IEnumerable<AbstractCorpusAdapter> GetCorporaOBSOLETE(this Project project)
    {
      var guids = project.CorporaGuidsAndDisplaynames;
      return guids.Select(guid => project.GetCorpus(guid.Key));
    }
  }
}