using System.Collections.Generic;

namespace CorpusExplorer.Terminal.Universal.Message.Request.Corpus
{
  public class RequestCorpus
  {
    public string Format { get; set; }
    public string[] Paths { get; set; }
    public string Tagger { get; set; } = null;
    public string Language { get; set; } = null;
    public string OutputPath { get; set; } = null;
  }
}
