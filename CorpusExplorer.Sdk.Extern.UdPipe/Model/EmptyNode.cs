#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace CorpusExplorer.Sdk.Extern.UdPipe.Model
{
  public class EmptyNode : IDisposable
  {
    protected bool swigCMemOwn;
    private HandleRef swigCPtr;

    public EmptyNode(int id, int index) : this(udpipe_csharpPINVOKE.new_EmptyNode__SWIG_0(id, index), true)
    {
    }

    public EmptyNode(int id) : this(udpipe_csharpPINVOKE.new_EmptyNode__SWIG_1(id), true)
    {
    }

    public EmptyNode() : this(udpipe_csharpPINVOKE.new_EmptyNode__SWIG_2(), true)
    {
    }

    internal EmptyNode(IntPtr cPtr, bool cMemoryOwn)
    {
      swigCMemOwn = cMemoryOwn;
      swigCPtr = new HandleRef(this, cPtr);
    }

    public string deps
    {
      set
      {
        udpipe_csharpPINVOKE.EmptyNode_deps_set(swigCPtr, value);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      }
      get
      {
        var ret = udpipe_csharpPINVOKE.EmptyNode_deps_get(swigCPtr);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
        return ret;
      }
    }

    public string feats
    {
      set
      {
        udpipe_csharpPINVOKE.EmptyNode_feats_set(swigCPtr, value);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      }
      get
      {
        var ret = udpipe_csharpPINVOKE.EmptyNode_feats_get(swigCPtr);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
        return ret;
      }
    }

    public string form
    {
      set
      {
        udpipe_csharpPINVOKE.EmptyNode_form_set(swigCPtr, value);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      }
      get
      {
        var ret = udpipe_csharpPINVOKE.EmptyNode_form_get(swigCPtr);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
        return ret;
      }
    }

    public int id
    {
      set => udpipe_csharpPINVOKE.EmptyNode_id_set(swigCPtr, value);
      get
      {
        var ret = udpipe_csharpPINVOKE.EmptyNode_id_get(swigCPtr);
        return ret;
      }
    }

    public int index
    {
      set => udpipe_csharpPINVOKE.EmptyNode_index_set(swigCPtr, value);
      get
      {
        var ret = udpipe_csharpPINVOKE.EmptyNode_index_get(swigCPtr);
        return ret;
      }
    }

    public string lemma
    {
      set
      {
        udpipe_csharpPINVOKE.EmptyNode_lemma_set(swigCPtr, value);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      }
      get
      {
        var ret = udpipe_csharpPINVOKE.EmptyNode_lemma_get(swigCPtr);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
        return ret;
      }
    }

    public string misc
    {
      set
      {
        udpipe_csharpPINVOKE.EmptyNode_misc_set(swigCPtr, value);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      }
      get
      {
        var ret = udpipe_csharpPINVOKE.EmptyNode_misc_get(swigCPtr);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
        return ret;
      }
    }

    public string upostag
    {
      set
      {
        udpipe_csharpPINVOKE.EmptyNode_upostag_set(swigCPtr, value);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      }
      get
      {
        var ret = udpipe_csharpPINVOKE.EmptyNode_upostag_get(swigCPtr);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
        return ret;
      }
    }

    public string xpostag
    {
      set
      {
        udpipe_csharpPINVOKE.EmptyNode_xpostag_set(swigCPtr, value);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      }
      get
      {
        var ret = udpipe_csharpPINVOKE.EmptyNode_xpostag_get(swigCPtr);
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
            udpipe_csharpPINVOKE.delete_EmptyNode(swigCPtr);
          }

          swigCPtr = new HandleRef(null, IntPtr.Zero);
        }

        GC.SuppressFinalize(this);
      }
    }

    ~EmptyNode()
    {
      Dispose();
    }

    internal static HandleRef getCPtr(EmptyNode obj) => obj == null ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }
}