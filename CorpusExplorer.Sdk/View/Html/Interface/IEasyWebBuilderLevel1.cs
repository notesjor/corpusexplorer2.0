using System.Collections.Generic;
using CorpusExplorer.Sdk.Model;

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
    /// Replaces the script.
    /// </summary>
    /// <param name="selection">The selection.</param>
    /// <returns>IEasyWebBuilderLevel1.</returns>
    IEasyWebBuilderLevel1 ReplaceScript(Selection selection);
    /// <summary>
    /// Finalizes this instance.
    /// </summary>
    /// <returns>Index-Path</returns>
    string Finalize();
  }
}