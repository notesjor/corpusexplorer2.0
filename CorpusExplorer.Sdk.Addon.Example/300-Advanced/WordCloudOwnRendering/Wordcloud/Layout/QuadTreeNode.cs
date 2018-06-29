#region

using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

#endregion

namespace CorpusExplorer.Sdk.Addon.Example.WordCloudOwnRendering.Wordcloud.Layout
{
  public class QuadTreeNode<T>
    where T : LayoutItem
  {
    private QuadTreeNode<T>[] m_Nodes = new QuadTreeNode<T>[0];

    public QuadTreeNode(RectangleF bounds)
    {
      Bounds = bounds;
    }

    public RectangleF Bounds { get; }

    public Stack<T> Contents { get; } = new Stack<T>();

    public int Count
    {
      get
      {
        var count = m_Nodes.Sum(node => node.Count);

        count += Contents.Count;

        return count;
      }
    }

    public bool IsEmpty => Bounds.IsEmpty || m_Nodes.Length == 0;

    public IEnumerable<T> SubTreeContents
    {
      get
      {
        IEnumerable<T> results = new T[0];

        results = m_Nodes.Aggregate(results, (current, node) => current.Concat(node.SubTreeContents));

        results = results.Concat(Contents);
        return results;
      }
    }

    public void ForEach(QuadTree<T>.QuadTreeAction action)
    {
      action(this);

      // draw the child quads
      foreach (var node in m_Nodes)
        node.ForEach(action);
    }

    public bool HasContent(RectangleF queryArea)
    {
      var queryResult = Query(queryArea);
      return IsEmptyEnumerable(queryResult);
    }

    public void Insert(T item)
    {
      // if the item is not contained in this quad, there's a problem
      if (!Bounds.Contains(item.Rectangle))
      {
        Trace.TraceWarning("feature is out of the bounds of this quadtree node");
        return;
      }

      // if the subnodes are null create them. may not be sucessfull: see below
      // we may be at the smallest allowed size in which case the subnodes will not be created
      if (m_Nodes.Length == 0)
        CreateSubNodes();

      // for each subnode:
      // if the node contains the item, add the item to that node and return
      // this recurses into the node that is just large enough to fit this item
      foreach (var node in m_Nodes.Where(node => node.Bounds.Contains(item.Rectangle)))
      {
        node.Insert(item);
        return;
      }

      // if we make it to here, either
      // 1) none of the subnodes completely contained the item. or
      // 2) we're at the smallest subnode size allowed 
      // add the item to this node's contents.
      Contents.Push(item);
    }

    /// <summary>
    ///   Query the QuadTree for items that are in the given area
    /// </summary>
    /// <param name="queryArea">
    ///   <returns></returns>
    /// </param>
    public IEnumerable<T> Query(RectangleF queryArea)
    {
      // this quad contains items that are not entirely contained by
      // it's four sub-quads. Iterate through the items in this quad 
      // to see if they intersect.
      foreach (var item in Contents.Where(item => queryArea.IntersectsWith(item.Rectangle)))
        yield return item;

      foreach (var node in m_Nodes.Where(node => !node.IsEmpty))
      {
        // Case 1: search area completely contained by sub-quad
        // if a node completely contains the query area, go down that branch
        // and skip the remaining nodes (break this loop)
        if (node.Bounds.Contains(queryArea))
        {
          var subResults = node.Query(queryArea);
          foreach (var subResult in subResults)
            yield return subResult;
          break;
        }

        // Case 2: Sub-quad completely contained by search area 
        // if the query area completely contains a sub-quad,
        // just add all the contents of that quad and it's children 
        // to the result set. You need to continue the loop to test 
        // the other quads
        if (queryArea.Contains(node.Bounds))
        {
          var subResults = node.SubTreeContents;
          foreach (var subResult in subResults)
            yield return subResult;
          continue;
        }

        // Case 3: search area intersects with sub-quad
        // traverse into this quad, continue the loop to search other
        // quads
        // ReSharper disable once InvertIf
        if (node.Bounds.IntersectsWith(queryArea))
        {
          var subResults = node.Query(queryArea);
          foreach (var subResult in subResults)
            yield return subResult;
        }
      }
    }

    private void CreateSubNodes()
    {
      // the smallest subnode has an area 
      if (Bounds.Height * Bounds.Width <= 10)
        return;

      var halfWidth = Bounds.Width / 2f;
      var halfHeight = Bounds.Height / 2f;

      m_Nodes = new QuadTreeNode<T>[4];
      m_Nodes[0] = new QuadTreeNode<T>(new RectangleF(Bounds.Location, new SizeF(halfWidth, halfHeight)));
      m_Nodes[1] =
        new QuadTreeNode<T>(
          new RectangleF(
            new PointF(Bounds.Left, Bounds.Top + halfHeight),
            new SizeF(halfWidth, halfHeight)));
      m_Nodes[2] =
        new QuadTreeNode<T>(
          new RectangleF(
            new PointF(Bounds.Left + halfWidth, Bounds.Top),
            new SizeF(halfWidth, halfHeight)));
      m_Nodes[3] =
        new QuadTreeNode<T>(
          new RectangleF(
            new PointF(Bounds.Left + halfWidth, Bounds.Top + halfHeight),
            new SizeF(halfWidth, halfHeight)));
    }

    private static bool IsEmptyEnumerable(IEnumerable<T> queryResult)
    {
      using (var enumerator = queryResult.GetEnumerator())
      {
        return enumerator.MoveNext();
      }
    }
  }
}