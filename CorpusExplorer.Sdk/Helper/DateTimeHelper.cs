#region

using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

#endregion

namespace CorpusExplorer.Sdk.Helper
{
  public static class DateTimeHelper
  {
    private static readonly Regex GermanMarchPatch = new Regex(@"\sM.{1,6}rz\s");

    /// <summary>
    ///   Gibt zurück ob ein Datum (testDateTime) im Bereich (timeSpan) eines Referenzdatums (referenceDateTime) liegt.
    /// </summary>
    /// <param name="referenceDateTime">Referenzdatum</param>
    /// <param name="timeSpan">Zeitspanne (+/-)</param>
    /// <param name="testDateTime">Zu testendes Datum</param>
    /// <returns>Liegt im Bereich?</returns>
    public static bool IsDateInRange(DateTime referenceDateTime, TimeSpan timeSpan, DateTime testDateTime)
    {
      return IsDateInRange(
        referenceDateTime,
        timeSpan,
        new TimeSpan(
          Math.Abs(timeSpan.Days) * -1,
          Math.Abs(timeSpan.Hours) * -1,
          Math.Abs(timeSpan.Minutes) * -1,
          Math.Abs(timeSpan.Seconds) * -1,
          Math.Abs(timeSpan.Milliseconds) * -1),
        testDateTime);
    }

    /// <summary>
    ///   Gibt zurück ob ein Datum (testDateTime) im Bereich (timeSpanUp / timeSpanDown) eines Referenzdatums
    ///   (referenceDateTime) liegt.
    /// </summary>
    /// <param name="referenceDateTime">Referenzdatum</param>
    /// <param name="timeSpanUp">Zeitspanne nach oben (muss positiv sein)</param>
    /// <param name="timeSpanDown">Zeitspanne nach unten (muss negativ sein)</param>
    /// <param name="testDateTime">Zu testendes Datum</param>
    /// <returns>Liegt im Bereich?</returns>
    public static bool IsDateInRange(
      DateTime referenceDateTime,
      TimeSpan timeSpanUp,
      TimeSpan timeSpanDown,
      DateTime testDateTime)
    {
      var up = referenceDateTime.Add(timeSpanUp);
      var dn = referenceDateTime.Add(timeSpanDown);

      return testDateTime > dn && testDateTime < up;
    }

    /// <summary>
    ///   Erkennt automatisch das DateTime-Format insofern ein standardisiertes Format vorliegt.
    /// </summary>
    /// <param name="dateTimeString">String der Datum/Uhrzeit enthält</param>
    /// <param name="useGermanMarchPatch">
    ///   Sichert ab, dass deutsche Texte mit fehlerhafter März-Datumsangabe korrekt geparst
    ///   werden.
    /// </param>
    /// <returns>DateTime (Wenn ein Fehler vorliegt dann DateTime.MinValue)</returns>
    public static DateTime Parse(string dateTimeString, bool useGermanMarchPatch = false)
    {
      if (useGermanMarchPatch)
        dateTimeString = GermanMarchPatch.Replace(dateTimeString, " März ");

      if (dateTimeString.Length == 4 && int.TryParse(dateTimeString, out int i))
        return new DateTime(i, 1, 1);

      var dateTime = DateTime.MinValue;
      // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
      CultureInfo.GetCultures(CultureTypes.AllCultures).FirstOrDefault(ci =>
        DateTime.TryParse(dateTimeString, ci, DateTimeStyles.None, out dateTime));
      return dateTime;
    }

    /// <summary>
    ///   Konvertiert einen DateTimeString mit Hilfe des DateTimeFormats
    /// </summary>
    /// <param name="dateTimeString">String der Datum/Uhrzeit enthält</param>
    /// <param name="dateTimeFormat">Format von Datum/Uhrzeit</param>
    /// <returns>DateTime (Wenn ein Fehler vorliegt dann DateTime.MinValue)</returns>
    public static DateTime Parse(string dateTimeString, string dateTimeFormat)
    {
      try
      {
        return DateTime.ParseExact(dateTimeString, dateTimeFormat, CultureInfo.InvariantCulture);
      }
      catch
      {
        return DateTime.MinValue;
      }
    }

    /// <summary>
    /// Berechnet das Quartal eines gegeben Datums
    /// </summary>
    /// <param name="dt">Datum</param>
    /// <returns>Quartal</returns>
    public static int GetYearQuarter(DateTime dt)
      => (dt.Month - 1) / 3 + 1;

    /// <summary>
    /// Gets the week.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns>System.Int32.</returns>
    public static int GetYearWeek(DateTime dt, CalendarWeekRule rule = CalendarWeekRule.FirstDay, DayOfWeek firstWeekday = DayOfWeek.Monday)
      => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(dt, rule, firstWeekday);
  }
}