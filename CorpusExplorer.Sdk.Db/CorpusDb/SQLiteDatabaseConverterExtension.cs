using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Db.CorpusDb
{
  public static class SQLiteDatabaseConverterExtension
  {
    public static void ToSQLiteDatabase(Model.Corpus corpus, string outputPath)
    {
      if (corpus == null || string.IsNullOrEmpty(outputPath)) return;

      var dir = Path.GetDirectoryName(outputPath);
      if (dir != null && !Directory.Exists(dir))
        Directory.CreateDirectory(dir);

      File.Copy(Configuration.GetRelativAppFilePath("CorpusDb/corpusPrototype.s3db"), outputPath, true);

      var context = new CorpusExplorerModel("Data Source=" + outputPath);

      // Erzeuge neues dbCorpus
      var dbCorpus = new Corpus {Name = corpus.Displayname};
      context.Add(dbCorpus);
      context.SaveChanges();

      foreach (var meta in corpus.Metadata)
      {
        context.Add(new CorpusMetadata
                    {
                      Corpus = dbCorpus,
                      CorpusId = dbCorpus.Id,
                      Name = meta.Key,
                      Value = meta.Value.ToString()
                    });
      }
      context.SaveChanges();

      // Zwischenspeicher für bereits erstellte dbDokumenten
      // Wird ab dem zweiten dbLayer dazu verwendet bereits erstellte dbDokumente wiederzufinden
      var docs = new Dictionary<Guid, Document>();

      foreach (var layer in corpus.Layers)
      {
        // Erstelle neuen dbLayer
        var dbLayer = new Layer {Corpus = dbCorpus, Name = layer.Displayname};
        context.Add(dbLayer);

        // Befülle dbLayer mit Index/Werten
        var values = layer.Values.ToArray();
        var vcache = new List<LayerIndex>();
        for (var i = 0; i < values.Length; i++)
        {
          var item = new LayerIndex
                     {
                       Layer = dbLayer,
                       LayerId = dbLayer.Id,
                       Value = values[i],
                       Index = (ulong) i
                     };
          vcache.Add(item);
          context.Add(item);
        }
        context.SaveChanges();

        // Index der zur ermittlung der noch nicht persitierten dbDocuments verwendet wird.
        var idx = 0;

        // Befülle Layer mit Dokumenten
        foreach (var doc in layer)
        {
          Document dbDoc;
          if (docs.ContainsKey(doc.Key)) // Wenn dbDokument bereits exsistiert verwende es erneut.
            dbDoc = docs[doc.Key];
          else // Ansonsten erzeuge neues dbDokument
          {
            dbDoc = new Document {Corpus = dbCorpus, Name = doc.Key.ToString("N")};
            context.Add(dbDoc);
            docs.Add(doc.Key, dbDoc);

            var metas = corpus.GetDocumentMetadata(doc.Key);
            foreach (var meta in metas)
            {
              context.Add(
                          new DocumentMetadata
                          {
                            Document = dbDoc,
                            DocumentId = dbDoc.Id,
                            Name = meta.Key,
                            Value = meta.Value.ToString()
                          });
            }
          }

          idx++;
          if (idx >= 100)
          {
            context.SaveChanges();
            idx = 0;
          }

          // Der Architekt hat das Wort
          for (var i = 0; i < doc.Value.Length; i++)
          {
            var sentence = doc.Value[i];
            for (var j = 0; j < sentence.Length; j++)
            {
              var word = sentence[j];
              var w = vcache[word];
              context.Add(
                          new DocumentLayerIndex
                          {
                            Document = dbDoc,
                            DocumentId = dbDoc.Id,
                            Layer = dbLayer,
                            LayerId = dbLayer.Id,
                            LayerIndex = w,
                            LayerIndexIdx = w.Index,
                            SentenceIdx = i,
                            WordIdx = j
                          });
            }
          }
        }

        context.SaveChanges();
      }
      context.SaveChanges();
    }
  }
}