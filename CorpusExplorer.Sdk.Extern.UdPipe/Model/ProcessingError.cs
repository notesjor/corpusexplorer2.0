using System;
using System.Runtime.InteropServices;

namespace CorpusExplorer.Sdk.Extern.UdPipe.Model
{
  public class ProcessingError : IDisposable
  {
    protected bool swigCMemOwn;
    private HandleRef swigCPtr;

    public ProcessingError() : this(udpipe_csharpPINVOKE.new_ProcessingError(), true)
    {
    }

    internal ProcessingError(IntPtr cPtr, bool cMemoryOwn)
    {
      swigCMemOwn = cMemoryOwn;
      swigCPtr = new HandleRef(this, cPtr);
    }

    public string message
    {
      set
      {
        udpipe_csharpPINVOKE.ProcessingError_message_set(swigCPtr, value);
        if (udpipe_csharpPINVOKE.SWIGPendingException.Pending)
          throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      }
      get
      {
        string ret = udpipe_csharpPINVOKE.ProcessingError_message_get(swigCPtr);
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
            udpipe_csharpPINVOKE.delete_ProcessingError(swigCPtr);
          }

          swigCPtr = new HandleRef(null, IntPtr.Zero);
        }

        GC.SuppressFinalize(this);
      }
    }

    public bool occurred()
    {
      bool ret = udpipe_csharpPINVOKE.ProcessingError_occurred(swigCPtr);
      return ret;
    }

    internal static HandleRef getCPtr(ProcessingError obj)
    {
      return obj == null ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
    }

    ~ProcessingError()
    {
      Dispose();
    }
  }
}