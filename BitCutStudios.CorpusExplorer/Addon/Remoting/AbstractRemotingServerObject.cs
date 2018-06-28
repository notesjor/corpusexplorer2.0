#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using Bcs.Addon.Remoting.Interfaces;

#endregion

namespace Bcs.Addon.Remoting
{
  /// <summary>
  ///   Klasse von der alle Remoting-Server abgeleitet sind
  /// </summary>
  public abstract class AbstractRemotingServerObject
    : MarshalByRefObject, IRemotingAuthenticationContract, IServerContract
  {
    private readonly Dictionary<string, Session> _manager = new Dictionary<string, Session>();

    // ReSharper disable once NotAccessedField.Local
    private Timer _timer;

    /// <summary>
    ///   Erzeugt einen neuen RemotingServer
    /// </summary>
    protected AbstractRemotingServerObject()
    {
      _timer = new Timer(RecuringClean, null, 300000, 300000);
    }

    /// <summary>
    ///   Logins the specified email.
    /// </summary>
    /// <param name="email">The email.</param>
    /// <param name="password">The password.</param>
    /// <returns>
    ///   SessionKey
    /// </returns>
    public abstract string LogIn(string email, string password);

    /// <summary>
    ///   Determines whether the specified session key is alive.
    /// </summary>
    /// <param name="sessionKey">The session key.</param>
    /// <returns>
    ///   <c>true</c> if the specified session key is alive; otherwise,
    ///   <c>false</c> .
    /// </returns>
    public bool IsAlive(string sessionKey)
    {
      try
      {
        return GetSession(sessionKey, GetIdentity()) != null;
      }
      catch
      {
        return false;
      }
    }

    /// <summary>
    ///   Determines whether this instance is connected.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if this instance is connected; otherwise, <c>false</c> .
    /// </returns>
    public bool IsConnected()
    {
      return true;
    }

    /// <summary>
    ///   Anonyme Anmeldung
    /// </summary>
    /// <returns>sessionKey - null wenn keine anonyme Anmeldung erlaubt</returns>
    public abstract string LogInAnonymus();

    /// <summary>
    ///   Logoffs the specified session key.
    /// </summary>
    /// <param name="sessionKey">The session key.</param>
    /// <returns>
    ///   <c>true</c> if XXXX, <c>false</c> otherwise
    /// </returns>
    public bool LogOut(string sessionKey)
    {
      return RemoveSession(sessionKey);
    }

    /// <summary>
    ///   Erzeugt eine neue <see cref="Session" />
    /// </summary>
    /// <returns>
    ///   SessionKey
    /// </returns>
    public string NewSession()
    {
      return NewSession(GetIdentity());
    }

    /// <summary>
    ///   Gibt die Sessiondaten zurück die unter dem angegebenen SessionKey gespiechert sind.
    ///   Wenn keine Session verfügbar, dann gibt die funktion Null zurück
    /// </summary>
    /// <param name="sessionKey">SessionKey</param>
    /// <returns>SessionDaten.</returns>
    protected Session GetSession(string sessionKey)
    {
      return GetSession(sessionKey, GetIdentity());
    }

    /// <summary>
    ///   Erzeugt eine neue <see cref="Session" />
    /// </summary>
    /// <param name="sessionData">Daten die in der Session hinterlegt werden sollen.</param>
    /// <returns>SessionKey</returns>
    protected string NewSession(Dictionary<string, object> sessionData)
    {
      return NewSession(GetIdentity(), sessionData);
    }

    private static string GetIdentity()
    {
      var identity = Thread.CurrentPrincipal.Identity as WindowsIdentity;
      return identity != null && identity.IsAuthenticated ? identity.Name : null;
    }

    /// <summary>
    ///   Gibt die <see cref="Session" /> zurück (falls diese existiert UND der
    ///   Aufrufer der Besitzer ist)
    /// </summary>
    /// <param name="sessionKey">sessionKey</param>
    /// <param name="securityToken">securityToken</param>
    /// <exception cref="Exception">
    ///   Schmeißt Fehler wenn irgend etwas nicht stimmt.
    /// </exception>
    /// <returns>
    ///   <see cref="Session" />
    /// </returns>
    private Session GetSession(string sessionKey, string securityToken)
    {
      if (string.IsNullOrEmpty(sessionKey) ||
          !_manager.ContainsKey(sessionKey))
        return null;

      var res = _manager[sessionKey];

      if (res.Timeout < DateTime.Now ||
          res.SecurityToken == null && securityToken != null
          ||
          res.SecurityToken != null && securityToken == null
          ||
          res.SecurityToken != null && securityToken != null && !res.SecurityToken.Equals(securityToken))
      {
        _manager.Remove(sessionKey);
        return null;
      }

      res.Timeout = DateTime.Now.AddMinutes(15);
      _manager[sessionKey] = res;

      return res;
    }

    // Internal Methods (3) 
    //  Public Methods (3) 
    /// <summary>
    ///   Erzeugt eine neue <see cref="Session" />
    /// </summary>
    /// <param name="securityToken">Token welches den Zugriff ansichert</param>
    /// <param name="sessionData"></param>
    /// <returns>
    ///   session
    /// </returns>
    private string NewSession(string securityToken, Dictionary<string, object> sessionData = null)
    {
      try
      {
        var session = new Session(securityToken, sessionData);
        string guid;

        do
        {
          guid = Guid.NewGuid().ToString("N") + "-" + Guid.NewGuid().ToString("N");
        } while (
          _manager.ContainsKey(guid));

        _manager.Add(guid, session);
        return guid;
      }
      catch
      {
        return null;
      }
    }

    private void RecuringClean(object state)
    {
      var date = DateTime.Now;
      foreach (var session in _manager.Where(session => session.Value.Timeout < date))
        RemoveSession(session.Key);
    }

    /// <summary>
    ///   Löscht eine <see cref="Session" /> aus der aktuellen Liste
    /// </summary>
    /// <param name="sessionKey">
    ///   <see cref="Session" /> die beendet werden soll
    /// </param>
    private bool RemoveSession(string sessionKey)
    {
      try
      {
        _manager.Remove(sessionKey);
        return true;
      }
      catch
      {
        return false;
      }
    }
  }
}