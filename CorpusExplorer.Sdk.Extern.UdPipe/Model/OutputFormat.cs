#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace CorpusExplorer.Sdk.Extern.UdPipe.Model
{
  public class OutputFormat : IDisposable
  {
    protected bool swigCMemOwn;
    private HandleRef swigCPtr;

    internal OutputFormat(IntPtr cPtr, bool cMemoryOwn)
    {
      swigCMemOwn = cMemoryOwn;
      swigCPtr = new HandleRef(this, cPtr);
    }

    public static string CONLLU_V1
    {
      get
      {
        var ret = udpipe_csharpPINVOKE.OutputFormat_CONLLU_V1_get();
        return ret;
      }
    }

    public static string CONLLU_V2
    {
      get
      {
        var ret = udpipe_csharpPINVOKE.OutputFormat_CONLLU_V2_get();
        return ret;
      }
    }

    public static string HORIZONTAL_PARAGRAPHS
    {
      get
      {
        var ret = udpipe_csharpPINVOKE.OutputFormat_HORIZONTAL_PARAGRAPHS_get();
        return ret;
      }
    }

    public static string PLAINTEXT_NORMALIZED_SPACES
    {
      get
      {
        var ret = udpipe_csharpPINVOKE.OutputFormat_PLAINTEXT_NORMALIZED_SPACES_get();
        return ret;
      }
    }

    public static string VERTICAL_PARAGRAPHS
    {
      get
      {
        var ret = udpipe_csharpPINVOKE.OutputFormat_VERTICAL_PARAGRAPHS_get();
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
            udpipe_csharpPINVOKE.delete_OutputFormat(swigCPtr);
          }

          swigCPtr = new HandleRef(null, IntPtr.Zero);
        }

        GC.SuppressFinalize(this);
      }
    }

    ~OutputFormat()
    {
      Dispose();
    }

    public virtual string finishDocument()
    {
      var ret = udpipe_csharpPINVOKE.OutputFormat_finishDocument(swigCPtr);
      return ret;
    }

    internal static HandleRef getCPtr(OutputFormat obj)
    {
      return obj == null ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
    }

    public static OutputFormat newConlluOutputFormat(string options)
    {
      var cPtr = udpipe_csharpPINVOKE.OutputFormat_newConlluOutputFormat__SWIG_0(options);
      var ret = cPtr == IntPtr.Zero ? null : new OutputFormat(cPtr, true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public static OutputFormat newConlluOutputFormat()
    {
      var cPtr = udpipe_csharpPINVOKE.OutputFormat_newConlluOutputFormat__SWIG_1();
      var ret = cPtr == IntPtr.Zero ? null : new OutputFormat(cPtr, true);
      return ret;
    }

    public static OutputFormat newEpeOutputFormat(string options)
    {
      var cPtr = udpipe_csharpPINVOKE.OutputFormat_newEpeOutputFormat__SWIG_0(options);
      var ret = cPtr == IntPtr.Zero ? null : new OutputFormat(cPtr, true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public static OutputFormat newEpeOutputFormat()
    {
      var cPtr = udpipe_csharpPINVOKE.OutputFormat_newEpeOutputFormat__SWIG_1();
      var ret = cPtr == IntPtr.Zero ? null : new OutputFormat(cPtr, true);
      return ret;
    }

    public static OutputFormat newHorizontalOutputFormat(string options)
    {
      var cPtr = udpipe_csharpPINVOKE.OutputFormat_newHorizontalOutputFormat__SWIG_0(options);
      var ret = cPtr == IntPtr.Zero ? null : new OutputFormat(cPtr, true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public static OutputFormat newHorizontalOutputFormat()
    {
      var cPtr = udpipe_csharpPINVOKE.OutputFormat_newHorizontalOutputFormat__SWIG_1();
      var ret = cPtr == IntPtr.Zero ? null : new OutputFormat(cPtr, true);
      return ret;
    }

    public static OutputFormat newMatxinOutputFormat(string options)
    {
      var cPtr = udpipe_csharpPINVOKE.OutputFormat_newMatxinOutputFormat__SWIG_0(options);
      var ret = cPtr == IntPtr.Zero ? null : new OutputFormat(cPtr, true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public static OutputFormat newMatxinOutputFormat()
    {
      var cPtr = udpipe_csharpPINVOKE.OutputFormat_newMatxinOutputFormat__SWIG_1();
      var ret = cPtr == IntPtr.Zero ? null : new OutputFormat(cPtr, true);
      return ret;
    }

    public static OutputFormat newOutputFormat(string name)
    {
      var cPtr = udpipe_csharpPINVOKE.OutputFormat_newOutputFormat(name);
      var ret = cPtr == IntPtr.Zero ? null : new OutputFormat(cPtr, true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public static OutputFormat newPlaintextOutputFormat(string options)
    {
      var cPtr = udpipe_csharpPINVOKE.OutputFormat_newPlaintextOutputFormat__SWIG_0(options);
      var ret = cPtr == IntPtr.Zero ? null : new OutputFormat(cPtr, true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public static OutputFormat newPlaintextOutputFormat()
    {
      var cPtr = udpipe_csharpPINVOKE.OutputFormat_newPlaintextOutputFormat__SWIG_1();
      var ret = cPtr == IntPtr.Zero ? null : new OutputFormat(cPtr, true);
      return ret;
    }

    public static OutputFormat newVerticalOutputFormat(string options)
    {
      var cPtr = udpipe_csharpPINVOKE.OutputFormat_newVerticalOutputFormat__SWIG_0(options);
      var ret = cPtr == IntPtr.Zero ? null : new OutputFormat(cPtr, true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public static OutputFormat newVerticalOutputFormat()
    {
      var cPtr = udpipe_csharpPINVOKE.OutputFormat_newVerticalOutputFormat__SWIG_1();
      var ret = cPtr == IntPtr.Zero ? null : new OutputFormat(cPtr, true);
      return ret;
    }

    public virtual string writeSentence(Sentence s)
    {
      var ret = udpipe_csharpPINVOKE.OutputFormat_writeSentence(swigCPtr, Sentence.getCPtr(s));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }
  }
}