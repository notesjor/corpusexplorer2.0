#region

using System;
using System.Collections.Generic;

#endregion

namespace Bcs.Addon.Remoting
{
  /// <summary>
  ///   The session.
  /// </summary>
  public sealed class Session
  {
    /// <summary>
    ///   Konstruktor
    /// </summary>
    /// <param name="securityToken">Sicherheitstoken</param>
    /// <param name="sessionData"></param>
    internal Session(string securityToken, Dictionary<string, object> sessionData)
    {
      Timeout = DateTime.Now.AddMinutes(15);
      SessionData = sessionData ?? new Dictionary<string, object>();
      SecurityToken = securityToken;
    }

    /// <summary>
    ///   Sicherheitstoken
    /// </summary>
    internal string SecurityToken { get; private set; }

    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    /// <summary>
    ///   Daten die für dieses Session hinterlegt wurden
    /// </summary>
    public Dictionary<string, object> SessionData { get; private set; }

    /// <summary>
    ///   TimeOut der Session
    /// </summary>
    internal DateTime Timeout { get; set; }
  }
}