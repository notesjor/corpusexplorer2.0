using Bcs.Addon.Interfaces;

namespace Bcs.Addon.Remoting.Interfaces
{
  public interface IRemotingContract : IServiceContract
  {
    /// <summary>
    ///   Ist die <see cref="Session" /> noch gültig?
    /// </summary>
    /// <param name="sessionKey">SessionKey</param>
    /// <returns>
    ///   Ist gültig?
    /// </returns>
    bool IsAlive(string sessionKey);

    /// <summary>
    ///   Ist der Service verfügbar?
    /// </summary>
    /// <returns>
    ///   Verfügbar
    /// </returns>
    bool IsConnected();

    /// <summary>
    ///   Anonyme Anmeldung
    /// </summary>
    /// <returns>sessionKey - null wenn keine anonyme Anmeldung erlaubt</returns>
    string LogInAnonymus();

    // ReSharper disable once UnusedMethodReturnValue.Global
    /// <summary>
    ///   Abmelden
    /// </summary>
    /// <param name="sessionKey">SessionKey</param>
    /// <returns>
    ///   Abmelden erfolgreich?
    /// </returns>
    bool LogOut(string sessionKey);
  }
}