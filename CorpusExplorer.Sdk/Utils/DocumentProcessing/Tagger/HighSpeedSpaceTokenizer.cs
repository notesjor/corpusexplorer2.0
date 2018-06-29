using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger
{
  public sealed class HighSpeedSpaceTokenizer : AbstractTokenizer
  {
    private readonly Dictionary<string, string> _conv1 = new Dictionary<string, string>
    {
      {"(", " ( "},
      {"[", " [ "},
      {")", " ) "},
      {"]", " ] "},
      {".", " . "},
      {",", " , "},
      {"!", " ! "},
      {"?", " ? "},
      {";", " ; "},
      {":", " : "},
      {"//t . co/", "//t.co/"},
      {"https : //", "https://"},
      {"http : //", "http://"},
      {"{", " { "},
      {"}", " } "},
      {"\"", " \" "},
      {"''", " \" "},
      {"«", " \" "},
      {"»", " \" "},
      {",,", " \" "},
      {"\r\n", " "},
      {"\n\r", " "},
      {"\t", " "},
      {"\r", " "},
      {"\n", " "}
    };

    public override string DisplayName => "Space Tokenizer";

    public override string Language
    {
      get => "Universal";
      set { }
    }

    public override string Execute(string input)
    {
      input = _conv1.Aggregate(input, (current, x) => current.Replace(x.Key, x.Value));

      int length;
      do
      {
        length = input.Length;
        input = input.Replace("  ", " ");
      } while (input.Length != length);

      return input.Replace("< ENDOFCORPUSEXPLORERFILE >", "<ENDOFCORPUSEXPLORERFILE>").Trim().Replace(" ", "\r\n");
    }
  }
}