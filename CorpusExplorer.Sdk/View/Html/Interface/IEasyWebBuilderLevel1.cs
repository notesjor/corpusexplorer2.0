using System.Collections.Generic;

namespace CorpusExplorer.Sdk.View.Html.Interface
{
  public interface IEasyWebBuilderLevel1
  {
    /// <summary>
    /// Replaces Template variables
    /// </summary>
    /// <param name="templateVars">The template vars.</param>
    /// <returns>IEasyWebBuilderLevel1.</returns>
    IEasyWebBuilderLevel1 ReplaceTemplateVars(Dictionary<string, string> templateVars);
    /// <summary>
    /// Finalizes this instance.
    /// </summary>
    /// <returns>Index-Path</returns>
    string Finalize();
  }
}