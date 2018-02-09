using System;
using System.Collections.Generic;

namespace CorpusExplorer.Sdk.Helper
{
  public class TypeEqualityComparer : IEqualityComparer<Type>
  {
    /// <summary>
    ///   Determines whether the specified objects are equal.
    /// </summary>
    /// <returns>
    ///   true if the specified objects are equal; otherwise, false.
    /// </returns>
    public bool Equals(Type x, Type y)
    {
      return x.GetHashCode() == y.GetHashCode();
    }

    /// <summary>
    ///   Returns a hash code for the specified object.
    /// </summary>
    /// <returns>
    ///   A hash code for the specified object.
    /// </returns>
    /// <param name="obj">The <see cref="T:System.Object" /> for which a hash code is to be returned.</param>
    /// <exception cref="T:System.ArgumentNullException">
    ///   The type of <paramref name="obj" /> is a reference type and
    ///   <paramref name="obj" /> is null.
    /// </exception>
    public int GetHashCode(Type obj)
    {
      return obj.GetHashCode();
    }
  }
}