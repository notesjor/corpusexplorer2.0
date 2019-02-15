using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Extern.Xml.Dpxc.Model;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;

namespace CorpusExplorer.Terminal.WinForm.Forms.ValidationCorpus
{
  public partial class GenerateValidationCorpus : AbstractDialog
  {
    private decimal _A;
    private decimal _AB;
    private decimal _B;
    private decimal _C;
    private string _labelA;
    private string _labelB;
    private string _labelC;

    public GenerateValidationCorpus()
    {
      InitializeComponent();
    }

    private void btn_generate_Click(object sender, EventArgs e)
    {
      _labelA = txt_a.Text;
      _labelB = txt_b.Text;
      _labelC = txt_c.Text;

      _AB = cnt_AB.Value;
      _A = cnt_AnotB.Value;
      _B = cnt_notAB.Value;
      _C = cnt_notAnotB.Value;

      var textAB1 = _labelA + " " + _labelB;
      var textAC1 = _labelA + " " + _labelC;
      var textBC1 = _labelB + " " + _labelC;
      var textCC = _labelC + " "  + _labelC;
      var textAB2 = _labelB + " " + _labelA;
      var textAC2 = _labelC + " " + _labelA;
      var textBC2 = _labelC + " " + _labelB;

      var docs = new List<Dictionary<string, object>>();
      for (var i = 0; i < _AB; i++)
        docs.Add(new Dictionary<string, object> {{"Text", CrazyGenerator1(i, textAB1, textAB2)}});
      for (var i = 0; i < _A; i++)
        docs.Add(new Dictionary<string, object> {{"Text", CrazyGenerator1(i, textAC1, textAC2)}});
      for (var i = 0; i < _B; i++)
        docs.Add(new Dictionary<string, object> {{"Text", CrazyGenerator1(i, textBC1, textBC2)}});
      for (var i = 0; i < _C; i++)
        docs.Add(new Dictionary<string, object> {{"Text", textCC}});

      var dpxc = new DocPlusCorpus(docs);

      var sfd = new SaveFileDialog {Filter = "DocPlusXmlCorpus (*.dpxc)|*.dpxc"};
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      using (var fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write))
      using (var bs = new BufferedStream(fs))
      {
        var bf = new NetDataContractSerializer();
        bf.Serialize(bs, dpxc);
      }
    }

    private void cnt_AB_ValueChanged(object sender, EventArgs e)
    {
      _AB = cnt_AB.Value;
    }

    private void cnt_AnotB_ValueChanged(object sender, EventArgs e)
    {
      _A = cnt_AnotB.Value;
    }

    private void cnt_notAB_ValueChanged(object sender, EventArgs e)
    {
      _B = cnt_notAB.Value;
    }

    private void cnt_notAnotB_ValueChanged(object sender, EventArgs e)
    {
      _C = cnt_notAnotB.Value;
    }

    private string CrazyGenerator1(int i, string variant1, string variant2)
    {
      return i % 2 == 0 ? variant1 : variant2;
    }

    private void txt_a_TextChanged(object sender, EventArgs e)
    {
      _labelA = txt_a.Text;
      lbl_isA.Text = _labelA;
      lbl_isNotA.Text = $"nicht {_labelA}";
    }

    private void txt_b_TextChanged(object sender, EventArgs e)
    {
      _labelB = txt_b.Text;
      lbl_isB.Text = _labelB;
      lbl_isNotB.Text = $"nicht {_labelB}";
    }

    private void txt_c_TextChanged(object sender, EventArgs e)
    {
      _labelC = txt_c.Text;
    }
  }
}