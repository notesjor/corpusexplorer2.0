#region

using System;
using System.Reflection;
using CorpusExplorer.Sdk.Diagnostic;
using PostSharp.Aspects;
using PostSharp.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Aspect
{
  /// <summary>
  ///   Aspekt zum dekorieren von Methoden. Fängt automatisch Fehler ab und (falls Debug-gesetzt) erstellt ein Tracinglog.
  ///   <code>
  /// [ErrorReportingAndTracingAspect]
  /// public void DekorierteMethode(int a)
  /// {
  /// return 5 / a;
  /// }
  /// </code>
  /// </summary>
  [PSerializable]
  public sealed class ErrorReportingAspect : OnMethodBoundaryAspect
  {
    /// <summary>
    ///   Standardwert, der im Fehlerfall (OnException) zurückgegeben wird
    /// </summary>
    private readonly object _defaultReturn;

    /// <summary>
    ///   Speichert ob ein Standardwert hinterlegt wurde
    /// </summary>
    private readonly bool _hasDefaultValue;

    /// <summary>
    ///   Initializes a new instance of the <see cref="ErrorReportingAspect" /> class.
    ///   Konstruktor für alle void-Methoden sowie alle nicht-void-Methoden
    ///   bei denen die Exception durchgereicht werden soll.
    /// </summary>
    public ErrorReportingAspect() => _hasDefaultValue = false;

    /// <summary>
    ///   Initializes a new instance of the <see cref="ErrorReportingAspect" /> class.
    ///   Setzt einen Standardwert, der im Fehlerfall zurückgeben wird.
    ///   Hinweis: darf -NICHT- für void-Methoden verwendet werden.
    /// </summary>
    /// <param name="defaultReturn">
    ///   The default Return.
    /// </param>
    public ErrorReportingAspect(object defaultReturn)
    {
      _defaultReturn = defaultReturn;
      _hasDefaultValue = true;
    }

    /// <summary>
    ///   Mapping für Typdefinition
    /// </summary>
    private Type Type => MethodBase.GetCurrentMethod().DeclaringType;

    /// <summary>
    ///   Wird aufgerufen, wenn die dekorierte Methode einen Fehler (Exception) auslöst
    /// </summary>
    /// <param name="args">
    ///   MethodExecutionArgs
    /// </param>
    public override void OnException(MethodExecutionArgs args)
    {
      InMemoryErrorConsole.Log(args.Exception);

      if (_hasDefaultValue)
      {
        args.ReturnValue = _defaultReturn;

        // Tue so, als wäre nichts passiert. Die Exception gilt als behandelt/unterdrückt.
        args.FlowBehavior = FlowBehavior.Return;
      }
      else
      {
        args.FlowBehavior = FlowBehavior.Continue;
      }
    }
  }
}