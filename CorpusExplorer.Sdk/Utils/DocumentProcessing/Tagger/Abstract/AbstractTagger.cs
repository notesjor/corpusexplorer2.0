#region

using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer.Abstract;
using System.Collections.Generic;

#endregion

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract
{
  public abstract class AbstractTagger
    : AbstractDocumentProcessingStepFull<Dictionary<string, object>, AbstractCorpusAdapter>
  {
    public AbstractCorpusBuilder CorpusBuilder { get; set; } = new CorpusBuilderWriteDirect();
    public AbstractTokenizer Tokenizer { get; set; }
    public abstract string InstallationPath { get; set; }
    public abstract IEnumerable<string> LanguagesAvailabel { get; }
    public abstract string LanguageSelected { get; set; }
  }
}