using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Addon
{
  public interface IAction
  {
    /// <summary>
    /// Eindeutiger Name der ACTION.
    /// Vergeben Sie möglichst aussagekräftigen und individuellen Namen für die ACTION.
    /// </summary>
    /// <value>Eindeutiger Name</value>
    string Action { get; }

    /// <summary>
    /// Beschreiben Sie hier in wenigen Worten die Funktion der ACTION sowie möglicher Parameter.
    /// Dieser Text wird angezeigt, wenn die Nutzerin die Hilfe aufruft.
    /// </summary>
    /// <value>Hilfetext</value>
    string Description { get; }

    /// <summary>
    /// Führt die Berechnung aus. Implementieren Sie hier die Funktion der ACTION.
    /// </summary>
    /// <param name="selection">Schnappschuss (Analysegrundlage)</param>
    /// <param name="args">Argumente/Parameter die über die Konsole oder ein Skript bereitgestellt werden. Es werden nur relevante Parameter übergeben ([INPUT]/[QUERY] werden gefltert)</param>
    /// <param name="writer">Das gewünschte Ausgabeformat. Die Ausgabe der ACTION sollte eine DataTable sein, die mit writer.WriteTable(</param>
    /// <example>
    /// public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    /// {
    ///   var vm = new Frequency1LayerViewModel { Selection = selection };
    ///   if (args != null && args.Length == 1)
    ///     vm.LayerDisplayname = args[0];
    ///   vm.Execute();
    /// 
    ///   writer.WriteTable(selection.Displayname, vm.GetNormalizedDataTable());
    /// }
    /// </example>
    void Execute(Selection selection, string[] args, AbstractTableWriter writer);
  }
}
