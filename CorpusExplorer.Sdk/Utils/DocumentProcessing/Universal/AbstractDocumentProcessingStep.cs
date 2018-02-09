#region

using System;

#endregion

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Universal
{
  [Serializable]
  public abstract class AbstractDocumentProcessingStep<T>
  {
    public abstract string DisplayName { get; }
    public abstract bool IsReady { get; }
    public abstract T Execute();
  }
}