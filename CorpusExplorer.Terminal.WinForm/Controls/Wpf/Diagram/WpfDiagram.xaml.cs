using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.Converter.Abstract;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.Model;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Helper;
using CorpusExplorer.Terminal.WinForm.Helper;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams;
using Telerik.Windows.Diagrams.Core;

namespace CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram
{
  /// <summary>
  ///   Interaktionslogik für WpfDiagram.xaml
  /// </summary>
  public partial class WpfDiagram : UserControl
  {
    private readonly Dictionary<string, Dictionary<string, Tuple<double, RadDiagramConnection>>> _connections =
      new Dictionary<string, Dictionary<string, Tuple<double, RadDiagramConnection>>>();

    private readonly Dictionary<string, RadDiagramShape> _nodes = new Dictionary<string, RadDiagramShape>();

    public WpfDiagram()
    {
      XamlHighDpiExceptionHelper.Ensure(InitializeComponent);
    }

    #region LAYOUT

    public void CallLayoutAsSugiyama()
    {
      diagram.Layout(LayoutType.Sugiyama, new SugiyamaSettings
      {
        HorizontalDistance = 50,
        VerticalDistance = 50,
        Orientation = Telerik.Windows.Diagrams.Core.Orientation.Horizontal,
        TotalMargin = new Size(20, 20),
        ShapeMargin = new Size(10, 10)
      });
    }

    public void CallLayoutAsTreeRadial()
    {
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

    public void CallLayoutAsTreeHorizontal()
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

    #endregion

    #region NEW / LOAD / SAVE / EXPORT

    public void CallLoad(string fileName)
    {
      CallNew();
      diagram.Load(File.ReadAllText(fileName));
    }

    public void CallNew()
    {
      diagram.Clear();
      _nodes.Clear();
      _connections.Clear();
    }

    public void CallClearConnections()
    {
      _connections.Clear();
      foreach (var con in _connections.SelectMany(x => x.Value).Select(x => x.Value.Item2))
        diagram.RemoveConnection(con);
    }

    public void CallSave(string fileName)
    {
      File.WriteAllText(fileName, diagram.Save());
    }

    public string CallExport(AbstractGraphConverter converter)
    {
      return converter.Convert(_nodes.Values, _connections.Values.SelectMany(x => x).Select(x => x.Value.Item2));
    }

    #endregion

    #region BASIC

    public void CallAddNodes(IEnumerable<string> nodes, bool renderComplexNodeContent = false,
                             UniversalColor color = null, Shape shape = Shape.Rectangle)
    {
      if (color == null)
        color = new UniversalColor(30, 80, 255);

      var input = new HashSet<string>(nodes);

      var newItems = new List<RadDiagramShape>();
      foreach (var node in input)
      {
        if (_nodes.ContainsKey(node))
          continue;

        var content = renderComplexNodeContent ? RenderComplexNodeContent(node) : node;
        var item = new RadDiagramShape
        {
          Width = 180,
          Height = 100,
          Position = new System.Windows.Point {X = 100, Y = 100},
          Content = content,
          Foreground = new SolidColorBrush(Colors.Black),
          Geometry = ShapeFactory.GetShapeGeometry(shape == Shape.Rectangle
                                                     ? CommonShapeType.RectangleShape
                                                     : CommonShapeType.EllipseShape),
          Background = new SolidColorBrush(UniversalColorExtension.ToWpfColor(color))
        };
        newItems.Add(item);
        _nodes.Add(node, item);
      }

      foreach (var item in newItems)
        diagram.AddShape(item);
    }

    public void CallAddConnections(IEnumerable<Tuple<string, string, double>> connections, bool drawArrow = true,
                                   CallAddConnectionsConflictDelegate func = null)
    {
      if (func == null)
        func = PredefinedCallAddConnectionsConflictDelegates.Sum;

      var newConnections = new List<RadDiagramConnection>();
      foreach (var connection in connections)
      {
        if (string.IsNullOrEmpty(connection.Item1) || string.IsNullOrEmpty(connection.Item2))
          continue;

        if (!_connections.ContainsKey(connection.Item1))
          _connections.Add(connection.Item1, new Dictionary<string, Tuple<double, RadDiagramConnection>>());

        if (_connections[connection.Item1].ContainsKey(connection.Item2))
        {
          var merge = func(_connections[connection.Item1][connection.Item2].Item1, connection.Item3);
          var con = CreateConnection(connection.Item1, connection.Item2, merge, drawArrow);
          if (con != null)
            _connections[connection.Item1][connection.Item2] = new Tuple<double, RadDiagramConnection>(merge, con);
        }
        else
        {
          var con = CreateConnection(connection.Item1, connection.Item2, connection.Item3, drawArrow);
          if (con == null)
            continue;
          newConnections.Add(con);
          _connections[connection.Item1]
           .Add(connection.Item2, new Tuple<double, RadDiagramConnection>(connection.Item3, con));
        }
      }

      foreach (var c in newConnections)
        diagram.AddConnection(c);
    }

    public void CallColorizeNode(string node, UniversalColor color1, UniversalColor color2 = null,
                                 UniversalColor color3 = null)
    {
      if (_nodes.ContainsKey(node))
        _nodes[node].Background = GetColorizeBrush(color1, color2, color3);
    }

    private static Brush GetColorizeBrush(UniversalColor color1, UniversalColor color2, UniversalColor color3)
    {
      // Farben ggf. durchreichen
      if (color2 == null && color3 != null)
      {
        color2 = color3;
        color3 = null;
      }

      if (color1 == null && color2 != null)
      {
        color1 = color2;
        color2 = null;
      }

      // Baue Brush
      Brush brush;
      if (color2 == null)
      {
        brush = new SolidColorBrush(UniversalColorExtension.ToWpfColor(color1));
      }
      else
      {
        brush = new LinearGradientBrush();
        if (color3 == null)
        {
          ((LinearGradientBrush) brush).GradientStops.Add(new GradientStop(UniversalColorExtension.ToWpfColor(color1), 0));
          ((LinearGradientBrush) brush).GradientStops.Add(new GradientStop(UniversalColorExtension.ToWpfColor(color2), 1));
        }
        else
        {
          ((LinearGradientBrush) brush).GradientStops.Add(new GradientStop(UniversalColorExtension.ToWpfColor(color1), 0));
          ((LinearGradientBrush) brush).GradientStops.Add(new GradientStop(UniversalColorExtension.ToWpfColor(color2), 0.5));
          ((LinearGradientBrush) brush).GradientStops.Add(new GradientStop(UniversalColorExtension.ToWpfColor(color3), 1));
        }
      }

      return brush;
    }

    public void CallColorizeNodes(IEnumerable<string> nodes, UniversalColor color1, UniversalColor color2 = null,
                                  UniversalColor color3 = null)
    {
      var brush = GetColorizeBrush(color1, color2, color3);

      // Setze Brush für alle Nodes
      foreach (var node in nodes)
        if (_nodes.ContainsKey(node))
          _nodes[node].Background = brush;
    }

    public void CallConnectionRendering(double minSize = 1, double maxSize = 20)
    {
      var max = _connections.AsParallel().SelectMany(x => x.Value).Max(x => x.Value.Item1);
      foreach (var x in _connections)
      foreach (var y in x.Value)
      {
        var thickness = y.Value.Item1 / max * maxSize;
        if (thickness < minSize)
          thickness = minSize;
        y.Value.Item2.StrokeThickness = thickness;
      }
    }

    #endregion

    #region SPECIAL / RENDERING

    private object RenderComplexNodeContent(string node)
    {
      var stack = new WrapPanel
      {
        HorizontalAlignment = HorizontalAlignment.Stretch,
        VerticalAlignment = VerticalAlignment.Stretch,
        Orientation = System.Windows.Controls.Orientation.Horizontal
      };
      var split = node.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
      foreach (var s in split)
      {
        var highlight = s.StartsWith("<strong>");
        stack.Children.Add(new TextBlock
        {
          FontWeight = highlight ? FontWeights.ExtraBold : FontWeights.Normal,
          Text = highlight ? s.Replace("<strong>", "").Replace("</strong>", "") : s,
          Margin = new System.Windows.Thickness(0, 0, 3, 4)
        });
      }

      return stack;
    }

    private RadDiagramConnection CreateConnection(string source, string target, double value, bool drawArrow)
    {
      return !_nodes.ContainsKey(source) || !_nodes.ContainsKey(target)
               ? null
               : new RadDiagramConnection
               {
                 Source = _nodes[source],
                 Target = _nodes[target],
                 StrokeThickness = 1,
                 TargetCapType = drawArrow ? CapType.Arrow1Filled : CapType.None,
                 Content = new TextBlock
                 {
                   Text = $"{source} > {value} > {target}",
                   Background = new SolidColorBrush(Colors.White)
                 },
                 Tag = value
               };
    }

    #endregion

    #region ANALYTICS

    public IEnumerable<KeyValuePair<string, double>> CallGetChildNodes(string node)
    {
      return _connections.ContainsKey(node)
               ? null
               : _connections[node].Select(x => new KeyValuePair<string, double>(x.Key, x.Value.Item1));
    }

    public IEnumerable<KeyValuePair<string, double>> CallGetParentNodes(string node)
    {
      return _connections.AsParallel().Where(x => x.Value.ContainsKey(node))
                         .Select(x => new KeyValuePair<string, double>(x.Key, x.Value[node].Item1));
    }

    public IEnumerable<string> CallNodes => _nodes.Keys;

    #endregion
  }
}