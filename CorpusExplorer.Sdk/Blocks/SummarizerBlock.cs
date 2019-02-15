using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  public class SummarizerBlock : AbstractSimple1LayerBlock
  {
    private readonly object _dsLock = new object();
    private Dictionary<Guid, Dictionary<string, double>> _idtdf;

    public SummarizerBlock()
    {
      LayerDisplayname = "Wort";
    }

    public Dictionary<Guid, string> DocumentSummarizes { get; set; }
    public string EmptyPlaceholder { get; set; } = " [...] ";
    public int MaxCharCountPerSentence { get; set; } = 200;
    public int MaxSentenceCount { get; set; } = 5;
    public int MaxTfIdfCount { get; set; } = 100;

    protected override void CalculateCall(AbstractCorpusAdapter corpus, AbstractLayerAdapter layer, Guid dsel,
                                          int[][] doc)
    {
      if (_idtdf[dsel] == null || _idtdf[dsel].Count == 0)
        return;

      var max = _idtdf[dsel].Max(x => x.Value);
      var vec = _idtdf[dsel].OrderByDescending(x => x.Value).Take(MaxTfIdfCount)
                            .ToDictionary(x => layer[x.Key], x => x.Value / max);

      var sentences = new Dictionary<int, double>();
      var @lock = new object();
      Parallel.For(0, doc.Length, Configuration.ParallelOptions, i =>
      {
        var sum = doc[i].Where(j => vec.ContainsKey(j)).Sum(j => vec[j]);
        lock (@lock)
        {
          sentences.Add(i, sum);
        }
      });

      var select = sentences.OrderByDescending(x => x.Value).Take(MaxSentenceCount).OrderBy(x => x.Key)
                            .Select(x => x.Key).ToArray();
      var stb = new StringBuilder();

      var last = -1;
      var hyph = false;

      foreach (var sid in select)
      {
        if (last > -1 && last + 1 < sid && !hyph) // Wenn die Sätze auseinandergerissen sind
          stb.Append(EmptyPlaceholder);
        if (last > -1 && last + 1 == sid && !hyph) // Wenn die Sätze direkt aneinandergrenzen
          stb.Append(" ");

        hyph = false;
        last = sid;

        var text = Selection.GetReadableDocumentSnippet(dsel, LayerDisplayname, sid, sid).ReduceDocumentToText();
        if (text.Length > MaxCharCountPerSentence) // kürze überlange Sätze ein.
        {
          stb.Append(text.Substring(0, MaxCharCountPerSentence));
          stb.Append(EmptyPlaceholder);
          hyph = true;
        }
        else
        {
          stb.Append(text);
        }
      }

      lock (_dsLock)
      {
        DocumentSummarizes.Add(dsel, stb.ToString());
      }
    }

    protected override void CalculateCleanup()
    {
    }

    protected override void CalculateFinalize()
    {
    }

    protected override void CalculateInitProperties()
    {
      DocumentSummarizes = new Dictionary<Guid, string>();

      var block = Selection.CreateBlock<InverseDocumentVectorBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.Calculate();
      _idtdf = block.InverseDocumentVector;
    }
  }
}