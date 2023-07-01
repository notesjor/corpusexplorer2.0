using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Utils.Drm
{
  public class CorpusLicenceInfo
  {
    public string CorpusName { get; set; }
    public string CorpusDescription { get; set; }
    public string LicenceHolder { get; set; }
    public string LicenceName { get; set; }
    public string LicenceUrl { get; set; }
    public string AdditionalInfoUrl { get; set; }
    public string Version { get; set; }
    public bool NeedAcceptance { get; set; }
  }
}
