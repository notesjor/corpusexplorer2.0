#region

using System;
using System.Linq;
using CorpusExplorer.Sdk.Helper;

#endregion

namespace CorpusExplorer.Sdk.Extern.Binary.Excel.Kidko.Model
{
  [Serializable]
  public sealed class KidkoItem
  {
    private string _dateString;
    private string _name;

    /// <summary>
    ///   Kategorie
    /// </summary>
    public string Category { get; internal set; }

    /// <summary>
    ///   Datum sicher gecastet (wenn kein cast möglich dann: DateTime.MinValue)
    /// </summary>
    internal DateTime Date
    {
      get
      {
        try
        {
          return DateTimeHelper.Parse(DateString, true);
        }
        catch
        {
          return DateTime.MinValue;
        }
      }
    }

    /// <summary>
    ///   Datum
    /// </summary>
    internal string DateString
    {
      get { return _dateString; }
      set
      {
        value =
          value.Replace(" um ", " ")
               .Replace("UhUhr", "Uhr")
               .Replace("MSO120329_36", "")
               .Replace(" Uhr", ":00")
               .Replace("Uhr", ":00")
               .Replace("\"", "")
               .Replace(" I", "")
               .Replace(", ", " ")
               .Replace("<", "")
               .Replace(">", "")
               .Replace("/", "")
               .Replace(" Januar", ".01.2012")
               .Replace(" Februar", ".02.2012")
               .Replace(" März", ".03.2012")
               .Replace(" April", ".04.2012")
               .Replace("..", ".")
               .Replace("head", "")
               .Replace("date", "");

        if (value.StartsWith("229"))
          value = value.Replace("229", "29");

        if (value.Count(c => c == '.') > 2)
        {
          var idx = value.IndexOf('.');
          idx = value.IndexOf('.', idx + 1);
          idx = value.IndexOf('.', idx + 1);

          value = value.Substring(0, idx) + ":" + value.Substring(idx + 1).Replace(".", ":");
        }

        value = value.Replace("2012 2012", "2012").Replace("  ", " ");
        value = value.Trim();

        if (value.StartsWith("February ") &&
            value.Contains("th "))
          value = value.Replace("February ", "").Replace("th ", ".02.2012 ");

        value = value.Trim();
        if (value.EndsWith("15:37 "))
          value = value.Replace("15:37 ", "15:37:00");

        if (value.EndsWith("r"))
          value = value.Substring(0, value.Length - 1);

        _dateString = value;
      }
    }

    /// <summary>
    ///   Reihenfolge (innerhalb eines Diskussions-Threads)
    /// </summary>
    internal string DiscussionTimestamp { get; set; }

    /// <summary>
    ///   Name/Sigle
    /// </summary>
    internal string Name
    {
      get { return _name; }
      set
      {
        if (string.IsNullOrEmpty(value))
          _name = "GEN_" + Guid.NewGuid().ToString("N");
        else
          _name = value;
      }
    }

    /// <summary>
    ///   Herkunft/Medienbeitrag, auf den sich die Texte beziehen
    /// </summary>
    internal string Source { get; set; }

    /// <summary>
    ///   Text
    /// </summary>
    internal string Text { get; set; }

    /// <summary>
    ///   Typ
    /// </summary>
    internal string Type { get; set; }
  }
}