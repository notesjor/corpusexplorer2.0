#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.VisualBasic.Devices;

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

    private static TelemetryClient _telemetryClient;

    public static IEnumerable<KeyValuePair<DateTime, Exception>> Errors => _queue;

    public static bool ShowErrorConsoleOnAppCrash => !_insightAllowed;

    public static void Clear()
    {
      if (_insightAllowed)
      {
        _telemetryClient.Flush();
        Thread.Sleep(1000);
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

          if (_insightAllowed)
          {
            _telemetryClient = new TelemetryClient { InstrumentationKey = "4a02d22c-737b-4af1-af78-b150fb346d98" };
            _telemetryClient.Context.User.Id = _insigtId;
            _telemetryClient.Context.Session.Id = Guid.NewGuid().ToString();

            var ci = new ComputerInfo();

            _telemetryClient.Context.Device.OperatingSystem = ci.OSFullName;
            _telemetryClient.Context.Properties.Add("CPU", Environment.ProcessorCount.ToString());
            _telemetryClient.Context.Properties.Add("RAM", ci.TotalPhysicalMemory.ToString());
          }
        }
      }
      catch
      {
      }

      _insightChecked = true;
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

      if (_insightAllowed) _telemetryClient.TrackException(ex);
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

    public static void TrackEvent(string @event, Dictionary<string, string> properties = null,
      Dictionary<string, double> metrics = null)
    {
      if (!_insightChecked)
        InsightSetup();

      if (!_insightAllowed)
        return;

      if (!_insightAllowed)
        return;

      _telemetryClient.TrackEvent(@event, properties, metrics);
    }

    public static void TrackPageView(string page)
    {
      if (!_insightChecked)
        InsightSetup();

      if (!_insightAllowed)
        return;

      if (!_insightAllowed)
        return;

      _telemetryClient.TrackPageView(page);
    }
  }
}