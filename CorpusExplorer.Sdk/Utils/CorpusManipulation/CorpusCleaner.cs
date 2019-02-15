using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;

namespace CorpusExplorer.Sdk.Utils.CorpusManipulation
{
  public static class CorpusCleaner
  {
    public static AbstractCorpusAdapter Clean(IHydra input, AbstractCorpusBuilder builder = null)
    {
      if (builder == null)
        builder = new CorpusBuilderWriteDirect();

      var corpus = input.ToCorpus(builder);
      foreach (var layer in corpus.Layers)
      {
        var dict = layer.ReciveRawReverseLayerDictionary();
        var nonexsits = new HashSet<int>(dict.Select(x => x.Key));

        foreach (var dsel in layer.DocumentGuids)
        {
          var doc = layer[dsel];
          foreach (var s in doc)
          foreach (var w in s)
            if (nonexsits.Contains(w))
              nonexsits.Remove(w);
        }

        if (nonexsits.Count == 0)
          continue;

        foreach (var x in nonexsits)
          dict.Remove(x);

        layer.ResetRawReverseLayerDictionary(dict);
      }

      return corpus;
    }

    public static void Clean(IHydra input, AbstractCorpusBuilder builder, string outputPath)
    {
      Clean(input, builder).Save(outputPath, false);
    }
  }
}
