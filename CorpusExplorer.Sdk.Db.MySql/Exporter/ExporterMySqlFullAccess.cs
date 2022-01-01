#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Db.Gui;
using CorpusExplorer.Sdk.Db.LinqConnect.Model;
using CorpusExplorer.Sdk.Db.MySql.Model.Full;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using Devart.Data.Linq;
using Corpus = CorpusExplorer.Sdk.Db.MySql.Model.Full.Corpus;
using DataContext = CorpusExplorer.Sdk.Db.MySQL.Model.DataContext;
using Layer = CorpusExplorer.Sdk.Db.MySql.Model.Full.Layer;

#endregion

namespace CorpusExplorer.Sdk.Db.MySql.Exporter
{
  public class ExporterMySqlFullAccess : AbstractExporter
  {
    public string SentenceLayerMark { get; set; } = "$.";

    private void AddAnnotations(Dictionary<Guid, int> guids, Dictionary<string, Dictionary<string, ulong>> values,
                                Selection selection, FullAccessContext context)
    {
      var tokens = new List<Token>();
      var annotations = new List<Annotation>();
      var sentences = new List<AnnotationSpan>();

      foreach (var dsel in guids)
      {
        var mdoc = selection.GetReadableMultilayerDocument(dsel.Key)
                            .ToDictionary(x => x.Key, x => x.Value.Select(y => y.ToArray()).ToArray());
        var first = mdoc.First().Value;
        var tdidx = 1; // Token im Dokument Index - wird verwendet, um Satzgrenzen zu setzen.

        for (var i = 0; i < first.Length; i++)
        {
          var s = first[i];
          var start = (ulong)tdidx;
          for (var j = 0; j < s.Length; j++)
          {
            var tidx = (ulong)tokens.Count + 1; // TokenID - Identifiziert ein Token in der DB.
            tokens.Add(new Token
            {
              ID = tidx,
              DocumentID = (uint)dsel.Value,
              TokenIndex = (uint)tdidx
            });

            foreach (var ldoc in mdoc)
              annotations.Add(new Annotation
              {
                ID = (ulong)annotations.Count + 1,
                TokenID = tidx,
                LayerValueID = (uint)values[ldoc.Key][ldoc.Value[i][j]]
              });

            tdidx++;
          }

          sentences.Add(new AnnotationSpan
          {
            ID = (ulong)sentences.Count + 1,
            LayerValueID = (uint)values[SentenceLayerMark][SentenceLayerMark],
            TokenStartID = start,
            TokenEndID = (ulong)tdidx - 1
          });
        }
      }

      context.Tokens.InsertAllOnSubmit(tokens);
      context.Annotations.InsertAllOnSubmit(annotations);
      context.AnnotationSpans.InsertAllOnSubmit(sentences);
      context.SubmitChanges(ConflictMode.ContinueOnConflict);
    }

    private static void AddCorpus(FullAccessContext context, AbstractCorpusAdapter corpus)
    {
      context.Corpora.InsertOnSubmit(new Corpus
      {
        ID = 1,
        GUID = corpus.CorpusGuid,
        Displayname = corpus.CorpusDisplayname
      });
      context.SubmitChanges(ConflictMode.ContinueOnConflict);
    }

    private static void AddCorpusMetadata(AbstractCorpusAdapter corpus, FullAccessContext context)
    {
      var metas = new List<CorpusMetadata>();
      foreach (var pair in corpus.GetCorpusMetadata())
        metas.Add(new CorpusMetadata
        {
          CorpusID = 1,
          Label = pair.Key,
          Value = pair.Value?.ToString()
        });

      context.CorpusMetadatas.InsertAllOnSubmit(metas);
      context.SubmitChanges(ConflictMode.ContinueOnConflict);
    }

    private static void AddDocumentAndDocumentMetadata(Dictionary<Guid, int> guids, Selection selection,
                                                       FullAccessContext context)
    {
      var docs = new List<Document>();
      var meta = new List<DocumentMetadata>();
      foreach (var dsel in guids)
      {
        var didx = docs.Count + 1;
        docs.Add(new Document
        {
          CorpusID = 1,
          GUID = dsel.Key,
          ID = (uint)didx
        });

        var ms = selection.GetDocumentMetadata(dsel.Key);
        foreach (var m in ms)
          meta.Add(new DocumentMetadata
          {
            DocumentID = (uint)didx,
            Label = m.Key,
            Value = m.Value?.ToString()
          });
      }

      context.Documents.InsertAllOnSubmit(docs);
      context.DocumentMetadatas.InsertAllOnSubmit(meta);
      context.SubmitChanges(ConflictMode.ContinueOnConflict);
    }

    private Dictionary<string, int> AddLayer(Selection selection, FullAccessContext context)
    {
      var res = new Dictionary<string, int>();
      var layers = new List<Layer>();
      foreach (var layer in selection.Layers)
      {
        var lidx = layers.Count + 1;

        layers.Add(new Layer
        {
          ID = (uint)lidx,
          GUID = layer.Guid,
          Displayname = layer.Displayname
        });
        var key = layer.Displayname;
        res.Add(key, lidx);
      }

      // Layer für Satzgrenzen
      var idx = layers.Count + 1;
      layers.Add(new Layer
      {
        ID = (uint)idx,
        Displayname = SentenceLayerMark,
        GUID = Guid.NewGuid()
      });
      res.Add(SentenceLayerMark, idx);

      context.Layers.InsertAllOnSubmit(layers);
      context.SubmitChanges(ConflictMode.ContinueOnConflict);

      return res;
    }

    private Dictionary<string, Dictionary<string, ulong>> AddLayerValues(
      Dictionary<string, int> layers, Selection selection, FullAccessContext context)
    {
      var res = new Dictionary<string, Dictionary<string, ulong>>();
      var values = new List<LayerValue>();
      foreach (var layer in selection.Layers)
      {
        var key = layer.Displayname;
        res.Add(key, new Dictionary<string, ulong>());

        var dict = layer.ReciveRawLayerDictionary();
        foreach (var x in dict)
        {
          var vidx = (ulong)values.Count + 1;
          res[key].Add(x.Key, vidx);
          values.Add(new LayerValue
          {
            ID = (uint)vidx,
            LayerID = (uint)layers[layer.Displayname],
            Value = x.Key
          });
        }
      }

      // Layer für Satzgrenzen
      var idx = (ulong)values.Count + 1;
      res.Add(SentenceLayerMark, new Dictionary<string, ulong> { { SentenceLayerMark, idx } });
      values.Add(new LayerValue
      {
        ID = (uint)idx,
        LayerID = (uint)layers[SentenceLayerMark],
        Value = SentenceLayerMark
      });

      context.LayerValues.InsertAllOnSubmit(values);
      context.SubmitChanges(ConflictMode.ContinueOnConflict);

      return res;
    }

    private string CreateConnectionString(DbSettingsReader setting) =>
      CreateConnectionString(setting.Host, setting.Port, setting.DbName, setting.Username, setting.Password);

    private string CreateConnectionString(string host, int port, string dbName, string user, string password) =>
      $"user id={user};password={password};host={host};port={port};database={dbName};persist security info=True";

    public override void Export(IHydra hydra, string path)
    {
      var setting = FormHelper.Show("MySQL",
                                    "localhost",
                                    3306, (host, port, dbName, user, password) =>
                                    {
                                      var cTest =
                                        new DataContext(CreateConnectionString(host, port, dbName, user, password));
                                      if (!cTest.DatabaseExists())
                                        cTest.CreateDatabase(true, true);

                                      return cTest.DatabaseExists();
                                    },
                                    "CorpusExplorer --> MySQL (*.db)|*.db",
                                    path);

      LinqConnectConfiguration.ConnectionString = CreateConnectionString(setting);

      var context = new FullAccessContext(LinqConnectConfiguration.ConnectionString);
      if (!context.DatabaseExists())
        context.CreateDatabase(true, true);

      var corpus = hydra.ToCorpus();
      var selection = corpus.ToSelection();
      var guids = new Dictionary<Guid, int>();
      foreach (var guid in selection.DocumentGuids)
        guids.Add(guid, guids.Count + 1);

      AddCorpus(context, corpus);
      AddCorpusMetadata(corpus, context);
      AddDocumentAndDocumentMetadata(guids, selection, context);
      AddAnnotations(guids, AddLayerValues(AddLayer(selection, context), selection, context), selection, context);
    }
  }
}