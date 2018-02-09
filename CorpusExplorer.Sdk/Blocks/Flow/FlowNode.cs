using System.Collections.Generic;
using System.Linq;

namespace CorpusExplorer.Sdk.Blocks.Flow
{
  public class FlowNode
  {
    private Dictionary<string, FlowNode> _children = new Dictionary<string, FlowNode>();

    public FlowNode(string content) { Content = content; }

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
      Frequency++;
      if (sentence.Count == 0)
        return;

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
  }
}