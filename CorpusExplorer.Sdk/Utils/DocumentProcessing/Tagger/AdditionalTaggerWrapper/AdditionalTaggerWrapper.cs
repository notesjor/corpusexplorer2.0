using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.AdditionalTaggerWrapper.Model;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.AdditionalTaggerWrapper
{
  public class AdditionalTaggerWrapper : AbstractAdditionalTagger
  {
    private readonly AbstractTagger tagger;

    public AdditionalTaggerWrapper(AbstractTagger tagger)
    {
      this.tagger = tagger;
      DisplayName = tagger.DisplayName;
    }

    public override string DisplayName { get; }

    protected override void Cleanup()
    {
      while (tagger.Output.Count > 0)
        tagger.Output.TryDequeue(out var obj);
    }

    protected override IEnumerable<AbstractLayerState> ExecuteCall(ref AbstractCorpusAdapter corpus)
    {
      foreach (var dsel in corpus.DocumentGuids)
        tagger.Input.Enqueue(corpus.GetDocumentRaw(dsel));

      tagger.Execute();
      foreach (var x in tagger.Output.OfType<AdditionalTaggerWrapperCorpus>())
        foreach (var y in x.AdditionalTaggerWrapperLayers.Where(y => y.AbstractLayerState.Displayname != "Wort"))
          y.AbstractLayerState.Displayname = $"{y.AbstractLayerState.Displayname} ({DisplayName})";

      return tagger.Output.OfType<AdditionalTaggerWrapperCorpus>()
                          .SelectMany(x => x.AdditionalTaggerWrapperLayers
                          .Where(l=> l.AbstractLayerState.Displayname != "Wort")
                          .Select(y => y.AbstractLayerState));
    }

    protected override void Initialize()
    {
      tagger.CorpusBuilder = new AdditionalTaggerWrapperCorpusBuilder();
    }
  }
}
