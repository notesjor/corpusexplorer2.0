#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace CorpusExplorer.Sdk.Extern.UdPipe.Model
{
  public class Evaluator : IDisposable
  {
    protected bool swigCMemOwn;
    private HandleRef swigCPtr;

    public Evaluator(Model m, string tokenizer, string tagger, string parser) : this(
                                                                                     udpipe_csharpPINVOKE
                                                                                      .new_Evaluator(Model.getCPtr(m),
                                                                                                     tokenizer, tagger,
                                                                                                     parser), true)
    {
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    internal Evaluator(IntPtr cPtr, bool cMemoryOwn)
    {
      swigCMemOwn = cMemoryOwn;
      swigCPtr = new HandleRef(this, cPtr);
    }

    public static string DEFAULT
    {
      get
      {
        var ret = udpipe_csharpPINVOKE.Evaluator_DEFAULT_get();
        return ret;
      }
    }

    public static string NONE
    {
      get
      {
        var ret = udpipe_csharpPINVOKE.Evaluator_NONE_get();
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
            udpipe_csharpPINVOKE.delete_Evaluator(swigCPtr);
          }

          swigCPtr = new HandleRef(null, IntPtr.Zero);
        }

        GC.SuppressFinalize(this);
      }
    }

    public string evaluate(string data, ProcessingError error)
    {
      var ret = udpipe_csharpPINVOKE.Evaluator_evaluate__SWIG_0(swigCPtr, data, ProcessingError.getCPtr(error));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public string evaluate(string data)
    {
      var ret = udpipe_csharpPINVOKE.Evaluator_evaluate__SWIG_1(swigCPtr, data);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    ~Evaluator()
    {
      Dispose();
    }

    internal static HandleRef getCPtr(Evaluator obj)
    {
      return obj == null ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
    }

    public void setModel(Model m)
    {
      udpipe_csharpPINVOKE.Evaluator_setModel(swigCPtr, Model.getCPtr(m));
    }

    public void setParser(string parser)
    {
      udpipe_csharpPINVOKE.Evaluator_setParser(swigCPtr, parser);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void setTagger(string tagger)
    {
      udpipe_csharpPINVOKE.Evaluator_setTagger(swigCPtr, tagger);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void setTokenizer(string tokenizer)
    {
      udpipe_csharpPINVOKE.Evaluator_setTokenizer(swigCPtr, tokenizer);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }
  }
}