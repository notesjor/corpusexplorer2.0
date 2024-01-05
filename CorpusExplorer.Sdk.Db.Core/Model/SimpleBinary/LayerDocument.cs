using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Db.Core.Model.SimpleBinary
{
  public class LayerDocument
  {
    [NonSerialized]
    [NotMapped]
    private int[][] _content;

    [NotMapped]
    public int[][] Content
    {
      get => _content ?? (_content = DocumentSerializerHelper.Deserialize(ContentRaw));
      set
      {
        _content = value;
        ContentRaw = DocumentSerializerHelper.Serialize(value);
      }
    }

    public byte[] ContentRaw { get; set; }

    [NotMapped]
    public Document Document
      => (from x in Layer.Corpus.Documents where x.DocumentId == LayerDocumentId select x).FirstOrDefault();

    [ForeignKey("LayerId")]
    public virtual Layer Layer { get; set; }

    [Key]
    [Column(Order = 1)]
    public Guid LayerDocumentId { get; set; }

    [Key]
    [Column(Order = 2)]
    public Guid LayerId { get; set; }
  }
}