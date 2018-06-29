using System;
using System.IO;
using Bcs.IO;
using CorpusExplorer.Sdk.Diagnostic;

namespace CorpusExplorer.Terminal.WinForm.Forms.Insight
{
  public static class InsightController
  {
    private const string _askForPermissionFlag = "insight.no";
    private const string _insightId = "insight.id";

    public static bool AskForPermission => !File.Exists(_askForPermissionFlag);

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
  }
}