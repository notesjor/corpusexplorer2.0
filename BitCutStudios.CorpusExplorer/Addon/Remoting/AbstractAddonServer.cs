#region

using System;
using System.Collections;
using System.Net.Security;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using System.Security.Principal;
using Bcs.Addon.Interfaces;

#endregion

namespace Bcs.Addon.Remoting
{
  public abstract class AbstractAddonServer<T> : IAddon
    where T : AbstractRemotingServerObject
  {
    private IChannel _channel;
    private bool _serverRuns;
    protected abstract bool EnableImpersonate { get; }
    protected abstract bool EnableSecurity { get; }
    protected abstract int Port { get; }
    protected abstract T ServerObject { get; }

    private Type ServerType => ServerObject.GetType();

    /// <summary>
    ///   AddonHost der dieses Addon verwaltet
    /// </summary>
    public IAddonHost AddonHost { get; set; }

    /// <summary>
    ///   Eindeutige Bezeichnung (Name) des Addons
    /// </summary>
    public abstract string Guid { get; }

    public void Initialize() { Start(); }

    public AddonLoadPriority LoadPriority => AddonLoadPriority.Level2System;

    public void Start()
    {
      if (_serverRuns)
        return;

      // Frage Channels ab
      _channel = ChannelServices.GetChannel(Guid + "_Server");
      if (_channel != null)
        return;

      // Wenn Channel noch nicht exsistiert, dann erzeuge einen neuen Channel
      _channel = new TcpChannel(GetSettings(), null, GetProvider());

      // Und registriere ihn
      if (_channel != null)
        ChannelServices.RegisterChannel(_channel, false);

      RemotingConfiguration.RegisterWellKnownServiceType(ServerType, Guid, WellKnownObjectMode.Singleton);

      Console.WriteLine("[{1}]: {0} gestartet (Port: {2})", Guid, DateTime.Now, Port);
      _serverRuns = true;
    }

    public void Stop()
    {
      if (!_serverRuns)
        return;

      ChannelServices.UnregisterChannel(ChannelServices.GetChannel(Guid));
      Console.WriteLine("[{1}]: {0} angehalten", Guid, DateTime.Now);
      _serverRuns = false;
    }

    public void Terminate() { Stop(); }

    private static BinaryServerFormatterSinkProvider GetProvider()
    {
      return new BinaryServerFormatterSinkProvider {TypeFilterLevel = TypeFilterLevel.Full};
    }

    private IDictionary GetSettings()
    {
      IDictionary sett = new Hashtable();
      sett["name"] = Guid + "_Server";
      sett["port"] = Port;
      sett["secure"] = EnableSecurity;

      if (!EnableSecurity)
        return sett;

      sett["tokenImpersonationLevel"] = EnableImpersonate
                                          ? TokenImpersonationLevel.Impersonation
                                          : TokenImpersonationLevel.Identification;
      sett["protectionLevel"] = ProtectionLevel.EncryptAndSign;

      return sett;
    }
  }
}