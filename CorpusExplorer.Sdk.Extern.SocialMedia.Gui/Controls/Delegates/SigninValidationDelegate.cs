using System.Collections.Generic;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Controls.Delegates
{
  public delegate AbstractAuthentication SigninValidationDelegate(Dictionary<string, string> credentials);
}