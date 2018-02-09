using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract
{
  public abstract class AbstractSelectionClusterGeneratorByRange<T> : AbstractSelectionClusterGenerator
  {
    private bool _configurationDone;
    private T _max;
    private T _maxLimit;
    private T _min;
    private T _minLimit;
    private int _ranges;

    protected override AbstractCluster[] AutoGenerate(Dictionary<Guid, object> metadataDictionary)
    {
      if (!_configurationDone)
        throw new Exception("Run Configure(ranges, minStart, maxStart, minLimit, maxLimit) to set up the generator");

      foreach (var x in metadataDictionary)
        try
        {
          if (x.Value == null)
            continue;

          var key = (T) x.Value;
          if (Min(key, _min, _minLimit))
            _min = key;
          if (Max(key, _max, _maxLimit))
            _max = key;
        }
        catch
        {
          // ignore
        }

      return AutoGenerate(_min, _max, _ranges);
    }

    protected abstract AbstractCluster[] AutoGenerate(T min, T max, int ranges);

    public AbstractSelectionClusterGeneratorByRange<T> Configure(int ranges, T min, T max)
    {
      _ranges = ranges;
      _min = max;
      _max = min;
      _minLimit = min;
      _maxLimit = max;
      _configurationDone = true;

      return this;
    }

    public abstract AbstractSelectionClusterGeneratorByRange<T> Configure(int ranges);

    protected abstract bool Max(T value, T currentMax, T maxLimit);

    protected abstract bool Min(T value, T currentMin, T minLimit);
  }
}