#region

using System.Collections.Generic;
using System.Linq;

#endregion

namespace CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Abstract
{
  public abstract class AbstractTextAutoFix : AbstractAutoFix
  {
    public bool ApplyOnCompleteCorpus { get; set; }
    public bool ApplyOnMeta { get; set; }
    public bool ApplyOnText { get; set; } = true;

    public override void Apply(ref List<Dictionary<string, object>> docs)
    {
      // ReSharper disable once ForCanBeConvertedToForeach
      for (var dKey = 0; dKey < docs.Count; dKey++)
      {
        var keys = docs[dKey].Keys.ToArray();
        foreach (var pKey in keys)
          try
          {
            if (pKey == "Text" && ApplyOnText)
              docs[dKey][pKey] = Apply((string)docs[dKey][pKey]);
            if (pKey != "Text" && ApplyOnMeta && docs[dKey][pKey] is string)
              docs[dKey][pKey] = Apply((string)docs[dKey][pKey]);
          }
          catch
          {
            // ignore
          }
      }
    }

    protected abstract string Apply(string text);
  }
}