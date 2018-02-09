using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model;
using CorpusExplorer.Sdk.Extern.Xml.Weblicht.Serializer;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht
{
  public class ImporterWeblicht : AbstractImporterSimple3Steps<DSpin>
  {
    /// <summary>
    ///   Auflistung von Layern die durch diesen Importer bedient werden.
    /// </summary>
    /// <value>The layer names.</value>
    protected override IEnumerable<string> LayerNames => new[] {"Wort", "Lemma", "POS", "NER", "Orthografie"};

    private void BuildLayerDocument(
      string layerDisplayname,
      Guid documentGuid,
      ref string[][] token,
      Dictionary<string, string> dictionary)
    {
      var doc =
        token.Select(s => s.Select(t => dictionary.ContainsKey(t) ? dictionary[t] : string.Empty).ToArray()).ToArray();
      AddDocumet(layerDisplayname, documentGuid, ConvertToLayer(layerDisplayname, doc));
    }

    private string[][] GetSentenceStructure(DSpin dspin)
    {
      return
        dspin.TextCorpus.sentences.Select(
               sentence =>
                   sentence.tokenIDs.Split(new[] {" ", "\t", "\r\n", "\r", "\n"}, StringSplitOptions.RemoveEmptyEntries))
             .ToArray();
    }

    /// <summary>
    ///   Erster Importschritt - ließt die Datei ein und gibt (ein) entsprechend(es) Objekt(e) zurück.
    /// </summary>
    /// <param name="path">Dateipfad</param>
    /// <returns>Gibt (ein) Objekt(e) zurück die dem Korpus entsprechen.</returns>
    protected override DSpin ImportStep_1_ReadFile(string path)
    {
      var serializer = new WeblichtSerializer();
      return serializer.Deserialize(path);
    }

    /// <summary>
    ///   Zweiter Importschritt - lese alle verfügbaren Metadaten ein (Korpus/Dokumente/Layer).
    ///   Die Ergebnisse sollten in CorpusMetadata sowie DocumentMetadata geschrieben werden.
    /// </summary>
    /// <param name="documentGuid">Vorgeschlagener documentGUID</param>
    /// <param name="data">Datenobjekt</param>
    protected override void ImportStep_2_ImportMetadata(Guid documentGuid, ref DSpin data)
    {
      AddDocumentMetadata(documentGuid, new Dictionary<string, object>());
    }

    /// <summary>
    ///   Dritter Importschritt - lese alle verfügbaren Dokumente und dazugehörigen Layer ein.
    ///   Die Ergebnisse sollten in LayerDocuments sowie LayersDictionaries geschrieben werden.
    ///   Dokumente sollten mit DocumentMetadata abgeglichen werden.
    /// </summary>
    /// <param name="documentGuid">Vorgeschlagener documentGUID</param>
    /// <param name="data">Datenobjekt</param>
    protected override void ImportStep_3_ImportContent(Guid documentGuid, ref DSpin data)
    {
      // Ermittle die Struktur (Tokens) des Dokuments
      var token = GetSentenceStructure(data);

      // TokenID -> Wert - Zuordnung ermitteln

      // Wort (immer vorhanden)
      var wort = data.TextCorpus.tokens.ToDictionary(t => t.ID, t => t.Value);
      BuildLayerDocument("Wort", documentGuid, ref token, wort);

      // Lemma (nur vorhanden, wenn lemmatisiert)
      try
      {
        var lemma = data.TextCorpus.lemmas.ToDictionary(l => l.tokenIDs, l => l.Value);
        BuildLayerDocument("Lemma", documentGuid, ref token, lemma);
      }
      catch {}

      // POS (nur vorhanden, wenn POS-Tagger)
      try
      {
        var pos = data.TextCorpus.POStags.tag.ToDictionary(p => p.tokenIDs, p => p.Value);
        BuildLayerDocument("POS", documentGuid, ref token, pos);
      }
      catch {}

      // Orthografie (nur vorhanden, wenn Orthografie)
      try
      {
        var ortho = data.TextCorpus.orthography.ToDictionary(p => p.tokenIDs, p => p.Value);
        BuildLayerDocument("Orthografie", documentGuid, ref token, ortho);
      }
      catch {}

      // NER (Nur vorhanden, wen NER eingesetzt)
      try
      {
        var ner = new Dictionary<string, string>();
        // (Mehrere TokenIDs können einem Wert zugeordnet werden.)
        foreach (var n in data.TextCorpus.namedEntities.entity)
          if (n.tokenIDs.Contains(" "))
          {
            var tokens = n.tokenIDs.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var t in tokens)
              ner.Add(t, n.@class);
          }
          else
          {
            ner.Add(n.tokenIDs, n.@class);
          }

        BuildLayerDocument("NER", documentGuid, ref token, ner);
      }
      catch {}
    }
  }
}