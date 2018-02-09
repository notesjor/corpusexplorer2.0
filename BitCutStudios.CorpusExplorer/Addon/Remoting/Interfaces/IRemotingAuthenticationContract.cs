namespace Bcs.Addon.Remoting.Interfaces
{
  public interface IRemotingAuthenticationContract : IRemotingContract
  {
    /// <summary>
    ///   Anmelden
    /// </summary>
    /// <param name="email">Nutzername</param>
    /// <param name="password">Passwort</param>
    /// <returns>
    ///   SessionKey
    /// </returns>
    string LogIn(string email, string password);
  }
}