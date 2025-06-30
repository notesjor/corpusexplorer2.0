using Newtonsoft.Json;
using System.Linq;

namespace CorpusExplorer.Terminal.WinForm.Forms.Dashboard
{
  public class AddonItem
  {
    /// <summary>
    /// Examples: "Test-Korpus (Tweets)" (Addons/Corpora)
    /// </summary>
    [JsonProperty("Name")]
    public string Name { get; set; }

    /// <summary>
    /// Examples: "3 MB" (Addons/Corpora)
    /// </summary>
    [JsonProperty("SizeFile")]
    public string SizeFile { get; set; }

    /// <summary>
    /// Examples: "1,61 Tsd." (only Corpora)
    /// </summary>
    [JsonProperty("SizeTokens")]
    public string SizeTokens { get; set; }

    /// <summary>
    /// Examples: "k. A." (only Corpora)
    /// </summary>
    [JsonProperty("SizeSentences")]
    public string SizeSentences { get; set; }

    /// <summary>
    /// Examples: "27,7 Tsd." (only Corpora)
    /// </summary>
    [JsonProperty("SizeDocuments")]
    public string SizeDocuments { get; set; }

    /// <summary>
    /// Examples: "Wort, POS, Lemma, Phrase" (only Corpora)
    /// </summary>
    [JsonProperty("Layer")]
    public string Layer { get; set; }

    /// <summary>
    /// Examples: "http://www.bitcutstudios.com/products/CorpusExplorer/corpora/standard/Demo03.ceAddon" (Addons/Corpora)
    /// </summary>
    [JsonProperty("UrlPack")]
    public string UrlPack { get; set; }

    [JsonIgnore]
    public string RemoveInfo => UrlPack.Split(new[] { "/" }, System.StringSplitOptions.RemoveEmptyEntries).Last();

    /// <summary>
    /// Examples: "http://www.corpusexplorer.de/" (Addons/Corpora)
    /// </summary>
    [JsonProperty("UrlInfo")]
    public string UrlInfo { get; set; }

    /// <summary>
    /// Examples: "Tweets des Accounts notesjor - Stand 12.02.2019" (Addons/Corpora)
    /// </summary>
    [JsonProperty("Info")]
    public string Info { get; set; }
  }
}
