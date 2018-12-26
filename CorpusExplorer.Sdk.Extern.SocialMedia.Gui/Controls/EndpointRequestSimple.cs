using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Controls.Abstract;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Controls
{
  public partial class EndpointRequestSimple : AbstractEndpointRequest
  {
    public EndpointRequestSimple()
    {
      InitializeComponent();
    }

    protected override void ExecuteBackgroundWorker()
    {
      OnExecute(new Dictionary<string, object>{{"queries", radTextBox1.Lines}});
    }
  }
}
