using System;
using System.Collections.Generic;
using System.Linq;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.ReMapper.Model;

namespace CorpusExplorer.Sdk.Utils.ReMapper.Abstract
{
  public abstract class AbstractReMapper
  {
    private IEnumerable<string> _layerDisplaynames;

    /// <summary>
    ///   Layer die zur Annotation herangezogen werden
    /// </summary>
    public IEnumerable<string> LayerDisplaynames
    {
      get => _layerDisplaynames;
      set
      {
        var res = new List<string>(value);
        if (!res.Contains("Wort"))
          res.Remove("Wort");

        _layerDisplaynames = res;
      }
    }

    /// <summary>
    ///   Wendet ddie Annotation im Korpus auf den originalen Rohtext an.
    /// </summary>
    /// <param name="corpus">Korpus</param>
    /// <param name="documentGuid">DocumentGUID</param>
    /// <param name="originalText">Originaltext (muss mit dem Inhalt von Korpus/DocumentGuid übereinstimmen)</param>
    /// <returns></returns>
    public string ApplyAnnotation(AbstractCorpusAdapter corpus, Guid documentGuid, string originalText)
    {
      if (LayerDisplaynames == null)
        throw new NullReferenceException("Property LayerDisplaynames is null");
      return ApplyAnnotation(corpus, documentGuid, originalText, LayerDisplaynames);
    }

    /// <summary>
    ///   Wende die Annotation im Korpus auf den originalen Rohtext an.
    /// </summary>
    /// <param name="corpus">Korpus</param>
    /// <param name="documentGuid">DocumentGUID</param>
    /// <param name="fileInput">Datei, die den Rohtext enthält</param>
    /// <param name="fileOutput">Datei, in die die Ausgaben geschrieben werden soll</param>
    public void ApplyAnnotation(AbstractCorpusAdapter corpus, Guid documentGuid, string fileInput, string fileOutput)
    {
      if (LayerDisplaynames == null)
        throw new NullReferenceException("Property LayerDisplaynames is null");
      FileIO.Write(fileOutput,
                   ApplyAnnotation(corpus, documentGuid, FileIO.ReadText(fileInput, Configuration.Encoding),
                                   LayerDisplaynames),
                   Configuration.Encoding);
    }

    /// <summary>
    ///   Wendet ddie Annotation im Korpus auf den originalen Rohtext an.
    /// </summary>
    /// <param name="layers">Layer/Document-Array</param>
    /// <param name="originalText">Originaltext (muss mit dem Inhalt von Korpus/DocumentGuid übereinstimmen)</param>
    /// <param name="annotationPositions">
    ///   Positionen an denen annotiert werden muss (Tuple-Aufbau: SatzID / WortID / Position
    ///   im originalText (Start) / Position im originalText (Stop))
    /// </param>
    /// <returns></returns>
    protected abstract string ApplyAnnotation(IEnumerable<KeyValuePair<AbstractLayerAdapter, int[][]>> layers, string originalText,
                                              List<ReMapperEntry> annotationPositions);

    /// <summary>
    ///   Findet die zu annotierenden Positionen im Originaltext
    /// </summary>
    /// <param name="corpus">Korpus</param>
    /// <param name="documentGuid">DocumentGUID</param>
    /// <param name="originalText">Originaltext (muss mit dem Inhalt von Korpus/DocumentGuid übereinstimmen)</param>
    /// <param name="layerDisplaynames">Layer die zur Annotation herangezogen werden</param>
    /// <returns></returns>
    private string ApplyAnnotation(AbstractCorpusAdapter corpus, Guid documentGuid, string originalText,
                                   IEnumerable<string> layerDisplaynames)
    {
      return ApplyAnnotation((from name in layerDisplaynames
                              select corpus.GetLayerOfDocument(documentGuid, name)
                              into layer
                              where layer != null
                              select new KeyValuePair<AbstractLayerAdapter, int[][]>(layer, layer[documentGuid])).ToArray(),
                             originalText,
                             FindPositions(corpus, documentGuid, originalText));
    }

    /// <summary>
    ///   Findet die zu annotierenden Positionen im Originaltext
    /// </summary>
    /// <param name="corpus">Korpus</param>
    /// <param name="documentGuid">DocumentGUID</param>
    /// <param name="originalText">Originaltext (muss mit dem Inhalt von Korpus/DocumentGuid übereinstimmen)</param>
    /// <returns>Tuple-Aufbau: SatzID / WortID / Position im originalText (Start) / Position im originalText (Stop)</returns>
    private List<ReMapperEntry> FindPositions(AbstractCorpusAdapter corpus, Guid documentGuid,
                                                      string originalText)
    {
      var res = new List<ReMapperEntry>();

      var wlayer = corpus.GetLayers("Wort").First();
      var wdoc = wlayer[documentGuid];

      var last = 0;
      for (var i = 0; i < wdoc.Length; i++)
      for (var j = 0; j < wdoc[i].Length; j++)
      {
        var word = wlayer[wdoc[i][j]];
        var current = originalText.IndexOf(word, last);
        var end = current + word.Length;

        res.Add(new ReMapperEntry
        {
          SentenceIndex = i, 
          TokenIndex = j, 
          TextCharFrom = current, 
          TextCharTo = end
        });

        last = end;
      }

      return res;
    }
  }
}