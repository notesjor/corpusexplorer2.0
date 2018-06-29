namespace CorpusExplorer.Sdk.Model.Cache
{
  public class CacheStrategyCurrentSelection : CacheStrategyClearCacheManually
  {
    public override void CurrentSelectionChanged()
    {
      Clear();
    }
  }
}