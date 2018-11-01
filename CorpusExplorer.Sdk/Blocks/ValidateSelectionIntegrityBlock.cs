using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  public class ValidateSelectionIntegrityBlock : AbstractBlock
  {
    private object _lockValidDocumentGuids = new object();
    private object _lockInvalidDocumentGuids = new object();
    private object _lockInvalidCorpusGuids = new object();
    public HashSet<Guid> EmptyDocumentGuids { get; private set; }
    public HashSet<Guid> NoLayerMatchingDocumentGuids { get; private set; }
    public HashSet<Guid> SentenceErrorDocumentGuids { get; private set; }
    public HashSet<Guid> InvalidCorpusGuids { get; private set; }
    public HashSet<Guid> ValidDocumentGuids { get; private set; }
    public bool HasError => InvalidCorpusGuids?.Count > 0 || EmptyDocumentGuids?.Count > 0 || NoLayerMatchingDocumentGuids?.Count > 0 || SentenceErrorDocumentGuids?.Count > 0;

    public override void Calculate()
    {
      EmptyDocumentGuids = new HashSet<Guid>();
      NoLayerMatchingDocumentGuids = new HashSet<Guid>();
      SentenceErrorDocumentGuids = new HashSet<Guid>();
      InvalidCorpusGuids = new HashSet<Guid>();
      ValidDocumentGuids = new HashSet<Guid>();

      Parallel.ForEach(Selection, csel =>
      {
        var corpus = Selection.GetCorpus(csel.Key);
        if (corpus == null)
          return;

        if (corpus.CountDocuments == 0 || corpus.Layers == null || !corpus.Layers.Any())
        {
          lock (_lockInvalidCorpusGuids)
            InvalidCorpusGuids.Add(corpus.CorpusGuid);
          return;
        }

        var layers = new List<AbstractLayerAdapter>(corpus.Layers);
        var firstL = layers.FirstOrDefault();
        if (firstL == null)
        {
          lock (_lockInvalidCorpusGuids)
            InvalidCorpusGuids.Add(corpus.CorpusGuid);
          return;
        }
        layers.Remove(firstL);

        Parallel.ForEach(csel.Value, dsel =>
        {
          try
          {
            if (!firstL.ContainsDocument(dsel)) // Dokument nicht vorhanden
            {
              lock (_lockInvalidDocumentGuids)
                EmptyDocumentGuids.Add(dsel);
              return;
            }

            var doc = firstL[dsel];
            if (doc.Length == 0) // Dokument ist leer (keine Sätze)
            {
              lock (_lockInvalidDocumentGuids)
                EmptyDocumentGuids.Add(dsel);
              return;
            }

            var slen = new List<int>();
            foreach (var s in doc)
            {
              if (s.Length > 500) // Dokument ohne Satzerkennung
              {
                lock (_lockInvalidDocumentGuids)
                  SentenceErrorDocumentGuids.Add(dsel);
                return;
              }

              slen.Add(s.Length);
            }            

            foreach (var layer in layers) // Vergleiche das Dokument mit dem ersten (first) Layer mit allen anderen
            {
              if (!layer.ContainsDocument(dsel)) // Dokument nicht vorhanden
              {
                lock (_lockInvalidDocumentGuids)
                  NoLayerMatchingDocumentGuids.Add(dsel);
                return;
              }

              var docC = layer[dsel];
              if (docC.Length == 0) // Dokument ist leer (keine Sätze)
              {
                lock (_lockInvalidDocumentGuids)
                  NoLayerMatchingDocumentGuids.Add(dsel);
                return;
              }

              if (docC.Length != slen.Count) // Dokument mit ungleicher Satzlänge
              {
                lock (_lockInvalidDocumentGuids)
                  NoLayerMatchingDocumentGuids.Add(dsel);
                return;
              }

              for (int i = 0; i < docC.Length; i++)
                if (slen[i] != doc[i].Length) // Dokumente mit unterschiedlicher Wortanzahl
                {
                  lock (_lockInvalidDocumentGuids)
                    NoLayerMatchingDocumentGuids.Add(dsel);
                  return;
                }
            }

            lock (_lockValidDocumentGuids)
              ValidDocumentGuids.Add(dsel);
          }
          catch (Exception ex)
          {
            InMemoryErrorConsole.Log(ex);
          }
        });
      });
    }
  }
}
