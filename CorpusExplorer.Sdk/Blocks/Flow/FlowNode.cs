using System;
using System.Collections.Generic;
using System.Linq;

namespace CorpusExplorer.Sdk.Blocks.Flow
{
  public class FlowNode
  {
    private Dictionary<string, FlowNode> _children = new Dictionary<string, FlowNode>();

    public FlowNode(string content)
    {
      Content = content;
    }

    public IEnumerable<FlowNode> Children => _children.Values;
    public int ChildrenCount => _children.Count;
    public string Content { get; private set; }
    public int Diversity => _children.Count == 0 ? 1 : _children.Sum(child => child.Value.Diversity);
    public int Frequency { get; private set; }

    public void Join(FlowNodeDirection direction, string nodeValueSeparator = " ")
    {
      if (_children.Count == 0)
        return;

      while (_children.Count == 1)
      {
        var first = _children.First();
        Content = string.IsNullOrEmpty(Content)
                    ? first.Key
                    : direction == FlowNodeDirection.Forward
                      ? string.Join(nodeValueSeparator, Content, first.Key)
                      : string.Join(nodeValueSeparator, first.Key, Content);
        _children = first.Value._children;
      }

      foreach (var child in _children)
        child.Value.Join(direction, nodeValueSeparator);
    }

    public void Merge(List<string> sentence, FlowNodeDirection direction)
    {
      if (sentence.Count == 0)
        return;
      if (_children == null || _children.Count == 0)
        _children = new Dictionary<string, FlowNode>();

      Frequency++;

      string key;
      if (direction == FlowNodeDirection.Forward)
      {
        key = sentence[0];
        sentence.RemoveAt(0);
      }
      else
      {
        key = sentence[sentence.Count - 1];
        sentence.RemoveAt(sentence.Count - 1);
      }

      FlowNode node;
      if (_children.ContainsKey(key))
      {
        node = _children[key];
      }
      else
      {
        node = new FlowNode(key);
        _children.Add(key, node);
      }

      node.Merge(sentence, direction);
    }

    public IEnumerable<Tuple<string, string, double>> RecursiveConnections(bool forward)
    {
      if (_children == null || _children.Count == 0)
        return new List<Tuple<string, string, double>>();

      var res = new List<Tuple<string, string, double>>();
      foreach (var child in _children)
      {
        res.Add(forward
                  ? new Tuple<string, string, double>(Content, child.Value.Content, child.Value.Frequency)
                  : new Tuple<string, string, double>(child.Value.Content, Content, child.Value.Frequency));
        res.AddRange(child.Value.RecursiveConnections(forward));
      }

      return res;
    }

    public IEnumerable<string> RecursiveNodes()
    {
      if (_children == null || _children.Count == 0)
        return new List<string> {Content};

      var res = new HashSet<string> {Content};
      foreach (var c in _children)
      {
        var t = c.Value.RecursiveNodes();
        foreach (var x in t) res.Add(x);
      }

      return res;
    }
  }
}