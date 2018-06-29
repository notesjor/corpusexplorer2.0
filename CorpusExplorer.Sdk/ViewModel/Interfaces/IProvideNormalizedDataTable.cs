using System.Data;

namespace CorpusExplorer.Sdk.ViewModel.Interfaces
{
  public interface IProvideNormalizedDataTable : IViewModel
  {
    /// <summary>
    ///   Gibt eine Datentabelle zurück
    /// </summary>
    /// <param name="baseValue">Basis-Wert für Normalisierung (Standard: 1 Mio.)</param>
    /// <returns>Datentabelle</returns>
    DataTable GetNormalizedDataTable(double baseValue = 1000000);
  }
}