#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Db.SqLite.Model.CoQuery;
using CorpusExplorer.Sdk.Db.SQLite.Properties;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using File = CorpusExplorer.Sdk.Db.SqLite.Model.CoQuery.File;

#endregion

namespace CorpusExplorer.Sdk.Db.SQLite.Exporter
{
  public class ExporterCoQuery : AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
      var context = new CoQueryDataContext($"data source={path};failifmissing=False");
      if (!context.DatabaseExists())
        context.CreateDatabase(true, true);

      var select = hydra.ToSelection();
      var guids = select.DocumentGuids.ToArray();

      context.Files.InsertAllOnSubmit(guids.Select((t, i) => new File
      {
        FileId = (short)(i + 1),
        Filename = select.GetDocumentDisplayname(t),
        Path = select.GetDocumentDisplayname(t)
      }));
      context.SubmitChanges();

      var fdict = new Dictionary<Guid, int>();
      for (var i = 0; i < guids.Length; i++)
        fdict.Add(guids[i], i + 1);

      var dict = new Dictionary<string, int>();
      var dictIndex = 1;
      var entryId = (long)1;

      var lexicons = new List<Lexicon>();
      var entries = new List<Corpus>();

      foreach (var guid in guids)
      {
        var mdoc = @select.GetReadableMultilayerDocument(guid);
        var lemma = mdoc["Lemma"]?.Select(x => x.ToArray()).ToArray();
        var word = mdoc["Wort"].Select(x => x.ToArray()).ToArray();
        var pos = mdoc["POS"]?.Select(x => x.ToArray()).ToArray();

        for (var s = 0; s < word.Length; s++)
        for (var w = 0; w < word[s].Length; w++)
        {
          var bag = new List<string> { word[s][w] };
          if (lemma != null)
            bag.Add(lemma[s][w]);
          if (pos != null)
            bag.Add(pos[s][w]);

          var key = string.Join("|", bag);
          if (!dict.ContainsKey(key))
          {
            dict.Add(key, dictIndex);
            lexicons.Add(new Lexicon
            {
              Lemma = lemma == null ? "" : lemma[s][w],
              POS = pos     == null ? "" : pos[s][w],
              Word = word[s][w],
              WordId = dictIndex++
            });
          }

          entries.Add(new Corpus
          {
            ID = entryId++,
            FileId = fdict[guid],
            SentenceId = s + 1,
            WordId = dict[key]
          });
        }
      }

      context.Lexicons.InsertAllOnSubmit(lexicons);
      context.SubmitChanges();
      context.Corpora.InsertAllOnSubmit(entries);
      context.SubmitChanges();

      var dir = Path.GetDirectoryName(path);
      var fn = Path.GetFileNameWithoutExtension(path);

      System.IO.File.WriteAllText(Path.Combine(dir, $"{fn}.py"),
                                  Resources.CoQueryPy
                                           .Replace("CORPUSEXPLORER_BIG", fn.ToUpper())
                                           .Replace("CORPUSEXPLORER_LOW", fn.ToLower())
                                           .Replace("tokens = 33242", $"tokens = {select.CountToken}"),
                                  Encoding.UTF8);
    }
  }
}