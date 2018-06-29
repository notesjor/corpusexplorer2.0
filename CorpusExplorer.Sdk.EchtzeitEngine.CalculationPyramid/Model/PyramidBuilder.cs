using CorpusExplorer.Sdk.EchtzeitEngine.CalculationPyramid.Model.Delegates;

namespace CorpusExplorer.Sdk.EchtzeitEngine.CalculationPyramid.Model
{
  public class PyramidBuilder<T>
  {
    private readonly PyramidLevel<T> _root;

    public PyramidBuilder(PyramidAggregationDelegate<T> aggregationFunc)
    {
      _root = new PyramidLevel<T>(aggregationFunc);
    }

    public void AddLevel(int spread)
    {
      var pyra = _root;
      while (pyra.Sub != null)
        pyra = pyra.Sub;
      pyra.SetLevelSpread(spread);
    }

    public PyramidLevel<T> GetPyramid()
    {
      return _root;
    }
  }
}