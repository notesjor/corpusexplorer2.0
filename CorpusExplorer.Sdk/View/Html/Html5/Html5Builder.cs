using System.Collections.Generic;
using System.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.View.Html.Html5
{
  public class Html5Builder
  {
    private string _webserverRoot;

    public Html5Builder()
    {
      var target = Path.Combine(Configuration.TempPath, "d3webserver");
      try
      {
        if (Directory.Exists(target))
          Directory.Delete(target, true);
      }
      catch
      {
        // ignore
      }

      try
      {
        Directory.CreateDirectory(target);
      }
      catch
      {
        // ignore
      }

      try
      {
        CopyDirectoryHelper.Copy(Configuration.GetDependencyPath(@"d3skeleton"), target, true);
      }
      catch
      {
        // ignore
      }
    }

    public string WebserverIndexPath => Path.Combine(WebserverRoot, "index.html");

    public string WebserverIndexUrl => WebserverIndexPath.Replace("\\", "/").Replace(@"\", "/");

    public string WebserverRoot
    {
      get => _webserverRoot ?? (_webserverRoot = Path.Combine(Configuration.TempPath, "d3webserver"));
      set => _webserverRoot = value;
    }

    public void Execute(
      string htmlTemplatePath,
      Dictionary<string, string> templateVars)
    {
      TemplateTextGenerator.GenerateFromFileToFile(htmlTemplatePath, WebserverIndexPath, templateVars,
        Configuration.Encoding);
    }

    public void Export(string path)
    {
      ZipHelper.Compress(WebserverRoot, path);
    }
  }
}