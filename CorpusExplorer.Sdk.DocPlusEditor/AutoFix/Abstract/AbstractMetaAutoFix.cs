#region

using System.Collections.Generic;
using System.Linq;

#endregion

namespace CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Abstract
{
  public abstract class AbstractMetaAutoFix : AbstractAutoFix
  {
    public string SelectedEntry { get; set; }

    public override void Apply(ref List<Dictionary<string, object>> docs)
    {
      // ReSharper disable once ForCanBeConvertedToForeach
      for (var dKey = 0; dKey < docs.Count; dKey++)
      {
        var keys = docs[dKey].Keys.ToArray();
        foreach (var pKey in keys)
          try
          {
            if (pKey == SelectedEntry && IsApplicable(docs[dKey][pKey]))
              docs[dKey][pKey] = Apply(docs[dKey][pKey]);
          }
          catch
          {
            // ignore
          }
      }
    }

    protected abstract object Apply(object obj);

    protected abstract bool IsApplicable(object obj);
  }
}