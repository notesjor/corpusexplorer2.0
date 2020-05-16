using System.Collections.Generic;
using System.Linq;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup.Abstract;
using NTextCat;

namespace CorpusExplorer.Sdk.Extern.NTextCat
{
  public class NTextCatLanguageCleanup : AbstractCleanup
  {
    private readonly RankedLanguageIdentifierFactory _factory;
    private readonly RankedLanguageIdentifier _identifier;
    public string Language { get; set; } = "de";
    public IEnumerable<string> AvailableLanguages { get; private set; }

    public NTextCatLanguageCleanup()
    {
      _factory = new RankedLanguageIdentifierFactory();
      _identifier = _factory.Load(Configuration.GetDependencyPath("NTextCat/Wiki280.profile.xml"));
      AvailableLanguages = FileIO.ReadLines(Configuration.GetDependencyPath("NTextCat/ntextcat.list"));
    }

    public bool Match(string text)
    {
      var match = _identifier.Identify(text).FirstOrDefault();
      return match?.Item1 != null && match.Item1.Iso639_3 == Language;
    }

    public override string DisplayName => "NTextCat";

    protected override string Execute(string key, string input) => Match(input) ? input : null;
  }
}
