using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  public class ValidateSelectionIntegrityBlock : AbstractBlock
  {
    private readonly object _lockInvalidCorpusGuids = new object();
    private readonly object _lockInvalidDocumentGuids = new object();
    private readonly object _lockValidDocumentGuids = new object();
    private readonly object _lockLayerTokensContainsSpace = new object();

    public HashSet<Guid> EmptyDocumentGuids { get; private set; }
    public HashSet<Guid> NoLayerMatchingDocumentGuids { get; private set; }
    public HashSet<Guid> SentenceErrorDocumentGuids { get; private set; }
    public HashSet<Guid> LayerTokensContainsSpace { get; private set; }

    public HashSet<Guid> InvalidCorpusGuids { get; private set; }
    public HashSet<Guid> ValidDocumentGuids { get; private set; }

    public bool HasError { get; private set; }

    public override void Calculate()
    {
      EmptyDocumentGuids = new HashSet<Guid>();
      NoLayerMatchingDocumentGuids = new HashSet<Guid>();
      SentenceErrorDocumentGuids = new HashSet<Guid>();
      LayerTokensContainsSpace = new HashSet<Guid>();

      InvalidCorpusGuids = new HashSet<Guid>();
      ValidDocumentGuids = new HashSet<Guid>();

      Parallel.ForEach(Selection, csel =>
      {
        var corpus = Selection.GetCorpus(csel.Key);
        if (corpus == null)
          return;

        if (corpus.CountDocuments < 1 || corpus.CountToken < 1 || corpus.Layers == null || !corpus.Layers.Any())
        {
          lock (_lockInvalidCorpusGuids)
            InvalidCorpusGuids.Add(corpus.CorpusGuid);

          return;
        }

        var layers = new List<AbstractLayerAdapter>(corpus.Layers);
        Parallel.ForEach(layers, layer =>
        {
          if (layer.Values.Any(v => v.Contains(' ')))
            lock (_lockLayerTokensContainsSpace)
              LayerTokensContainsSpace.Add(layer.Guid);
        });

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

            var slen = new int[doc.Length];
            for (int i = 0; i < doc.Length; i++)
            {
              if (doc[i].Length > 500) // Dokument ohne Satzerkennung
              {
                lock (_lockInvalidDocumentGuids)
                  SentenceErrorDocumentGuids.Add(dsel);

                return;
              }

              slen[i] = doc[i].Length;
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

              if (docC.Length != slen.Length) // Dokument mit ungleicher Satzlänge
              {
                lock (_lockInvalidDocumentGuids)
                  NoLayerMatchingDocumentGuids.Add(dsel);

                return;
              }

              for (var i = 0; i < docC.Length; i++)
                if (slen[i] != docC[i].Length) // Dokumente mit unterschiedlicher Wortanzahl
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

      HasError = ValidDocumentGuids.Count < Selection.CountDocuments || InvalidCorpusGuids.Count > 0;
    }
  }
}