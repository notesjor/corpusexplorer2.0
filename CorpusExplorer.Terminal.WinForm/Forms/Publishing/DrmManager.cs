using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace CorpusExplorer.Terminal.WinForm.Forms.Publishing
{
  public partial class DrmManager : AbstractForm
  {
    public DrmManager(string token)
    {
      InitializeComponent();
      txt_token.Text = token;
    }

    public Dictionary<string, string> ResultUserPasswordCombinations => grid_userPasswordCombinations.Rows.ToDictionary(row => row.Cells[0].Value.ToString(), row => row.Cells[1].Value.ToString());

    private void btn_ok_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
      Close();
    }

    private void btn_abort_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Abort;
      Close();
    }
  }
}
