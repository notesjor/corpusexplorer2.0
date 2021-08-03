using System.Collections.Generic;

namespace CorpusExplorer.Sdk.Extern.Json.SimpleStandoff.Model
{
  public class Document
  {
    public string Text { get; set; }
    public string[] TextToken { get; set; }
    public string[][] TextSentenceToken { get; set; }

    public Dictionary<string, object> Metadata { get; set; }

    public Annotation[] Annotations { get; set; }
  }
}
