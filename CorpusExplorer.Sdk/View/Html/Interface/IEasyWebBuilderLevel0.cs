namespace CorpusExplorer.Sdk.View.Html.Interface
{
  public interface IEasyWebBuilderLevel0
  {
    /// <summary>
    /// Adds the dependency.
    /// </summary>
    /// <param name="dependencyName">Name of the dependency.</param>
    /// <returns>IEasyWebBuilderLevel0.</returns>
    IEasyWebBuilderLevel0 AddDependency(string dependencyName);
    /// <summary>
    /// Adds the dependency.
    /// </summary>
    /// <param name="path">Name of the dependency.</param>
    /// <returns>IEasyWebBuilderLevel0.</returns>
    IEasyWebBuilderLevel0 AddDependencyUntrusted(string path);
    /// <summary>
    /// Writes the index.html
    /// </summary>
    /// <param name="html">The HTML.</param>
    /// <returns>IEasyWebBuilderLevel1.</returns>
    IEasyWebBuilderLevel1 SetIndexByString(string html);
    /// <summary>
    /// Use a HTML-File as index.html
    /// </summary>
    /// <param name="path">The Path</param>
    /// <returns>IEasyWebBuilderLevel1.</returns>
    IEasyWebBuilderLevel1 SetIndexByFile(string path);
    /// <summary>
    /// Use a HTML-File (XDependency) as index.html
    /// </summary>
    /// <param name="dependencyPath">The relative dependency Path</param>
    /// <returns>IEasyWebBuilderLevel1.</returns>
    IEasyWebBuilderLevel1 SetIndexByDependencyFile(string dependencyPath);
  }
}