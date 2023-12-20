using Bcs.IO;
using CorpusExplorer.Sdk.Extern.Binary.Excel.Universal.Reader;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Extern.Binary.Excel.Universal
{
  public class ImporterUniversalExcel : AbstractImporterBase
  {
    private HashSet<string> _wordKeys = new HashSet<string> { "Wort", "Wortform", "Text", "text", "word", "Token", "token" };
    private HashSet<string> _sentenceMarks = new HashSet<string> { ".", ":", ";", "!", "?", "$." };

    public bool EmptyLineIsSentenceEnd { get; set; } = true;

    protected override void ExecuteCall(string path)
    {
      var reader = new ExcelUniversalDataReader();
      var data = reader.ReadData(path).ToArray();

      var header = data.First().Keys.ToList();
      var wordformIndex = GetWordFormIndex(header);

      if (wordformIndex == null)
        throw new Exception("No wordform column found");
      header.Remove(wordformIndex); // remove wordform column

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
      var hash = new HashSet<string>{ wordformIndex };

      for (var i = 1; i < data.Length; i++)
      {
        var split = data[i];

        if (split.Count != validLength)
        {
          if (EmptyLineIsSentenceEnd)
            AddSentenceToLayer(ref sentences, ref layers);
        }

        var wordform = split[wordformIndex];

        if (string.IsNullOrWhiteSpace(wordform))
          continue;

        var token = AddLineToSentence(ref split, ref header, hash, ref sentences);
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

    private string AddLineToSentence(ref Dictionary<string, string> split, ref List<string> header, HashSet<string> wordformIndex, ref Dictionary<string, List<string>> sentences)
    {
      string res = null;
      foreach(var s in split)
      {
        if (wordformIndex.Contains(s.Key))
        {
          sentences["Wort"].Add(s.Value);
        }
        else
        {
          sentences[s.Key].Add(s.Value);
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

    private string GetWordFormIndex(List<string> header)
    {
      for (int i = 0; i < header.Count; i++)
        if (_wordKeys.Contains(header[i]))
          return header[i];

      return null;
    }
  }
}
