using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Db.Core.Model.SimpleBinary
{
  public class Document
  {
    [ForeignKey("CorpusId")]
    public virtual Corpus Corpus { get; set; }

    public Guid CorpusId { get; set; }

    [Key]
    public Guid DocumentId { get; set; }

    [NotMapped]
    public IEnumerable<LayerDocument> LayerDocuments
      => from l in Corpus.Layers from d in l.LayerDocuments where d.LayerDocumentId == DocumentId select d;

    [NotMapped]
    public Dictionary<string, object> Metadata
    {
      get { return Serializer.InMemoryDeserialize<Dictionary<string, object>>(MetadataRaw); }
      set { MetadataRaw = Serializer.InMemorySerialize(value); }
    }

    public byte[] MetadataRaw { get; set; }
    public int SentenceCount { get; set; }
    public int TokenCount { get; set; }
  }
}