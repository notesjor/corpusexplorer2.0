#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace CorpusExplorer.Sdk.Extern.UdPipe.Model
{
  public class MultiwordToken : Token
  {
    private HandleRef swigCPtr;

    public MultiwordToken(int id_first, int id_last, string form, string misc) : this(
                                                                                      udpipe_csharpPINVOKE
                                                                                       .new_MultiwordToken__SWIG_0(id_first,
                                                                                                                   id_last,
                                                                                                                   form,
                                                                                                                   misc),
                                                                                      true)
    {
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public MultiwordToken(int id_first, int id_last, string form) : this(
                                                                         udpipe_csharpPINVOKE
                                                                          .new_MultiwordToken__SWIG_1(id_first, id_last,
                                                                                                      form), true)
    {
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public MultiwordToken(int id_first, int id_last) : this(
                                                            udpipe_csharpPINVOKE
                                                             .new_MultiwordToken__SWIG_2(id_first, id_last), true)
    {
    }

    public MultiwordToken(int id_first) : this(udpipe_csharpPINVOKE.new_MultiwordToken__SWIG_3(id_first), true)
    {
    }

    public MultiwordToken() : this(udpipe_csharpPINVOKE.new_MultiwordToken__SWIG_4(), true)
    {
    }

    internal MultiwordToken(IntPtr cPtr, bool cMemoryOwn) : base(udpipe_csharpPINVOKE.MultiwordToken_SWIGUpcast(cPtr),
                                                                 cMemoryOwn)
    {
      swigCPtr = new HandleRef(this, cPtr);
    }

    public int idFirst
    {
      set => udpipe_csharpPINVOKE.MultiwordToken_idFirst_set(swigCPtr, value);
      get
      {
        var ret = udpipe_csharpPINVOKE.MultiwordToken_idFirst_get(swigCPtr);
        return ret;
      }
    }

    public int idLast
    {
      set => udpipe_csharpPINVOKE.MultiwordToken_idLast_set(swigCPtr, value);
      get
      {
        var ret = udpipe_csharpPINVOKE.MultiwordToken_idLast_get(swigCPtr);
        return ret;
      }
    }

    public override void Dispose()
    {
      lock (this)
      {
        if (swigCPtr.Handle != IntPtr.Zero)
        {
          if (swigCMemOwn)
          {
            swigCMemOwn = false;
            udpipe_csharpPINVOKE.delete_MultiwordToken(swigCPtr);
          }

          swigCPtr = new HandleRef(null, IntPtr.Zero);
        }

        GC.SuppressFinalize(this);
        base.Dispose();
      }
    }

    ~MultiwordToken()
    {
      Dispose();
    }

    internal static HandleRef getCPtr(MultiwordToken obj)
    {
      return obj == null ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
    }
  }
}