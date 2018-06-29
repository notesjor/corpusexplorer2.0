#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Helper
{
  public class DisposingContainer : IContainer
  {
    public delegate void DisposingContainerDelegate<in T>(T disposableObject) where T : class, IDisposable;

    private readonly List<IDisposable> _container = new List<IDisposable>();

    /// <summary>
    ///   Fügt dem <see cref="T:System.ComponentModel.IContainer" /> am Ende der Liste die angegebene
    ///   <see cref="T:System.ComponentModel.IComponent" /> hinzu.
    /// </summary>
    /// <param name="component">Die zu addierende <see cref="T:System.ComponentModel.IComponent" />.</param>
    public void Add(IComponent component)
    {
      _container.Add(component);
    }

    /// <summary>
    ///   Fügt dem <see cref="T:System.ComponentModel.IContainer" /> am Ende der Liste die angegebene
    ///   <see cref="T:System.ComponentModel.IComponent" /> hinzu und weist der Komponente einen Namen zu.
    /// </summary>
    /// <param name="component">Die zu addierende <see cref="T:System.ComponentModel.IComponent" />.</param>
    /// <param name="name">
    ///   Der eindeutige Name für die Komponente, bei dem die Groß- und Kleinschreibung nicht berücksichtigt
    ///   wird. - oder -  null, wenn der Komponente kein Name zugewiesen wird.
    /// </param>
    public void Add(IComponent component, string name)
    {
      _container.Add(component);
    }

    /// <summary>
    ///   Ruft alle Komponenten im <see cref="T:System.ComponentModel.IContainer" /> ab.
    /// </summary>
    /// <returns>
    ///   Eine Auflistung von <see cref="T:System.ComponentModel.IComponent" />-Objekten, die alle Komponenten in
    ///   <see cref="T:System.ComponentModel.IContainer" /> darstellt.
    /// </returns>
    public ComponentCollection Components => new ComponentCollection(_container.OfType<IComponent>().ToArray());

    /// <summary>
    ///   Entfernt eine Komponente aus <see cref="T:System.ComponentModel.IContainer" />.
    /// </summary>
    /// <param name="component">Die zu entfernende <see cref="T:System.ComponentModel.IComponent" />.</param>
    public void Remove(IComponent component)
    {
      _container.Remove(component);
    }

    /// <summary>
    ///   Führt anwendungsspezifische Aufgaben aus, die mit dem Freigeben, Zurückgeben oder Zurücksetzen von nicht verwalteten
    ///   Ressourcen zusammenhängen.
    /// </summary>
    public void Dispose()
    {
      foreach (var entry in _container)
        entry.Dispose();
      _container.Clear();
    }

    /// <summary>
    ///   Fügt dem <see cref="T:System.ComponentModel.IContainer" /> am Ende der Liste die angegebene
    ///   <see cref="T:System.IDisposable" /> hinzu.
    /// </summary>
    /// <param name="disposableObject">Die zu addierende <see cref="T:System.IDisposable" />.</param>
    public void Add(IDisposable disposableObject)
    {
      _container.Add(disposableObject);
    }

    /// <summary>
    ///   Führt anwendungsspezifische Aufgaben aus, die mit dem Freigeben, Zurückgeben oder Zurücksetzen von nicht verwalteten
    ///   Ressourcen zusammenhängen.
    /// </summary>
    /// <typeparam name="T">Typ auf den die Operation angewendet werden soll.</typeparam>
    /// <param name="func">TFunktion die für alle Instanzen des Typs aufgerufen wird.</param>
    public void Dispose<T>(DisposingContainerDelegate<T> func) where T : class, IDisposable
    {
      foreach (var entry in _container)
      {
        var obj = entry as T;
        if (obj == null)
          continue;

        func(obj);
        entry.Dispose();
      }

      _container.Clear();
    }
  }
}