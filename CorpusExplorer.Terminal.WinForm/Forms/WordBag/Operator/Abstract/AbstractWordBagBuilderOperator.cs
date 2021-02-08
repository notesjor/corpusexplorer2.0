namespace CorpusExplorer.Terminal.WinForm.Forms.WordBag.Operator.Abstract
{
  public abstract class AbstractWordBagBuilderOperator
  {
    public abstract void Initialize(string query);
    public abstract bool IsMatch(string token);
  }
}
