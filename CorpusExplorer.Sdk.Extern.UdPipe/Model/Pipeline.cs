#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace CorpusExplorer.Sdk.Extern.UdPipe.Model
{
  public class Pipeline : IDisposable
  {
    protected bool swigCMemOwn;
    private HandleRef swigCPtr;

    public Pipeline(Model m, string input, string tagger, string parser, string output) : this(
     udpipe_csharpPINVOKE
      .new_Pipeline(Model.getCPtr(m),
                    input,
                    tagger,
                    parser,
                    output),
     true)
    {
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    internal Pipeline(IntPtr cPtr, bool cMemoryOwn)
    {
      swigCMemOwn = cMemoryOwn;
      swigCPtr = new HandleRef(this, cPtr);
    }

    public static string DEFAULT
    {
      get
      {
        var ret = udpipe_csharpPINVOKE.Pipeline_DEFAULT_get();
        return ret;
      }
    }

    public static string NONE
    {
      get
      {
        var ret = udpipe_csharpPINVOKE.Pipeline_NONE_get();
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
            udpipe_csharpPINVOKE.delete_Pipeline(swigCPtr);
          }

          swigCPtr = new HandleRef(null, IntPtr.Zero);
        }

        GC.SuppressFinalize(this);
      }
    }

    ~Pipeline()
    {
      Dispose();
    }

    internal static HandleRef getCPtr(Pipeline obj) => obj == null ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;

    public string process(string data, ProcessingError error)
    {
      var ret = udpipe_csharpPINVOKE.Pipeline_process__SWIG_0(swigCPtr, data, ProcessingError.getCPtr(error));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public string process(string data)
    {
      var ret = udpipe_csharpPINVOKE.Pipeline_process__SWIG_1(swigCPtr, data);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public void setDocumentId(string document_id)
    {
      udpipe_csharpPINVOKE.Pipeline_setDocumentId(swigCPtr, document_id);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void setImmediate(bool immediate)
    {
      udpipe_csharpPINVOKE.Pipeline_setImmediate(swigCPtr, immediate);
    }

    public void setInput(string input)
    {
      udpipe_csharpPINVOKE.Pipeline_setInput(swigCPtr, input);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void setModel(Model m)
    {
      udpipe_csharpPINVOKE.Pipeline_setModel(swigCPtr, Model.getCPtr(m));
    }

    public void setOutput(string output)
    {
      udpipe_csharpPINVOKE.Pipeline_setOutput(swigCPtr, output);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void setParser(string parser)
    {
      udpipe_csharpPINVOKE.Pipeline_setParser(swigCPtr, parser);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void setTagger(string tagger)
    {
      udpipe_csharpPINVOKE.Pipeline_setTagger(swigCPtr, tagger);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }
  }
}