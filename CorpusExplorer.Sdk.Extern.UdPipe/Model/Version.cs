#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace CorpusExplorer.Sdk.Extern.UdPipe.Model
{
  public class Version : IDisposable
  {
    protected bool swigCMemOwn;
    private HandleRef swigCPtr;

    public Version() : this(udpipe_csharpPINVOKE.new_Version(), true)
    {
    }

    internal Version(IntPtr cPtr, bool cMemoryOwn)
    {
      swigCMemOwn = cMemoryOwn;
      swigCPtr = new HandleRef(this, cPtr);
    }

    public uint major
    {
      set => udpipe_csharpPINVOKE.Version_major_set(swigCPtr, value);
      get
      {
        var ret = udpipe_csharpPINVOKE.Version_major_get(swigCPtr);
        return ret;
      }
    }

    public uint minor
    {
      set => udpipe_csharpPINVOKE.Version_minor_set(swigCPtr, value);
      get
      {
        var ret = udpipe_csharpPINVOKE.Version_minor_get(swigCPtr);
        return ret;
      }
    }

    public uint patch
    {
      set => udpipe_csharpPINVOKE.Version_patch_set(swigCPtr, value);
      get
      {
        var ret = udpipe_csharpPINVOKE.Version_patch_get(swigCPtr);
        return ret;
      }
    }

    public string prerelease
    {
      set
      {
        udpipe_csharpPINVOKE.Version_prerelease_set(swigCPtr, value);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      }
      get
      {
        var ret = udpipe_csharpPINVOKE.Version_prerelease_get(swigCPtr);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
        return ret;
      }
    }

    public virtual void Dispose()
    {
      lock (this)
      {
        if (swigCPtr.Handle != IntPtr.Zero)
        {
          if (swigCMemOwn)
          {
            swigCMemOwn = false;
            udpipe_csharpPINVOKE.delete_Version(swigCPtr);
          }

          swigCPtr = new HandleRef(null, IntPtr.Zero);
        }

        GC.SuppressFinalize(this);
      }
    }

    public static Version current()
    {
      var ret = new Version(udpipe_csharpPINVOKE.Version_current(), true);
      return ret;
    }

    ~Version()
    {
      Dispose();
    }

    internal static HandleRef getCPtr(Version obj)
    {
      return obj == null ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
    }
  }
}