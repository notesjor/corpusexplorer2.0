#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Bcs.Addon.Interfaces;
using CorpusExplorer.Sdk.Diagnostic;

#endregion

namespace Bcs.Addon
{
  /// <summary>
  /// </summary>
  public sealed class AddonHost : IAddonHost
  {
    private readonly IAddonHost _parentHost;
    private List<IAddon> _addons = new List<IAddon>();

    /// <summary>
    ///   Initializes a new instance of the <see cref="AddonHost" /> class.
    /// </summary>
    /// <param name="window">Fenster das visuelle Addons ansprechen können.</param>
    /// <param name="parentHost">AddonHost-Container</param>
    public AddonHost(IHostWindow window = null, IAddonHost parentHost = null)
    {
      Window = window;
      _parentHost = parentHost ?? this;
      if (Window != null)
        Window.AddonHost = this;
    }

    /// <summary>
    ///   Listet alle verfügbaren Addons auf
    /// </summary>
    /// <value>The available addons.</value>
    public IAddon[] AvailableAddons => _addons.ToArray();

    /// <summary>
    ///   Gibt das Addon mit dem eindeutigen Bezeichner zurück
    /// </summary>
    /// <param name="guid">
    ///   Eindeutiger Bezeichner des Addon
    /// </param>
    /// <returns>
    ///   Addon (Im Fehlerfall: null)
    /// </returns>
    public IAddon GetAddonBy(string guid)
    {
      return _addons.Find(x => x.Guid == guid);
    }

    /// <summary>
    ///   Dem AddonHost zugeordnetes <see cref="Window" /> (WPF) oder Form
    ///   (WinForm)
    /// </summary>
    public IHostWindow Window { get; }

    /// <summary>
    ///   Sucht in einem Verzeichnis nach Dateien die Addon
    ///   enthalten
    /// </summary>
    /// <param name="directory">Verzeichnisspfad</param>
    /// <param name="searchPattern">Suchpattern für die Dateisuche</param>
    public void SearchInDirectoryForAddons(string directory = null, string searchPattern = "*.dll")
    {
      var addons = new List<IAddon>();

      try
      {
        directory = GetDirectoryPath(directory);
        if (!Directory.Exists(directory))
          return;

        var files = Directory.GetFiles(directory, searchPattern, SearchOption.TopDirectoryOnly);

        foreach (var file in files)
          try
          {
            if (new FileInfo(file).Length < 1)
              continue;

            var assembly = Assembly.LoadFrom(file);
            var types = assembly.GetTypes();

            foreach (var type in types)
              try
              {
                if (!type.IsPublic  ||
                    type.IsAbstract ||
                    type.GetInterface("Bcs.Addon.Interfaces.IAddon", true) == null)
                  continue;

                var temp = Activator.CreateInstance(assembly.GetType(type.ToString())) as IAddon;
                if (temp == null)
                  return;

                temp.AddonHost = _parentHost;
                if (addons.FindIndex(x => x.Guid == temp.Guid) == -1)
                  addons.Add(temp);
              }
              catch (Exception ex)
              {
                InMemoryErrorConsole.Log(ex);
              }
          }
          catch (ReflectionTypeLoadException ex)
          {
            if (file.Contains("Hunspellx"))
              continue;
            if (file.EndsWith("udpipe_csharp.dll"))
              continue;
            if (ex is BadImageFormatException)
              continue;

            InMemoryErrorConsole.Log(file);
            foreach (var x in ex.LoaderExceptions)
              InMemoryErrorConsole.Log(x);
            InMemoryErrorConsole.Log(ex);
          }
          catch (Exception ex)
          {
            if (file.Contains("Hunspellx"))
              continue;
            if (file.EndsWith("udpipe_csharp.dll"))
              continue;
            if(ex is BadImageFormatException)
              continue;

            InMemoryErrorConsole.Log(ex);
          }
      }
      // ReSharper disable once EmptyGeneralCatchClause
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
      }

      addons.Sort((x, y) => (byte) x.LoadPriority - (byte) y.LoadPriority);
      _addons = addons;
    }

    /// <summary>
    ///   Beendet den <see cref="AddonHost" /> und entläd alle Plugins
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    public void ShutDown()
    {
      try
      {
        _addons.Sort((x, y) => (byte) y.LoadPriority - (byte) x.LoadPriority);

        var ts = _addons.Select(addon =>
        {
          var t = new Task(
                           () =>
                           {
                             addon.Stop();
                             addon.Terminate();
                             _addons.Remove(addon);
                           });
          t.Start();
          return t;
        }).ToArray();
        Task.WaitAll(ts);
      }
      // ReSharper disable once EmptyGeneralCatchClause
      catch
      {
      }
    }

    private static string GetDirectoryPath(string directory)
    {
      return string.IsNullOrEmpty(directory)
               ? Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
               : directory;
    }
  }
}