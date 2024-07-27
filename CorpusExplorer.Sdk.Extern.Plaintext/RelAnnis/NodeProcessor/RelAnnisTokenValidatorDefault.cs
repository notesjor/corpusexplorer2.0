using CorpusExplorer.Sdk.Extern.Plaintext.RelAnnis.NodeProcessor.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Extern.Plaintext.RelAnnis.NodeProcessor
{
  public class RelAnnisTokenValidatorDefault : AbstractRelAnnisTokenValidator
  {
    public override bool IsInvalid(string[] split)
    {
      var txt = split[7];
      if (txt == "NULL") // txt ist NULL wenn kein Token
        return true;

      var tid = int.Parse(txt);
      var tlf = int.Parse(split[8]);
      var tri = int.Parse(split[9]);

      return tid != tlf || tid != tri;
    }
  }
}
