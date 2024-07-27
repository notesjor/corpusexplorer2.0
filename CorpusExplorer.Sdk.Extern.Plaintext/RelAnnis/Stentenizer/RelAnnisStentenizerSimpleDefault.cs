using Bcs.IO;
using CorpusExplorer.Sdk.Extern.Plaintext.RelAnnis.Helper;
using CorpusExplorer.Sdk.Extern.Plaintext.RelAnnis.NodeProcessor;
using CorpusExplorer.Sdk.Extern.Plaintext.RelAnnis.Stentenizer.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Extern.Plaintext.RelAnnis.Stentenizer
{
  public class RelAnnisStentenizerSimpleDefault : AbstractRelAnnisSentenizer
  {
    private RelAnnisTokenValidatorDefault _tokenValidator = new RelAnnisTokenValidatorDefault();
    private static readonly HashSet<string>
      _sentenceEndings = new HashSet<string> { ".", "!", "?", ";", ":" }; // STTS 2.0

    public override Dictionary<int, List<KeyValuePair<int, int>>> GetSentences(string path)
    {
      var res = new Dictionary<int, List<KeyValuePair<int, int>>>();

      var lines = FileIO.ReadLines(AnnisFileResolverHelper.ResolveAnnisEndings(path, "node"));
      var lastDid = -1;
      var lastId = -1;

      if (lines != null)
        foreach (var line in lines)
        {
          var split = line.Split('\t');
          if (split.Length < 14)
            continue;

          var id = int.Parse(split[0]);
          var did = int.Parse(split[2]);
          var token = split[12];

          if(!_tokenValidator.IsInvalid(split))
            continue;

          if (lastId == -1) // neuer Satz
          {
            lastDid = did;
            lastId = id;
          }

          if (lastDid != did || _sentenceEndings.Contains(token)) // Dokumentwechsel oder Satzende
          {
            if (!res.ContainsKey(lastDid))
              res[lastDid] = new List<KeyValuePair<int, int>>();
            res[lastDid].Add(new KeyValuePair<int, int>(lastId, id));

            lastId = -1;
          }
        }

      return res;
    }
  }
}
