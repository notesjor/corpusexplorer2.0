#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace CorpusExplorer.Sdk.Extern.UdPipe.Model
{
  public class Model : IDisposable
  {
    protected bool swigCMemOwn;
    private HandleRef swigCPtr;

    internal Model(IntPtr cPtr, bool cMemoryOwn)
    {
      swigCMemOwn = cMemoryOwn;
      swigCPtr = new HandleRef(this, cPtr);
    }

    public static string DEFAULT
    {
      get
      {
        var ret = udpipe_csharpPINVOKE.Model_DEFAULT_get();
        return ret;
      }
    }

    public static string TOKENIZER_NORMALIZED_SPACES
    {
      get
      {
        var ret = udpipe_csharpPINVOKE.Model_TOKENIZER_NORMALIZED_SPACES_get();
        return ret;
      }
    }

    public static string TOKENIZER_PRESEGMENTED
    {
      get
      {
        var ret = udpipe_csharpPINVOKE.Model_TOKENIZER_PRESEGMENTED_get();
        return ret;
      }
    }

    public static string TOKENIZER_RANGES
    {
      get
      {
        var ret = udpipe_csharpPINVOKE.Model_TOKENIZER_RANGES_get();
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
            udpipe_csharpPINVOKE.delete_Model(swigCPtr);
          }

          swigCPtr = new HandleRef(null, IntPtr.Zero);
        }

        GC.SuppressFinalize(this);
      }
    }

    ~Model()
    {
      Dispose();
    }

    internal static HandleRef getCPtr(Model obj) => obj == null ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;

    public static Model load(string fname)
    {
      var cPtr = udpipe_csharpPINVOKE.Model_load(fname);
      var ret = cPtr == IntPtr.Zero ? null : new Model(cPtr, true);
      return ret;
    }

    public virtual InputFormat newTokenizer(string options)
    {
      var cPtr = udpipe_csharpPINVOKE.Model_newTokenizer(swigCPtr, options);
      var ret = cPtr == IntPtr.Zero ? null : new InputFormat(cPtr, true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public virtual bool parse(Sentence s, string options, ProcessingError error)
    {
      var ret = udpipe_csharpPINVOKE.Model_parse__SWIG_0(swigCPtr, Sentence.getCPtr(s), options,
                                                         ProcessingError.getCPtr(error));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public virtual bool parse(Sentence s, string options)
    {
      var ret = udpipe_csharpPINVOKE.Model_parse__SWIG_1(swigCPtr, Sentence.getCPtr(s), options);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public virtual bool tag(Sentence s, string options, ProcessingError error)
    {
      var ret = udpipe_csharpPINVOKE.Model_tag__SWIG_0(swigCPtr, Sentence.getCPtr(s), options,
                                                       ProcessingError.getCPtr(error));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public virtual bool tag(Sentence s, string options)
    {
      var ret = udpipe_csharpPINVOKE.Model_tag__SWIG_1(swigCPtr, Sentence.getCPtr(s), options);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }
  }
}