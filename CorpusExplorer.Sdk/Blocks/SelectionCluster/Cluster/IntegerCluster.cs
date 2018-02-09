using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster
{
  public class IntegerCluster : AbstractCluster
  {
    private readonly int _value;
    public IntegerCluster(int value) { _value = value; }

    public override object CentralValue => _value;

    public override string Displayname => _value.ToString();

    public override bool Add(Guid documentGuid, object obj)
    {
      try
      {
        var test = (int) obj;
        if (_value != test)
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