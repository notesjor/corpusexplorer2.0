using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter;
using CorpusExplorer.Sdk.View.Html.Interface;

namespace CorpusExplorer.Sdk.View.Html
{
  public class EasyWebBuilder : IEasyWebBuilderLevel0, IEasyWebBuilderLevel1
  {
    private readonly string _root;

    private EasyWebBuilder(string webserverRoot)
    {
      _root = webserverRoot ?? Path.Combine(Configuration.TempPath, "CorpusExplorerWebserver");

      if (Directory.Exists(_root))
        Directory.Delete(_root, true);
      Directory.CreateDirectory(_root);

      IndexPath = Path.Combine(_root, "index.html");
    }

    /// <summary>
    /// Gets or sets the index path.
    /// </summary>
    /// <value>The index path.</value>
    public string IndexPath { get; set; }

    /// <summary>
    /// Creates a webserver.
    /// </summary>
    /// <param name="webserverRoot">The webserver root.</param>
    /// <returns>EasyWebBuilder.</returns>
    public static IEasyWebBuilderLevel0 Create(string webserverRoot = null)
      => new EasyWebBuilder(webserverRoot);

    /// <summary>
    /// Adds the dependency.
    /// </summary>
    /// <param name="dependencyName">Name of the dependency.</param>
    /// <returns>EasyWebBuilder.</returns>
    public IEasyWebBuilderLevel0 AddDependency(string dependencyName)
    {
      if(string.IsNullOrWhiteSpace(dependencyName))
        return this;

      CopyDirectoryHelper.Copy(Configuration.GetDependencyPath(dependencyName), _root, true);
      return this;
    }

    /// <summary>
    /// Adds the dependency.
    /// </summary>
    /// <param name="path">Name of the dependency.</param>
    /// <returns>EasyWebBuilder.</returns>
    public IEasyWebBuilderLevel0 AddDependencyUntrusted(string path)
    {
      CopyDirectoryHelper.Copy(path, _root, true);
      return this;
    }

    /// <summary>
    /// Writes the index.html
    /// </summary>
    /// <param name="html">The HTML.</param>
    /// <returns>HTML-String</returns>
    public IEasyWebBuilderLevel1 SetIndexByString(string html)
    {
      FileIO.Write(IndexPath, html, Configuration.Encoding);
      return this;
    }

    /// <summary>
    /// Use a HTML-File as index.html
    /// </summary>
    /// <param name="path">The Path</param>
    /// <returns>Path to *.html</returns>
    public IEasyWebBuilderLevel1 SetIndexByFile(string path)
    {
      FileIO.Write(IndexPath, FileIO.ReadText(path, Configuration.Encoding), Configuration.Encoding);
      return this;
    }

    /// <summary>
    /// Use a HTML-File (XDependency) as index.html
    /// </summary>
    /// <param name="dependencyPath">The relative dependency Path</param>
    /// <returns>IEasyWebBuilderLevel1.</returns>
    public IEasyWebBuilderLevel1 SetIndexByDependencyFile(string dependencyPath)
    {
      return SetIndexByFile(Configuration.GetDependencyPath(dependencyPath));
    }

    /// <summary>
    /// Replaces Template variables
    /// </summary>
    /// <param name="templateVars">The template vars.</param>
    /// <returns>Path to index.html</returns>
    public IEasyWebBuilderLevel1 ReplaceTemplateVars(Dictionary<string, string> templateVars)
    {
      var html = templateVars.Aggregate(FileIO.ReadText(IndexPath, Configuration.Encoding),
                             (current, x) => current.Replace(x.Key, x.Value));
      FileIO.Write(IndexPath, html, Configuration.Encoding);
      return this;
    }

    private string ExecuteScript(Selection selection, string action, string[] arguments)
    {
      var a = Configuration.GetConsoleAction(action);
      if (a == null)
        return "";

      using (var ms = new MemoryStream())
      {
        var writer = new JsonTableWriter { OutputStream = ms };
        a.Execute(selection, arguments, writer);

        return Encoding.UTF8.GetString(ms.ToArray());
      }
    }

    /// <summary>
    /// Finalizes this instance.
    /// </summary>
    /// <returns>Path to Index-File</returns>
    public string Finalize()
      => IndexPath;
  }
}
