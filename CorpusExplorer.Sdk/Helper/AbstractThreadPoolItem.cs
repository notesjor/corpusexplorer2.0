#region

using System.Threading;

#endregion

namespace CorpusExplorer.Sdk.Helper
{
  /// <summary>
  ///   Abstraktes Item für die Verwendung in einem Threadpool
  /// </summary>
  /// <typeparam name="T">Typ den dieses Item erwartet und verarbeitet.</typeparam>
  public abstract class AbstractThreadPoolItem<T>
  {
    private readonly ManualResetEvent _dontEvent;

    protected AbstractThreadPoolItem(ManualResetEvent doneEvent) { _dontEvent = doneEvent; }

    protected abstract void Calculate(T context);

    public void ThreadPoolCallback(object threadContext)
    {
      Calculate((T) threadContext);
      _dontEvent.Set();
    }
  }
}