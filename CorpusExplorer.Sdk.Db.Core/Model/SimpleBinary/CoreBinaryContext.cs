﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Dieser Code wurde aus einer Vorlage generiert.
//
//    Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten Ihrer Anwendung.
//    Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Data.Common;
using System.Data.Entity;

namespace CorpusExplorer.Sdk.Db.Core.Model.SimpleBinary
{
  public partial class CoreBinaryContext : DbContext
  {
    internal CoreBinaryContext(string connectionString = "name=CoreContext")
            : base(connectionString)
    {
      Database.SetInitializer(new CreateDatabaseIfNotExists<CoreBinaryContext>());
    }

    internal CoreBinaryContext(DbConnection connection) : base(connection, true)
    {
      Database.SetInitializer(new CreateDatabaseIfNotExists<CoreBinaryContext>());
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }

    public DbSet<Corpus> CorpusSet { get; set; }
    public DbSet<Layer> LayerSet { get; set; }
    public DbSet<LayerDocument> LayerDocumentSet { get; set; }
    public DbSet<Document> DocumentSet { get; set; }
  }
}