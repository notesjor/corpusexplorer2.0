#region

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
    public Project Project { get; set; }

    public string ProjectPath { get; private set; }

    /// <summary>
    ///   The project load.
    /// </summary>
    /// <param name="path">
    ///   The path.
    /// </param>
    public void ProjectLoad(string path)
    {
      Project = Project.Load(path);
      ProjectPath = path;
    }

    /// <summary>
    ///   The project new.
    /// </summary>
    public void ProjectNew()
    {
      Project = Project.Create();
      ProjectPath = null;
    }

    /// <summary>
    ///   The project save.
    /// </summary>
    public void ProjectSave(string path = null)
    {
      if (string.IsNullOrEmpty(path))
        path = ProjectPath;
      if (string.IsNullOrEmpty(path))
        path = Path.Combine(Configuration.MyProjects, Project.Displayname + ".proj5");

      Project.Save(path);
    }
  }
}