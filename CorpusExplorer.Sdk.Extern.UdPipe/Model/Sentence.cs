#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace CorpusExplorer.Sdk.Extern.UdPipe.Model
{
  public class Sentence : IDisposable
  {
    protected bool swigCMemOwn;
    private HandleRef swigCPtr;

    public Sentence() : this(udpipe_csharpPINVOKE.new_Sentence(), true)
    {
    }

    internal Sentence(IntPtr cPtr, bool cMemoryOwn)
    {
      swigCMemOwn = cMemoryOwn;
      swigCPtr = new HandleRef(this, cPtr);
    }

    public Comments comments
    {
      set => udpipe_csharpPINVOKE.Sentence_comments_set(swigCPtr, Comments.getCPtr(value));
      get
      {
        var cPtr = udpipe_csharpPINVOKE.Sentence_comments_get(swigCPtr);
        var ret = cPtr == IntPtr.Zero ? null : new Comments(cPtr, false);
        return ret;
      }
    }

    public EmptyNodes emptyNodes
    {
      set => udpipe_csharpPINVOKE.Sentence_emptyNodes_set(swigCPtr, EmptyNodes.getCPtr(value));
      get
      {
        var cPtr = udpipe_csharpPINVOKE.Sentence_emptyNodes_get(swigCPtr);
        var ret = cPtr == IntPtr.Zero ? null : new EmptyNodes(cPtr, false);
        return ret;
      }
    }

    public MultiwordTokens multiwordTokens
    {
      set => udpipe_csharpPINVOKE.Sentence_multiwordTokens_set(swigCPtr, MultiwordTokens.getCPtr(value));
      get
      {
        var cPtr = udpipe_csharpPINVOKE.Sentence_multiwordTokens_get(swigCPtr);
        var ret = cPtr == IntPtr.Zero ? null : new MultiwordTokens(cPtr, false);
        return ret;
      }
    }

    public static string rootForm
    {
      get
      {
        var ret = udpipe_csharpPINVOKE.Sentence_rootForm_get();
        return ret;
      }
    }

    public Words words
    {
      set => udpipe_csharpPINVOKE.Sentence_words_set(swigCPtr, Words.getCPtr(value));
      get
      {
        var cPtr = udpipe_csharpPINVOKE.Sentence_words_get(swigCPtr);
        var ret = cPtr == IntPtr.Zero ? null : new Words(cPtr, false);
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
            udpipe_csharpPINVOKE.delete_Sentence(swigCPtr);
          }

          swigCPtr = new HandleRef(null, IntPtr.Zero);
        }

        GC.SuppressFinalize(this);
      }
    }

    public virtual Word addWord(string form)
    {
      var ret = new Word(udpipe_csharpPINVOKE.Sentence_addWord(swigCPtr, form), false);
      return ret;
    }

    public void clear()
    {
      udpipe_csharpPINVOKE.Sentence_clear(swigCPtr);
    }

    public bool empty()
    {
      var ret = udpipe_csharpPINVOKE.Sentence_empty(swigCPtr);
      return ret;
    }

    ~Sentence()
    {
      Dispose();
    }

    internal static HandleRef getCPtr(Sentence obj)
    {
      return obj == null ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
    }

    public bool getNewDoc()
    {
      var ret = udpipe_csharpPINVOKE.Sentence_getNewDoc(swigCPtr);
      return ret;
    }

    public string getNewDocId()
    {
      var ret = udpipe_csharpPINVOKE.Sentence_getNewDocId(swigCPtr);
      return ret;
    }

    public bool getNewPar()
    {
      var ret = udpipe_csharpPINVOKE.Sentence_getNewPar(swigCPtr);
      return ret;
    }

    public string getNewParId()
    {
      var ret = udpipe_csharpPINVOKE.Sentence_getNewParId(swigCPtr);
      return ret;
    }

    public string getSentId()
    {
      var ret = udpipe_csharpPINVOKE.Sentence_getSentId(swigCPtr);
      return ret;
    }

    public string getText()
    {
      var ret = udpipe_csharpPINVOKE.Sentence_getText(swigCPtr);
      return ret;
    }

    public void setHead(int id, int head, string deprel)
    {
      udpipe_csharpPINVOKE.Sentence_setHead(swigCPtr, id, head, deprel);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void setNewDoc(bool new_doc, string id)
    {
      udpipe_csharpPINVOKE.Sentence_setNewDoc__SWIG_0(swigCPtr, new_doc, id);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void setNewDoc(bool new_doc)
    {
      udpipe_csharpPINVOKE.Sentence_setNewDoc__SWIG_1(swigCPtr, new_doc);
    }

    public void setNewPar(bool new_par, string id)
    {
      udpipe_csharpPINVOKE.Sentence_setNewPar__SWIG_0(swigCPtr, new_par, id);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void setNewPar(bool new_par)
    {
      udpipe_csharpPINVOKE.Sentence_setNewPar__SWIG_1(swigCPtr, new_par);
    }

    public void setSentId(string id)
    {
      udpipe_csharpPINVOKE.Sentence_setSentId(swigCPtr, id);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void setText(string id)
    {
      udpipe_csharpPINVOKE.Sentence_setText(swigCPtr, id);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void unlinkAllNodes()
    {
      udpipe_csharpPINVOKE.Sentence_unlinkAllNodes(swigCPtr);
    }
  }
}