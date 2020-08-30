#region

using CorpusExplorer.Sdk.Db.LinqConnect.Model;
using CorpusExplorer.Sdk.Db.SQLite.Builder;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Db.SQLite.Exporter
{
  public class ExporterSqlite : AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
      LinqConnectConfiguration.ConnectionString = $"data source={path};failifmissing=False";
      hydra.ToCorpus(new CorpusBuilderSqlite());
    }
  }
}