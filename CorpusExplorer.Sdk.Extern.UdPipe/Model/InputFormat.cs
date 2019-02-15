using System;
using System.Runtime.InteropServices;

namespace CorpusExplorer.Sdk.Extern.UdPipe.Model
{
  public class InputFormat : IDisposable
  {
    protected bool swigCMemOwn;
    private HandleRef swigCPtr;

    internal InputFormat(IntPtr cPtr, bool cMemoryOwn)
    {
      swigCMemOwn = cMemoryOwn;
      swigCPtr = new HandleRef(this, cPtr);
    }

    public static string CONLLU_V1
    {
      get
      {
        var ret = udpipe_csharpPINVOKE.InputFormat_CONLLU_V1_get();
        return ret;
      }
    }

    public static string CONLLU_V2
    {
      get
      {
        var ret = udpipe_csharpPINVOKE.InputFormat_CONLLU_V2_get();
        return ret;
      }
    }

    public static string GENERIC_TOKENIZER_NORMALIZED_SPACES
    {
      get
      {
        var ret = udpipe_csharpPINVOKE.InputFormat_GENERIC_TOKENIZER_NORMALIZED_SPACES_get();
        return ret;
      }
    }

    public static string GENERIC_TOKENIZER_PRESEGMENTED
    {
      get
      {
        var ret = udpipe_csharpPINVOKE.InputFormat_GENERIC_TOKENIZER_PRESEGMENTED_get();
        return ret;
      }
    }

    public static string GENERIC_TOKENIZER_RANGES
    {
      get
      {
        var ret = udpipe_csharpPINVOKE.InputFormat_GENERIC_TOKENIZER_RANGES_get();
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
            udpipe_csharpPINVOKE.delete_InputFormat(swigCPtr);
          }

          swigCPtr = new HandleRef(null, IntPtr.Zero);
        }

        GC.SuppressFinalize(this);
      }
    }

    public static InputFormat newConlluInputFormat(string options)
    {
      var cPtr = udpipe_csharpPINVOKE.InputFormat_newConlluInputFormat__SWIG_0(options);
      var ret = cPtr == IntPtr.Zero ? null : new InputFormat(cPtr, true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public static InputFormat newConlluInputFormat()
    {
      var cPtr = udpipe_csharpPINVOKE.InputFormat_newConlluInputFormat__SWIG_1();
      var ret = cPtr == IntPtr.Zero ? null : new InputFormat(cPtr, true);
      return ret;
    }

    public static InputFormat newGenericTokenizerInputFormat(string options)
    {
      var cPtr = udpipe_csharpPINVOKE.InputFormat_newGenericTokenizerInputFormat__SWIG_0(options);
      var ret = cPtr == IntPtr.Zero ? null : new InputFormat(cPtr, true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public static InputFormat newGenericTokenizerInputFormat()
    {
      var cPtr = udpipe_csharpPINVOKE.InputFormat_newGenericTokenizerInputFormat__SWIG_1();
      var ret = cPtr == IntPtr.Zero ? null : new InputFormat(cPtr, true);
      return ret;
    }

    public static InputFormat newHorizontalInputFormat(string options)
    {
      var cPtr = udpipe_csharpPINVOKE.InputFormat_newHorizontalInputFormat__SWIG_0(options);
      var ret = cPtr == IntPtr.Zero ? null : new InputFormat(cPtr, true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public static InputFormat newHorizontalInputFormat()
    {
      var cPtr = udpipe_csharpPINVOKE.InputFormat_newHorizontalInputFormat__SWIG_1();
      var ret = cPtr == IntPtr.Zero ? null : new InputFormat(cPtr, true);
      return ret;
    }

    public static InputFormat newInputFormat(string name)
    {
      var cPtr = udpipe_csharpPINVOKE.InputFormat_newInputFormat(name);
      var ret = cPtr == IntPtr.Zero ? null : new InputFormat(cPtr, true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public static InputFormat newPresegmentedTokenizer(InputFormat DISOWN)
    {
      var cPtr = udpipe_csharpPINVOKE.InputFormat_newPresegmentedTokenizer(getCPtrAndDisown(DISOWN));
      var ret = cPtr == IntPtr.Zero ? null : new InputFormat(cPtr, true);
      return ret;
    }

    public static InputFormat newVerticalInputFormat(string options)
    {
      var cPtr = udpipe_csharpPINVOKE.InputFormat_newVerticalInputFormat__SWIG_0(options);
      var ret = cPtr == IntPtr.Zero ? null : new InputFormat(cPtr, true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public static InputFormat newVerticalInputFormat()
    {
      var cPtr = udpipe_csharpPINVOKE.InputFormat_newVerticalInputFormat__SWIG_1();
      var ret = cPtr == IntPtr.Zero ? null : new InputFormat(cPtr, true);
      return ret;
    }

    public virtual bool nextSentence(Sentence s, ProcessingError error)
    {
      var ret = udpipe_csharpPINVOKE.InputFormat_nextSentence__SWIG_0(swigCPtr, Sentence.getCPtr(s),
                                                                      ProcessingError.getCPtr(error));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public virtual bool nextSentence(Sentence s)
    {
      var ret = udpipe_csharpPINVOKE.InputFormat_nextSentence__SWIG_1(swigCPtr, Sentence.getCPtr(s));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public virtual void resetDocument(string id)
    {
      udpipe_csharpPINVOKE.InputFormat_resetDocument__SWIG_0(swigCPtr, id);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual void resetDocument()
    {
      udpipe_csharpPINVOKE.InputFormat_resetDocument__SWIG_1(swigCPtr);
    }

    public virtual void setText(string text)
    {
      udpipe_csharpPINVOKE.InputFormat_setText(swigCPtr, text);
    }

    internal static HandleRef getCPtr(InputFormat obj)
    {
      return obj == null ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
    }

    internal static HandleRef getCPtrAndDisown(InputFormat obj)
    {
      if (obj != null) obj.swigCMemOwn = false;
      return getCPtr(obj);
    }

    ~InputFormat()
    {
      Dispose();
    }
  }
}