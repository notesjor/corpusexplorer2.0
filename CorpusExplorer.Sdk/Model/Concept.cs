using CorpusExplorer.Sdk.Properties;

#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Model.CorpusExplorer;

#endregion

namespace CorpusExplorer.Sdk.Model
{
  [Serializable]
  public class Concept : CeObject
  {
    private readonly List<Tuple<Guid, Guid>> _documentMarks = new List<Tuple<Guid, Guid>>();
    private readonly List<Tuple<Guid, Guid, Guid, object>> _links = new List<Tuple<Guid, Guid, Guid, object>>();
    private readonly List<Tuple<Guid, int[], object>> _marks = new List<Tuple<Guid, int[], object>>();

    /// <summary>
    ///   Gibt eine Auflistung aller Dokumente (documentsGuids) zurück, zu denen in diesem Konzept Informationen hinterlegt
    ///   sind.
    /// </summary>
    public IEnumerable<Guid> AvailabelAnnotationsForDocumentGuids
    {
      get { return _documentMarks.Select(x => x.Item1); }
    }

    /// <summary>
    ///   Erstellt einen neuen Link und gibt dessen linkGuid zurück
    /// </summary>
    /// <param name="guidMarkOrLinkStart">Guid der Start-Markierung oder des Start-Links (für Hierarchien)</param>
    /// <param name="guidMarkOrLinkStop">Guid der Ziel-Markierung oder des Stop-Links (für Hierarchien)</param>
    /// <param name="metadata">Metadaten die für diesen Link hinterlegt werden</param>
    /// <returns>linkGuid des neuen Links</returns>
    public Guid AddLink(Guid guidMarkOrLinkStart, Guid guidMarkOrLinkStop, object metadata = null)
    {
      var res = Guid.NewGuid();
      _links.Add(new Tuple<Guid, Guid, Guid, object>(res, guidMarkOrLinkStart, guidMarkOrLinkStop, metadata));
      return res;
    }

    /// <summary>
    ///   Erstellt eine neue Dokument-Marke und gibt deren GUID zurück.
    /// </summary>
    /// <param name="documenentGuid">Guid des Dokuments für das eine Marke erstellt werden soll.</param>
    /// <param name="sentenceStartIndex">Start Satz (nullbasierter Index)</param>
    /// <param name="wordStartIndex">Start Wort (nullbasierter Index)</param>
    /// <param name="sentenceStopIndex">
    ///   Stop Satz (nullbasierter Index) - Wenn -1 dann ist die Markierung nur ein Wort lang
    ///   gültig.
    /// </param>
    /// <param name="wordStopIndex">Stop Wort (nullbasierter Index) - Wenn -1 dann ist die Markierung nur ein Wort lang gültig.</param>
    /// <param name="metaData">Metadaten die hinterlegt werden</param>
    /// <returns>Guid der Marke</returns>
    public Guid AddMark(
      Guid documenentGuid,
      int sentenceStartIndex,
      int wordStartIndex,
      int sentenceStopIndex = -1,
      int wordStopIndex = -1,
      object metaData = null)
    {
      if (sentenceStopIndex == -1 ||
          wordStopIndex     == -1)
        if (sentenceStopIndex != wordStopIndex)
          throw new ArgumentException(
                                      Resources.ConceptRangeException);

      var res = Guid.NewGuid();
      _marks.Add(
                 new Tuple<Guid, int[], object>(
                                                res,
                                                sentenceStopIndex > -1
                                                  ? new[]
                                                  {
                                                    sentenceStartIndex, wordStartIndex, sentenceStopIndex, wordStopIndex
                                                  }
                                                  : new[] {sentenceStartIndex, wordStartIndex},
                                                metaData));
      _documentMarks.Add(new Tuple<Guid, Guid>(documenentGuid, res));

      return res;
    }

    /// <summary>
    ///   Gibt alle Dokument-Marken zurück
    /// </summary>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <returns>
    ///   Tupel (1: linkGuid / 2: linkBereiche (StartSatz/WortStart/StopSatz/StopWort) / 3: Metadaten) - kann null sein
    ///   wenn keine Daten für das Dokument hinterlegt sind.
    /// </returns>
    public IEnumerable<Tuple<Guid, int[], object>> GetDocumentMarks(Guid documentGuid)
    {
      try
      {
        var hash =
          new HashSet<Guid>(
                            from documentMark in _documentMarks
                            where documentMark.Item1 == documentGuid
                            select documentMark.Item2);
        return _marks.Where(item => hash.Contains(item.Item1));
      }
      catch
      {
        return null;
      }
    }

    /// <summary>
    ///   Löscht alle Dokument-Marken.
    /// </summary>
    /// <param name="documentGuid">DokumentGUID</param>
    /// <returns>Erfolgreich?</returns>
    public bool RemoveAllDocumentMarks(Guid documentGuid)
    {
      try
      {
        var dmarks = _documentMarks.Where(x => x.Item1 == documentGuid).ToArray();
        var markGuids = new HashSet<Guid>(dmarks.Select(x => x.Item2));

        foreach (var tuple in dmarks)
          _documentMarks.Remove(tuple);

        var marks = _marks.Where(x => markGuids.Contains(x.Item1));
        foreach (var tuple in marks)
          _marks.Remove(tuple);

        var links = _links.Where(x => markGuids.Contains(x.Item2) || markGuids.Contains(x.Item3));
        foreach (var tuple in links)
          _links.Remove(tuple);

        return true;
      }
      catch
      {
        return false;
      }
    }

    /// <summary>
    ///   Löscht einen Link
    /// </summary>
    /// <param name="linkGuid">Guid des Links</param>
    /// <returns>Erfolgreich?</returns>
    public bool RemoveLink(Guid linkGuid)
    {
      return _links.Remove(_links.FirstOrDefault(x => x.Item1 == linkGuid));
    }

    /// <summary>
    ///   Löscht eine bestimmt Dokument-Marke
    /// </summary>
    /// <param name="markGuid">MarkenGUID</param>
    /// <returns>Erfolgreich?</returns>
    public bool RemoveMark(Guid markGuid)
    {
      try
      {
        var dmarks = _documentMarks.Where(x => x.Item2 == markGuid);
        foreach (var tuple in dmarks)
          _documentMarks.Remove(tuple);
        var marks = _marks.Where(x => x.Item1 == markGuid);
        foreach (var tuple in marks)
          _marks.Remove(tuple);
        var links = _links.Where(x => x.Item2 == markGuid || x.Item3 == markGuid);
        foreach (var tuple in links)
          _links.Remove(tuple);

        return true;
      }
      catch
      {
        return false;
      }
    }

    /// <summary>
    ///   Gibt sowohl die ein als auch ausgehenden Links zu einer Markierung oder zu einem Link an.
    /// </summary>
    /// <param name="guidMarkOrLink">Guid einer Marke oder eines Links</param>
    /// <returns>Ein-/Ausgehende Links</returns>
    public IEnumerable<Tuple<Guid, Guid, Guid, object>> ResolveLinks(Guid guidMarkOrLink)
    {
      return _links.Where(x => x.Item2 == guidMarkOrLink || x.Item3 == guidMarkOrLink);
    }
  }
}