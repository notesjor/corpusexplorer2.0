using CorpusExplorer.Sdk.Blocks.SelectionCluster.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract
{
  public abstract class AbstractDateTimeCluster : AbstractCluster
  {
    public override bool Add(Guid documentGuid, object obj)
      => Add(documentGuid, SelectionClusterDateTimeHelper.SafeConvert(obj));

    public abstract bool Add(Guid documentGuid, DateTime obj);
  }
}
