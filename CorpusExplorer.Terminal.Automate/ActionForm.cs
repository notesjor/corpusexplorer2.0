using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.Automate
{
  public partial class ActionForm : AbstractForm
  {
    public ActionForm()
    {
      InitializeComponent();
    }

    private void grid_sessions_CellFormatting(object sender, CellFormattingEventArgs e)
    {
      if (e.CellElement is GridCommandCellElement cmdCell)
        cmdCell.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
    }

    private void info_session_Click(object sender, EventArgs e)
      =>
        MessageBox.Show("Der Knoten <session> definiert eine Analyse-Session. Quellen (sources) stehen nur innerhalb der Session zur Verfügung - ebenso Schnappschüsse (queries). Analysen (actions) können a/synchron darauf zugreifen.",
                        "<session>",
                        MessageBoxButtons.OK);

    private void info_sources_Click(object sender, EventArgs e)
      =>
        MessageBox.Show("<sources> können Korpora per <annotate> oder <import> erstellen. Das Attribut \"processing\" erlaubt drei Modi: none = normal, merge = alle Quellen werden zusammengefasst, loop = die Quellen werden nacheinander geladen und bearbeitet.",
                        "<sources>",
                        MessageBoxButtons.OK);

    private void info_queries_Click(object sender, EventArgs e)
      =>
        MessageBox.Show("<queries> sind Abfragen auf die Gesamtmenge (sources - siehe auch processing-Modi).",
                        "<queries>",
                        MessageBoxButtons.OK);

    private void info_actions_Click(object sender, EventArgs e)
      =>
        MessageBox.Show("<actions> sind die Aktionen/Analysen die auf Basis der Schnappschüsse (queries) ausgeführt werden.",
                        "<actions>",
                        MessageBoxButtons.OK);
  }
}
