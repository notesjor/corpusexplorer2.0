using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Db.Core.Model.SimpleBinary
{
  public class Corpus
  {
    public Corpus()
    {
      Layers = new HashSet<Layer>();
      Documents = new HashSet<Document>();
    }

    [Key]
    public Guid CorpusId { get; set; }

    public string Displayname { get; set; }
    public virtual ICollection<Document> Documents { get; set; }

    public virtual ICollection<Layer> Layers { get; set; }

    [NotMapped]
    public Dictionary<string, object> Metadata
    {
      get { return Serializer.InMemoryDeserialize<Dictionary<string, object>>(MetadataRaw); }
      set { MetadataRaw = Serializer.InMemorySerialize(value); }
    }

    public byte[] MetadataRaw { get; set; }
  }
}