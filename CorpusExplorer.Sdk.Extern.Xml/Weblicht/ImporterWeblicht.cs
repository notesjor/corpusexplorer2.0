using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht
{
  public class ImporterWeblicht : AbstractImporterSimple3Steps<DSpin>
  {
    /// <summary>
    ///   Erster Importschritt - ließt die Datei ein und gibt (ein) entsprechend(es) Objekt(e) zurück.
    /// </summary>
    /// <param name="path">Dateipfad</param>
    /// <returns>Gibt (ein) Objekt(e) zurück die dem Korpus entsprechen.</returns>
    protected override DSpin ImportStep_1_ReadFile(string path)
    {
      return XmlSerializerHelper.Deserialize<DSpin>(path);
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
      var wort = data.TextCorpus.tokens.ToDictionary(t => t.ID, t => t.Text);
      BuildLayerDocument("Wort", documentGuid, ref token, wort);

      // Lemma (nur vorhanden, wenn lemmatisiert)
      try
      {
        var lemma = data.TextCorpus.lemmas.ToDictionary(l => l.tokenIDs, l => l.Text);
        BuildLayerDocument("Lemma", documentGuid, ref token, lemma);
      }
      catch
      {
      }

      // POS (nur vorhanden, wenn POS-Tagger)
      try
      {
        var pos = data.TextCorpus.POStags.tag.ToDictionary(p => p.tokenIDs, p => p.Text);
        BuildLayerDocument("POS", documentGuid, ref token, pos);
      }
      catch
      {
      }
    }

    private void BuildLayerDocument(
      string layerDisplayname,
      Guid documentGuid,
      ref string[][] token,
      Dictionary<string, string> dictionary)
    {
      var doc =
        token.Select(s => s.Select(t => dictionary.ContainsKey(t) ? dictionary[t] : string.Empty).ToArray()).ToArray();
      AddDocument(layerDisplayname, documentGuid, ConvertToLayer(layerDisplayname, doc));
    }

    private string[][] GetSentenceStructure(DSpin dspin)
    {
      return
        dspin.TextCorpus.sentences.Select(
            sentence =>
              sentence.tokenIDs.Split(new[] { " ", "\t", "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries))
          .ToArray();
    }
  }
}