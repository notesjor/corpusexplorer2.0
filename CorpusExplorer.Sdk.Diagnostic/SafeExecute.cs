using System;

namespace CorpusExplorer.Sdk.Diagnostic
{
  public static class SafeExecute
  {
    // ReSharper disable once UnusedMember.Global
    public static void Call(Action action)
    {
      try
      {
        action();
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
      }
    }

    public static T Call<T>(Func<T> func, T defaultReturn)
    {
      try
      {
        return func();
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
        return defaultReturn;
      }
    }
  }
}