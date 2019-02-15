using System.Collections.Generic;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Controls.Delegates
{
  public delegate void CallEndpointDelegate(AbstractAuthentication auth, Dictionary<string, object> parameters);
}