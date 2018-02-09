using CorpusExplorer.Sdk.Db.MySql.Builder;
using CorpusExplorer.Sdk.Model.Export.Abstract;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Model.Interface;

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
