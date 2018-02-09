#region

using System.Collections.Generic;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;

#endregion

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract
{
  public abstract class AbstractTagger
    : AbstractDocumentProcessingStepFull<Dictionary<string, object>, AbstractCorpusAdapter>
  {
    public AbstractCorpusBuilder CorpusBuilder { get; set; } = new CorpusBuilderWriteDirect();
    public abstract string InstallationPath { get; set; }
    public abstract IEnumerable<string> LanguagesAvailabel { get; }
    public abstract string LanguageSelected { get; set; }
  }
}