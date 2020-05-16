#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#endregion

namespace CorpusExplorer.Sdk.Extern.UdPipe.Model
{
  public class MultiwordTokens : IDisposable, IEnumerable, IEnumerable<MultiwordToken>
  {
    protected bool swigCMemOwn;
    private HandleRef swigCPtr;

    public MultiwordTokens(ICollection c) : this()
    {
      if (c == null)
        throw new ArgumentNullException("c");
      foreach (MultiwordToken element in c) Add(element);
    }

    public MultiwordTokens() : this(udpipe_csharpPINVOKE.new_MultiwordTokens__SWIG_0(), true)
    {
    }

    public MultiwordTokens(MultiwordTokens other) : this(
                                                         udpipe_csharpPINVOKE
                                                          .new_MultiwordTokens__SWIG_1(getCPtr(other)), true)
    {
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public MultiwordTokens(int capacity) : this(udpipe_csharpPINVOKE.new_MultiwordTokens__SWIG_2(capacity), true)
    {
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    internal MultiwordTokens(IntPtr cPtr, bool cMemoryOwn)
    {
      swigCMemOwn = cMemoryOwn;
      swigCPtr = new HandleRef(this, cPtr);
    }

    public int Capacity
    {
      get => (int) capacity();
      set
      {
        if (value < size())
          throw new ArgumentOutOfRangeException("Capacity");
        reserve((uint) value);
      }
    }

    public int Count => (int) size();

    public bool IsFixedSize => false;

    public bool IsReadOnly => false;

    public bool IsSynchronized => false;

    public MultiwordToken this[int index]
    {
      get => getitem(index);
      set => setitem(index, value);
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
            udpipe_csharpPINVOKE.delete_MultiwordTokens(swigCPtr);
          }

          swigCPtr = new HandleRef(null, IntPtr.Zero);
        }

        GC.SuppressFinalize(this);
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return new MultiwordTokensEnumerator(this);
    }

    IEnumerator<MultiwordToken> IEnumerable<MultiwordToken>.GetEnumerator()
    {
      return new MultiwordTokensEnumerator(this);
    }

    public void Add(MultiwordToken x)
    {
      udpipe_csharpPINVOKE.MultiwordTokens_Add(swigCPtr, MultiwordToken.getCPtr(x));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void AddRange(MultiwordTokens values)
    {
      udpipe_csharpPINVOKE.MultiwordTokens_AddRange(swigCPtr, getCPtr(values));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    private uint capacity()
    {
      var ret = udpipe_csharpPINVOKE.MultiwordTokens_capacity(swigCPtr);
      return ret;
    }

    public void Clear()
    {
      udpipe_csharpPINVOKE.MultiwordTokens_Clear(swigCPtr);
    }

    public void CopyTo(MultiwordToken[] array)
    {
      CopyTo(0, array, 0, Count);
    }

    public void CopyTo(MultiwordToken[] array, int arrayIndex)
    {
      CopyTo(0, array, arrayIndex, Count);
    }

    public void CopyTo(int index, MultiwordToken[] array, int arrayIndex, int count)
    {
      if (array == null)
        throw new ArgumentNullException("array");
      if (index < 0)
        throw new ArgumentOutOfRangeException("index", "Value is less than zero");
      if (arrayIndex < 0)
        throw new ArgumentOutOfRangeException("arrayIndex", "Value is less than zero");
      if (count < 0)
        throw new ArgumentOutOfRangeException("count", "Value is less than zero");
      if (array.Rank > 1)
        throw new ArgumentException("Multi dimensional array.", "array");
      if (index + count > Count || arrayIndex + count > array.Length)
        throw new ArgumentException("Number of elements to copy is too large.");
      for (var i = 0; i < count; i++)
        array.SetValue(getitemcopy(index + i), arrayIndex + i);
    }

    ~MultiwordTokens()
    {
      Dispose();
    }

    internal static HandleRef getCPtr(MultiwordTokens obj)
    {
      return obj == null ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
    }

    public MultiwordTokensEnumerator GetEnumerator()
    {
      return new MultiwordTokensEnumerator(this);
    }

    private MultiwordToken getitem(int index)
    {
      var ret = new MultiwordToken(udpipe_csharpPINVOKE.MultiwordTokens_getitem(swigCPtr, index), false);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    private MultiwordToken getitemcopy(int index)
    {
      var ret = new MultiwordToken(udpipe_csharpPINVOKE.MultiwordTokens_getitemcopy(swigCPtr, index), true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public MultiwordTokens GetRange(int index, int count)
    {
      var cPtr = udpipe_csharpPINVOKE.MultiwordTokens_GetRange(swigCPtr, index, count);
      var ret = cPtr == IntPtr.Zero ? null : new MultiwordTokens(cPtr, true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public void Insert(int index, MultiwordToken x)
    {
      udpipe_csharpPINVOKE.MultiwordTokens_Insert(swigCPtr, index, MultiwordToken.getCPtr(x));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void InsertRange(int index, MultiwordTokens values)
    {
      udpipe_csharpPINVOKE.MultiwordTokens_InsertRange(swigCPtr, index, getCPtr(values));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void RemoveAt(int index)
    {
      udpipe_csharpPINVOKE.MultiwordTokens_RemoveAt(swigCPtr, index);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void RemoveRange(int index, int count)
    {
      udpipe_csharpPINVOKE.MultiwordTokens_RemoveRange(swigCPtr, index, count);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public static MultiwordTokens Repeat(MultiwordToken value, int count)
    {
      var cPtr = udpipe_csharpPINVOKE.MultiwordTokens_Repeat(MultiwordToken.getCPtr(value), count);
      var ret = cPtr == IntPtr.Zero ? null : new MultiwordTokens(cPtr, true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    private void reserve(uint n)
    {
      udpipe_csharpPINVOKE.MultiwordTokens_reserve(swigCPtr, n);
    }

    public void Reverse()
    {
      udpipe_csharpPINVOKE.MultiwordTokens_Reverse__SWIG_0(swigCPtr);
    }

    public void Reverse(int index, int count)
    {
      udpipe_csharpPINVOKE.MultiwordTokens_Reverse__SWIG_1(swigCPtr, index, count);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    private void setitem(int index, MultiwordToken val)
    {
      udpipe_csharpPINVOKE.MultiwordTokens_setitem(swigCPtr, index, MultiwordToken.getCPtr(val));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void SetRange(int index, MultiwordTokens values)
    {
      udpipe_csharpPINVOKE.MultiwordTokens_SetRange(swigCPtr, index, getCPtr(values));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    private uint size()
    {
      var ret = udpipe_csharpPINVOKE.MultiwordTokens_size(swigCPtr);
      return ret;
    }

    // Type-safe enumerator
    /// Note that the IEnumerator documentation requires an InvalidOperationException to be thrown
    /// whenever the collection is modified. This has been done for changes in the size of the
    /// collection but not when one of the elements of the collection is modified as it is a bit
    /// tricky to detect unmanaged code that modifies the collection under our feet.
    public sealed class MultiwordTokensEnumerator : IEnumerator, IEnumerator<MultiwordToken>
    {
      private readonly MultiwordTokens collectionRef;
      private readonly int currentSize;
      private int currentIndex;
      private object currentObject;

      public MultiwordTokensEnumerator(MultiwordTokens collection)
      {
        collectionRef = collection;
        currentIndex = -1;
        currentObject = null;
        currentSize = collectionRef.Count;
      }

      public void Dispose()
      {
        currentIndex = -1;
        currentObject = null;
      }

      // Type-unsafe IEnumerator.Current
      object IEnumerator.Current => Current;

      public bool MoveNext()
      {
        var size = collectionRef.Count;
        var moveOkay = currentIndex + 1 < size && size == currentSize;
        if (moveOkay)
        {
          currentIndex++;
          currentObject = collectionRef[currentIndex];
        }
        else
        {
          currentObject = null;
        }

        return moveOkay;
      }

      public void Reset()
      {
        currentIndex = -1;
        currentObject = null;
        if (collectionRef.Count != currentSize) throw new InvalidOperationException("Collection modified.");
      }

      // Type-safe iterator Current
      public MultiwordToken Current
      {
        get
        {
          if (currentIndex == -1)
            throw new InvalidOperationException("Enumeration not started.");
          if (currentIndex > currentSize - 1)
            throw new InvalidOperationException("Enumeration finished.");
          if (currentObject == null)
            throw new InvalidOperationException("Collection modified.");
          return (MultiwordToken) currentObject;
        }
      }
    }
  }
}