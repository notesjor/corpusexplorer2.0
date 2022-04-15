using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;
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

    public IEasyWebBuilderLevel1 ReplaceScript(Selection selection)
    {
      var done = new HashSet<string>();
      var html = FileIO.ReadText(IndexPath, Configuration.Encoding);
      var first = 0;

      while (first > -1)
      {
        var last = html.IndexOf(End, first);
        if (last == -1)
          break;

        var key = html.Substring(first, last - first + End.Length);
        var cnt = key.Substring(Start.Length, key.Length - Start.Length - End.Length);

        if (!done.Contains(key))
        {
          var lines = cnt.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
          var result = string.Empty;
          foreach (var line in lines)
            result = ExecuteScript(line, selection);

          done.Add(key);
        }

        first = html.IndexOf(Start, last + 1);
      }

      return this;
    }

    private string ExecuteScript(string command, Selection selection)
    {
      throw new NotImplementedException();
      /*
      var process = new Process
      {
        StartInfo =
        {
          FileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "cec.exe"),
          Arguments = task.StartsWith("F:") ? task : $"F:JSON {task}",
          CreateNoWindow = true,
          UseShellExecute = false,
          StandardOutputEncoding = Configuration.Encoding,
          RedirectStandardOutput = true,
          WindowStyle = ProcessWindowStyle.Hidden
        }
      };

      process.Start();

      var res = process.StandardOutput.ReadToEnd();
      process.WaitForExit();

      return res;
      */
    }

    /// <summary>
    /// Finalizes this instance.
    /// </summary>
    /// <returns>Path to Index-File</returns>
    public string Finalize()
      => IndexPath;

    private const string End = "*/";
    private const string Start = "/*CEC";
  }
}
