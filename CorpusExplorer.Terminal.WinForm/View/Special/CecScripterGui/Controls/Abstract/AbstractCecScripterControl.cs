using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Abstract;

namespace CorpusExplorer.Terminal.WinForm.View.Special.CecScripterControls.Abstract
{
  public partial class AbstractCecScripterControl : AbstractUserControl
  {
    public AbstractCecScripterControl()
    {
      InitializeComponent();
    }

    public virtual string Query
    {
      get;
      set;
    }
  }
}
