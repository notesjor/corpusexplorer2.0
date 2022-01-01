#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace CorpusExplorer.Sdk.Extern.UdPipe.Model
{
  public class Trainer : IDisposable
  {
    protected bool swigCMemOwn;
    private HandleRef swigCPtr;

    public Trainer() : this(udpipe_csharpPINVOKE.new_Trainer(), true)
    {
    }

    internal Trainer(IntPtr cPtr, bool cMemoryOwn)
    {
      swigCMemOwn = cMemoryOwn;
      swigCPtr = new HandleRef(this, cPtr);
    }

    public static string DEFAULT
    {
      get
      {
        var ret = udpipe_csharpPINVOKE.Trainer_DEFAULT_get();
        return ret;
      }
    }

    public static string NONE
    {
      get
      {
        var ret = udpipe_csharpPINVOKE.Trainer_NONE_get();
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
            udpipe_csharpPINVOKE.delete_Trainer(swigCPtr);
          }

          swigCPtr = new HandleRef(null, IntPtr.Zero);
        }

        GC.SuppressFinalize(this);
      }
    }

    ~Trainer()
    {
      Dispose();
    }

    internal static HandleRef getCPtr(Trainer obj) => obj == null ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;

    public static string train(string method, Sentences train, Sentences heldout, string tokenizer, string tagger,
                               string parser, ProcessingError error)
    {
      var ret = udpipe_csharpPINVOKE.Trainer_train__SWIG_0(method, Sentences.getCPtr(train),
                                                           Sentences.getCPtr(heldout), tokenizer, tagger, parser,
                                                           ProcessingError.getCPtr(error));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public static string train(string method, Sentences train, Sentences heldout, string tokenizer, string tagger,
                               string parser)
    {
      var ret = udpipe_csharpPINVOKE.Trainer_train__SWIG_1(method, Sentences.getCPtr(train),
                                                           Sentences.getCPtr(heldout), tokenizer, tagger, parser);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }
  }
}