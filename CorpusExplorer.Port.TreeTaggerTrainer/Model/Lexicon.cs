#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bcs.IO;
using CorpusExplorer.Sdk.Model.Interface;

#endregion

namespace CorpusExplorer.Port.TreeTaggerTrainer.Model
{
  [Serializable]
  public class Lexicon
  {
    private readonly object @lock = new object();
    private readonly Dictionary<string, Dictionary<string, string>> _data = new Dictionary<string, Dictionary<string, string>>();

    private Lexicon() { }

    public Lexicon(IHydra iHydra, string layerDisplayname)
    {
      Parallel.ForEach(
        iHydra.DocumentGuids,
        tguid =>
        {
          var wl = iHydra.GetLayerOfDocument(tguid, "Wort");
          var ll = iHydra.GetLayerOfDocument(tguid, "Lemma");
          var tl = iHydra.GetLayerOfDocument(tguid, layerDisplayname);

          if ((wl == null) ||
              (ll == null) ||
              (tl == null))
            return;


          string[][] wdoc, ldoc, tdoc;
          try
          {
            wdoc = wl.GetReadableDocumentByGuid(tguid).Select(x => x.ToArray()).ToArray();
            ldoc = ll.GetReadableDocumentByGuid(tguid).Select(x => x.ToArray()).ToArray();
            tdoc = tl.GetReadableDocumentByGuid(tguid).Select(x => x.ToArray()).ToArray();
          }
          catch
          {
            return;
          }

          try
          {
            for (var i = 0; i < wdoc.Length; i++)
            {
              if (wdoc[i] == null)
                continue;
              for (var j = 0; j < wdoc[i].Length; j++)
                lock (@lock)
                {
                  if (_data.ContainsKey(wdoc[i][j]))
                  {
                    if (!_data[wdoc[i][j]].ContainsKey(tdoc[i][j]))
                      _data[wdoc[i][j]].Add(tdoc[i][j], ldoc[i][j]);
                  }
                  else
                    _data.Add(wdoc[i][j], new Dictionary<string, string> {{tdoc[i][j], ldoc[i][j]}});
                }
            }
          }
          catch {}
        });
    }

    public Lexicon(IEnumerable<Lexicon> lexicons)
    {
      foreach (var entry in lexicons.SelectMany(lexicon => lexicon._data))
        if (_data.ContainsKey(entry.Key))
          foreach (var value in entry.Value.Where(value => !_data[entry.Key].ContainsKey(value.Key)))
            _data[entry.Key].Add(value.Key, value.Value);
        else
          _data.Add(entry.Key, entry.Value);
    }

    public void GenerateTextFile(string path)
    {
      var res = new StringBuilder();
      res.Append("CORPUSEXPLORERSENTTAGFIX\tSENT\tCORPUSEXPLORERSENTTAGFIX\r\n");

      lock (@lock)
      {
        foreach (var entry in _data)
        {
          var stb = new StringBuilder();

          if (string.IsNullOrEmpty(entry.Key))
            continue;

          var arr = entry.Value.ToArray();
          if (arr.Length == 0)
            continue;
          for (var i = 0; i < arr.Length; i++)
          {
            if (string.IsNullOrEmpty(arr[i].Key) ||
                string.IsNullOrEmpty(arr[i].Value))
              continue;

            stb.AppendFormat("{0}\t{1}", arr[i].Key, arr[i].Value);
            if (i + 1 < arr.Length)
              stb.Append("\t");
          }

          var tags = stb.ToString().Trim();
          if (tags.Length < 2)
            tags = "UNKNOWN\t" + entry.Key;

          res.AppendFormat("{0}\t{1}\r\n", entry.Key, tags);
        }
      }

      FileIO.Write(path, res.ToString());
    }
  }
}