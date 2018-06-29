using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  public class WordListBlock : AbstractBlock
  {
    public WordListBlock()
    {
      LayerDisplayname = "Wort";
    }

    /// <summary>
    ///   Gets or sets the layer displayname.
    /// </summary>
    public string LayerDisplayname { get; set; }

    public HashSet<string> WordList { get; set; }

    public override void Calculate()
    {
      WordList = new HashSet<string>();
      var layers = Selection.GetLayers(LayerDisplayname);
      foreach (var l in layers)
      {
        var values = l.Values;
        foreach (var v in values)
          WordList.Add(v);
      }
    }
  }
}