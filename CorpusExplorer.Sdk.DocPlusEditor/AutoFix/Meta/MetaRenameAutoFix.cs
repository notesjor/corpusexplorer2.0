#region

using System.Collections.Generic;
using CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Abstract;

#endregion

namespace CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Meta
{
  public class MetaRenameAutoFix : AbstractAutoFix
  {
    public string EntryNewName { get; set; }
    public string SelectedEntry { get; set; }

    public override void Apply(ref List<Dictionary<string, object>> docs)
    {
      // ReSharper disable once ForCanBeConvertedToForeach
      for (var dKey = 0; dKey < docs.Count; dKey++)
        if (docs[dKey].ContainsKey(SelectedEntry))
        {
          var val = docs[dKey][SelectedEntry];
          docs[dKey].Add(EntryNewName, val);
          docs[dKey].Remove(SelectedEntry);
        }
    }
  }
}