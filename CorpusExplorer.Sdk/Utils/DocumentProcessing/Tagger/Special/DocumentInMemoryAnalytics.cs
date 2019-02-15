using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.RawText;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Special
{
  public static class DocumentInMemoryAnalytics
  {
    /// <summary>
    ///   Führt eine schnelle Frequenzauswertung durch.
    ///   HINWEIS: Diese Funktion ist nur für das temporäre Verarbeiten von Texten gedacht.
    /// </summary>
    /// <param name="text">Text</param>
    /// <param name="cleaner">Wie soll der Text vorher bereinigt werden?</param>
    /// <param name="tagger">Wie soll der Text annotiert werden?</param>
    /// <returns>Frequenztabelle</returns>
    public static Dictionary<string, double> Frequency(
      string text,
      IEnumerable<AbstractCleanup> cleaner = null,
      AbstractTagger tagger = null)
    {
      var corpus = Parse(text, cleaner: cleaner, tagger: tagger).FirstOrDefault();
      if (corpus == null || corpus.CountDocuments == 0 || corpus.CountToken == 0)
        return null;

      var selection = corpus.ToSelection();
      var block = selection.CreateBlock<Frequency1LayerBlock>();
      block.Calculate();

      return block.Frequency;
    }

    /// <summary>
    ///   Konvertiert einen Text InMemory in ein Korpus.
    ///   HINWEIS: Diese Funktion ist nur für das temporäre Verarbeiten von Texten gedacht.
    /// </summary>
    /// <param name="text">Text</param>
    /// <param name="corpusBuilder">Was für ein Korpus soll erzeugt werden?</param>
    /// <param name="cleaner">Wie soll der Text vorher bereinigt werden?</param>
    /// <param name="tagger">Wie soll der Text annotiert werden?</param>
    /// <returns>Korpus</returns>
    public static IEnumerable<AbstractCorpusAdapter> Parse(
      string text,
      AbstractCorpusBuilder corpusBuilder = null,
      IEnumerable<AbstractCleanup> cleaner = null,
      AbstractTagger tagger = null)
    {
      return Parse(
                   new[] {new Dictionary<string, object> {{"Text", text}}},
                   corpusBuilder,
                   cleaner,
                   tagger);
    }

    /// <summary>
    ///   Konvertiert einen Text InMemory in ein Korpus.
    ///   HINWEIS: Diese Funktion ist nur für das temporäre Verarbeiten von Texten gedacht.
    /// </summary>
    /// <param name="scrapDocument">Bereits vorbereites ScrapDokument</param>
    /// <param name="corpusBuilder">Was für ein Korpus soll erzeugt werden?</param>
    /// <param name="cleaner">Wie soll der Text vorher bereinigt werden?</param>
    /// <param name="tagger">Wie soll der Text annotiert werden?</param>
    /// <returns>Korpus</returns>
    public static IEnumerable<AbstractCorpusAdapter> Parse(
      Dictionary<string, object> scrapDocument,
      AbstractCorpusBuilder corpusBuilder = null,
      IEnumerable<AbstractCleanup> cleaner = null,
      AbstractTagger tagger = null)
    {
      return Parse(
                   new[] {scrapDocument},
                   corpusBuilder,
                   cleaner,
                   tagger);
    }

    /// <summary>
    ///   Konvertiert einen Text InMemory in ein Korpus.
    ///   HINWEIS: Diese Funktion ist nur für das temporäre Verarbeiten von Texten gedacht.
    /// </summary>
    /// <param name="scrapDocument">Bereits vorbereites ScrapDokument</param>
    /// <param name="corpusBuilder">Was für ein Korpus soll erzeugt werden?</param>
    /// <param name="cleaner">Wie soll der Text vorher bereinigt werden?</param>
    /// <param name="tagger">Wie soll der Text annotiert werden?</param>
    /// <returns>Korpus</returns>
    public static IEnumerable<AbstractCorpusAdapter> Parse(
      IEnumerable<Dictionary<string, object>> scrapDocument,
      AbstractCorpusBuilder corpusBuilder = null,
      IEnumerable<AbstractCleanup> cleaner = null,
      AbstractTagger tagger = null)
    {
      if (cleaner != null)
        foreach (var cleanup in cleaner)
        {
          cleanup.Input.Enqueue(scrapDocument);
          cleanup.Execute();
          scrapDocument = cleanup.Output;
        }

      if (tagger == null)
        tagger = new RawTextTagger();

      tagger.Input.Enqueue(scrapDocument);
      tagger.CorpusBuilder = corpusBuilder ?? new CorpusBuilderWriteDirect();

      tagger.Execute();

      return tagger.Output;
    }
  }
}