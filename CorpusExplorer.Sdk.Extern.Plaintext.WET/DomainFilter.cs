using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CorpusExplorer.Sdk.Extern.Plaintext.WET
{
  public class DomainFilter
  {
    private readonly Regex _regex =
      new Regex(
        @"^(http\:\/\/|https\:\/\/|)((?:www\.)?(?:\w[-\w]{0-61}\w|\w)(?:\.\w[-\w]{0-61}\w|\w)*?)\.((?:\w{2-3}\.)?\w+)");

    private readonly HashSet<string> _tldFilter;

    public DomainFilter(HashSet<string> tldFilter)
    {
      _tldFilter = tldFilter;
    }

    public bool Match(string url)
    {
      if (_tldFilter == null || _tldFilter.Count == 0)
        return true;

      var match = _regex.Match(url);
      var group = match.Groups[2].Value;

      return _tldFilter.Contains(group);
    }
  }
}