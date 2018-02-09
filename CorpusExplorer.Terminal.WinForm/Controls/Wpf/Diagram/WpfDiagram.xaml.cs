using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.Converter.Abstract;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Helper;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams;
using Telerik.Windows.Diagrams.Core;
using Orientation = System.Windows.Controls.Orientation;

namespace CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram
{
  /// <summary>
  ///   Interaktionslogik für WpfDiagram.xaml
  /// </summary>
  public partial class WpfDiagram : UserControl
  {
    [NonSerialized]
    private readonly Dictionary<Guid, IConnection> _connections = new Dictionary<Guid, IConnection>();

    [NonSerialized]
    private readonly Dictionary<Guid, IShape> _nodes = new Dictionary<Guid, IShape>();

    [NonSerialized]
    private readonly Dictionary<string, Guid> _dic = new Dictionary<string, Guid>();

    public WpfDiagram()
    {
      StyleManager.ApplicationTheme = new Windows8TouchTheme();
      InitializeComponent();
    }

    private Guid AddConnection(Guid nodeSource, Guid nodeTarget, bool addArrow)
    {
      return AddConnection(_nodes[nodeSource], _nodes[nodeTarget], addArrow);
    }

    private Guid AddConnection(IShape startShape, IShape endShape, bool addArrow)
    {
      var res = Guid.NewGuid();
      var con = diagram.AddConnection(startShape, endShape);
      if (addArrow)
      {
        con.TargetCapSize = new Size(10, 10);
        con.TargetCapType = CapType.Arrow1;
      }

      _connections.Add(res, con);      
      return res;
    }

    private Guid AddConnection(IConnection connection)
    {
      var res = Guid.NewGuid();
      _connections.Add(res, connection);
      diagram.AddConnection(connection);
      return res;
    }

    public Dictionary<string, Guid> CallAddNodes(HashSet<string> nodes, UniversalColor color = null)
    {
      if (color == null)
        color = new UniversalColor(30, 80, 255);

      return nodes.ToDictionary(node => node, node => CallAddNode(node, color));
    }

    public Guid CallAddNode(string node, UniversalColor color = null)
    {
      if (_dic.ContainsKey(node))
        return _dic[node];

      if (color == null)
        color = new UniversalColor(30, 80, 255);

      var shape = new RadDiagramShape
      {
        Width = 180,
        Height = 100,
        Position = new Point { X = 100, Y = 100 },
        Content = MakeComplexNodeContent(node),
        Geometry = ShapeFactory.GetShapeGeometry(CommonShapeType.RectangleShape),
        Background = new SolidColorBrush(color.ToWpfColor())
      };

      diagram.AddShape(shape);

      var res = Guid.NewGuid();
      _nodes.Add(res, shape);
      _dic.Add(node, res);

      return res;
    }

    private object MakeComplexNodeContent(string node)
    {
      var stack = new WrapPanel
      {
        HorizontalAlignment = HorizontalAlignment.Stretch,
        VerticalAlignment = VerticalAlignment.Stretch,
        Orientation = Orientation.Horizontal
      };
      var split = node.Split(new[]{" "}, StringSplitOptions.RemoveEmptyEntries);
      foreach (var s in split)
      {
        var highlight = s.StartsWith("<strong>");
        stack.Children.Add( new TextBlock
        {
          FontWeight = highlight ? FontWeights.ExtraBold : FontWeights.Normal,
          Text = highlight ? s.Replace("<strong>", "").Replace("</strong>", "") : s,
          Margin = new Thickness(0, 0, 3, 4)
        });
      }
      return stack;
    }

    public void CallAdd(IEnumerable<Tuple<string, double, string>> nodesAndEdges, UniversalColor color = null, bool addArrow = false)
    {
      foreach (var entry in nodesAndEdges)
      {
        var con = _connections[AddConnection(CallAddNode(entry.Item1, color), CallAddNode(entry.Item3), addArrow)];
        con.Content = new TextBlock
        {
          Text = entry.Item2 > 0 ? Math.Round(entry.Item2, 3).ToString(CultureInfo.CurrentCulture) : "",
          Foreground = new SolidColorBrush { Color = Colors.Black }
        };
      }
    }

    public void CallBuildAggregatedChain(IEnumerable<KeyValuePair<string, int>> ngrams)
    {
      CallBuildAggregatedChain(ngrams.Select(ngram => new KeyValuePair<string[], int>(ngram.Key.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries), ngram.Value)));
    }

    public void CallBuildAggregatedChain(IEnumerable<KeyValuePair<string[], int>> ngrams)
    {
      CallNew();
      var hash = new Dictionary<string, RadDiagramShape>();

      const double stroke = 11.0d;
      var dec = (stroke - 1.0d) / ngrams.Count();
      var act = stroke;

      foreach (var ngram in ngrams)
      {
        for (var i = 0; i < ngram.Key.Length; i++)
        {
          RadDiagramShape shape;
          if (hash.ContainsKey(ngram.Key[i]))
            shape = hash[ngram.Key[i]];
          else
          {
            shape = new RadDiagramShape
            {
              Width = 180,
              Height = 100,
              Content = ngram.Key[i],
              Foreground = new SolidColorBrush(Colors.Black),
              FontSize = 16,
              Geometry = ShapeFactory.GetShapeGeometry(CommonShapeType.RectangleShape),
              Background = new LinearGradientBrush()
            };

            var color = i == 0
                          ? Color.FromRgb(150, 255, 180)
                          : i + 1 == ngram.Key.Length
                            ? Color.FromRgb(255, 150, 150)
                            : Color.FromRgb(150, 180, 255);

            ((LinearGradientBrush)shape.Background).GradientStops.Add(new GradientStop(color, 0));
            ((LinearGradientBrush)shape.Background).GradientStops.Add(new GradientStop(color, 0.5));
            ((LinearGradientBrush)shape.Background).GradientStops.Add(new GradientStop(color, 1));

            diagram.AddShape(shape);
            hash.Add(ngram.Key[i], shape);
          }

          if (i == 0)
            ((LinearGradientBrush)shape.Background).GradientStops[0] = new GradientStop(
              Color.FromRgb(150, 255, 180),
              0);
          else if (i + 1 == ngram.Key.Length)
            ((LinearGradientBrush)shape.Background).GradientStops[2] = new GradientStop(
              Color.FromRgb(255, 150, 150),
              1);
          else
            ((LinearGradientBrush)shape.Background).GradientStops[1] = new GradientStop(
              Color.FromRgb(150, 180, 255),
              0.5);

          if (i > 0)
            AddConnection(
              new RadDiagramConnection
              {
                Source = hash[ngram.Key[i - 1]],
                Target = shape,
                Content =
                  new TextBlock
                  {
                    Text = ngram.Value.ToString(),
                    Foreground = new SolidColorBrush { Color = Colors.Black },
                    Background = new SolidColorBrush(Colors.White)
                  },
                StrokeThickness = act,
                TargetCapType = CapType.Arrow1Filled
              });
        }

        act -= dec;
      }

      diagram.Layout();
    }

    public void CallBuildChain(IEnumerable<KeyValuePair<string, int>> ngrams)
    {
      CallBuildChain(ngrams.Select(ngram => new KeyValuePair<string[], int>(ngram.Key.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries), ngram.Value)));
    }

    public void CallBuildChain(IEnumerable<KeyValuePair<string[], int>> ngrams)
    {
      CallNew();
      var levels = new Dictionary<int, Dictionary<string, IShape>>();

      const double stroke = 11.0d;
      var dec = (stroke - 1.0d) / ngrams.Count();
      var act = stroke;

      foreach (var ngram in ngrams)
      {
        for (var i = 0; i < ngram.Key.Length; i++)
        {
          if (!levels.ContainsKey(i))
            levels.Add(i, new Dictionary<string, IShape>());

          IShape shape;
          if (levels[i].ContainsKey(ngram.Key[i]))
            shape = levels[i][ngram.Key[i]];
          else
          {
            shape = new RadDiagramShape
            {
              Width = 180,
              Height = 100,
              Content = ngram.Key[i],
              Foreground = new SolidColorBrush(Colors.Black),
              FontSize = 16,
              Geometry = ShapeFactory.GetShapeGeometry(CommonShapeType.RectangleShape),
              Background =
                i == 0
                  ? new SolidColorBrush(Color.FromRgb(150, 255, 180))
                  : i + 1 == ngram.Key.Length
                    ? new SolidColorBrush(Color.FromRgb(255, 150, 150))
                    : new SolidColorBrush(Color.FromRgb(150, 180, 255))
            };
            diagram.AddShape(shape);
            levels[i].Add(ngram.Key[i], shape);
          }

          if (i > 0)
            AddConnection(
              new RadDiagramConnection
              {
                Source = levels[i - 1][ngram.Key[i - 1]],
                Target = shape,
                Content =
                  new TextBlock
                  {
                    Text = ngram.Value.ToString(),
                    Foreground = new SolidColorBrush { Color = Colors.Black },
                    Background = new SolidColorBrush(Colors.White)
                  },
                StrokeThickness = act,
                TargetCapType = CapType.Arrow1Filled
              });
        }

        act -= dec;
      }

      diagram.Layout();
    }

    public void CallLayoutAsSugiyama()
    {
      /*
      var settings = new SugiyamaSettings
      {
        HorizontalDistance = 50,
        VerticalDistance = 50,
        Orientation = Orientation.Horizontal,
        TotalMargin = new Size(20, 20),
        ShapeMargin = new Size(10, 10)
      };
      diagram.Layout(LayoutType.Sugiyama, settings);
      */
      diagram.Layout(
        LayoutType.Tree,
        new TreeLayoutSettings
        {
          TreeLayoutType = TreeLayoutType.RadialTree,
          HorizontalSeparation = 30,
          VerticalSeparation = 30
        });
    }

    public void CallLayoutAsTree()
    {
      diagram.Layout(
        LayoutType.Tree,
        new TreeLayoutSettings
        {
          TreeLayoutType = TreeLayoutType.TreeUp
        });
    }

    public void CallLayoutAsHorizontalTree()
    {
      diagram.Layout(
        LayoutType.Tree,
        new TreeLayoutSettings
        {
          TreeLayoutType = TreeLayoutType.TreeRight,
          TipOverTreeStartLevel = int.MaxValue,
          HorizontalSeparation = 50,
          VerticalSeparation = 30
        });
    }

    public void CallLoad(string fileName) { diagram.Load(File.ReadAllText(fileName)); }

    public void CallNew()
    {
      diagram.Clear();
      _nodes.Clear();
      _dic.Clear();
      _connections.Clear();
    }
    
    public void CallPlotFlow(List<string> connection, bool markEnd, bool addArrow)
    {
      var current = diagram.AddShape(
        new RadDiagramShape
        {
          Width = 180,
          Height = 100,
          Position = new Point { X = 100, Y = 100 },
          Content = connection.FirstOrDefault(),
          Geometry = ShapeFactory.GetShapeGeometry(CommonShapeType.EllipseShape),
          Background = new SolidColorBrush(Color.FromRgb(150, 255, 180))
        });

      for (var i = 1; i < connection.Count - 1; i++)
      {
        var temp = diagram.AddShape(
          new RadDiagramShape
          {
            Width = 180,
            Height = 100,
            Position = new Point { X = 100, Y = 100 },
            Content = connection[i],
            Geometry = ShapeFactory.GetShapeGeometry(CommonShapeType.RectangleShape),
            Background = new SolidColorBrush(Color.FromRgb(150, 180, 255))
          });
        AddConnection(current, temp, addArrow);
        current = temp;
      }

      if (connection.Count == 1)
        return;

      var temp2 = diagram.AddShape(
        new RadDiagramShape
        {
          Width = 180,
          Height = 100,
          Position = new Point { X = 100, Y = 100 },
          Content = connection.Last(),
          Geometry =
            ShapeFactory.GetShapeGeometry(markEnd ? CommonShapeType.EllipseShape : CommonShapeType.RectangleShape),
          Background = new SolidColorBrush(markEnd ? Color.FromRgb(255, 150, 150) : Color.FromRgb(150, 180, 255))
        });
      AddConnection(current, temp2, addArrow);
    }

    public void CallSave(string fileName) { File.WriteAllText(fileName, diagram.Save()); }

    public string Export(AbstractGraphConverter converter) { return converter.Convert(_nodes.Values, _connections.Values); }

    public void PlotConnection(string source, string destination, bool addArrow)
    {
      AddConnection(_nodes[_dic[source]], _nodes[_dic[destination]], addArrow);
    }

    public void CallAddConnection(Guid sourceNodeGuid, Guid targetNodeGuid, bool addArrow)
    {
      AddConnection(_nodes[sourceNodeGuid], _nodes[targetNodeGuid], addArrow);
    }
  }
}