using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Utils.ReMapper2
{
  public class ReMapperDocument
  {
    public ReMapperDocument(AbstractLayerAdapter layer, Guid documentGuid)
    {
      Document = layer.GetReadableDocumentByGuid(documentGuid).Select(x => x.ToArray()).ToArray();

      Before = Clone();
      After = Clone();
      PositionNotes = MakePositionNotes();
    }

    private List<string>[][] MakePositionNotes()
    {
      var res = new List<string>[Document.Length][];
      for (var i = 0; i < Document.Length; i++)
      {
        res[i] = new List<string>[Document[i].Length];
        for (var j = 0; j < Document[i].Length; j++)
          res[i][j] = new List<string>();
      }
      return res;
    }

    private string[][] Clone()
    {
      var res = new string[Document.Length][];
      for (var i = 0; i < Document.Length; i++)
      {
        res[i] = new string[Document[i].Length];
        for (var j = 0; j < Document[i].Length; j++)
          res[i][j] = string.Empty;
      }
      return res;
    }

    /// <summary>
    /// Daten die vor einem Token geschrieben werden - z. B. open-Tag
    /// </summary>
    public string[][] Before { get; set; }

    /// <summary>
    /// Daten die nach einem Token geschrieben werden - z. B. closing-Tag
    /// </summary>
    public string[][] After { get; set; }

    /// <summary>
    /// Das Dokument als Token-Array
    /// </summary>
    public string[][] Document { get; }

    /// <summary>
    /// Erlaubt es Notizen an eine Position zu hängen.
    /// </summary>
    public List<string>[][] PositionNotes { get; set; }

    public override string ToString()
    {
      var res = new StringBuilder();

      for (var i = 0; i < Document.Length; i++)
        for (var j = 0; j < Document[i].Length; j++)
        {
          res.Append(Before[i][j]);
          res.Append(Document[i][j]);
          res.Append(After[i][j]);
        }

      return res.ToString();
    }
  }
}
