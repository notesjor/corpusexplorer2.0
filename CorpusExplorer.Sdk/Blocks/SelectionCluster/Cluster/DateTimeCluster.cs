using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster
{
  public class DateTimeCluster : AbstractCluster
  {
    private readonly DateTime _value;
    public DateTimeCluster(DateTime value) { _value = value; }

    public override object CentralValue => _value;

    public override string Displayname => _value.ToString("yyyy-MM-dd HH:mm:ss");

    public override bool Add(Guid documentGuid, object obj)
    {
      try
      {
        var test = (DateTime) obj;
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