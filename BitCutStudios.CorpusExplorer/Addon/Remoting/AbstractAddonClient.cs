#region

using System;
using System.Collections;
using System.Net.Security;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using System.Security.Principal;
using Bcs.Addon.Remoting.Interfaces;

#endregion

namespace Bcs.Addon.Remoting
{
  /// <summary>
  ///   Abstrakter AddonClient
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public abstract class AbstractAddonClient<T> : AbstractAddonService<T>
    where T : class, IRemotingContract
  {
    // ReSharper disable once MemberCanBeProtected.Global
    /// <summary>
    ///   Soll die Verbindung gesichert werden (nur wenn vom Server utnerstützt)
    /// </summary>
    public abstract bool EnableSecurity { get; }

    /// <summary>
    ///   Gibt zurück ob der Service verfügbar ist.
    /// </summary>
    public bool IsAvailable => true;

    /// <summary>
    ///   Gibt zurück ob der Service verfügbar ist.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is available; otherwise, <c>false</c> .
    /// </value>
    public bool IsConnected
    {
      get
      {
        if (Contract.IsConnected())
          Initialize();

        if (!string.IsNullOrEmpty(SessionKey))
          return Contract.IsAlive(SessionKey);

        var contract = Contract as IRemotingAuthenticationContract;
        SessionKey = contract != null
          ? contract.LogIn(Username, Password)
          : Contract.LogInAnonymus();

        return Contract.IsAlive(SessionKey);
      }
    }

    // ReSharper disable once MemberCanBeProtected.Global
    /// <summary>
    ///   Stellt das Passwort des Benutzer (Username) bereit
    /// </summary>
    /// <value>
    ///   The password.
    /// </value>
    public abstract string Password { get; set; }

    // ReSharper disable once MemberCanBeProtected.Global
    /// <summary>
    ///   Name des Remoting-Object muss vom Typ <typeparamref name="T" /> sein.
    /// </summary>
    /// <value>
    ///   The name of the server object.
    /// </value>
    public abstract string ServerObjectName { get; }

    // ReSharper disable once MemberCanBeProtected.Global
    /// <summary>
    ///   Port auf dem Server (ServerUrl) unter dem das ServerObject (definiert
    ///   durch ServerObjectName) erreichbar ist.
    /// </summary>
    /// <value>
    ///   The server object port.
    /// </value>
    public abstract int ServerObjectPort { get; }

    // ReSharper disable once MemberCanBeProtected.Global
    /// <summary>
    ///   Url des Servers (OHNE Protokoll) - Bsp.-Url: bitcut.de
    /// </summary>
    /// <value>
    ///   The server URL.
    /// </value>
    public abstract string ServerUrl { get; }

    // ReSharper disable once MemberCanBePrivate.Global
    /// <summary>
    ///   Gets the session key.
    /// </summary>
    /// <value>
    ///   The session key.
    /// </value>
    public string SessionKey { get; private set; }

    // ReSharper disable once MemberCanBeProtected.Global
    /// <summary>
    ///   Stellt den Benutzernamen bereit
    /// </summary>
    /// <value>
    ///   The username.
    /// </value>
    public abstract string Username { get; set; }

    /// <summary>
    ///   Ist Impersonate aktiv? - Nur möglich wenn <see cref="EnableSecurity" /> =
    ///   <see langword="true" />
    /// </summary>
    protected abstract bool EnableImpersonate { get; }

    /// <summary>
    ///   Initializes this instance.
    /// </summary>
    public override void Initialize()
    {
      Connect();
    }

    /// <summary>
    ///   <para>Contract</para>
    ///   <para>Starts this instance.</para>
    /// </summary>
    public override void Start()
    {
      if (!Contract.IsConnected())
        Initialize();

      if (!string.IsNullOrEmpty(SessionKey) && Contract.IsAlive(SessionKey))
        return;

      var contract = Contract as IRemotingAuthenticationContract;
      SessionKey = contract != null
        ? contract.LogIn(Username, Password)
        : Contract.LogInAnonymus();
    }

    /// <summary>
    ///   Stops this instance.
    /// </summary>
    public override void Stop()
    {
      if (!string.IsNullOrEmpty(SessionKey))
        Contract.LogOut(SessionKey);
    }

    /// <summary>
    ///   Terminates this instance.
    /// </summary>
    public override void Terminate()
    {
      Stop();
      Disconnect();
    }

    private void Connect()
    {
      var channel = ChannelServices.GetChannel(Guid + "_Client");
      if (channel != null)
        return;

      IDictionary channelSettings = new Hashtable();
      channelSettings["port"] = 0;
      channelSettings["name"] = Guid + "_Client";
      channelSettings["secure"] = EnableSecurity;

      if (EnableSecurity)
      {
        channelSettings["tokenImpersonationLevel"] = EnableImpersonate
          ? TokenImpersonationLevel.Impersonation
          : TokenImpersonationLevel.Identification;
        channelSettings["protectionLevel"] = ProtectionLevel.EncryptAndSign;
      }

      var provider = new BinaryServerFormatterSinkProvider {TypeFilterLevel = TypeFilterLevel.Full};

      channel = new TcpChannel(channelSettings, null, provider);
      ChannelServices.RegisterChannel(channel, EnableSecurity);

      Contract =
        Activator.GetObject(
          typeof(T),
          $"tcp://{ServerUrl}:{ServerObjectPort}/{ServerObjectName}") as T;
    }

    private void Disconnect()
    {
      var channel = ChannelServices.GetChannel(Guid);
      if (channel != null)
        ChannelServices.UnregisterChannel(channel);
    }
  }
}