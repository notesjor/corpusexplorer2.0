using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Model.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Model
{
  public class TaggerLanguageByZipFile : AbstractTaggerLanguage
  {
    public TaggerLanguageByZipFile(string label, string installationPath, string pathExists, string url)
      : base(label, installationPath)
    {
      PathExists = pathExists;
      Url = url;
    }

    public string PathExists { get; private set; }

    public string Url { get; private set; }

    public override bool CheckInstallation()
    {
      return File.Exists(PathExists);
    }

    public override void Install()
    {
      var tempDir = Path.Combine(Path.GetTempPath(), "CorpusExplorer");
      if (!Directory.Exists(tempDir))
        Directory.CreateDirectory(tempDir);

      var tempFile = Path.Combine(tempDir, "language.zip");

      using (var wc = new CorpusExplorerWebClient())
        wc.DownloadFile(Url, tempFile);

      ZipHelper.Uncompress(tempFile, InstallationPath);

      try
      {
        Directory.Delete(tempDir, true);
      }
      catch
      {
        // ignore
      }
    }

    public override void Uninstall()
    {
      var tempDir = Path.Combine(Path.GetTempPath(), "CorpusExplorer");
      if (!Directory.Exists(tempDir))
        Directory.CreateDirectory(tempDir);

      var tempFile = Path.Combine(tempDir, "language.zip");

      using (var wc = new CorpusExplorerWebClient())
        wc.DownloadFile(Url, tempFile);

      var files = ZipHelper.GetRelativeZipEntryPath(tempDir);
      foreach (var file in files)
      {
        try
        {
          File.Delete(Path.Combine(InstallationPath, file));
        }
        catch
        {
          // ignore
        }
      }

      try
      {
        Directory.Delete(tempDir, true);
      }
      catch
      {
        // ignore
      }
    }
  }
}
