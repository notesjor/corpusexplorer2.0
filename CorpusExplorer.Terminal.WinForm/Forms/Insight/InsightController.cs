using System;
using System.IO;
using System.Text;
using Bcs.IO;
using CorpusExplorer.Sdk.Diagnostic;

namespace CorpusExplorer.Terminal.WinForm.Forms.Insight
{
  public static class InsightController
  {
    private const string _askForPermissionFlag = "insight.no";
    private const string _insightId = "insight.id";

    public static bool AskForPermission
    {
      get
      {
        if (File.Exists(_insightId))
          return false;

        if (!File.Exists(_askForPermissionFlag))
          return true;

        try
        {
          if ((new FileInfo(_askForPermissionFlag)).CreationTime.AddDays(90) >= DateTime.Now) 
            return false;

          File.Delete(_askForPermissionFlag);
          return true;

        }
        catch
        {
          return false;
        }
      }
    }

    public static string InsightId => FileIO.ReadText(_insightId);

    public static bool IsInsightActive => File.Exists(_insightId) && new FileInfo(_insightId).Length == 36;

    public static void NeverAskAgain()
    {
      if (!File.Exists(_askForPermissionFlag))
        File.Create(_askForPermissionFlag);
    }

    public static void NewInstallationId()
    {
      if (File.Exists(_insightId))
        File.Delete(_insightId);
      SetInsightStatus(true);
      InMemoryErrorConsole.InsightSetup();
    }

    public static void SetInsightStatus(bool status)
    {
      if (status)
      {
        if (!File.Exists(_insightId) || new FileInfo(_insightId).Length != 36)
          FileIO.Write(_insightId, Guid.NewGuid().ToString());
      }
      else
      {
        if (File.Exists(_insightId))
          File.Delete(_insightId);
      }

      NeverAskAgain();
    }

    public static void SetLocation(string country, string city)
    {
      try
      {
        File.WriteAllLines("insight.loc", new[] { country, city }, Encoding.UTF8);
      }
      catch
      {
        // ignore
      }
    }
  }
}