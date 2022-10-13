using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Special
{
  public static class AdditionalTagger
  {
    public static void AddAnnotation(this Selection selection, AbstractTagger tagger)
    {
      AddAnnotation(selection.GetParentProject(), tagger);
    }

    public static void AddAnnotation(this Project project, AbstractTagger tagger)
    {
      foreach (var corpus in project.CorporaGuids)
        AddAnnotation(project.GetCorpus(corpus), tagger);
    }

    public static void AddAnnotation(this AbstractCorpusAdapter corpus, AbstractTagger tagger)
    {
      var layer = corpus.GetLayers("Wort").ToArray().FirstOrDefault();

      var docs = new Dictionary<Guid, int>();

      foreach (var guid in corpus.DocumentGuids)
      {
        var stream = layer.GetReadableDocumentByGuid(guid).ReduceDocumentToStreamDocument().ToArray();
        tagger.Input.Enqueue(
                             new Dictionary<string, object>
                             {
                               {"Text", string.Join(Environment.NewLine, stream)},
                               {"GUID", guid}
                             });
        docs.Add(guid, stream.Length);
      }

      tagger.Execute();
      if (!tagger.Output.TryDequeue(out var output))
        return;
      if (output == null)
        return;

      var ignore = new HashSet<string>(corpus.LayerDisplaynames);
      foreach (var l in output.LayerGuidAndDisplaynames)
      {
        if (ignore.Contains(l.Value))
          continue;

        corpus.AddLayer(output.GetLayer(l.Key));
      }
    }
  }
}