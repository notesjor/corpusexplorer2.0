using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Db.Abstract;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.Db.CollocationDb
{
  public class CollocationDatabaseBuilder : AbstractDatabaseBuilder<CooccurrenceBlock>
  {
    public string LayerDisplayname { get; set; }

    protected override CooccurrenceBlock InitializeBlock(Selection selection)
    {
      var block = selection.CreateBlock<CooccurrenceBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.Calculate();

      return block;
    }

    protected override void MapBlockToDatabase(CooccurrenceBlock block, string connectionString)
    {
      var db = new EntitiesModel(connectionString);

      foreach (var t in block.CooccurrenceFrequency)
      {
        var dbT = (from x in db.Terms where x.Value == t.Key select x).FirstOrDefault();
        if (dbT == null)
        {
          dbT = new Term {Value = t.Key};
          db.Add(dbT);
          db.SaveChanges();
        }

        foreach (var c in t.Value)
        {
          var dbC = (from x in db.Terms where x.Value == c.Key select x).FirstOrDefault();
          if (dbC == null)
          {
            dbC = new Term {Value = t.Key};
            db.Add(dbC);
            db.SaveChanges();
          }

          var rel = new TermRelation {Frequency = (uint) c.Value};
          dbT.TermRelations.Add(rel);
          dbC.TermRelations.Add(rel);
          db.Add(rel);
        }
      }

      db.SaveChanges();
    }
  }
}