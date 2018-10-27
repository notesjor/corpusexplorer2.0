using System.Security.Cryptography;
using CorpusExplorer.Sdk.Extern.SocialMedia.Interface;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Abstract
{
  public abstract class AbstractAuthentication
  {
    public object Signin() => LoadData() ? OpenConnection() : RequestData() && SaveData() ? OpenConnection() : null;

    protected abstract bool LoadData();
    protected abstract bool SaveData();
    protected abstract bool RequestData();
    protected abstract object OpenConnection();
  }
}