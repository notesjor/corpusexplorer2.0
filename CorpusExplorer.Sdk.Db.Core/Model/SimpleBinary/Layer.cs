using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.CorpusExplorer;

namespace CorpusExplorer.Sdk.Db.Core.Model.SimpleBinary
{
  public class Layer
  {
    public Layer() { LayerDocuments = new HashSet<LayerDocument>(); }

    [ForeignKey("CorpusId")]
    public virtual Corpus Corpus { get; set; }

    public Guid CorpusId { get; set; }

    [NotMapped]
    public CeDictionary Dictionary
    {
      get { return Serializer.InMemoryDeserialize<CeDictionary>(DictionaryRaw); }
      set { DictionaryRaw = Serializer.InMemorySerialize(value); }
    }

    public byte[] DictionaryRaw { get; set; }
    public string Displayname { get; set; }
    public virtual ICollection<LayerDocument> LayerDocuments { get; set; }

    [Key]
    public Guid LayerId { get; set; }
  }
}