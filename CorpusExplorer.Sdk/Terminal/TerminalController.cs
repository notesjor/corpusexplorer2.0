#region

using System;
using System.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model;

#endregion

namespace CorpusExplorer.Sdk.Terminal
{
  /// <summary>
  ///   The terminal controler.
  /// </summary>
  public class TerminalController
  {
    private object _projectLock = new object();
    private Project _project = null;

    /// <summary>
    ///   Initializes a new instance of the <see cref="TerminalController" /> class.
    /// </summary>
    internal TerminalController()
    {
    }

    public bool HasProjectStoredToHarddisk => !string.IsNullOrEmpty(ProjectPath);

    /// <summary>
    ///   Gets or sets the project.
    /// </summary>
    public Project Project
    {
      get
      {
        lock (_projectLock)
          return _project;
      }
      private set
      {
        lock (_projectLock)
          _project = value;
      }
    }

    public string ProjectPath { get; private set; }

    /// <summary>
    ///   The project load.
    /// </summary>
    /// <param name="path">
    ///   The path.
    /// </param>
    public void ProjectLoad(string path, string forceCorpusRoot = null)
    {
      Project = Project.Load(path, forceCorpusRoot);
      ProjectPath = path;
    }

    /// <summary>
    ///   The project new.
    /// </summary>
    /// <param name="clearOldProject">Wenn true, wird ein zuvor erstelltes Projekt gelöscht. False - um Multi-Project-Handling zu aktivieren.
    /// Achtung: Sie sollten beim setzen von false das Projekt (A) selbst verwalten (B) Multithrad-Resistent machen
    /// </param>
    /// <example>
    /// Project project;
    /// lock (_lockState)
    /// {
    ///   terminal.ProjectNew(false);
    ///   project = terminal.Project;
    /// }
    /// </example>
    public Project ProjectNew(bool clearOldProject = true, bool invokeGarbageCollector = true)
    {
      lock (_projectLock)
      {
        if (clearOldProject && _project != null)
        {
          _project.Clear();
          if (invokeGarbageCollector)
            GC.Collect();
        }

        _project = Project.Create();
        ProjectPath = null;
        return _project;
      }
    }

    /// <summary>
    ///   The project save.
    /// </summary>
    public void ProjectSave(string path = null, bool saveFullCorpusPath = true)
    {
      if (string.IsNullOrEmpty(path))
        path = ProjectPath;
      if (string.IsNullOrEmpty(path))
        path = Path.Combine(Configuration.MyProjects, Project.Displayname + ".proj5");

      lock (_projectLock)
        _project.Save(path, saveFullCorpusPath);
    }
  }
}