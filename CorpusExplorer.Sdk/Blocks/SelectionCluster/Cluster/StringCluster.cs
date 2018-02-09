using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster
{
  public class StringCluster : AbstractCluster
  {
    private readonly string _value;
    public StringCluster(string value) { _value = value ?? ""; }

    public override object CentralValue => _value;

    public override string Displayname => _value;

    public override bool Add(Guid documentGuid, object obj)
    {
      try
      {
        if (obj == null)
          return false;
        var test = obj.ToString();
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