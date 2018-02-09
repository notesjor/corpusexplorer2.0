using System.Diagnostics.CodeAnalysis;

namespace CorpusExplorer.Sdk.Utils.Diff
{
  /// <summary>details of one difference.</summary>
  [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")]
  public struct DiffDelta
  {
    /// <summary>Number of changes in Data A.</summary>
    public int DeletedA;

    /// <summary>Number of changes in Data B.</summary>
    public int InsertedB;

    /// <summary>Start Line number in Data A.</summary>
    public int StartA;

    /// <summary>Start Line number in Data B.</summary>
    public int StartB;

    public int EditDistance => DeletedA + InsertedB;
  }
}