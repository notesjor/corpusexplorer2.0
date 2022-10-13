using System.IO;
using System.Reflection;

namespace CorpusExplorer.Terminal.Universal.Helper
{
  public static class PathHelper
  {
    private static string _pathApp;
    private static string _pathCorpora;
    private static string _pathProjects;
    private static string _pathClient;
    private static string _pathBranding;
    private static string _pathLocalize;
    private static bool _initialized = false;

    public static void Initialize()
    {
      if(_initialized)
        return;

      _pathApp = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      _pathCorpora = Path.Combine(_pathApp, "Corpora");
      _pathProjects = Path.Combine(_pathApp, "Projects");
      _pathClient = Path.Combine(_pathApp, "App", "Client");
      _pathBranding = Path.Combine(_pathApp, "App", "Branding");
      _pathLocalize = Path.Combine(_pathApp, "App", "Localize");
      
      _initialized = true;
    }

    public static string PathApp
    {
      get
      {
        Initialize();
        return _pathApp;
      }
    }

    public static string PathCorpora
    {
      get
      {
        Initialize();
        return _pathCorpora;
      }
    }

    public static string PathProjects
    {
      get
      {
        Initialize();
        return _pathProjects;
      }
    }

    public static string PathClient
    {
      get
      {
        Initialize();
        return _pathClient;
      }
    }

    public static string PathBranding
    {
      get
      {
        Initialize();
        return _pathBranding;
      }
    }

    public static string PathLocalize
    {
      get
      {
        Initialize();
        return _pathLocalize;
      }
    }
  }
}
