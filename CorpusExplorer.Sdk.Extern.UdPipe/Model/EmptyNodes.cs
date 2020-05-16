#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#endregion

namespace CorpusExplorer.Sdk.Extern.UdPipe.Model
{
  public class EmptyNodes : IDisposable, IEnumerable, IEnumerable<EmptyNode>
  {
    protected bool swigCMemOwn;
    private HandleRef swigCPtr;

    public EmptyNodes(ICollection c) : this()
    {
      if (c == null)
        throw new ArgumentNullException("c");
      foreach (EmptyNode element in c) Add(element);
    }

    public EmptyNodes() : this(udpipe_csharpPINVOKE.new_EmptyNodes__SWIG_0(), true)
    {
    }

    public EmptyNodes(EmptyNodes other) : this(udpipe_csharpPINVOKE.new_EmptyNodes__SWIG_1(getCPtr(other)), true)
    {
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public EmptyNodes(int capacity) : this(udpipe_csharpPINVOKE.new_EmptyNodes__SWIG_2(capacity), true)
    {
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    internal EmptyNodes(IntPtr cPtr, bool cMemoryOwn)
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

    public EmptyNode this[int index]
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
            udpipe_csharpPINVOKE.delete_EmptyNodes(swigCPtr);
          }

          swigCPtr = new HandleRef(null, IntPtr.Zero);
        }

        GC.SuppressFinalize(this);
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return new EmptyNodesEnumerator(this);
    }

    IEnumerator<EmptyNode> IEnumerable<EmptyNode>.GetEnumerator()
    {
      return new EmptyNodesEnumerator(this);
    }

    public void Add(EmptyNode x)
    {
      udpipe_csharpPINVOKE.EmptyNodes_Add(swigCPtr, EmptyNode.getCPtr(x));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void AddRange(EmptyNodes values)
    {
      udpipe_csharpPINVOKE.EmptyNodes_AddRange(swigCPtr, getCPtr(values));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    private uint capacity()
    {
      var ret = udpipe_csharpPINVOKE.EmptyNodes_capacity(swigCPtr);
      return ret;
    }

    public void Clear()
    {
      udpipe_csharpPINVOKE.EmptyNodes_Clear(swigCPtr);
    }

    public void CopyTo(EmptyNode[] array)
    {
      CopyTo(0, array, 0, Count);
    }

    public void CopyTo(EmptyNode[] array, int arrayIndex)
    {
      CopyTo(0, array, arrayIndex, Count);
    }

    public void CopyTo(int index, EmptyNode[] array, int arrayIndex, int count)
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

    ~EmptyNodes()
    {
      Dispose();
    }

    internal static HandleRef getCPtr(EmptyNodes obj)
    {
      return obj == null ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
    }

    public EmptyNodesEnumerator GetEnumerator()
    {
      return new EmptyNodesEnumerator(this);
    }

    private EmptyNode getitem(int index)
    {
      var ret = new EmptyNode(udpipe_csharpPINVOKE.EmptyNodes_getitem(swigCPtr, index), false);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    private EmptyNode getitemcopy(int index)
    {
      var ret = new EmptyNode(udpipe_csharpPINVOKE.EmptyNodes_getitemcopy(swigCPtr, index), true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public EmptyNodes GetRange(int index, int count)
    {
      var cPtr = udpipe_csharpPINVOKE.EmptyNodes_GetRange(swigCPtr, index, count);
      var ret = cPtr == IntPtr.Zero ? null : new EmptyNodes(cPtr, true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    public void Insert(int index, EmptyNode x)
    {
      udpipe_csharpPINVOKE.EmptyNodes_Insert(swigCPtr, index, EmptyNode.getCPtr(x));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void InsertRange(int index, EmptyNodes values)
    {
      udpipe_csharpPINVOKE.EmptyNodes_InsertRange(swigCPtr, index, getCPtr(values));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void RemoveAt(int index)
    {
      udpipe_csharpPINVOKE.EmptyNodes_RemoveAt(swigCPtr, index);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void RemoveRange(int index, int count)
    {
      udpipe_csharpPINVOKE.EmptyNodes_RemoveRange(swigCPtr, index, count);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public static EmptyNodes Repeat(EmptyNode value, int count)
    {
      var cPtr = udpipe_csharpPINVOKE.EmptyNodes_Repeat(EmptyNode.getCPtr(value), count);
      var ret = cPtr == IntPtr.Zero ? null : new EmptyNodes(cPtr, true);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }

    private void reserve(uint n)
    {
      udpipe_csharpPINVOKE.EmptyNodes_reserve(swigCPtr, n);
    }

    public void Reverse()
    {
      udpipe_csharpPINVOKE.EmptyNodes_Reverse__SWIG_0(swigCPtr);
    }

    public void Reverse(int index, int count)
    {
      udpipe_csharpPINVOKE.EmptyNodes_Reverse__SWIG_1(swigCPtr, index, count);
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    private void setitem(int index, EmptyNode val)
    {
      udpipe_csharpPINVOKE.EmptyNodes_setitem(swigCPtr, index, EmptyNode.getCPtr(val));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    public void SetRange(int index, EmptyNodes values)
    {
      udpipe_csharpPINVOKE.EmptyNodes_SetRange(swigCPtr, index, getCPtr(values));
      if (udpipe_csharpPINVOKE.SWIGPendingException.Pending) throw udpipe_csharpPINVOKE.SWIGPendingException.Retrieve();
    }

    private uint size()
    {
      var ret = udpipe_csharpPINVOKE.EmptyNodes_size(swigCPtr);
      return ret;
    }

    // Type-safe enumerator
    /// Note that the IEnumerator documentation requires an InvalidOperationException to be thrown
    /// whenever the collection is modified. This has been done for changes in the size of the
    /// collection but not when one of the elements of the collection is modified as it is a bit
    /// tricky to detect unmanaged code that modifies the collection under our feet.
    public sealed class EmptyNodesEnumerator : IEnumerator, IEnumerator<EmptyNode>
    {
      private readonly EmptyNodes collectionRef;
      private readonly int currentSize;
      private int currentIndex;
      private object currentObject;

      public EmptyNodesEnumerator(EmptyNodes collection)
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
      public EmptyNode Current
      {
        get
        {
          if (currentIndex == -1)
            throw new InvalidOperationException("Enumeration not started.");
          if (currentIndex > currentSize - 1)
            throw new InvalidOperationException("Enumeration finished.");
          if (currentObject == null)
            throw new InvalidOperationException("Collection modified.");
          return (EmptyNode) currentObject;
        }
      }
    }
  }
}