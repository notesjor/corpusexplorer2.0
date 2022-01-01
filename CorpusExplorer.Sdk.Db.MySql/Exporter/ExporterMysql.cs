#region

using CorpusExplorer.Sdk.Db.MySql.Builder;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Db.MySql.Exporter
{
  public class ExporterMysql : AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
      hydra.ToCorpus(new CorpusBuilderMySql { SaveSettingsPath = path });
    }
  }
}