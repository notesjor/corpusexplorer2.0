namespace CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.Model
{
  public delegate double CallAddConnectionsConflictDelegate(double a, double b);

  public static class PredefinedCallAddConnectionsConflictDelegates
  {
    public static double First(double a, double b)
    {
      return a;
    }

    public static double Last(double a, double b)
    {
      return b;
    }

    public static double Sum(double a, double b)
    {
      return a + b;
    }
  }
}