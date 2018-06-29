using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Sdk.Blocks
{
  public class DocumentCloneQuickDetectionBlock : AbstractBlock
  {
    private Dictionary<string, Guid> _hashs;

    public HashSet<Guid> DetectedClones { get; private set; }

    public IEnumerable<Guid> IndividualDocuments
    {
      get { return _hashs.Select(x => x.Value); }
    }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      var block = Selection.CreateBlock<DocumentFulltextBlock>();
      block.Calculate();

      _hashs = new Dictionary<string, Guid>();
      DetectedClones = new HashSet<Guid>();

      using (var algo = SHA512.Create())
      {
        foreach (var doc in block.Documents)
        {
          var key = Convert.ToBase64String(algo.ComputeHash(Configuration.Encoding.GetBytes(doc.Value)));
          if (_hashs.ContainsKey(key))
            DetectedClones.Add(doc.Key);
          else
            _hashs.Add(key, doc.Key);
        }
      }
    }
  }
}