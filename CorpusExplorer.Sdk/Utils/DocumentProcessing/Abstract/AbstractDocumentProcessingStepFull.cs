#region

using System;
using System.Collections.Concurrent;

#endregion

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract
{
  [Serializable]
  public abstract class AbstractDocumentProcessingStepFull<TI, TO> : AbstractDocumentProcessingStepOutputOnly<TO>
  {
    public ConcurrentQueue<TI> Input { get; set; } = new ConcurrentQueue<TI>();
  }
}