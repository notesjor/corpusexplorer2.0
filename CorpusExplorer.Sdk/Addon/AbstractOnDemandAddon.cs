using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;

namespace CorpusExplorer.Sdk.Addon
{
  public abstract class AbstractOnDemandAddon
  {
    public abstract string Displayname { get; }

    public abstract string Url { get; }

    public object Call(object input)
    {
      if (!ValidateInstallation())
        RunInstallation();
      if (!ValidateInstallation())
        throw new FileNotFoundException($"Can't install OnDemandAddon {GetType().FullName}");
      return Execute(input);
    }

    protected abstract object Execute(object input);

    protected abstract bool ValidateInstallation();

    private void RunInstallation()
    {
      var tempDir = Path.Combine(Path.GetTempPath(), "CorpusExplorer");
      var i = 0;
      var tempFile = Path.Combine(tempDir, "ondemand." + i++ + ".zip");
      while (File.Exists(tempFile))
        tempFile = Path.Combine(tempDir, "ondemand." + i++ + ".zip");

      using (var wc = new CorpusExplorerWebClient())
        wc.DownloadFile(Url, tempFile);

      var appPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"CorpusExplorer\App");
      if (!Directory.Exists(appPath))
        appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

      var zip = new FastZip();
      zip.ExtractZip(tempFile, appPath, null);
    }

    private class CorpusExplorerWebClient : WebClient
    {
      protected override WebRequest GetWebRequest(Uri uri)
      {
        var res = base.GetWebRequest(uri);
        if (res != null)
          res.Timeout = 30 * 60 * 1000;
        return res;
      }
    }
  }
}
