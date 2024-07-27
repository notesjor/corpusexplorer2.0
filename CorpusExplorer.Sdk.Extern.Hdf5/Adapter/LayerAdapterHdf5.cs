using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;
using PureHDF;

namespace CorpusExplorer.Sdk.Extern.Hdf5.Adapter
{
  public class LayerAdapterHdf5 : AbstractLayerAdapter
  {
    private H5Group _h5layer;

    private LayerAdapterHdf5()
    {
    }

    public static AbstractLayerAdapter Create(AbstractCorpusAdapter corpus, AbstractLayerState layer)
    {
      var h5corpus = corpus as CorpusAdapterHdf5;
      if (h5corpus == null)
        return null;

      var res = new LayerAdapterHdf5();
      res._h5layer = new PureHDF.H5Group();
      h5corpus._layer[layer.Displayname] = res._h5layer;

      res._h5layer["guid"] = Guid.NewGuid().ToString();
      // h5layer["name"] = layer.Displayname; TODO

      var dicF = new PureHDF.H5Group();
      var dicB = new PureHDF.H5Group();
      foreach (var pair in layer.GetCache())
      {
        dicF[pair.Key] = pair.Value;
        dicB[pair.Value.ToString()] = pair.Key;
      }
      //res._h5layer["dicF"] = dicF;
      //res._h5layer["dicB"] = dicB;

      var docs = new PureHDF.H5Group();
      foreach(var doc in layer.GetDocuments())
        docs[doc.Key.ToString()] = DocumentSerializerHelper.Serialize(doc.Value);
      res._h5layer["docs"] = docs;

      return res;
    }

    public override int CountDocuments { get; }
    public override int CountValues { get; }
    public override IEnumerable<Guid> DocumentGuids { get; }

    public override string this[int index] => throw new NotImplementedException();

    public override int this[string index] => throw new NotImplementedException();

    public override int[][] this[Guid guid]
    {
      get => throw new NotImplementedException();
      set => throw new NotImplementedException();
    }

    public override IEnumerable<string> Values { get; }
    public override bool ContainsDocument(Guid guid)
    {
      throw new NotImplementedException();
    }

    public override AbstractLayerAdapter Copy()
    {
      throw new NotImplementedException();
    }

    public override AbstractLayerAdapter Copy(Guid documentGuid)
    {
      throw new NotImplementedException();
    }

    public override Dictionary<Guid, int[][]> GetDocumentDictionary()
    {
      throw new NotImplementedException();
    }

    public override IEnumerable<IEnumerable<bool>> GetDocumentLayervalueMask(Guid documentGuid, string layerValue)
    {
      throw new NotImplementedException();
    }

    public override IEnumerable<IEnumerable<string>> GetReadableDocumentByGuid(Guid documentGuid)
    {
      throw new NotImplementedException();
    }

    public override IEnumerable<IEnumerable<string>> GetReadableDocumentSnippetByGuid(Guid documentGuid, int start, int stop)
    {
      throw new NotImplementedException();
    }

    public override Dictionary<string, int> ReciveRawLayerDictionary()
    {
      throw new NotImplementedException();
    }

    public override Dictionary<int, string> ReciveRawReverseLayerDictionary()
    {
      throw new NotImplementedException();
    }

    public override void ResetRawLayerDictionary(Dictionary<string, int> dictionary)
    {
      throw new NotImplementedException();
    }

    public override void ResetRawReverseLayerDictionary(Dictionary<int, string> reverse)
    {
      throw new NotImplementedException();
    }

    public override void RefreshDictionaries()
    {
      throw new NotImplementedException();
    }

    public override bool SetDocumentLayerValueMaskBySwitch(Guid documentGuid, int sentenceIndex, int wordIndex, string value)
    {
      throw new NotImplementedException();
    }

    public override bool SetQuickStreamDocumentAnnotation(Guid documentGuid, IEnumerable<string> streamDocument)
    {
      throw new NotImplementedException();
    }

    public override Concept ToConcept(IEnumerable<string> ignoreValues = null)
    {
      throw new NotImplementedException();
    }

    public override void ValueAdd(string value)
    {
      throw new NotImplementedException();
    }

    public override void ValueChange(string oldValue, string newValue)
    {
      throw new NotImplementedException();
    }

    public override void ValueRemove(string removeValue)
    {
      throw new NotImplementedException();
    }

    protected override CeDictionary GetValueDictionary()
    {
      throw new NotImplementedException();
    }

    protected override IEnumerable<string> ValuesByRegex(string regEx)
    {
      throw new NotImplementedException();
    }
  }
}