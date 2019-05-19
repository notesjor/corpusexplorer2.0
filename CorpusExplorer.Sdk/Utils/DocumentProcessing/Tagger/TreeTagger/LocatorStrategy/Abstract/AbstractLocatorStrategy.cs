using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.TreeTagger.LocatorStrategy.Abstract
{
  public abstract class AbstractLocatorStrategy
  {
    public string TreeTaggerRootDirectory => Configuration.GetDependencyPath(@"TreeTagger");

    /// <summary>
    /// Listet alle verfügbaren Sprachen auf.
    /// </summary>
    public abstract IEnumerable<string> AvailableLanguages { get; }

    /// <summary>
    /// Bereitet eine Annotation mit der angegebenen Sprache vor.
    /// </summary>
    /// <param name="language">Die gewählte Sprache</param>
    /// <param name="temporaryFile">Pfad unter dem ggf. eine Datei gespeichert werden kann.</param>
    public abstract string ApplyLanguage(string language, string temporaryFile = null);

    /// <summary>
    /// Überprüft, ob die Sprache verfügbar ist.
    /// </summary>
    /// <param name="language">Sprache</param>
    /// <returns>Sprache verfügbar?</returns>
    public abstract bool ValidateLanguageSelection(string language);
  }
}
