using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Db.LinqConnect.Builder;
using CorpusExplorer.Sdk.Db.LinqConnect.Model;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.CorpusManipulation;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using Devart.Data.Linq.Mapping.Fluent;

namespace CorpusExplorer.Sdk.Db.LinqConnect.Exporter
{
  public class SqliteExporter : AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
      LinqConnectConfiguration.ConnectionString = $"data source={path};failifmissing=False";
      hydra.ToCorpus(new CorpusBuilderLinqConnect());
    }
  }
  
  public class PostgresExporter : AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
      LinqConnectConfiguration.ConnectionString = $"data source={path};failifmissing=False";
      hydra.ToCorpus(new CorpusBuilderLinqConnect());
    }
  }
  
  public class MysqlExporter : AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
      LinqConnectConfiguration.ConnectionString = @"Host=localhost;Database=test;Persist Security Info=True";
      hydra.ToCorpus(new CorpusBuilderLinqConnect());
    }
  }
  
  public class SqlServerExporter : AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
      LinqConnectConfiguration.ConnectionString = $"data source={path};failifmissing=False";
      hydra.ToCorpus(new CorpusBuilderLinqConnect());
    }
  }
  
  public class OracleExporter : AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
      LinqConnectConfiguration.ConnectionString = $"data source={path};failifmissing=False";
      hydra.ToCorpus(new CorpusBuilderLinqConnect());
    }
  }
}
