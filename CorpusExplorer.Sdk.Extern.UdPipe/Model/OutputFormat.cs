using System;
using System.Runtime.InteropServices;

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
        string ret = udpipe_csharpPINVOKE.OutputFormat_CONLLU_V1_get();
        return ret;
      }
    }

    public static string CONLLU_V2
    {
      get
      {
        string ret = udpipe_csharpPINVOKE.OutputFormat_CONLLU_V2_get();
        return ret;
      }
    }

    public static string HORIZONTAL_PARAGRAPHS
    {
      get
      {
        string ret = udpipe_csharpPINVOKE.OutputFormat_HORIZONTAL_PARAGRAPHS_get();
        return ret;
      }
    }

    public static string PLAINTEXT_NORMALIZED_SPACES
    {
      get
      {
        string ret = udpipe_csharpPINVOKE.OutputFormat_PLAINTEXT_NORMALIZED_SPACES_get();
        return ret;
      }
    }

    public static string VERTICAL_PARAGRAPHS
    {
      get
      {
        string ret = udpipe_csharpPINVOKE.OutputFormat_VERTICAL_PARAGRAPHS_get();
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

    public virtual string finishDocument()
    {
      string ret = udpipe_csharpPINVOKE.OutputFormat_finishDocument(swigCPtr);
      return ret;
    }

    public static OutputFormat newConlluOutputFormat(string options)
    {
      IntPtr cPtr = udpipe_csharpPINVOKE.OutputFormat_newConlluOutputFormat__SWIG_0(options);
      OutputFormat ret = cPtr == IntPtr.Zero ? null : new OutputFormat(cPtr, true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public static OutputFormat newConlluOutputFormat()
    {
      IntPtr cPtr = udpipe_csharpPINVOKE.OutputFormat_newConlluOutputFormat__SWIG_1();
      OutputFormat ret = cPtr == IntPtr.Zero ? null : new OutputFormat(cPtr, true);
      return ret;
    }

    public static OutputFormat newEpeOutputFormat(string options)
    {
      IntPtr cPtr = udpipe_csharpPINVOKE.OutputFormat_newEpeOutputFormat__SWIG_0(options);
      OutputFormat ret = cPtr == IntPtr.Zero ? null : new OutputFormat(cPtr, true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public static OutputFormat newEpeOutputFormat()
    {
      IntPtr cPtr = udpipe_csharpPINVOKE.OutputFormat_newEpeOutputFormat__SWIG_1();
      OutputFormat ret = cPtr == IntPtr.Zero ? null : new OutputFormat(cPtr, true);
      return ret;
    }

    public static OutputFormat newHorizontalOutputFormat(string options)
    {
      IntPtr cPtr = udpipe_csharpPINVOKE.OutputFormat_newHorizontalOutputFormat__SWIG_0(options);
      OutputFormat ret = cPtr == IntPtr.Zero ? null : new OutputFormat(cPtr, true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public static OutputFormat newHorizontalOutputFormat()
    {
      IntPtr cPtr = udpipe_csharpPINVOKE.OutputFormat_newHorizontalOutputFormat__SWIG_1();
      OutputFormat ret = cPtr == IntPtr.Zero ? null : new OutputFormat(cPtr, true);
      return ret;
    }

    public static OutputFormat newMatxinOutputFormat(string options)
    {
      IntPtr cPtr = udpipe_csharpPINVOKE.OutputFormat_newMatxinOutputFormat__SWIG_0(options);
      OutputFormat ret = cPtr == IntPtr.Zero ? null : new OutputFormat(cPtr, true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public static OutputFormat newMatxinOutputFormat()
    {
      IntPtr cPtr = udpipe_csharpPINVOKE.OutputFormat_newMatxinOutputFormat__SWIG_1();
      OutputFormat ret = cPtr == IntPtr.Zero ? null : new OutputFormat(cPtr, true);
      return ret;
    }

    public static OutputFormat newOutputFormat(string name)
    {
      IntPtr cPtr = udpipe_csharpPINVOKE.OutputFormat_newOutputFormat(name);
      OutputFormat ret = cPtr == IntPtr.Zero ? null : new OutputFormat(cPtr, true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public static OutputFormat newPlaintextOutputFormat(string options)
    {
      IntPtr cPtr = udpipe_csharpPINVOKE.OutputFormat_newPlaintextOutputFormat__SWIG_0(options);
      OutputFormat ret = cPtr == IntPtr.Zero ? null : new OutputFormat(cPtr, true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public static OutputFormat newPlaintextOutputFormat()
    {
      IntPtr cPtr = udpipe_csharpPINVOKE.OutputFormat_newPlaintextOutputFormat__SWIG_1();
      OutputFormat ret = cPtr == IntPtr.Zero ? null : new OutputFormat(cPtr, true);
      return ret;
    }

    public static OutputFormat newVerticalOutputFormat(string options)
    {
      IntPtr cPtr = udpipe_csharpPINVOKE.OutputFormat_newVerticalOutputFormat__SWIG_0(options);
      OutputFormat ret = cPtr == IntPtr.Zero ? null : new OutputFormat(cPtr, true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public static OutputFormat newVerticalOutputFormat()
    {
      IntPtr cPtr = udpipe_csharpPINVOKE.OutputFormat_newVerticalOutputFormat__SWIG_1();
      OutputFormat ret = cPtr == IntPtr.Zero ? null : new OutputFormat(cPtr, true);
      return ret;
    }

    public virtual string writeSentence(Sentence s)
    {
      string ret = udpipe_csharpPINVOKE.OutputFormat_writeSentence(swigCPtr, Sentence.getCPtr(s));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    internal static HandleRef getCPtr(OutputFormat obj)
    {
      return obj == null ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
    }

    ~OutputFormat()
    {
      Dispose();
    }
  }
}