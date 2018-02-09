﻿using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.Flow;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel.Abstract;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class TextFlowSearchViewModel : AbstractViewModel
  {
    private HashSet<string> _highlighter = new HashSet<string>();

    public bool AutoJoin { get; set; } = true;

    public FlowNode BranchPost { get; set; }

    public FlowNode BranchPre { get; set; }
    public bool HighlightCooccurrences { get; set; }

    public string LayerDisplayname { get; set; } = "Wort";
    public IEnumerable<string> LayerQueryPhrase { get; set; }
    public IEnumerable<string> LayerValues => Selection.GetLayerValues(LayerDisplayname);

    protected override void ExecuteAnalyse()
    {
      _highlighter.Clear();

      var block = Selection.CreateBlock<TextLiveSearchBlock>();
      block.LayerQueries = new[]
      {
        new FilterQuerySingleLayerExactPhrase {LayerDisplayname = LayerDisplayname, LayerQueries = LayerQueryPhrase}
      };
      block.Calculate();

      var pre = new List<string[]>();
      var post = new List<string[]>();

      foreach (var c in block.SearchResults)
      foreach (var d in c.Value)
      foreach (var s in d.Value)
      {
        var sent = Selection.GetReadableDocumentSnippet(d.Key, "Wort", s.Key, s.Key)
                            .ReduceDocumentToStreamDocument().ToArray();

        var tmp = new List<string>();

        for (var i = 0; i < s.Value.First(); i++)
          tmp.Add(sent[i]);
        pre.Add(tmp.ToArray());

        tmp.Clear();

        for (var i = s.Value.Last() + 1; i < sent.Length; i++)
          tmp.Add(sent[i]);
        post.Add(tmp.ToArray());
      }

      if (HighlightCooccurrences)
      {
        InitializeHighlighter();
        Highlight(ref pre);
        Highlight(ref post);
      }

      var phrase = string.Join(" ", LayerQueryPhrase);

      BranchPre = new FlowNode(phrase);
      foreach (var x in pre)
        BranchPre.Merge(x.ToList(), FlowNodeDirection.Backward);
      if (AutoJoin)
        BranchPre.Join(FlowNodeDirection.Backward);

      BranchPost = new FlowNode(phrase);
      foreach (var x in post)
        BranchPost.Merge(x.ToList(), FlowNodeDirection.Forward);
      if (AutoJoin)
        BranchPost.Join(FlowNodeDirection.Forward);
    }

    private void Highlight(ref List<string[]> list)
    {
      foreach (var x in list)
        for (var i = 0; i < x.Length; i++)
          if (_highlighter.Contains(x[i]))
            x[i] = $"<strong>{x[i]}</strong>";
    }

    private void InitializeHighlighter()
    {
      var block = Selection.CreateBlock<CooccurrenceBlock>();
      block.Calculate();
      var full = block.CooccurrenceSignificance.CompleteDictionaryToFullDictionary();

      _highlighter = new HashSet<string>(
        from x in LayerQueryPhrase where full.ContainsKey(x) from y in full[x] select y.Key);
    }

    protected override bool Validate() { return LayerQueryPhrase != null; }
  }
}