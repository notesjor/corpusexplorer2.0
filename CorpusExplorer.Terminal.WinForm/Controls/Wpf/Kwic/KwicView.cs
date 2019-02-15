#region

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CorpusExplorer.Sdk.Ecosystem.Model;
using PostSharp.Patterns.Threading;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.Wpf.Kwic
{
  /// <summary>
  ///   Interaktionslogik für KwicView.xaml
  /// </summary>
  public partial class KwicView
  {
    private IEnumerable<KeyValuePair<string[], int>> _dataSource;

    public KwicView()
    {
      InitializeComponent();
    }

    public IEnumerable<KeyValuePair<string[], int>> DataSource
    {
      get => _dataSource;
      set
      {
        _dataSource = value;
        BuildGrid();
      }
    }

    [Background]
    private void BuildGrid()
    {
      // Lösche Grid
      ClearGrid();

      // Ermittle Lauflängen
      var maxIndex = DataSource.Select(pair => pair.Value).Concat(new[] {0}).Max();
      var maxSuffix = DataSource.Select(pair => pair.Key.Length - maxIndex + 1).Concat(new[] {0}).Max();
      var maxSum = maxIndex + maxSuffix + 1;

      // Defniere Grid
      DefineGrid(maxSum);

      var array = DataSource.ToArray();

      // Füge Daten in Grid ein
      Parallel.For(
                   0,
                   array.Length,
                   Configuration.ParallelOptions,
                   i =>
                   {
                     var sentence = array[i];
                     // Füge Index ein
                     NewTextBlock(sentence.Key[sentence.Value], Colors.Red, i, maxIndex);

                     // Füge Prefix ein
                     var j = sentence.Value - 1;
                     var k = 1;
                     for (; j > -1; j--, k++)
                       NewTextBlock(sentence.Key[j], Colors.Black, i, maxIndex - k);

                     // Füge Suffix ein
                     j = sentence.Value + 1;
                     k = 1;
                     for (; j < sentence.Key.Length; j++, k++)
                       NewTextBlock(sentence.Key[j], Colors.Black, i, maxIndex + k);
                   });
    }

    private void ClearGrid()
    {
      Dispatcher.Invoke(() =>
      {
        grid.Children.Clear();
        grid.ColumnDefinitions.Clear();
        grid.RowDefinitions.Clear();
      });
    }

    private void DefineGrid(int maxSum)
    {
      Dispatcher.Invoke(() =>
      {
        for (var i = 0; i < maxSum; i++)
          grid.ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Auto});
        for (var i = 0; i < DataSource.Count(); i++)
          grid.RowDefinitions.Add(new RowDefinition());
      });
    }

    private void NewTextBlock(string text, Color color, int i, int j)
    {
      Dispatcher.Invoke(() =>
      {
        //FIX
        // ReSharper disable once LoopVariableIsNeverChangedInsideLoop
        while (j >= grid.ColumnDefinitions.Count)
          grid.ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Auto});

        var tb = new TextBlock
        {
          Text = text + " ",
          Foreground = new SolidColorBrush(color),
          VerticalAlignment = VerticalAlignment.Top,
          HorizontalAlignment = HorizontalAlignment.Center
        };
        Grid.SetRow(tb, i);
        Grid.SetColumn(tb, j);

        if (grid.ColumnDefinitions[j].MinWidth < tb.Width)
          grid.ColumnDefinitions[j].MinWidth = tb.Width + 5;

        grid.Children.Add(tb);
      });
    }
  }
}