using System;

namespace CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper.Delegates
{
  /// <summary>
  /// Wird aufgerufen, wenn ein Fehler während des De-/Serialisierungsprozesses auftritt.
  /// </summary>
  /// <param name="path">Pfad der betroffenen Datei</param>
  /// <param name="ex">Exception</param>
  /// <returns>Soll die De-/Serialisierung wiederholt werden?</returns>
  public delegate bool ExceptionDelegate(string path, Exception ex);
}
