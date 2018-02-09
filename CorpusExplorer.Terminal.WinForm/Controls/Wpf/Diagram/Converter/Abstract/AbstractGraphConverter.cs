using System.Collections.Generic;
using Telerik.Windows.Diagrams.Core;

namespace CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.Converter.Abstract
{
  public abstract class AbstractGraphConverter
  {
    public abstract string Convert(IEnumerable<IShape> shapes, IEnumerable<IConnection> connections);
  }
}