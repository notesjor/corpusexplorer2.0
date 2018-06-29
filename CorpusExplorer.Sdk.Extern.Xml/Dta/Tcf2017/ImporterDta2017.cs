using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model;
using CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Serializer;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017
{
  public class ImporterDta2017 : AbstractImporterSimple3Steps<DSpin>
  {
    /// <summary>
    ///   Auflistung von Layern die durch diesen Importer bedient werden.
    /// </summary>
    /// <value>The layer names.</value>
    protected override IEnumerable<string> LayerNames => new[] {"Wort", "Lemma", "POS", "NER", "Orthografie"};

    /// <summary>
    ///   Erster Importschritt - ließt die Datei ein und gibt (ein) entsprechend(es) Objekt(e) zurück.
    /// </summary>
    /// <param name="path">Dateipfad</param>
    /// <returns>Gibt (ein) Objekt(e) zurück die dem Korpus entsprechen.</returns>
    protected override DSpin ImportStep_1_ReadFile(string path)
    {
      var serializer = new Dta2017Serializer();
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

      var cmd = data?.MetaData?.source1?.CMD1;

      if (cmd != null)
        res.Add("URL", SafeGetMetadata(() => cmd.Header.MdSelfLink));

      var tei = cmd?.Components?.teiHeader1;

      var prof = tei?.profileDesc;
      if (prof != null)
      {
        res.Add("Sprache", prof.langUsage?.language1?.ident ?? "");
        var dwdsMain = (from x in prof.textClass where x.scheme.EndsWith("dwds1main") select x.Text).FirstOrDefault();
        res.Add("DWDS-Hauptkategorie", dwdsMain == null ? "" : string.Join(" ", dwdsMain));
        var dwdsSub = (from x in prof.textClass where x.scheme.EndsWith("dwds1sub") select x.Text).FirstOrDefault();
        res.Add("DWDS-Unterkategorie", dwdsSub == null ? "" : string.Join(" ", dwdsSub));
        var dtaMain = (from x in prof.textClass where x.scheme.EndsWith("dtamain") select x.Text).FirstOrDefault();
        res.Add("DTA-Hauptkategorie", dtaMain == null ? "" : string.Join(" ", dtaMain));
        var dtaSub = (from x in prof.textClass where x.scheme.EndsWith("dtasub") select x.Text).FirstOrDefault();
        res.Add("DTA-Unterkategorie", dtaSub == null ? "" : string.Join(" ", dtaSub));
      }

      var head = tei?.fileDesc;

      var title = head?.titleStmt;
      if (title != null)
      {
        var tMain = (from x in title.title where x.type == "main" select x.Text).FirstOrDefault();
        res.Add("Titel", tMain == null ? "" : string.Join(" ", tMain));
        var tSub = (from x in title.title where x.type == "sub" select x.Text).FirstOrDefault();
        res.Add("Untertitel", tSub == null ? "" : string.Join(" ", tSub));

        var author = title.author?.persName;
        var aurl = author?.idno?.idno1?.FirstOrDefault()?.Text;
        res.Add("Autor (URL)", aurl == null ? "" : string.Join(" ", aurl));
        res.Add("Autor",
          string.IsNullOrEmpty(author?.surname) ? author?.forename :
          string.IsNullOrEmpty(author?.forename) ? author?.surname : $"{author.surname}, {author.forename}");
        Add(title.editor, ref res);
      }

      var bibl = head?.sourceDesc?.biblFull;
      if (bibl != null)
      {
        res.Add("Ausgabe", bibl.editionStmt?.edition1?.n ?? "0");
        res.Add("Jahr",
          bibl.publicationStmt?.date?.Text == null ? "" : string.Join(" ", bibl.publicationStmt?.date?.Text));
        res.Add("Verlagsort",
          bibl.publicationStmt?.pubPlace == null ? "" : string.Join(" ", bibl.publicationStmt?.pubPlace));
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
      var wort = data.TextCorpus.tokens.ToDictionary(t => t.ID, t => string.Join(" ", t.Text));
      BuildLayerDocument("Wort", documentGuid, ref token, wort);

      // Lemma (nur vorhanden, wenn lemmatisiert)
      try
      {
        var lemma = data.TextCorpus.lemmas.ToDictionary(l => l.tokenIDs, l => string.Join(" ", l.Text));
        BuildLayerDocument("Lemma", documentGuid, ref token, lemma);
      }
      catch
      {
      }

      // POS (nur vorhanden, wenn POS-Tagger)
      try
      {
        var pos = data.TextCorpus.POStags.tag.ToDictionary(p => p.tokenIDs, p => string.Join(" ", p.Text));
        BuildLayerDocument("POS", documentGuid, ref token, pos);
      }
      catch
      {
      }

      // Orthografie (nur vorhanden, wenn Orthografie)
      try
      {
        var ortho = data.TextCorpus.orthography.ToDictionary(p => p.tokenIDs, p => string.Join(" ", p.Text));
        BuildLayerDocument("Orthografie", documentGuid, ref token, ortho);
      }
      catch
      {
      }
    }

    private void Add(editor[] editors, ref Dictionary<string, object> res)
    {
      try
      {
        var names = new List<string>();
        var idnos = new List<string>();
        foreach (var editor in editors)
        {
          var sname = editor?.persName?.surname ?? "";
          var fname = editor?.persName?.forename ?? "";

          names.Add($"{sname}, {fname}");

          var idno = editor?.persName?.idno?.idno1?.FirstOrDefault()?.Text;
          idnos.Add(idno == null ? "" : string.Join(" ", idno));
        }

        Add("Editor", "Editoren", names, ref res);
        Add("Editor (IDNO)", "Editoren (IDNO)", idnos, ref res);
      }
      catch
      {
        // ignore
      }
    }

    private void Add(string labelSingle, string labelMulti, IEnumerable<string> items,
      ref Dictionary<string, object> res)
    {
      var order = items.OrderBy(x => x).ToArray();
      res.Add(labelMulti, string.Join("; ", order));

      for (int i = 0; i < order.Length; i++)
        res.Add($"{labelSingle} ({i + 1:D2})", order[i]);
    }

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