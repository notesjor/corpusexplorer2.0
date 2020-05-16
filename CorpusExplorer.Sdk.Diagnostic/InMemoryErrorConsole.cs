#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenSourceTelemetrieClient;

#endregion

namespace CorpusExplorer.Sdk.Diagnostic
{
  public static class InMemoryErrorConsole
  {
    private static bool _insightAllowed;
    private static bool _insightChecked;
    private static string _insigtId;
    private static readonly int _max = 1000;

    private static string _pathId = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                                 @"CorpusExplorer\App\insight.id");
    private static string _pathLo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                                 @"CorpusExplorer\App\insight.loc");

    public static event OnLogEventHandler OnException;

    private static readonly Queue<KeyValuePair<DateTime, Exception>> _queue =
      new Queue<KeyValuePair<DateTime, Exception>>();

    private static TelemetrieClient _telemetryClient;

    public static IEnumerable<KeyValuePair<DateTime, Exception>> Errors => _queue;

    public static bool ShowErrorConsoleOnAppCrash => !_insightAllowed;

    public static void Clear()
    {
      if (_insightAllowed)
      {
        _telemetryClient.Flush();
      }

      _queue.Clear();
    }

    public static void InsightSetup()
    {
      try
      {
        if (File.Exists(_pathId))
        {
          _insigtId = File.ReadAllText(_pathId);
          _insightAllowed = !string.IsNullOrEmpty(_insigtId);
          GetLocation(out var country, out var city);

          if (_insightAllowed)
          {
            _telemetryClient = new TelemetrieClient(_insigtId, "81.30.156.64", 8512, country, city);
          }
        }
      }
      catch
      {
        // ignore
      }

      _insightChecked = true;
    }

    private static void GetLocation(out string country, out string city)
    {
      country = "";
      city = "";
      try
      {
        if (!File.Exists(_pathLo)) 
          return;

        var lines = File.ReadAllLines(_pathLo, Encoding.UTF8);
        if (lines.Length < 2)
          return;
        country = lines[0];
        city = lines[1];
      }
      catch
      {
        // ignore
      }
    }

    public static void Log(string message) 
      => Log(new Exception(message));

    public static void Log(Exception ex)
    {
      if (!_insightChecked)
        InsightSetup();

      // ReSharper disable once PossibleNullReferenceException
      while (_queue.Count > _max)
        _queue.Dequeue();

      _queue.Enqueue(new KeyValuePair<DateTime, Exception>(DateTime.Now, ex));

      if (_insightAllowed) _telemetryClient.SendTelemetrie(ex);
      OnException?.Invoke(ex);
    }

    public static void SendAppCrash(Exception ex)
    {
      try
      {
        if (!_insightChecked)
          InsightSetup();

        _telemetryClient.SendPublicCrashReport(ex);
      }
      catch
      {
        // ignore
      }
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

    public static void TrackEvent(string @event, double metric)
    {
      if (!_insightChecked)
        InsightSetup();

      if (!_insightAllowed)
        return;

      if (!_insightAllowed)
        return;

      _telemetryClient.SendTelemetrie(@event, metric);
    }

    public static void TrackEvent(Dictionary<string, double> metrics)
    {
      if (!_insightChecked)
        InsightSetup();

      if (!_insightAllowed)
        return;

      if (!_insightAllowed)
        return;

      _telemetryClient.SendTelemetrie(metrics);
    }

    public static void TrackPageView(string page)
    {
      if (!_insightChecked)
        InsightSetup();

      if (!_insightAllowed)
        return;

      if (!_insightAllowed)
        return;

      _telemetryClient.SendTelemetrie(page);
    }
  }
}