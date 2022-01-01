#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#endregion

namespace CorpusExplorer.Sdk.Extern.UdPipe.Model
{
  public class Comments : IDisposable, IEnumerable, IList<string>
  {
    protected bool swigCMemOwn;
    private HandleRef swigCPtr;

    public Comments(ICollection c) : this()
    {
      if (c == null)
        throw new ArgumentNullException("c");
      foreach (string element in c) Add(element);
    }

    public Comments() : this(udpipe_csharpPINVOKE.new_Comments__SWIG_0(), true)
    {
    }

    public Comments(Comments other) : this(udpipe_csharpPINVOKE.new_Comments__SWIG_1(getCPtr(other)), true)
    {
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public Comments(int capacity) : this(udpipe_csharpPINVOKE.new_Comments__SWIG_2(capacity), true)
    {
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    internal Comments(IntPtr cPtr, bool cMemoryOwn)
    {
      swigCMemOwn = cMemoryOwn;
      swigCPtr = new HandleRef(this, cPtr);
    }

    public int Capacity
    {
      get => (int)capacity();
      set
      {
        if (value < size())
          throw new ArgumentOutOfRangeException("Capacity");
        reserve((uint)value);
      }
    }

    public bool IsFixedSize => false;

    public bool IsSynchronized => false;

    public void Add(string x)
    {
      udpipe_csharpPINVOKE.Comments_Add(swigCPtr, x);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void Clear()
    {
      udpipe_csharpPINVOKE.Comments_Clear(swigCPtr);
    }

    public bool Contains(string value)
    {
      var ret = udpipe_csharpPINVOKE.Comments_Contains(swigCPtr, value);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public void CopyTo(string[] array, int arrayIndex)
    {
      CopyTo(0, array, arrayIndex, Count);
    }

    public int Count => (int)size();

    public bool IsReadOnly => false;

    public bool Remove(string value)
    {
      var ret = udpipe_csharpPINVOKE.Comments_Remove(swigCPtr, value);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
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
            udpipe_csharpPINVOKE.delete_Comments(swigCPtr);
          }

          swigCPtr = new HandleRef(null, IntPtr.Zero);
        }

        GC.SuppressFinalize(this);
      }
    }

    IEnumerator IEnumerable.GetEnumerator() => new CommentsEnumerator(this);

    IEnumerator<string> IEnumerable<string>.GetEnumerator() => new CommentsEnumerator(this);

    public int IndexOf(string value)
    {
      var ret = udpipe_csharpPINVOKE.Comments_IndexOf(swigCPtr, value);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public void Insert(int index, string x)
    {
      udpipe_csharpPINVOKE.Comments_Insert(swigCPtr, index, x);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public string this[int index]
    {
      get => getitem(index);
      set => setitem(index, value);
    }

    public void RemoveAt(int index)
    {
      udpipe_csharpPINVOKE.Comments_RemoveAt(swigCPtr, index);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void AddRange(Comments values)
    {
      udpipe_csharpPINVOKE.Comments_AddRange(swigCPtr, getCPtr(values));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    private uint capacity()
    {
      var ret = udpipe_csharpPINVOKE.Comments_capacity(swigCPtr);
      return ret;
    }

    public void CopyTo(string[] array)
    {
      CopyTo(0, array, 0, Count);
    }

    public void CopyTo(int index, string[] array, int arrayIndex, int count)
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

    ~Comments()
    {
      Dispose();
    }

    internal static HandleRef getCPtr(Comments obj) => obj == null ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;

    public CommentsEnumerator GetEnumerator() => new CommentsEnumerator(this);

    private string getitem(int index)
    {
      var ret = udpipe_csharpPINVOKE.Comments_getitem(swigCPtr, index);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    private string getitemcopy(int index)
    {
      var ret = udpipe_csharpPINVOKE.Comments_getitemcopy(swigCPtr, index);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public Comments GetRange(int index, int count)
    {
      var cPtr = udpipe_csharpPINVOKE.Comments_GetRange(swigCPtr, index, count);
      var ret = cPtr == IntPtr.Zero ? null : new Comments(cPtr, true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public void InsertRange(int index, Comments values)
    {
      udpipe_csharpPINVOKE.Comments_InsertRange(swigCPtr, index, getCPtr(values));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public int LastIndexOf(string value)
    {
      var ret = udpipe_csharpPINVOKE.Comments_LastIndexOf(swigCPtr, value);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public void RemoveRange(int index, int count)
    {
      udpipe_csharpPINVOKE.Comments_RemoveRange(swigCPtr, index, count);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public static Comments Repeat(string value, int count)
    {
      var cPtr = udpipe_csharpPINVOKE.Comments_Repeat(value, count);
      var ret = cPtr == IntPtr.Zero ? null : new Comments(cPtr, true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    private void reserve(uint n)
    {
      udpipe_csharpPINVOKE.Comments_reserve(swigCPtr, n);
    }

    public void Reverse()
    {
      udpipe_csharpPINVOKE.Comments_Reverse__SWIG_0(swigCPtr);
    }

    public void Reverse(int index, int count)
    {
      udpipe_csharpPINVOKE.Comments_Reverse__SWIG_1(swigCPtr, index, count);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    private void setitem(int index, string val)
    {
      udpipe_csharpPINVOKE.Comments_setitem(swigCPtr, index, val);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void SetRange(int index, Comments values)
    {
      udpipe_csharpPINVOKE.Comments_SetRange(swigCPtr, index, getCPtr(values));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    private uint size()
    {
      var ret = udpipe_csharpPINVOKE.Comments_size(swigCPtr);
      return ret;
    }

    // Type-safe enumerator
    /// Note that the IEnumerator documentation requires an InvalidOperationException to be thrown
    /// whenever the collection is modified. This has been done for changes in the size of the
    /// collection but not when one of the elements of the collection is modified as it is a bit
    /// tricky to detect unmanaged code that modifies the collection under our feet.
    public sealed class CommentsEnumerator : IEnumerator, IEnumerator<string>
    {
      private readonly Comments collectionRef;
      private readonly int currentSize;
      private int currentIndex;
      private object currentObject;

      public CommentsEnumerator(Comments collection)
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
      public string Current
      {
        get
        {
          if (currentIndex == -1)
            throw new InvalidOperationException("Enumeration not started.");
          if (currentIndex > currentSize - 1)
            throw new InvalidOperationException("Enumeration finished.");
          if (currentObject == null)
            throw new InvalidOperationException("Collection modified.");
          return (string)currentObject;
        }
      }
    }
  }
}