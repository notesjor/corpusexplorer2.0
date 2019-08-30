using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Helper
{
  public static class ThreadPoolHelper
  {
    public static void WaitForAll()
    {
      while (true)
      {
        ThreadPool.GetMaxThreads(out var work, out _);
        ThreadPool.GetAvailableThreads(out var avail, out _);

        if (work == avail)
          break;

        Thread.Sleep(2000);
      }
    }
  }
}
