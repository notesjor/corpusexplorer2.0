using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using PureHDF;

namespace CorpusExplorer.Sdk.Extern.Hdf5.Adapter
{
  public class CorpusAdapterHdf5 : AbstractCorpusAdapter
  {
    private string _path;
    private readonly long _fileId;
    private readonly long _root;

    private CorpusAdapterHdf5(string path)
    {
      _path = path;
      // TODO: _fileId = PureHDF.H5File.Open(path, FileMode);
      // TODO: _root = Hdf5.CreateOrOpenGroup(_fileId, "/ce");
    }

    public static AbstractCorpusAdapter Create(Dictionary<Guid, Dictionary<string, object>> documentMetadata, Dictionary<string, object> corpusMetadata, List<Concept> concepts)
    {
      throw new NotImplementedException();

      var path = ""; // TODO path;
      // TODO: var fileId = Hdf5.OpenFile(path);
      // TODO: var root = Hdf5.CreateOrOpenGroup(fileId, "/ce");

      var guid = Guid.NewGuid();
      // TODO: Hdf5.WriteAsciiString(root, "guid", guid.ToString());
    }

    public static IEnumerable<AbstractCorpusAdapter> Create(string path)
    {
      return new AbstractCorpusAdapter[] { new CorpusAdapterHdf5(path) };
    }

    public override IEnumerable<Concept> Concepts { get; } = null; // TODO: Wird aktuell nicht unterstützt.

    public override string CorpusDisplayname
    {
      get
      {
        return null;// TODO: Hdf5.ReadUnicodeString(_root, "name");
      }

      set
      {
        // TODO: Hdf5.WriteUnicodeString(_root, "name", value);
      }
    }

    public override Guid CorpusGuid
    {
      get
      {
        return Guid.Empty; // TODO:  Guid.Parse(Hdf5.ReadAsciiString(_root, "guid"));
      }
    }
    public override bool UseCompression { get; }
    public override IEnumerable<Guid> DocumentGuids { get; }
    public override IEnumerable<KeyValuePair<Guid, Dictionary<string, object>>> DocumentMetadata { get; }

    public override bool ContainsDocument(Guid documentGuid)
    {
      throw new NotImplementedException();
    }

    public override bool ContainsLayer(Guid layerGuid)
    {
      throw new NotImplementedException();
    }

    public override bool ContainsLayer(string layerDisplayname)
    {
      throw new NotImplementedException();
    }

    public override IEnumerable<Guid> FindDocumentByMetadata(Dictionary<string, object> example)
    {
      throw new NotImplementedException();
    }

    public override long GetDocumentLengthInSentences(Guid documentGuid)
    {
      throw new NotImplementedException();
    }

    public override long GetDocumentLengthInWords(Guid documentGuid)
    {
      throw new NotImplementedException();
    }

    public override Dictionary<string, object> GetDocumentMetadata(Guid documentGuid)
    {
      throw new NotImplementedException();
    }

    public override Dictionary<string, HashSet<object>> GetDocumentMetadataPrototype()
    {
      throw new NotImplementedException();
    }

    public override IEnumerable<string> GetDocumentMetadataPrototypeOnlyProperties()
    {
      throw new NotImplementedException();
    }

    public override IEnumerable<object> GetDocumentMetadataPrototypeOnlyPropertieValues(string property)
    {
      throw new NotImplementedException();
    }

    public override AbstractLayerAdapter GetLayer(Guid layerGuid)
    {
      throw new NotImplementedException();
    }

    public override AbstractLayerAdapter GetLayerOfDocument(Guid documentGuid, string layerDisplayname)
    {
      throw new NotImplementedException();
    }

    public override IEnumerable<AbstractLayerAdapter> GetLayers(string displayname)
    {
      throw new NotImplementedException();
    }

    public override IEnumerable<AbstractLayerAdapter> GetLayersOfDocument(Guid documentGuid)
    {
      throw new NotImplementedException();
    }

    public override IEnumerable<string> GetLayerValues(string layerDisplayname)
    {
      throw new NotImplementedException();
    }

    public override IEnumerable<string> GetLayerValues(Guid layerGuid)
    {
      throw new NotImplementedException();
    }

    public override IEnumerable<IEnumerable<string>> GetReadableDocument(Guid documentGuid, string layerDisplayname)
    {
      throw new NotImplementedException();
    }

    public override IEnumerable<IEnumerable<string>> GetReadableDocument(Guid documentGuid, Guid layerGuid)
    {
      throw new NotImplementedException();
    }

    public override IEnumerable<IEnumerable<string>> GetReadableDocumentSnippet(Guid documentGuid, string layerDisplayname, int start, int stop)
    {
      throw new NotImplementedException();
    }

    public override Dictionary<string, IEnumerable<IEnumerable<string>>> GetReadableMultilayerDocument(Guid documentGuid)
    {
      throw new NotImplementedException();
    }

    public override void LayerCopy(string layerDisplaynameOriginal, string layerDisplaynameCopy)
    {
      throw new NotImplementedException();
    }

    public override void LayerDelete(string layerDisplayname)
    {
      throw new NotImplementedException();
    }

    public override void LayerNew(string layerDisplayname)
    {
      throw new NotImplementedException();
    }

    public override void LayerRename(string layerDisplaynameOld, string layerDisplaynameNew)
    {
      throw new NotImplementedException();
    }

    public override void ResetAllDocumentMetadata(Dictionary<Guid, Dictionary<string, object>> newMetadata)
    {
      throw new NotImplementedException();
    }

    public override bool SetDocumentLayerValueMask(Guid documentGuid, Guid layerGuid, int sentenceIndex, int wordIndex, string layerValue)
    {
      throw new NotImplementedException();
    }

    public override bool SetDocumentLayerValueMask(Guid documentGuid, string layerDisplayname, int sentenceIndex, int wordIndex,
      string layerValue)
    {
      throw new NotImplementedException();
    }

    public override void SetDocumentMetadata(Guid documentGuid, Dictionary<string, object> metadata)
    {
      throw new NotImplementedException();
    }

    public override void SetNewDocumentMetadata(string metadataKey, Type type)
    {
      throw new NotImplementedException();
    }

    public override void AddConcept(Concept concept)
    {
      throw new NotImplementedException();
    }

    public override void AddLayer(AbstractLayerAdapter layer)
    {
      throw new NotImplementedException();
    }

    public override AbstractCorpusBuilder GetCorpusBuilder()
    {
      throw new NotImplementedException();
    }

    public override IEnumerable<KeyValuePair<string, object>> GetCorpusMetadata()
    {
      throw new NotImplementedException();
    }

    public override bool RemoveConcept(Concept concept)
    {
      throw new NotImplementedException();
    }

    public override void Save(string path = null, bool useCompression = true)
    {
      throw new NotImplementedException();
    }

    public override void SetCorpusMetadata(string key, object value)
    {
      throw new NotImplementedException();
    }

    public override void Dispose()
    {
      throw new NotImplementedException();
    }

    public override IEnumerable<AbstractLayerAdapter> Layers { get; }
    public override IEnumerable<string> LayerUniqueDisplaynames { get; }
    public override IEnumerable<string> LayerDisplaynames { get; }
    public override IEnumerable<KeyValuePair<Guid, string>> LayerGuidAndDisplaynames { get; }
    public override IEnumerable<Guid> LayerGuids { get; }
    public override Guid FirstDocument { get; }
  }
}
