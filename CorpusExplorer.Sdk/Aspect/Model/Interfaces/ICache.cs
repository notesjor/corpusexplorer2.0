namespace CorpusExplorer.Sdk.Aspect.Model.Interfaces
{
  public interface ICache<T>
    where T : class
  {
    T this[string key] { get; set; }
  }
}