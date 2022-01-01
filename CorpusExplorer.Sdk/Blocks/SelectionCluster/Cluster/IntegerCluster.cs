#region

using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Helper;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster
{
  public class IntegerCluster : AbstractCluster
  {
    private readonly int _value;

    public IntegerCluster(int value) => _value = value;

    public override object CentralValue => _value;

    public override string Displayname => _value.ToString();

    public override bool Add(Guid documentGuid, object obj)
    {
      try
      {
        var val = obj.SafeCastInt();
        if (_value != val)
          return false;
        Add(documentGuid);
        return true;
      }
      catch
      {
        return false;
      }
    }
  }
}