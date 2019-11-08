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
  public partial class BasicInformationForm : AbstractForm
  {
    public BasicInformationForm()
    {
      InitializeComponent();
    }

    private void grid_sessions_CellFormatting(object sender, CellFormattingEventArgs e)
    {
      if (e.CellElement is GridCommandCellElement cmdCell)
        cmdCell.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter;
    }

    private void info_cescript_Click(object sender, EventArgs e)
      =>
        MessageBox.Show("Der Knoten <cescript> ist der Root-Knoten. Er beinhaltet Meta-Informationen und Sessions. Über das Attribut \"version\" können Sie die Version einstellen. Verwenden Sie am besten immer die aktuellste Version.",
                        "<cescript>", 
                        MessageBoxButtons.OK);

    private void info_head_Click(object sender, EventArgs e)
      =>
        MessageBox.Show("Im Knoten <head> können Meta-Datengespeichert werden. Diese haben für das Skript keine funktionalen Eigenschaften. Vielmehr können Sie hier Informationen zum Projekthintergrund hinterlegen.",
                        "<meta>",
                        MessageBoxButtons.OK);

    private void info_sessions_Click(object sender, EventArgs e)
      =>
        MessageBox.Show("Im Knoten <sessions> beinhaltet die Analyse-Session. Diese können synchron oder asynchron ausgeführt werden (siehe Attribut mode). Bearbeiten Sie eine Session, um weitere Informationen anzuzeigen.",
                        "<sessions>",
                        MessageBoxButtons.OK);
  }
}
