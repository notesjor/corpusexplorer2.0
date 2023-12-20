using Bcs.IO;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Extern.Plaintext.Tsv
{
  public class ImporterTsv : AbstractImporterBase
  {
    private HashSet<string> _wordKeys = new HashSet<string> { "Wort", "Wortform", "Text", "text", "word", "Token", "token" };
    private HashSet<string> _sentenceMarks = new HashSet<string> { ".", ":", ";", "!", "?", "$." };

    public bool EmptyLineIsSentenceEnd { get; set; } = true;

    protected override void ExecuteCall(string path)
    {
      var lines = FileIO.ReadLines(path);
      var header = lines.First().Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries).ToList();
      var wordformIndex = GetWordFormIndex(header);

      if (wordformIndex == -1)
        throw new Exception("No wordform column found");
      header.RemoveAt(wordformIndex); // remove wordform column

      var layers = new Dictionary<string, List<string[]>>();
      var sentences = new Dictionary<string, List<string>>();

      // create dictionary keys
      layers.Add("Wort", new List<string[]>());
      sentences.Add("Wort", new List<string>());
      foreach (var column in header)
        if (!layers.ContainsKey(column))
        {
          layers.Add(column, new List<string[]>());
          sentences.Add(column, new List<string>());
        }

      // build layers
      var validLength = header.Count + 1;
      for (var i = 1; i < lines.Length; i++)
      {
        var line = lines[i];
        var split = line.Split(new[] { "\t" }, StringSplitOptions.None);

        if (split.Length != validLength)
        {
          if (EmptyLineIsSentenceEnd)
            AddSentenceToLayer(ref sentences, ref layers);
        }

        var wordform = split[wordformIndex];

        if (string.IsNullOrWhiteSpace(wordform))
          continue;

        var token = AddLineToSentence(ref split, ref header, wordformIndex, ref sentences);
        if (_sentenceMarks.Contains(token))
          AddSentenceToLayer(ref sentences, ref layers);
      }

      var guid = Guid.NewGuid();
      AddDocumentMetadata(guid, new Dictionary<string, object>
      {
        { "Datei", Path.GetFileNameWithoutExtension(path) },
        { "Pfad", path }
      });

      AddSentenceToLayer(ref sentences, ref layers);

      foreach (var layer in layers)
        AddDocument(layer.Key, guid, layer.Value.ToArray());
    }

    private string AddLineToSentence(ref string[] split, ref List<string> header, int wordformIndex, ref Dictionary<string, List<string>> sentences)
    {
      string res = null;
      for (int i = 0; i < header.Count + 1; i++)
      {        
        if (i == wordformIndex)
        {
          res = split[i];
          sentences["Wort"].Add(res);
        }
        else
        {
          string h = header[i < wordformIndex ? i : i - 1];
          sentences[h].Add(split[i]);
        }
      }
      return res;
    }

    private void AddSentenceToLayer(ref Dictionary<string, List<string>> sentences, ref Dictionary<string, List<string[]>> layers)
    {
      if (sentences.First().Value.Count == 0)
        return;

      foreach (var sentence in sentences)
      {
        layers[sentence.Key].Add(sentence.Value.ToArray());
        sentence.Value.Clear();
      }
    }

    private int GetWordFormIndex(List<string> header)
    {
      for (int i = 0; i < header.Count; i++)
        if (_wordKeys.Contains(header[i]))
          return i;

      return -1;
    }
  }
}
