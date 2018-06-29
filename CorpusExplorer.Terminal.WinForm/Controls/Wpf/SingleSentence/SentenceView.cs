#region usings

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.SingleSentence.Model;
using Telerik.Windows.Controls;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.Wpf.SingleSentence
{
  /// <summary>
  ///   Interaktionslogik für SentenceView.xaml
  /// </summary>
  public partial class SentenceView
  {
    public SentenceView()
    {
      InitializeComponent();
    }

    public void ClearItems()
    {
      radTreeView.Items.Clear();
    }

    public void SetItems(IEnumerable<SentenceViewItem> items)
    {
      ClearItems();

      foreach (var nitem in items.Select(GenerateItemRekursiv))
        radTreeView.Items.Add(nitem);
    }

    private RadTreeViewItem GenerateItemRekursiv(SentenceViewItem item)
    {
      var nitem = new RadTreeViewItem
      {
        Header = item.Label,
        Foreground = item.ForegroundColor,
        Background = item.BackgroundColor,
        FontSize = 16,
        BorderBrush = new SolidColorBrush(Colors.White),
        BorderThickness = new Thickness(1d),
        ItemContainerStyle = FindResource("TreeViewItemStyle") as Style
      };

      foreach (var subitem in item.Items)
        nitem.Items.Add(GenerateItemRekursiv(subitem));

      return nitem;
    }
  }
}