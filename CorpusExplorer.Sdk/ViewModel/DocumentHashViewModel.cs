using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class DocumentHashViewModel : AbstractViewModel, IProvideDataTable, IUseSpecificLayer
  {
    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<DocumentHashBlock>();
      block.LayerDisplayname = LayerDisplayname;

      switch (HashAlgorithm)
      {
        case Algorithm.MD5:
          block.HashAlgorithm = MD5.Create();
          break;
        case Algorithm.SHA1:
          block.HashAlgorithm = SHA1.Create();
          break;
        case Algorithm.SHA256:
          block.HashAlgorithm = SHA256.Create();
          break;
        case Algorithm.SHA512:
          block.HashAlgorithm = SHA512.Create();
          break;
      }

      block.Calculate();
      DocumentHashes = block.DocumentHashes;
    }

    public Dictionary<Guid, string> DocumentHashes { get; set; }

    protected override bool Validate()
    {
      return !string.IsNullOrEmpty(LayerDisplayname);
    }

    public DataTable GetDataTable()
    {
      var dt = new DataTable();
      dt.Columns.Add("GUID", typeof(string));
      dt.Columns.Add("HASH", typeof(string));

      dt.BeginLoadData();
      foreach (var hash in DocumentHashes)
        dt.Rows.Add(hash.Key.ToString("N"), hash.Value);
      dt.EndLoadData();

      return dt;
    }

    public Algorithm HashAlgorithm { get; set; } = Algorithm.SHA512;
    public IEnumerable<string> LayerDisplaynames => new[] { LayerDisplayname };
    public string LayerDisplayname { get; set; } = "Wort";

    public enum Algorithm
    {
      MD5,
      SHA1,
      SHA256,
      SHA512
    }
  }
}
