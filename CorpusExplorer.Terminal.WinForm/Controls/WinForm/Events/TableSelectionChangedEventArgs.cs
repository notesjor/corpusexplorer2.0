#region

using System;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.Events
{
  public class TableSelectionChangedEventArgs : EventArgs
  {
    public TableSelectionChangedEventArgs(int columnIndex, int rowIndex)
    {
      RowIndex = rowIndex;
      ColumnIndex = columnIndex;
    }

    public int ColumnIndex { get; }
    public int RowIndex { get; }
  }
}