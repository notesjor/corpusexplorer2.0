#region

using System.Security.Principal;

#endregion

namespace Bcs.Security
{
  // ReSharper disable once UnusedMember.Global
  public static class OsSecurity
  {
    /// <summary>
    ///   Ist der Nutzer Administrator
    /// </summary>
    public static bool IsAdministrator
    {
      get
      {
        try
        {
          var identity = WindowsIdentity.GetCurrent();
          return new WindowsPrincipal(identity).IsInRole(WindowsBuiltInRole.Administrator);
        }
        catch
        {
          return false;
        }
      }
    }

    /// <summary>
    ///   Gibt die Sid des Users zurück
    /// </summary>
    public static string UserSid
    {
      get
      {
        try
        {
          var identity = WindowsIdentity.GetCurrent();
          return identity.User == null ? null : identity.User.Value;
        }
        catch
        {
          return null;
        }
      }
    }
  }
}