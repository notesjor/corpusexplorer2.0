#region

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Layouts;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.Events
{
  public class RadMenuInsertTableItem : RadMenuItemBase
  {
    private readonly string HeaderText = "Insert Table";
    private int _currentColumnIndex = -1;
    private int _currentRowIndex = -1;
    private LightVisualElement _header;
    private StackLayoutElement _stackLayout;
    private UniformGrid _uniformGrid;

    protected override Type ThemeEffectiveType => typeof(RadMenuItem);

    public event EventHandler<TableSelectionChangedEventArgs> SelectionChanged;

    protected override SizeF ArrangeOverride(SizeF finalSize)
    {
      var menuLayout = Parent as RadDropDownMenuLayout;
      if (menuLayout == null)
        return finalSize;
      var x = Math.Max(menuLayout.LeftColumnWidth, menuLayout.LeftColumnMinWidth) + menuLayout.LeftColumnMaxPadding;

      var size = finalSize;
      size.Width -= x;

      var finalRect = new RectangleF(new PointF(x, 0), size);

      _stackLayout.Arrange(finalRect);
      return finalSize;
    }

    protected override void CreateChildElements()
    {
      base.CreateChildElements();

      const int rowsCount = 8;
      const int columnsCount = 10;
      var boxSize = new Size(16, 16);

      _stackLayout = new StackLayoutElement
      {
        Orientation = Orientation.Vertical,
        StretchHorizontally = true,
        StretchVertically = true,
        NotifyParentOnMouseInput = true
      };
      Children.Add(_stackLayout);

      _header = new LightVisualElement
      {
        TextAlignment = ContentAlignment.MiddleLeft,
        StretchVertically = false,
        Text = HeaderText,
        DrawFill = true,
        Font = new Font("Segoe UI", 9, FontStyle.Bold),
        GradientStyle = GradientStyles.Solid,
        BackColor = Color.FromArgb(240, 242, 245)
      };
      _stackLayout.Children.Add(_header);

      _uniformGrid = new UniformGrid
      {
        StretchVertically = true,
        NotifyParentOnMouseInput = true,
        Rows = rowsCount,
        Columns = columnsCount,
        MinSize = new Size(160, 140),
        Margin = new Padding(5, 5, 0, 0)
      };
      _stackLayout.Children.Add(_uniformGrid);

      for (var i = 1; i <= rowsCount * columnsCount; i++)
      {
        var box = new LightVisualElement
        {
          DrawBorder = true,
          BorderGradientStyle = GradientStyles.Solid,
          BorderBoxStyle = BorderBoxStyle.OuterInnerBorders,
          MaxSize = boxSize,
          MinSize = boxSize,
          NotifyParentOnMouseInput = true
        };
        box.MouseMove += OnBoxMouseMove;
        box.MouseDown += OnBoxMouseDown;
        _uniformGrid.Children.Add(box);
      }
    }

    protected override void InitializeFields()
    {
      base.InitializeFields();
      ShouldHandleMouseInput = true;
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);

      if (e.Button == MouseButtons.Left)
        OnSelectionChanged(new TableSelectionChangedEventArgs(_currentColumnIndex, _currentRowIndex));
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);
      SelectBoxes(e.Location);
    }

    protected override void OnPropertyChanged(RadPropertyChangedEventArgs e)
    {
      base.OnPropertyChanged(e);

      if (!Equals(e.Property, ContainsMouseProperty))
        return;
      if (!(bool) e.NewValue)
        ResetVisuals();
    }

    protected virtual void OnSelectionChanged(TableSelectionChangedEventArgs e)
    {
      var handler = SelectionChanged;
      handler?.Invoke(this, e);

      var buttonElement = Owner as RadDropDownButtonElement;

      if (buttonElement == null)
        return;

      buttonElement.DropDownMenu.ClosePopup(RadPopupCloseReason.Mouse);
      ResetVisuals();
    }

    private void OnBoxMouseDown(object sender, MouseEventArgs e)
    {
      OnSelectionChanged(new TableSelectionChangedEventArgs(_currentColumnIndex, _currentRowIndex));
    }

    private void OnBoxMouseMove(object sender, MouseEventArgs e)
    {
      SelectBoxes(e.Location);
    }

    private void ResetVisuals()
    {
      _header.Text = HeaderText;

      foreach (var element in _uniformGrid.Children.OfType<LightVisualElement>())
      {
        element.ResetValue(LightVisualElement.BorderColorProperty, ValueResetFlags.Local);
        element.ResetValue(LightVisualElement.BorderInnerColorProperty, ValueResetFlags.Local);
      }
    }

    private void SelectBoxes(Point location)
    {
      _currentColumnIndex = -1;
      _currentRowIndex = -1;

      foreach (var radElement in _uniformGrid.Children)
      {
        var element = radElement as LightVisualElement;
        if (element == null)
          continue;
        RectangleF elementBounds = element.ControlBoundingRectangle;

        if (elementBounds.X <= location.X &&
            elementBounds.Y <= location.Y)
        {
          var columnIndex = UniformGrid.GetColumnIndex(element);
          var rowIndex = UniformGrid.GetRowIndex(element);

          _currentColumnIndex = Math.Max(_currentColumnIndex, columnIndex);
          _currentRowIndex = Math.Max(_currentRowIndex, rowIndex);

          element.BorderColor = Color.DarkOrange;
          element.BorderInnerColor = Color.OrangeRed;
        }
        else
        {
          element.ResetValue(LightVisualElement.BorderColorProperty, ValueResetFlags.Local);
          element.ResetValue(LightVisualElement.BorderInnerColorProperty, ValueResetFlags.Local);
        }
      }

      var text = HeaderText;

      if (_currentColumnIndex >= 0 &&
          _currentRowIndex >= 0)
        text = $"{_currentColumnIndex + 1}x{_currentRowIndex + 1}";

      _header.Text = text;
    }
  }
}