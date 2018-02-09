#region

using System.Data;

#endregion

namespace CorpusExplorer.Sdk.ViewModel.Interfaces
{
  public interface IProvideDataTable : IViewModel
  {
    /// <summary>
    ///   Gibt eine Datentabelle zurück
    /// </summary>
    /// <returns>Datentabelle</returns>
    DataTable GetDataTable();
  }
}