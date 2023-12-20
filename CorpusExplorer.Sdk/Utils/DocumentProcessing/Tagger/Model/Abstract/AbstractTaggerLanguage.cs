using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Model.Abstract
{
  public abstract class AbstractTaggerLanguage
  {
    public AbstractTaggerLanguage(string label, string installationPath)
    {
      Label = label;
      InstallationPath = installationPath;
    }

    public string Label { get; private set; }
    public string InstallationPath { get; private set; }

    public string Ensure()
    {
      if(!CheckInstallation())
        Install();
      return InstallationPath;
    }

    public abstract bool CheckInstallation();
    public abstract void Install();
    public abstract void Uninstall();
  }
}
