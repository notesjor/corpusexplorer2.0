using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.Db.Abstract
{
  public abstract class AbstractDatabaseBuilder<T> where T : AbstractBlock
  {
    public void Execute(Selection selection, string connectionString)
    {
      MapBlockToDatabase(InitializeBlock(selection), connectionString);
    }

    protected abstract T InitializeBlock(Selection selection);
    protected abstract void MapBlockToDatabase(T block, string connectionString);
  }
}