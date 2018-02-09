using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using CorpusExplorer.Sdk.Helper;
using Nest;

namespace CorpusExplorer.Sdk.Db.Elastic.Model
{
  [ElasticsearchType(IdProperty = nameof(LayerDocumentId))]
  public class LayerDocument
  {
    private Guid _documentId;
    private Guid _layerId;

    [Text]
    public string ContentRaw { get; set; }

    [Object(Ignore = true)]
    public int[][] Content { get; set; }

    public Guid DocumentId
    {
      get => _documentId;
      set
      {
        _documentId = value;
        LayerDocumentId = string.Concat(value, ".", LayerId);
      }
    }

    public string LayerDocumentId { get; private set; }

    public Guid LayerId
    {
      get => _layerId;
      set
      {
        _layerId = value;
        LayerDocumentId = string.Concat(DocumentId, ".", value);
      }
    }

    [OnSerializing]
    private void OnSerializing(StreamingContext context)
    {
      if (Content != null)
        ContentRaw = DocumentSerializerHelper.SerializeToBase64String(Content);
    }

    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
      if (ContentRaw != null)
        Content = DocumentSerializerHelper.Deserialize(ContentRaw);
    }
  }
}