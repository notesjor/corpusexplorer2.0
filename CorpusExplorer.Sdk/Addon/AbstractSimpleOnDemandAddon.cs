#region

using System.IO;

#endregion

namespace CorpusExplorer.Sdk.Addon
{
  public abstract class AbstractSimpleOnDemandAddon : AbstractOnDemandAddon
  {
    public abstract string FilePath { get; }

    protected override object Execute(object input)
      => FilePath;

    protected override bool ValidateInstallation()
      => File.Exists(FilePath);
  }
}