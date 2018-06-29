using System.Linq;
using CorpusExplorer.Sdk.Ecosystem.Model;
using NTextCat;

namespace CorpusExplorer.Sdk.Extern.Plaintext.WET
{
  public class LanguageFilter
  {
    private readonly RankedLanguageIdentifierFactory _factory;
    private readonly RankedLanguageIdentifier _identifier;
    private readonly string _language;

    public LanguageFilter(string language)
    {
      _language = language;
      _factory = new RankedLanguageIdentifierFactory();
      _identifier = _factory.Load(Configuration.GetDependencyPath("NTextCat/Wiki280.profile.xml"));
    }

    public bool Match(string text)
    {
      var match = _identifier.Identify(text).FirstOrDefault();
      return match?.Item1 != null && match.Item1.Iso639_3 == _language;
    }
  }
}