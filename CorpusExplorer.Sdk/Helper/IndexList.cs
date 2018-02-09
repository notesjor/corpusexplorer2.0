#region

using System.Collections;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace CorpusExplorer.Sdk.Helper
{
  /// <summary>
  ///   Class IndexList.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class IndexList<T> : IList<T>
  {
    /// <summary>
    ///   The _list
    /// </summary>
    private readonly List<T> _list;

    /// <summary>
    ///   The _current index
    /// </summary>
    private int _currentIndex;

    /// <summary>
    ///   Initializes a new instance of the <see cref="IndexList{T}" /> class.
    /// </summary>
    /// <param name="items">The items.</param>
    public IndexList(IEnumerable<T> items)
    {
      _list = items.ToList();
      CurrentIndex = 0;
    }

    /// <summary>
    ///   Gets or sets the index of the current.
    /// </summary>
    /// <value>The index of the current.</value>
    public int CurrentIndex
    {
      get => _currentIndex;
      set
      {
        if (value < 0)
          value = 0;
        if (value >= _list.Count)
          value = _list.Count - 1;

        _currentIndex = value;
      }
    }

    /// <summary>
    ///   Gets or sets the current item.
    /// </summary>
    /// <value>The current item.</value>
    public T CurrentItem
    {
      get => CurrentIndex == -1 ? default(T) : _list[CurrentIndex];
      set
      {
        if (CurrentIndex == -1)
          return;
        _list[CurrentIndex] = value;
      }
    }

    /// <summary>
    ///   Gets the items.
    /// </summary>
    /// <value>The items.</value>
    public IEnumerable<T> Items => _list;

    /// <summary>
    ///   Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1" />.
    /// </summary>
    /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
    public void Add(T item)
    {
      _list.Add(item);
    }

    /// <summary>
    ///   Entfernt alle Elemente aus <see cref="T:System.Collections.Generic.ICollection`1" />.
    /// </summary>
    /// <exception cref="T:System.NotSupportedException">
    ///   <see cref="T:System.Collections.Generic.ICollection`1" /> ist
    ///   schreibgeschützt.
    /// </exception>
    public void Clear()
    {
      _list.Clear();
    }

    /// <summary>
    ///   Bestimmt, ob <see cref="T:System.Collections.Generic.ICollection`1" /> einen bestimmten Wert enthält.
    /// </summary>
    /// <param name="item">Das im <see cref="T:System.Collections.Generic.ICollection`1" /> zu suchende Objekt.</param>
    /// <returns>
    ///   true, wenn sich <paramref name="item" /> in <see cref="T:System.Collections.Generic.ICollection`1" />
    ///   befindet, andernfalls false.
    /// </returns>
    public bool Contains(T item)
    {
      return _list.Contains(item);
    }

    /// <summary>
    ///   Kopiert die Elemente von <see cref="T:System.Collections.Generic.ICollection`1" /> in ein
    ///   <see cref="T:System.Array" />, beginnend bei einem bestimmten <see cref="T:System.Array" />-Index.
    /// </summary>
    /// <param name="array">
    ///   Das eindimensionale <see cref="T:System.Array" />, das das Ziel der aus
    ///   <see cref="T:System.Collections.Generic.ICollection`1" /> kopierten Elemente ist.Für <see cref="T:System.Array" />
    ///   muss eine nullbasierte Indizierung verwendet werden.
    /// </param>
    /// <param name="arrayIndex">Der nullbasierte Index in <paramref name="array" />, an dem das Kopieren beginnt.</param>
    /// <exception cref="T:System.ArgumentNullException"><paramref name="array" /> hat den Wert null.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="arrayIndex" /> ist kleiner als 0.</exception>
    /// <exception cref="T:System.ArgumentException">
    ///   <paramref name="array" /> ist mehrdimensional.- oder -Die Anzahl der
    ///   Elemente in der Quelle <see cref="T:System.Collections.Generic.ICollection`1" /> ist größer als der verfügbare
    ///   Speicherplatz ab <paramref name="arrayIndex" /> bis zum Ende des <paramref name="array" />, das als Ziel festgelegt
    ///   wurde.- oder -Typ (T) kann nicht automatisch in den Typ des Ziel-<paramref name="array" />
    ///   umgewandelt werden.
    /// </exception>
    public void CopyTo(T[] array, int arrayIndex)
    {
      _list.CopyTo(array, arrayIndex);
    }

    /// <summary>
    ///   Ruft die Anzahl der Elemente ab, die in <see cref="T:System.Collections.Generic.ICollection`1" /> enthalten sind.
    /// </summary>
    /// <value>The count.</value>
    public int Count => _list.Count;

    /// <summary>
    ///   Ruft einen Wert ab, der angibt, ob <see cref="T:System.Collections.Generic.ICollection`1" /> schreibgeschützt ist.
    /// </summary>
    /// <value><c>true</c> if this instance is read only; otherwise, <c>false</c>.</value>
    public bool IsReadOnly => false;

    /// <summary>
    ///   Entfernt das erste Vorkommen eines bestimmten Objekts aus <see cref="T:System.Collections.Generic.ICollection`1" />.
    /// </summary>
    /// <param name="item">Das aus dem <see cref="T:System.Collections.Generic.ICollection`1" /> zu entfernende Objekt.</param>
    /// <returns>
    ///   true, wenn <paramref name="item" /> erfolgreich aus <see cref="T:System.Collections.Generic.ICollection`1" />
    ///   gelöscht wurde, andernfalls false.Diese Methode gibt auch dann false zurück, wenn <paramref name="item" /> nicht in
    ///   der ursprünglichen <see cref="T:System.Collections.Generic.ICollection`1" /> gefunden wurde.
    /// </returns>
    /// <exception cref="T:System.NotSupportedException">
    ///   <see cref="T:System.Collections.Generic.ICollection`1" /> ist
    ///   schreibgeschützt.
    /// </exception>
    bool ICollection<T>.Remove(T item)
    {
      return _list.Remove(item);
    }

    /// <summary>
    ///   Gibt einen Enumerator zurück, der eine Auflistung durchläuft.
    /// </summary>
    /// <returns>
    ///   Ein <see cref="T:System.Collections.IEnumerator" />-Objekt, das zum Durchlaufen der Auflistung verwendet
    ///   werden kann.
    /// </returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    /// <summary>
    ///   Gibt einen Enumerator zurück, der die Auflistung durchläuft.
    /// </summary>
    /// <returns>
    ///   Ein <see cref="T:System.Collections.Generic.IEnumerator`1" />, der zum Durchlaufen der Auflistung verwendet
    ///   werden kann.
    /// </returns>
    public IEnumerator<T> GetEnumerator()
    {
      return _list.GetEnumerator();
    }

    /// <summary>
    ///   Bestimmt den Index eines bestimmten Elements in der <see cref="T:System.Collections.Generic.IList`1" />.
    /// </summary>
    /// <param name="item">Das im <see cref="T:System.Collections.Generic.IList`1" /> zu suchende Objekt.</param>
    /// <returns>Der Index von <paramref name="item" />, wenn das Element in der Liste gefunden wird, andernfalls -1.</returns>
    public int IndexOf(T item)
    {
      return _list.IndexOf(item);
    }

    /// <summary>
    ///   Fügt am angegebenen Index ein Element in die <see cref="T:System.Collections.Generic.IList`1" /> ein.
    /// </summary>
    /// <param name="index">Der nullbasierte Index, an dem <paramref name="item" /> eingefügt werden soll.</param>
    /// <param name="item">Das in die <see cref="T:System.Collections.Generic.IList`1" /> einzufügende Objekt.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    ///   <paramref name="index" /> ist kein gültiger Index in der
    ///   <see cref="T:System.Collections.Generic.IList`1" />.
    /// </exception>
    /// <exception cref="T:System.NotSupportedException">
    ///   Die <see cref="T:System.Collections.Generic.IList`1" /> ist
    ///   schreibgeschützt.
    /// </exception>
    public void Insert(int index, T item)
    {
      _list.Insert(index, item);
    }

    /// <summary>
    ///   Ruft das Element am angegebenen Index ab oder legt dieses fest.
    /// </summary>
    /// <param name="index">The index.</param>
    /// <returns>Das Element am angegebenen Index.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    ///   <paramref name="index" /> ist kein gültiger Index in der
    ///   <see cref="T:System.Collections.Generic.IList`1" />.
    /// </exception>
    /// <exception cref="T:System.NotSupportedException">
    ///   Die Eigenschaft wird festgelegt, und die
    ///   <see cref="T:System.Collections.Generic.IList`1" /> ist schreibgeschützt.
    /// </exception>
    public T this[int index] { get => _list[index]; set => _list[index] = value; }

    /// <summary>
    ///   Removes the <see cref="T:System.Collections.Generic.IList`1" /> item at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the item to remove.</param>
    public void RemoveAt(int index)
    {
      _list.RemoveAt(index);
    }

    /// <summary>
    ///   Nexts this instance.
    /// </summary>
    public void Next()
    {
      CurrentIndex++;
    }

    /// <summary>
    ///   Previews this instance.
    /// </summary>
    public void Preview()
    {
      CurrentIndex--;
    }

    /// <summary>
    ///   Removes the specified item.
    /// </summary>
    /// <param name="item">The item.</param>
    public void Remove(T item)
    {
      _list.Remove(item);
    }
  }
}