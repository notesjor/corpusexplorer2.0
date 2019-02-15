#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
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

    private static readonly Queue<KeyValuePair<DateTime, Exception>> _queue =
      new Queue<KeyValuePair<DateTime, Exception>>();

    private static TelemetrieClient _telemetryClient;

    public static IEnumerable<KeyValuePair<DateTime, Exception>> Errors => _queue;

    public static bool ShowErrorConsoleOnAppCrash => !_insightAllowed;

    public static void Clear()
    {
      if (_insightAllowed)
      {
        _telemetryClient.Flush().Wait();
      }

      _queue.Clear();
    }

    public static void InsightSetup()
    {
      try
      {
        const string insigtFile = "insight.id";
        if (File.Exists(insigtFile))
        {
          _insigtId = File.ReadAllText(insigtFile);
          _insightAllowed = !string.IsNullOrEmpty(_insigtId);
          GetLocation(out var country, out var city);

          if (_insightAllowed)
          {
            _telemetryClient = new TelemetrieClient(_insigtId, "212.224.95.216", 8512, country, city);
          }
        }
      }
      catch
      {
      }

      _insightChecked = true;
    }

    private static void GetLocation(out string country, out string city)
    {
      country = "";
      city = "";
      try
      {
        const string insigtFile = "insight.loc";
        if (File.Exists(insigtFile))
        {
          var lines = File.ReadAllLines(insigtFile, Encoding.UTF8);
          if (lines.Length < 2)
            return;
          country = lines[0];
          city = lines[1];
        }
      }
      catch
      {
        // ignore
      }
    }

    // ReSharper disable once UnusedMember.Global
    public static void Log(string message)
    {
      Log(new Exception(message));
    }

    public static void Log(Exception ex)
    {
      if (!_insightChecked)
        InsightSetup();

      // ReSharper disable once PossibleNullReferenceException
      while (_queue.Count > _max)
        _queue.Dequeue();

      _queue.Enqueue(new KeyValuePair<DateTime, Exception>(DateTime.Now, ex));

      if (_insightAllowed) _telemetryClient.SendTelemetrie(ex);
    }

    public static void SendAppCrash(Exception ex)
    {
      if (!_insightChecked)
        InsightSetup();

      _telemetryClient.SendPublicCrashReport(ex);
    }

    public static void Save(string path)
    {
      var stb = new StringBuilder();

      foreach (var error in Errors)
        try
        {
          if (error.Value.InnerException == null)
            stb.AppendFormat("{0}\r\n{1}\r\n{2}\r\n---\r\n", error.Key, error.Value.Message, error.Value.StackTrace);
          else
            stb.AppendFormat(
                             "{0}\r\n{1}\r\n>\t{3}\r\n{2}\r\n>\t{4}\r\n---\r\n",
                             error.Key,
                             error.Value.Message,
                             error.Value.StackTrace,
                             error.Value.InnerException.Message,
                             error.Value.InnerException.StackTrace);
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