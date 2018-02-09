using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model;
using CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Serializer;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf
{
  public class ImporterDta : AbstractImporterSimple3Steps<DSpin>
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
      var serializer = new DtaSerializer();
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
      var res = new Dictionary<string, object>();
      
      var cmd = data?.MetaData?.source?.CMD;

      if(cmd != null)
        res.Add("URL", SafeGetMetadata(() => cmd.Header.MdSelfLink));

      var tei = cmd?.Components?.teiHeader;

      var prof = tei?.profileDesc;
      if (prof != null)
      {
        res.Add("Sprache", prof.langUsage?.language?.Value ?? "");
        var dwdsMain = (from x in prof.textClass where x.scheme.EndsWith("dwds1main") select x.Value).FirstOrDefault();
        res.Add("DWDS-Hauptkategorie", dwdsMain ?? "");
        var dwdsSub = (from x in prof.textClass where x.scheme.EndsWith("dwds1sub") select x.Value).FirstOrDefault();
        res.Add("DWDS-Unterkategorie", dwdsSub ?? "");
      }

      var head = tei?.fileDesc;

      var title = head?.titleStmt;
      if (title != null)
      {
        res.Add("Titel", (from x in title.title where x.type == "main" select x.Value).FirstOrDefault());
        var author = title.author?.persName;
        res.Add("Autor (URL)", author?.idno?.idno?.Value);
        res.Add(
          "Autor",
          string.IsNullOrEmpty(author?.surname)
            ? author?.forename
            : string.IsNullOrEmpty(author?.forename) ? author?.surname : $"{author.surname}, {author.forename}");
      }

      var bibl = head?.sourceDesc?.biblFull;
      if (bibl != null)
      {
        res.Add("Ausgabe", bibl.editionStmt?.edition?.n ?? 0);
        res.Add("Verleger", bibl.publicationStmt?.publisher?.name ?? "");
        res.Add("Jahr", bibl.publicationStmt?.date?.Value ?? -1);
        res.Add("Verlagsort", bibl.publicationStmt?.pubPlace ?? "");
      }

      AddDocumentMetadata(documentGuid, res);
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
    }

    private string SafeGetMetadata(Func<string> func)
    {
      try
      {
        return func();
      }
      catch
      {
        return "";
      }
    }
  }
}