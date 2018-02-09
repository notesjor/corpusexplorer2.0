﻿#region

using System;
using System.ComponentModel;
using System.Drawing;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Abstract;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  [ToolboxItem(true)]
  public partial class RadButtonWithCheckmark : AbstractUserControl
  {
    public RadButtonWithCheckmark() { InitializeComponent(); }

    public Image Image { get { return radButton1.Image; } set { radButton1.Image = value; } }

    public Image ImageCheckmark { get { return pictureBox1.Image; } set { pictureBox1.Image = value; } }

    public string Label { get { return radButton1.Text; } set { radButton1.Text = value; } }

    public bool ShowCheckmark { get { return pictureBox1.Visible; } set { pictureBox1.Visible = value; } }

    private void ButtonClick(object sender, EventArgs e) { OnClick(e); }
  }
}