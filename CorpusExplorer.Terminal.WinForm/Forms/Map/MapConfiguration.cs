using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Terminal.WinForm.Forms.NamedEntity;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.Forms.Map
{
  public partial class MapConfiguration : AbstractExternalModelConfig
  {
    public MapConfiguration(string[][] data)
    {
      InitializeComponent();
      if (data != null)
        ConvertToDataTable(data);
    }

    protected override string ModelDefaultPath { get; } = Configuration.GetDependencyPath("Map/global.csv");

    protected override object ConvertToModel(RadGridView radGridView)
    {
      var res = new List<string[]> { radGridView.Columns.Select(x => x.Name).ToArray() };
      res.AddRange(radGridView.Rows.Select(row =>
                                              (from GridViewCellInfo c in row.Cells select c.Value?.ToString())
                                             .ToArray()));
      return res.ToArray();
    }
  }
}
