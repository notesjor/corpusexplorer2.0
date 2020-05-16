using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.Xml.Bnc.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.Bnc.Extension
{
  public static class sourceDescExtension
  {
    public static bibl Bibl(this sourceDesc obj)
    => obj.Item as bibl;

    public static recordingStmt RecordingStmt(this sourceDesc obj)
      => obj.Item as recordingStmt;
  }
}
