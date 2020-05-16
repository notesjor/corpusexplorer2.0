#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace CorpusExplorer.Sdk.Extern.UdPipe.Model
{
  public class Token : IDisposable
  {
    protected bool swigCMemOwn;
    private HandleRef swigCPtr;

    public Token(string form, string misc) : this(udpipe_csharpPINVOKE.new_Token__SWIG_0(form, misc), true)
    {
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public Token(string form) : this(udpipe_csharpPINVOKE.new_Token__SWIG_1(form), true)
    {
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public Token() : this(udpipe_csharpPINVOKE.new_Token__SWIG_2(), true)
    {
    }

    internal Token(IntPtr cPtr, bool cMemoryOwn)
    {
      swigCMemOwn = cMemoryOwn;
      swigCPtr = new HandleRef(this, cPtr);
    }

    public string form
    {
      set
      {
        udpipe_csharpPINVOKE.Token_form_set(swigCPtr, value);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      }
      get
      {
        var ret = udpipe_csharpPINVOKE.Token_form_get(swigCPtr);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
        return ret;
      }
    }

    public string misc
    {
      set
      {
        udpipe_csharpPINVOKE.Token_misc_set(swigCPtr, value);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      }
      get
      {
        var ret = udpipe_csharpPINVOKE.Token_misc_get(swigCPtr);
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
            udpipe_csharpPINVOKE.delete_Token(swigCPtr);
          }

          swigCPtr = new HandleRef(null, IntPtr.Zero);
        }

        GC.SuppressFinalize(this);
      }
    }

    ~Token()
    {
      Dispose();
    }

    internal static HandleRef getCPtr(Token obj)
    {
      return obj == null ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
    }

    public bool getSpaceAfter()
    {
      var ret = udpipe_csharpPINVOKE.Token_getSpaceAfter(swigCPtr);
      return ret;
    }

    public string getSpacesAfter()
    {
      var ret = udpipe_csharpPINVOKE.Token_getSpacesAfter(swigCPtr);
      return ret;
    }

    public string getSpacesBefore()
    {
      var ret = udpipe_csharpPINVOKE.Token_getSpacesBefore(swigCPtr);
      return ret;
    }

    public string getSpacesInToken()
    {
      var ret = udpipe_csharpPINVOKE.Token_getSpacesInToken(swigCPtr);
      return ret;
    }

    public bool getTokenRange()
    {
      var ret = udpipe_csharpPINVOKE.Token_getTokenRange(swigCPtr);
      return ret;
    }

    public uint getTokenRangeEnd()
    {
      var ret = udpipe_csharpPINVOKE.Token_getTokenRangeEnd(swigCPtr);
      return ret;
    }

    public uint getTokenRangeStart()
    {
      var ret = udpipe_csharpPINVOKE.Token_getTokenRangeStart(swigCPtr);
      return ret;
    }

    public void setSpaceAfter(bool space_after)
    {
      udpipe_csharpPINVOKE.Token_setSpaceAfter(swigCPtr, space_after);
    }

    public void setSpacesAfter(string spaces_after)
    {
      udpipe_csharpPINVOKE.Token_setSpacesAfter(swigCPtr, spaces_after);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void setSpacesBefore(string spaces_before)
    {
      udpipe_csharpPINVOKE.Token_setSpacesBefore(swigCPtr, spaces_before);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void setSpacesInToken(string spaces_in_token)
    {
      udpipe_csharpPINVOKE.Token_setSpacesInToken(swigCPtr, spaces_in_token);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void setTokenRange(uint start, uint end)
    {
      udpipe_csharpPINVOKE.Token_setTokenRange(swigCPtr, start, end);
    }
  }
}