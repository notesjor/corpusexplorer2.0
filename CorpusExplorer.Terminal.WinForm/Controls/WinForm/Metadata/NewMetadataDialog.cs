using System;
using System.Collections.Generic;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.Metadata
{
  public partial class NewMetadataDialog : AbstractDialog
  {
    public NewMetadataDialog()
    {
      InitializeComponent();

      SuspendLayout();
      cmb_type.Items.Add("Text");
      cmb_type.Items.Add("Ganzzahl");
      cmb_type.Items.Add("Kommazahl");
      cmb_type.Items.Add("Datum");
      ResumeLayout(false);
    }

    public KeyValuePair<string, Type> Result
    {
      get
      {
        Type type = null;

        switch (cmb_type.SelectedIndex)
        {
          case 0:
            type = typeof(string);
            break;
          case 1:
            type = typeof(int);
            break;
          case 2:
            type = typeof(double);
            break;
          case 3:
            type = typeof(DateTime);
            break;
        }

        return new KeyValuePair<string, Type>(txt_propertyName.Text, type);
      }
    }
  }
}