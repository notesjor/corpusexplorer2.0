using System;
using System.Runtime.InteropServices;

namespace CorpusExplorer.Sdk.Extern.UdPipe.Model
{
  public class Word : Token
  {
    private HandleRef swigCPtr;

    public Word(int id, string form) : this(udpipe_csharpPINVOKE.new_Word__SWIG_0(id, form), true)
    {
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public Word(int id) : this(udpipe_csharpPINVOKE.new_Word__SWIG_1(id), true)
    {
    }

    public Word() : this(udpipe_csharpPINVOKE.new_Word__SWIG_2(), true)
    {
    }

    internal Word(IntPtr cPtr, bool cMemoryOwn) : base(udpipe_csharpPINVOKE.Word_SWIGUpcast(cPtr), cMemoryOwn)
    {
      swigCPtr = new HandleRef(this, cPtr);
    }

    public Children children
    {
      set => udpipe_csharpPINVOKE.Word_children_set(swigCPtr, Children.getCPtr(value));
      get
      {
        IntPtr cPtr = udpipe_csharpPINVOKE.Word_children_get(swigCPtr);
        Children ret = cPtr == IntPtr.Zero ? null : new Children(cPtr, false);
        return ret;
      }
    }

    public string deprel
    {
      set
      {
        udpipe_csharpPINVOKE.Word_deprel_set(swigCPtr, value);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      }
      get
      {
        string ret = udpipe_csharpPINVOKE.Word_deprel_get(swigCPtr);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
        return ret;
      }
    }

    public string deps
    {
      set
      {
        udpipe_csharpPINVOKE.Word_deps_set(swigCPtr, value);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      }
      get
      {
        string ret = udpipe_csharpPINVOKE.Word_deps_get(swigCPtr);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
        return ret;
      }
    }

    public string feats
    {
      set
      {
        udpipe_csharpPINVOKE.Word_feats_set(swigCPtr, value);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      }
      get
      {
        string ret = udpipe_csharpPINVOKE.Word_feats_get(swigCPtr);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
        return ret;
      }
    }

    public int head
    {
      set => udpipe_csharpPINVOKE.Word_head_set(swigCPtr, value);
      get
      {
        int ret = udpipe_csharpPINVOKE.Word_head_get(swigCPtr);
        return ret;
      }
    }

    public int id
    {
      set => udpipe_csharpPINVOKE.Word_id_set(swigCPtr, value);
      get
      {
        int ret = udpipe_csharpPINVOKE.Word_id_get(swigCPtr);
        return ret;
      }
    }

    public string lemma
    {
      set
      {
        udpipe_csharpPINVOKE.Word_lemma_set(swigCPtr, value);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      }
      get
      {
        string ret = udpipe_csharpPINVOKE.Word_lemma_get(swigCPtr);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
        return ret;
      }
    }

    public string upostag
    {
      set
      {
        udpipe_csharpPINVOKE.Word_upostag_set(swigCPtr, value);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      }
      get
      {
        string ret = udpipe_csharpPINVOKE.Word_upostag_get(swigCPtr);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
        return ret;
      }
    }

    public string xpostag
    {
      set
      {
        udpipe_csharpPINVOKE.Word_xpostag_set(swigCPtr, value);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      }
      get
      {
        string ret = udpipe_csharpPINVOKE.Word_xpostag_get(swigCPtr);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
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
            udpipe_csharpPINVOKE.delete_Word(swigCPtr);
          }

          swigCPtr = new HandleRef(null, IntPtr.Zero);
        }

        GC.SuppressFinalize(this);
        base.Dispose();
      }
    }

    internal static HandleRef getCPtr(Word obj)
    {
      return obj == null ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
    }

    ~Word()
    {
      Dispose();
    }
  }
}