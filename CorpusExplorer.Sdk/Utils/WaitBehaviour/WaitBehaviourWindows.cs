using System;
using CorpusExplorer.Sdk.Utils.WaitBehaviour.Abstract;

namespace CorpusExplorer.Sdk.Utils.WaitBehaviour
{
  public class WaitBehaviourWindows : AbstractWaitBehaviour
  {
    public override void Wait()
    {
      while (true)
      {
        var command = Console.ReadLine();
        if (command == "quit" || command == "exit")
          break;
      }
    }
  }
}