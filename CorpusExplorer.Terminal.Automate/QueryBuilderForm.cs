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
  public partial class QueryBuilderForm : AbstractForm
  {
    public QueryBuilderForm(string query = null)
    {
      InitializeComponent();
    }

    public string Query { get; private set; }
  }
}
