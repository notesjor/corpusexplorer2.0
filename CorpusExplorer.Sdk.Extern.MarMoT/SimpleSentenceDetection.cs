#region

using System.Linq;

#endregion

namespace CorpusExplorer.Sdk.Extern.MarMoT
{
  public sealed class SimpleSentenceDetection
  {
    private static readonly string[] _endings =
    {
      ".",
      "!",
      "?"
    };

    public string DetectSentence(string text)
    {
      return _endings.Aggregate(text,
                                (current, ending) => current.Replace($"\r\n{ending}\r\n", $"\r\n{ending}\r\n\r\n"));
    }
  }
}