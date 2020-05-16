using System.Threading;
using CorpusExplorer.Sdk.Utils.WaitBehaviour.Abstract;

namespace CorpusExplorer.Sdk.Utils.WaitBehaviour
{
  public class WaitBehaviourLinux : AbstractWaitBehaviour
  {
    public override void Wait()
    {
      while (true)
        Thread.Sleep(25000);
    }
  }
}
