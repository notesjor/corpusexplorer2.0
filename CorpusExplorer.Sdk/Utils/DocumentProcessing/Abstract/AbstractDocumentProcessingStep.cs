using System;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract
{
  [Serializable]
  public abstract class AbstractDocumentProcessingStep
  {
    public abstract string DisplayName { get; }
    public abstract void Execute();
  }
}