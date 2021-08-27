namespace CorpusExplorer.Sdk.Data.Model.MetaInformationen
{
  public interface IAbstrakterMetaEintrag<out T>
  {
    T Value { get; }
  }
}