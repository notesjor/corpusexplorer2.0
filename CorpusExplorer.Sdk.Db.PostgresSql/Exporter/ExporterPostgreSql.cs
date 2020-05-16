#region

using CorpusExplorer.Sdk.Db.PostgreSql.Builder;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Db.PostgreSql.Exporter
{
  public class ExporterPostgreSql : AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
      hydra.ToCorpus(new CorpusBuilderPostgreSql {SaveSettingsPath = path});
    }
  }
}