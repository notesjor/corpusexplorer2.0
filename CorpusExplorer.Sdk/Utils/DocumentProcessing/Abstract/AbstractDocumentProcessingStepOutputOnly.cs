using System;
using System.Collections.Concurrent;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract
{
  [Serializable]
  public abstract class AbstractDocumentProcessingStepOutputOnly<TO> : AbstractDocumentProcessingStep
  {
    public ConcurrentQueue<TO> Output { get; set; } = new ConcurrentQueue<TO>();
  }
}