#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

#endregion

namespace CorpusExplorer.Sdk.Diagnostic
{
  public static class InMemoryErrorConsole
  {
    private static readonly int _max = 1000;
    public static event OnLogEventHandler OnException;

    private static readonly Queue<KeyValuePair<DateTime, Exception>> _queue = new Queue<KeyValuePair<DateTime, Exception>>();

    private static object _lockQueue = new object();

    public static IEnumerable<KeyValuePair<DateTime, Exception>> Errors
    {
      get
      {
        lock (_lockQueue)
          return _queue;
      }
    }

    public static void Clear()
    {
      lock (_lockQueue)
        _queue.Clear();
    }

    public static void Log(string message)
      => Log(new Exception(message));

    public static void Log(Exception ex)
    {
      lock (_lockQueue)
      {
        while (_queue.Count > _max)
          _queue.Dequeue();

        _queue.Enqueue(new KeyValuePair<DateTime, Exception>(DateTime.Now, ex));
      }

      OnException?.Invoke(ex);
    }

    public static void Save(string path)
    {
      var stb = new StringBuilder();

      foreach (var error in Errors)
        try
        {
          stb.AppendFormat(error.Value.InnerException == null
                             ? $"{error.Key}\r\n{error.Value.GetType().Name}\r\n{error.Value.Message}\r\n{error.Value.StackTrace}\r\n---\r\n"
                             : $"{error.Key}\r\n{error.Value.GetType().Name}\r\n{error.Value.Message}\r\n{error.Value.StackTrace}\r\n>>>\r\n{error.Value.InnerException.GetType().Name}\r\n{error.Value.InnerException.Message}\r\n>\t{error.Value.InnerException.StackTrace}\r\n---\r\n");
        }
        catch
        {
          // ignore
        }

      File.WriteAllText(path, stb.ToString());
    }
  }
}