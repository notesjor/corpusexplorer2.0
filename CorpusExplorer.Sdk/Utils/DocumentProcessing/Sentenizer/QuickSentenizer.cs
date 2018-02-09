using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Sentenizer.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Sentenizer
{
  public class QuickSentenizer : AbstractSentenizer
  {
    public override string DisplayName => "QuickSentenizer";
    public override string Language { get; set; }
    public HashSet<string> SentenceEndings { get; set; } = new HashSet<string> {".", "?", "!"};

    public override string[][] Execute(string[] input)
    {
      var doc = new List<string[]>();
      var sen = new List<string>();
      foreach (var x in input)
      {
        sen.Add(x);
        if (!SentenceEndings.Contains(x))
          continue;
        doc.Add(sen.ToArray());
        sen.Clear();
      }
      return doc.ToArray();
    }
  }
}
