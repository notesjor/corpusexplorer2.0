using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CorpusExplorer.Sdk.Extern.UdPipe.Model
{
  public class Sentences : IDisposable, IEnumerable
    , IEnumerable<Sentence>
  {
    protected bool swigCMemOwn;
    private HandleRef swigCPtr;

    public Sentences(ICollection c) : this()
    {
      if (c == null)
        throw new ArgumentNullException("c");
      foreach (Sentence element in c) Add(element);
    }

    public Sentences() : this(udpipe_csharpPINVOKE.new_Sentences__SWIG_0(), true)
    {
    }

    public Sentences(Sentences other) : this(udpipe_csharpPINVOKE.new_Sentences__SWIG_1(getCPtr(other)), true)
    {
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public Sentences(int capacity) : this(udpipe_csharpPINVOKE.new_Sentences__SWIG_2(capacity), true)
    {
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    internal Sentences(IntPtr cPtr, bool cMemoryOwn)
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

    public Sentence this[int index]
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
            udpipe_csharpPINVOKE.delete_Sentences(swigCPtr);
          }

          swigCPtr = new HandleRef(null, IntPtr.Zero);
        }

        GC.SuppressFinalize(this);
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return new SentencesEnumerator(this);
    }

    IEnumerator<Sentence> IEnumerable<Sentence>.GetEnumerator()
    {
      return new SentencesEnumerator(this);
    }

    public void Add(Sentence x)
    {
      udpipe_csharpPINVOKE.Sentences_Add(swigCPtr, Sentence.getCPtr(x));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void AddRange(Sentences values)
    {
      udpipe_csharpPINVOKE.Sentences_AddRange(swigCPtr, getCPtr(values));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void Clear()
    {
      udpipe_csharpPINVOKE.Sentences_Clear(swigCPtr);
    }

    public void CopyTo(Sentence[] array)
    {
      CopyTo(0, array, 0, Count);
    }

    public void CopyTo(Sentence[] array, int arrayIndex)
    {
      CopyTo(0, array, arrayIndex, Count);
    }

    public void CopyTo(int index, Sentence[] array, int arrayIndex, int count)
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
      for (int i = 0; i < count; i++)
        array.SetValue(getitemcopy(index + i), arrayIndex + i);
    }

    public SentencesEnumerator GetEnumerator()
    {
      return new SentencesEnumerator(this);
    }

    public Sentences GetRange(int index, int count)
    {
      IntPtr cPtr = udpipe_csharpPINVOKE.Sentences_GetRange(swigCPtr, index, count);
      Sentences ret = cPtr == IntPtr.Zero ? null : new Sentences(cPtr, true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public void Insert(int index, Sentence x)
    {
      udpipe_csharpPINVOKE.Sentences_Insert(swigCPtr, index, Sentence.getCPtr(x));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void InsertRange(int index, Sentences values)
    {
      udpipe_csharpPINVOKE.Sentences_InsertRange(swigCPtr, index, getCPtr(values));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void RemoveAt(int index)
    {
      udpipe_csharpPINVOKE.Sentences_RemoveAt(swigCPtr, index);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void RemoveRange(int index, int count)
    {
      udpipe_csharpPINVOKE.Sentences_RemoveRange(swigCPtr, index, count);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public static Sentences Repeat(Sentence value, int count)
    {
      IntPtr cPtr = udpipe_csharpPINVOKE.Sentences_Repeat(Sentence.getCPtr(value), count);
      Sentences ret = cPtr == IntPtr.Zero ? null : new Sentences(cPtr, true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public void Reverse()
    {
      udpipe_csharpPINVOKE.Sentences_Reverse__SWIG_0(swigCPtr);
    }

    public void Reverse(int index, int count)
    {
      udpipe_csharpPINVOKE.Sentences_Reverse__SWIG_1(swigCPtr, index, count);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void SetRange(int index, Sentences values)
    {
      udpipe_csharpPINVOKE.Sentences_SetRange(swigCPtr, index, getCPtr(values));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    internal static HandleRef getCPtr(Sentences obj)
    {
      return obj == null ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
    }

    private uint capacity()
    {
      uint ret = udpipe_csharpPINVOKE.Sentences_capacity(swigCPtr);
      return ret;
    }

    private Sentence getitem(int index)
    {
      Sentence ret = new Sentence(udpipe_csharpPINVOKE.Sentences_getitem(swigCPtr, index), false);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    private Sentence getitemcopy(int index)
    {
      Sentence ret = new Sentence(udpipe_csharpPINVOKE.Sentences_getitemcopy(swigCPtr, index), true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    private void reserve(uint n)
    {
      udpipe_csharpPINVOKE.Sentences_reserve(swigCPtr, n);
    }

    private void setitem(int index, Sentence val)
    {
      udpipe_csharpPINVOKE.Sentences_setitem(swigCPtr, index, Sentence.getCPtr(val));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    private uint size()
    {
      uint ret = udpipe_csharpPINVOKE.Sentences_size(swigCPtr);
      return ret;
    }

    ~Sentences()
    {
      Dispose();
    }

    // Type-safe enumerator
    /// Note that the IEnumerator documentation requires an InvalidOperationException to be thrown
    /// whenever the collection is modified. This has been done for changes in the size of the
    /// collection but not when one of the elements of the collection is modified as it is a bit
    /// tricky to detect unmanaged code that modifies the collection under our feet.
    public sealed class SentencesEnumerator : IEnumerator
      , IEnumerator<Sentence>
    {
      private readonly Sentences collectionRef;
      private int currentIndex;
      private object currentObject;
      private readonly int currentSize;

      public SentencesEnumerator(Sentences collection)
      {
        collectionRef = collection;
        currentIndex = -1;
        currentObject = null;
        currentSize = collectionRef.Count;
      }

      // Type-unsafe IEnumerator.Current
      object IEnumerator.Current => Current;

      public bool MoveNext()
      {
        int size = collectionRef.Count;
        bool moveOkay = currentIndex + 1 < size && size == currentSize;
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
      public Sentence Current
      {
        get
        {
          if (currentIndex == -1)
            throw new InvalidOperationException("Enumeration not started.");
          if (currentIndex > currentSize - 1)
            throw new InvalidOperationException("Enumeration finished.");
          if (currentObject == null)
            throw new InvalidOperationException("Collection modified.");
          return (Sentence) currentObject;
        }
      }

      public void Dispose()
      {
        currentIndex = -1;
        currentObject = null;
      }
    }
  }
}