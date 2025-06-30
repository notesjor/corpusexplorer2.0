using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.AdditionalTaggerWrapper.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.AdditionalTaggerWrapper
{
  public class AdditionalTaggerWrapper : AbstractAdditionalTagger
  {
    private readonly AbstractTagger _tagger;

    public AdditionalTaggerWrapper(AbstractTagger tagger)
    {
      _tagger = tagger;
      DisplayName = tagger.DisplayName;
    }

    public override string DisplayName { get; }

    protected override void Cleanup()
    {
      while (_tagger.Output.Count > 0)
        _tagger.Output.TryDequeue(out var obj);
    }

    protected override IEnumerable<AbstractLayerState> ExecuteCall(ref AbstractCorpusAdapter corpus)
    {
      foreach (var dsel in corpus.DocumentGuids)
        _tagger.Input.Enqueue(corpus.GetDocumentRaw(dsel));

      _tagger.Execute();
      var res = _tagger.Output.OfType<AdditionalTaggerWrapperCorpus>()
                          .SelectMany(x => x.AdditionalTaggerWrapperLayers
                          .Select(y => y.AbstractLayerState)).ToArray();

      // ReSharper disable once ForCanBeConvertedToForeach
      for (var i = 0; i < res.Length; i++)
      {  if (res[i].Displayname != "Wort")
          res[i].Displayname = $"{res[i].Displayname} ({DisplayName})"; }

      return res;
    }

    protected override void Initialize()
    {
      _tagger.CorpusBuilder = new AdditionalTaggerWrapperCorpusBuilder(); // Use the AdditionalTaggerWrapperCorpusBuilder to create the corpus
    }
  }
}
