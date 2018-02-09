using IWshRuntimeLibrary;

namespace CorpusExplorer.Installer.VirtualHost
{
  public static class Shortcut
  {
    #region Public Methods and Operators

    public static void Create(
      string appPath,
      string arguments,
      string shortcutPath,
      string shortcutName,
      string workDirectory)
    {
      var wshShell = new WshShell();
      var NewShortcut =
        (IWshShortcut) wshShell.CreateShortcut($"{shortcutPath}\\{shortcutName}.lnk");

      NewShortcut.TargetPath = appPath;
      NewShortcut.Arguments = arguments;
      NewShortcut.WindowStyle = 1;
      NewShortcut.IconLocation = $"{appPath},0";
      NewShortcut.WorkingDirectory = workDirectory;
      NewShortcut.Save();
    }

    #endregion
  }
}