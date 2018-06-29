using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.Localizer.PivotGrid
{
  public class PivotGridViewGermanLocalizer : PivotGridLocalizationProvider
  {
    public override string GetLocalizedString(string id)
    {
      switch (id)
      {
        case PivotStringId.GrandTotal: return "Gesamtsumme";
        case PivotStringId.Values: return "Werte";
        case PivotStringId.TotalP0: return "Total {0}";
        case PivotStringId.Product: return "Produkt";
        case PivotStringId.StdDevP: return "Standardabweichung (P)";
        case PivotStringId.Min: return "Minimum";
        case PivotStringId.Count: return "Zähle";
        case PivotStringId.StdDev: return "Standardabweichung";
        case PivotStringId.Sum: return "Summe";
        case PivotStringId.Average: return "Durchscnitt";
        case PivotStringId.Var: return "Varianz";
        case PivotStringId.VarP: return "Varianz (P)";
        case PivotStringId.GroupP0AggregateP1: return "{0} {1}";
        case PivotStringId.YearGroupField: return "Jahr";
        case PivotStringId.MonthGroupField: return "Monat";
        case PivotStringId.QuarterGroupField: return "Quartal";
        case PivotStringId.WeekGroupField: return "Woche";
        case PivotStringId.DayGroupField: return "Tag";
        case PivotStringId.HourGroupField: return "Stunde";
        case PivotStringId.MinuteGroupField: return "Minute";
        case PivotStringId.SecondsGroupField: return "Seknde";
        case PivotStringId.P0Total: return "{0} Total";
        case PivotStringId.PivotAggregateP0ofP1: return "{0} von {1}";
        case PivotStringId.ExpandCollapseMenuItem: return "Erweitern";
        case PivotStringId.CollapseAllMenuItems: return "Reduzieren";
        case PivotStringId.ExpandAllMenuItems: return "Alle erweitern";
        case PivotStringId.CopyMenuItem: return "Kopieren";
        case PivotStringId.HideMenuItem: return "Verbergen";
        case PivotStringId.SortMenuItem: return "Sortieren";
        case PivotStringId.BestFitMenuItem: return "Anpassen";
        case PivotStringId.ReloadDataMenuItem: return "Erneut laden";
        case PivotStringId.FieldListMenuItem: return "Zeige Feld-Liste";
        case PivotStringId.SortAZMenuItem: return "&Sortiere A-Z";
        case PivotStringId.SortZAMenuItem: return "S&ortiere Z-A";
        case PivotStringId.SortOptionsMenuItem: return "&Weitere sortier Optionen ...";
        case PivotStringId.ClearFilterMenuItem: return "&Lösche Filter";
        case PivotStringId.LabelFilterMenuItem: return "&Label Filter";
        case PivotStringId.ValueFilterMenuItem: return "&Wert Filter";
        case PivotStringId.AllNode: return "(Alle auswählen)";
        case PivotStringId.FilterMenuItemEqual: return "&Gleich...";
        case PivotStringId.FilterMenuItemDoesNotEquals: return "Ist &ungleich...";
        case PivotStringId.FilterMenuItemBeginsWith: return "Beginnt m&it...";
        case PivotStringId.FilterMenuItemDoesNotBeginWith: return "Beginnt ni&cht mit...";
        case PivotStringId.FIlterMenuItemEndsWith: return "Endet mi&t...";
        case PivotStringId.FilterMenuItemDoesNotEndsWith: return "Endet nic&ht auf...";
        case PivotStringId.FilterMenuItemContains: return "Enthä&lt...";
        case PivotStringId.FilterMenuItemDoesNotContain: return "E&nthält nicht...";
        case PivotStringId.FilterMenuItemGreaterThan: return "&Größer als...";
        case PivotStringId.FilterMenuItemGreaterThanOrEqualTo: return "Größer &oder gleich...";
        case PivotStringId.FilterMenuItemLessThan: return "&Kleiner als...";
        case PivotStringId.FilterMenuItemLessThanOrEqualTo: return "Kleiner o&der gleich...";
        case PivotStringId.FilterMenuItemBetween: return "&Zwischen...";
        case PivotStringId.FilterMenuItemNotBetween: return "&Außerhalb...";
        case PivotStringId.TopTenItem: return "&Top 10...";
        case PivotStringId.AllNodeSelectAllSearchResult: return "(Wähle alle Suchergebnisse)";
        case PivotStringId.FilterMenuAvailableFilters: return "&Verfügbare Filter";
        case PivotStringId.CheckBoxMenuItem: return "Wähle mehrere Einträge";
        case PivotStringId.CalculationOptionsDialogNoCalculation: return "Keine BErechnungen";
        case PivotStringId.CalculationOptionsDialogPrevious: return "(zurück)";
        case PivotStringId.CalculationOptionsDialogNext: return "(vor)";
        case PivotStringId.CalculationOptionsDialogGrandTotal: return "% der Gesamtsumme";
        case PivotStringId.CalculationOptionsDialogColumnTotal: return "% der Spalte";
        case PivotStringId.CalculationOptionsDialogRowTotal: return "% der Zeile";
        case PivotStringId.CalculationOptionsDialogOf: return "% von";
        case PivotStringId.CalculationOptionsDialogDifferenceFrom: return "Unterschied von";
        case PivotStringId.CalculationOptionsDialogPercentDifferenceFrom: return "% Unterschied von";
        case PivotStringId.CalculationOptionsDialogRunningTotalIn: return "Running Total In";
        case PivotStringId.CalculationOptionsDialogPercentRunningTotalIn: return "% Laufende Summe";
        case PivotStringId.CalculationOptionsDialogRankSmallestToLargest: return "Aufsteigend sortieren";
        case PivotStringId.CalculationOptionsDialogRankLargestToSmallest: return "Absteigend sortieren";
        case PivotStringId.CalculationOptionsDialogIndex: return "Index";
        case PivotStringId.CalculationOptionsDialogShowValueAs: return "Zeige Werte als ({0})";
        case PivotStringId.LabelFilterOptionsDialogEquals: return "gleich";
        case PivotStringId.LabelFilterOptionsDialogDoesNotEqual: return "ungleich";
        case PivotStringId.LabelFilterOptionsDialogIsGreaterThen: return "ist größer als";
        case PivotStringId.LabelFilterOptionsDialogIsGreaterThanOrEqualTo: return "ist größer oder gleich";
        case PivotStringId.LabelFilterOptionsDialogIsLessThan: return "ist kleiner als";
        case PivotStringId.LabelFilterOptionsDialogIsLessThanOrEqualTo: return "ist kleiner oder gleich";
        case PivotStringId.LabelFilterOptionsDialogBeginsWith: return "beginnt mit";
        case PivotStringId.LabelFilterOptionsDialogDoesNotBeginWith: return "beginnt nicht mit";
        case PivotStringId.LabelFilterOptionsDialogEndsWith: return "endet mit";
        case PivotStringId.LabelFilterOptionsDialogDoesNotEndsWith: return "endet nicht auf";
        case PivotStringId.LabelFilterOptionsDialogContains: return "enthält";
        case PivotStringId.LabelFilterOptionsDialogDoesNotContain: return "enthält nicht";
        case PivotStringId.LabelFilterOptionsDialogIsBetween: return "zwischen";
        case PivotStringId.LabelFilterOptionsDialogIsNotBetween: return "außerhalb";
        case PivotStringId.LabelFilterOptionsDialogLabelFilter: return "Label Filter ({0})";
        case PivotStringId.NumberFormatOptionsDialogCustomFormat: return "Eigenes Format";
        case PivotStringId.NumberFormatOptionsDialogFixedPoint: return "Festkomma mit 2 Nachkommastellen";
        case PivotStringId.NumberFormatOptionsDialogPrefixedCurrency:
          return "$ vorangestellte Währung mit 2 Nachkommastellen";
        case PivotStringId.NumberFormatOptionsDialogPostfixedCurrency:
          return "€ nachgestelle Währung mit 2 Nachkommastellen";
        case PivotStringId.NumberFormatOptionsDialogPostfixedTemperatureC:
          return "°C nachgestellte Temperatur mit 2 Nachkommastellen";
        case PivotStringId.NumberFormatOptionsDialogPostfixedTemperatureF:
          return "°F nachgestellte Temperatur mit 2 Nachkommastellen";
        case PivotStringId.NumberFormatOptionsDialogExponential: return "Exponential";
        case PivotStringId.NumberFormatOptionsDialogFormatOptions: return "Format-Optionen";
        case PivotStringId.NumberFormatOptionsDialogFormatOptionsDescription: return "Format Option ({0})";
        case PivotStringId.SortOptionsDialogSortOptions: return "Sortier Option ({0})";
        case PivotStringId.Top10FilterOptionsDialogTop: return "Top";
        case PivotStringId.Top10FilterOptionsDialogBottom: return "Bottom";
        case PivotStringId.Top10FilterOptionsDialogItems: return "Einträge";
        case PivotStringId.Top10FilterOptionsDialogPercent: return "Prozent";
        case PivotStringId.Top10FilterOptionsDialogTop10: return "Top10 Filter ({0})";
        case PivotStringId.ValueFilter: return "Wert Filter ({0})";
        case PivotStringId.AggregateOptionsDialogGroupBoxText: return "Werte zusammenfassen nach";
        case PivotStringId.AggregateOptionsDialogLabelCustomName: return "Eigener Name:";
        case PivotStringId.AggregateOptionsDialogLabelDescription:
          return
            "Wählen Sie die Berechnungsart aus, mit der die Daten des ausgewählten Feldes zusammengefasst werden sollen.";
        case PivotStringId.AggregateOptionsDialogLabelField: return "FieLabelld Name";
        case PivotStringId.AggregateOptionsDialogLabelSourceName: return "Quellen Name:";
        case PivotStringId.AggregateOptionsDialogText: return "Optionen: Aggregation";
        case PivotStringId.AggregateOptionsAggregateOptionsText: return "Aggregate Optionen";
        case PivotStringId.DialogButtonCancel: return "Abbrechen";
        case PivotStringId.DialogButtonOK: return "OK";
        case PivotStringId.CalculationOptionsDialogText: return "Optionen: Berechnung";
        case PivotStringId.CalculationOptionsDialogLabelBaseItem: return "Basis Item:";
        case PivotStringId.CalculationOptionsDialogLabelBaseField: return "Basis Feld:";
        case PivotStringId.CalculationOptionsDialogGroupBoxText: return "Zeige Wert als";
        case PivotStringId.LabelFilterOptionsDialogGroupBoxText: return "Einträge anzeigen, für die das Label";
        case PivotStringId.LabelFilterOptionsDialogText: return "LabelFilterOptionsDialog";
        case PivotStringId.LabelFilterOptionsDialogLabelAnd: return "und";
        case PivotStringId.NumberFormatOptionsDialogFormat: return "Format";
        case PivotStringId.NumberFormatOptionsDialogLabelDescription:
          return
            "Das Format sollte die Messgröße des Wertes bezeichnen. ($, ¥, €, kg., lb.), Das Format wird für allgemeine Berechnungen wie z. B. Sum, Average, Min und Max und andere verwendet.";
        case PivotStringId.NumberFormatOptionsDialogText: return "NumberFormatOptionsDialog";
        case PivotStringId.NumberFormatOptionsDialogGroupBoxText: return "Generelles Format";
        case PivotStringId.SortOptionsDialogAscending: return "Aufsteigend sortieren (A-Z):";
        case PivotStringId.SortOptionsDialogDescending: return "Absteigend sortieren (Z-A):";
        case PivotStringId.SortOptionsDialogGroupBoxText: return "Sortier-Optionen";
        case PivotStringId.SortOptionsDialogText: return "SortOptionsDialog";
        case PivotStringId.Top10FilterOptionsDialogGroupBoxText: return "Zeige";
        case PivotStringId.Top10FilterOptionsDialogLabelBy: return "nach";
        case PivotStringId.Top10FilterOptionsDialogText: return "Top10FilterOptionsDialog";
        case PivotStringId.ValueFilterOptionsDialogGroupBox: return "Zeige Einträge, für die";
        case PivotStringId.ValueFilterOptionsDialogText: return "ValueFilterOptionsDialog";
        case PivotStringId.DragDataItemsHere: return "Einträge hierhin ziehen";
        case PivotStringId.DragColumnItemsHere: return "Spalten hierhin ziehen";
        case PivotStringId.DragItemsHere: return "Zeilen hierhin ziehen";
        case PivotStringId.DragFilterItemsHere: return "Filter-Einträge hierhin ziehen";
        case PivotStringId.DragRowItemsHere: return "Spalten hierhin ziehen";
        case PivotStringId.ResultItemFormat: return "Id: {0}; Aggregation: {1}";
        case PivotStringId.Error: return "Fehler";
        case PivotStringId.KpiSchemaElementValidatorError:
          return "Es sollte mindestens ein KPI-Wert definiert werden (Ziel, Status, Trend, Wert)";
        case PivotStringId.SchemaElementValidatorMissingPropertyFormat: return "Erforderliche Eigenschaft fehlt: {0}";
        case PivotStringId.AdomdCellInfoToStringFormat: return "Ordinal: {0} | Wert: {1}";
        case PivotStringId.Aggregates: return "Aggregate";
        case PivotStringId.FilterMenuTextBoxItemNullText: return "Suche...";
        case PivotStringId.FieldChooserFormButtonAdd: return "Hinzufügen zu";
        case PivotStringId.FieldChooserFormFields: return "Felder:";
        case PivotStringId.FieldChooserFormText: return "Feld Auswahl";
        case PivotStringId.FieldChooserFormColumnArea: return "Saplten";
        case PivotStringId.FieldChooserFormDataArea: return "Daten/Werte";
        case PivotStringId.FieldChooserFormFilterArea: return "Filter";
        case PivotStringId.FieldChooserFormRowArea: return "Zeilen";
        case PivotStringId.FieldListlabelChooseFields: return "Verfügbare Felder:";
        case PivotStringId.FieldListButtonUpdate: return "Update";
        case PivotStringId.FieldListCheckBoxDeferUpdate: return "Update vermeiden";
        case PivotStringId.FieldListLabelDrag: return "Felder hierher verschieben:";
        case PivotStringId.FieldListLabelRowLabels: return "Zeilen";
        case PivotStringId.FieldListLabelColumnLabels: return "Spalten";
        case PivotStringId.FieldListLabelReportFilter: return "Filter";
        case PivotStringId.None: return "Nichts";
        case PivotStringId.PrintSettingsFitWidth: return "Breite anpassen";
        case PivotStringId.PrintSettingsFitHeight: return "Höhe anpassen";
        case PivotStringId.PrintSettingsCompact: return "Kompakt";
        case PivotStringId.PrintSettingsTabular: return "Tabellarisch";
        case PivotStringId.PrintSettingsFitAll: return "Automatisch anpassen";
        case PivotStringId.PrintSettingsPrintOrder: return "Druckreihenfolge";
        case PivotStringId.PrintSettingsThenOver: return "Horizontal";
        case PivotStringId.PrintSettingsThenDown: return "Vertikal";
        case PivotStringId.PrintSettingsFontsAndColors: return "Schriftart und Farben";
        case PivotStringId.PrintSettingsBackground: return "Hintergrund";
        case PivotStringId.PrintSettingsNone: return "(nichts)";
        case PivotStringId.PrintSettingsFont: return "Schrift";
        case PivotStringId.PrintSettingsGrantTotal: return "Gesamtsumme (Zellen):";
        case PivotStringId.PrintSettingsDescriptors: return "Gruppenbeschreibung:";
        case PivotStringId.PrintSettingsSubTotal: return "Zeilsumme (Zellen):";
        case PivotStringId.PrintSettingsHeaderCells: return "Spaltenkopf - Zellen:";
        case PivotStringId.PrintSettingsDataCells: return "Zellen:";
        case PivotStringId.PrintSettingsGridLinesColor: return "Gitterlinien-Farbe:";
        case PivotStringId.PrintSettingsSettings: return "Einstellungen";
        case PivotStringId.PrintSettingsLayuotType: return "Layout Typ:";
        case PivotStringId.PrintSettingsScaleMode: return "Skaliermodus:";
        case PivotStringId.PrintSettingsPrintSelectionOnly: return "Drucke Auswahl";
        case PivotStringId.PrintSettingsShowGridLines: return "Zeige Gitterlinien";
        case PivotStringId.CollapseMenuItem: return "Einklappen";
        case PivotStringId.CalcualtedFields: return "Berechnete Felder";
        case PivotStringId.Max: return "Max";
        case PivotStringId.NullValue: return "(leer)";
        case PivotStringId.PivotMoreFields: return "Weitere Felder";
        case PivotStringId.CellScreenTipValue: return "Wert";
        case PivotStringId.CellScreenTipRow: return "Reihe";
        case PivotStringId.CellScreenTipColumn: return "Saplte";
        case PivotStringId.SortOptionsContextFromAtoZMenuText: return "Aufsteigend sortieren (von A nach Z)";
        case PivotStringId.SortOptionsContextFromZtoAMenuText: return "Absteigend sortieren (von A nach Z)";
        case PivotStringId.SortOptionsContextMoreSortingOptionsMenuText: return "Weitere Sortier-Optionen ...";
        case PivotStringId.ContextTop10FilterOptionsMenuText: return "Top10 Filter";
        case PivotStringId.ContextNumberFormatrOptionsMenuText: return "Zahlen-Format...";
        case PivotStringId.ContextClearCalculationsrOptionsMenuText: return "Lösche Berechnungen";
        case PivotStringId.ContextMoreCalculationOptionsOptionsMenuText: return "Weitere berechnungs-Optionen...";
        case PivotStringId.ContextPercentOfGrandTotalOptionsOptionsMenuText: return "% der Gesamtsumme";
        case PivotStringId.ContextMoreAggregatOptionsOptionsMenuText: return "Weitere Aggregations-Optionen...";
        case PivotStringId.ContextGroupByYearOptionsMenuText: return "Gruppieren nach Jahr";
        case PivotStringId.ContextGroupByQuaterOptionsMenuText: return "Gruppieren nach Quartal";
        case PivotStringId.ContextGroupByMonthOptionsMenuText: return "Gruppieren nach Monat";
        case PivotStringId.ContextGroupByDayhOptionsMenuText: return "Gruppieren nach Tag";
        case PivotStringId.ContextStepText: return "Schritt";
        case PivotStringId.FieldListDateText: return "Datum";
      }

      return base.GetLocalizedString(id);
    }
  }
}