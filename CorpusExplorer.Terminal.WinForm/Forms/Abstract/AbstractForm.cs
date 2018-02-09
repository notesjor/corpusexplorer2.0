#region

using System.Drawing;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Model;
using Telerik.WinControls;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Forms.Abstract
{
  /// <summary>
  ///   The abstract form.
  /// </summary>
  public partial class AbstractForm : RadForm
  {
    protected AbstractForm() : this(null)
    {
      try
      {
        ThemeResolutionService.ApplicationThemeName = "TelerikMetroTouch";
      }
      catch {}
      RadControl.EnableDpiScaling = true;
      InitializeComponent();
    }

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractForm" /> class.
    /// </summary>
    public AbstractForm(Project project)
    {
      try
      {
        ThemeResolutionService.ApplicationThemeName = "TelerikMetroTouch";
      }
      catch {}
      Project = project;

      InitializeComponent();

      Load += (sender, args) =>
      {
        try
        {
          var tp = FormElement.TitleBar.TitlePrimitive;          
          tp.Font = new Font("Segoe UI", 12);
          tp.Margin = new Padding(0, 5, 0, 0);

          var ip = FormElement.TitleBar.IconPrimitive;
          ip.ImageScaling = ImageScaling.None;
          ip.Size = new Size(24, 24);
          ip.ScaleSize = new Size(24, 24);
        }
        catch {}
      };
    }

    public Project Project { get; set; }
  }
}