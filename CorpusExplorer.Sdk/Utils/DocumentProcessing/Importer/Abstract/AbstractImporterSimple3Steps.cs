#region

using System;
using CorpusExplorer.Sdk.Diagnostic;

#endregion

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract
{
  public abstract class AbstractImporterSimple3Steps<T> : AbstractImporterBase
  {
    protected override void ExecuteCall(string path)
    {
      try
      {
        var data = ImportStep_1_ReadFile(path);
        var guid = Guid.NewGuid();

        ImportStep_2_ImportMetadata(guid, ref data);
        ImportStep_3_ImportContent(guid, ref data);
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
      }
    }

    /// <summary>
    ///   Erster Importschritt - ließt die Datei ein und gibt (ein) entsprechend(es) Objekt(e) zurück.
    /// </summary>
    /// <param name="path">Dateipfad</param>
    /// <returns>Gibt (ein) Objekt(e) zurück die dem Korpus entsprechen.</returns>
    protected abstract T ImportStep_1_ReadFile(string path);

    /// <summary>
    ///   Zweiter Importschritt - lese alle verfügbaren Metadaten ein (Korpus/Dokumente/Layer).
    ///   Die Ergebnisse sollten in CorpusMetadata sowie DocumentMetadata geschrieben werden.
    /// </summary>
    /// <param name="documentGuid">Vorgeschlagener documentGUID</param>
    /// <param name="data">Datenobjekt</param>
    protected abstract void ImportStep_2_ImportMetadata(Guid documentGuid, ref T data);

    /// <summary>
    ///   Dritter Importschritt - lese alle verfügbaren Dokumente und dazugehörigen Layer ein.
    ///   Die Ergebnisse sollten in LayerDocuments sowie LayersDictionaries geschrieben werden.
    ///   Dokumente sollten mit DocumentMetadata abgeglichen werden.
    /// </summary>
    /// <param name="documentGuid">Vorgeschlagener documentGUID</param>
    /// <param name="data">Datenobjekt</param>
    protected abstract void ImportStep_3_ImportContent(Guid documentGuid, ref T data);
  }
}