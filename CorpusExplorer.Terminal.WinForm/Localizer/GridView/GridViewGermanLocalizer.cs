using CorpusExplorer.Terminal.WinForm.Properties;
using Telerik.WinControls.UI.Localization;

namespace CorpusExplorer.Terminal.WinForm.Localizer.GridView
{
  public class GridViewGermanLocalizer : RadGridLocalizationProvider
  {
    public override string GetLocalizedString(string id)
    {
      switch (id)
      {
        case RadGridStringId.FilterOperatorBetween:
          return Resources.Zwischen;
        case RadGridStringId.FilterOperatorContains:
          return Resources.Beinhaltet;
        case RadGridStringId.FilterOperatorDoesNotContain:
          return Resources.BeinhaltetNicht;
        case RadGridStringId.FilterOperatorEndsWith:
          return Resources.EndetMit;
        case RadGridStringId.FilterOperatorEqualTo:
          return Resources.IstGleich;
        case RadGridStringId.FilterOperatorGreaterThan:
          return Resources.GrößerAls;
        case RadGridStringId.FilterOperatorGreaterThanOrEqualTo:
          return Resources.GrößerAlsOderGleich;
        case RadGridStringId.FilterOperatorIsEmpty:
          return "Ist Leer";
        case RadGridStringId.FilterOperatorIsNull:
          return "Ist Null";
        case RadGridStringId.FilterOperatorLessThan:
          return Resources.WenigerAls;
        case RadGridStringId.FilterOperatorLessThanOrEqualTo:
          return Resources.WenigerAlsOderGleich;
        case RadGridStringId.FilterOperatorNoFilter:
          return Resources.KeinFilter;
        case RadGridStringId.FilterOperatorNotBetween:
          return Resources.NichtZwischen;
        case RadGridStringId.FilterOperatorNotEqualTo:
          return Resources.NichtGleich;
        case RadGridStringId.FilterOperatorNotIsEmpty:
          return Resources.NichtLeer;
        case RadGridStringId.FilterOperatorNotIsNull:
          return "Nicht Null";
        case RadGridStringId.FilterOperatorStartsWith:
          return Resources.StartetMit;
        case RadGridStringId.FilterOperatorIsLike:
          return Resources.Wie;
        case RadGridStringId.FilterOperatorNotIsLike:
          return Resources.NichtWie;
        case RadGridStringId.FilterOperatorIsContainedIn:
          return Resources.EnthaltenIn;
        case RadGridStringId.FilterOperatorNotIsContainedIn:
          return Resources.NichtBestandteilVon;
        case RadGridStringId.FilterOperatorCustom:
          return "Maßgeschneidert Funktion";
        case RadGridStringId.FilterFunctionBetween:
          return "Zwischen";
        case RadGridStringId.FilterFunctionContains:
          return Resources.Beinhaltet;
        case RadGridStringId.FilterFunctionDoesNotContain:
          return Resources.BeinhaltetNicht;
        case RadGridStringId.FilterFunctionEndsWith:
          return Resources.EndetMit;
        case RadGridStringId.FilterFunctionEqualTo:
          return Resources.IstGleich;
        case RadGridStringId.FilterFunctionGreaterThan:
          return Resources.GrößerAls;
        case RadGridStringId.FilterFunctionGreaterThanOrEqualTo:
          return Resources.GrößerAlsOderGleich;
        case RadGridStringId.FilterFunctionIsEmpty:
          return "Ist leer";
        case RadGridStringId.FilterFunctionIsNull:
          return "Ist null";
        case RadGridStringId.FilterFunctionLessThan:
          return Resources.WenigerAls;
        case RadGridStringId.FilterFunctionLessThanOrEqualTo:
          return Resources.WenigerAlsOderGleich;
        case RadGridStringId.FilterFunctionNoFilter:
          return Resources.KeinFilter;
        case RadGridStringId.FilterFunctionNotBetween:
          return Resources.NichtZwischen;
        case RadGridStringId.FilterFunctionNotEqualTo:
          return Resources.NichtGleich;
        case RadGridStringId.FilterFunctionNotIsEmpty:
          return Resources.NichtLeer;
        case RadGridStringId.FilterFunctionNotIsNull:
          return "Nicht null";
        case RadGridStringId.FilterFunctionStartsWith:
          return Resources.StartetMit;
        case RadGridStringId.FilterFunctionCustom:
          return Resources.IndividuelleFunktionen;
        case RadGridStringId.CustomFilterMenuItem:
          return Resources.Filter;
        case RadGridStringId.CustomFilterDialogCaption:
          return Resources.FilterDialog;
        case RadGridStringId.CustomFilterDialogLabel:
          return Resources.ZeigZeilenDie;
        case RadGridStringId.CustomFilterDialogRbAnd:
          return Resources.Und;
        case RadGridStringId.CustomFilterDialogRbOr:
          return Resources.Oder;
        case RadGridStringId.CustomFilterDialogBtnOk:
          return Resources.OK;
        case RadGridStringId.CustomFilterDialogBtnCancel:
          return Resources.Annullieren;
        case RadGridStringId.DeleteRowMenuItem:
          return Resources.ZeileLöschen;
        case RadGridStringId.SortAscendingMenuItem:
          return Resources.SortierenInAufsteigendeReihenfolge;
        case RadGridStringId.SortDescendingMenuItem:
          return Resources.SortierenInAbsteigendeReihenfolge;
        case RadGridStringId.ClearSortingMenuItem:
          return Resources.SortingLöschen;
        case RadGridStringId.ConditionalFormattingMenuItem:
          return Resources.Bedingungssatzformatierung;
        case RadGridStringId.GroupByThisColumnMenuItem:
          return Resources.PassenMitDieserSpalte;
        case RadGridStringId.UngroupThisColumn:
          return Resources.DieseSpalteVomGruppierungLöschen;
        case RadGridStringId.ColumnChooserMenuItem:
          return Resources.Spaltenwähler;
        case RadGridStringId.HideMenuItem:
          return Resources.Verstecken;
        case RadGridStringId.UnpinMenuItem:
          return Resources.FixierungAufheben;
        case RadGridStringId.UnpinRowMenuItem:
          return Resources.FixierungDerZeileAufheben;
        case RadGridStringId.PinAtTopMenuItem:
          return Resources.SpalteObenFixieren;
        case RadGridStringId.PinAtBottomMenuItem:
          return Resources.SpalteUntenFixieren;
        case RadGridStringId.PinMenuItem:
          return Resources.SpalteFixieren;
        case RadGridStringId.PinAtLeftMenuItem:
          return Resources.SpalteLinksFixieren;
        case RadGridStringId.PinAtRightMenuItem:
          return Resources.SpalteRechtsFixieren;
        case RadGridStringId.BestFitMenuItem:
          return Resources.BestePassung;
        case RadGridStringId.PasteMenuItem:
          return Resources.Einfügen;
        case RadGridStringId.EditMenuItem:
          return Resources.Bearbeiten;
        case RadGridStringId.CopyMenuItem:
          return Resources.Kopieren;
        case RadGridStringId.CutMenuItem:
          return Resources.Ausschneiden;
        case RadGridStringId.ClearValueMenuItem:
          return Resources.WertLöschen;
        case RadGridStringId.AddNewRowString:
          return Resources.KlickenSieHierUmEineNeueZeileEinzufügen;
        case RadGridStringId.ConditionalFormattingCaption:
          return "Maßgeschneidert Formatierung";
        case RadGridStringId.ConditionalFormattingLblColumn:
          return Resources.Spalte;
        case RadGridStringId.ConditionalFormattingLblName:
          return Resources.Name;
        case RadGridStringId.ConditionalFormattingLblType:
          return Resources.Typ;
        case RadGridStringId.ConditionalFormattingRuleAppliesOn:
          return Resources.RegelGiltFür;
        case RadGridStringId.ConditionalFormattingLblValue1:
          return Resources.Wert1;
        case RadGridStringId.ConditionalFormattingLblValue2:
          return Resources.Wert2;
        case RadGridStringId.ConditionalFormattingGrpConditions:
          return Resources.Auflagen;
        case RadGridStringId.ConditionalFormattingGrpProperties:
          return Resources.Eigenschaften;
        case RadGridStringId.ConditionalFormattingChkApplyToRow:
          return Resources.AufZeileAnwenden;
        case RadGridStringId.ConditionalFormattingBtnAdd:
          return Resources.Ansetzen;
        case RadGridStringId.ConditionalFormattingBtnRemove:
          return Resources.Löschen;
        case RadGridStringId.ConditionalFormattingBtnOK:
          return Resources.OK;
        case RadGridStringId.ConditionalFormattingBtnCancel:
          return Resources.Annullieren;
        case RadGridStringId.ConditionalFormattingBtnApply:
          return Resources.Anlegen;
        case RadGridStringId.ColumnChooserFormCaption:
          return Resources.Spaltenwähler;
        case RadGridStringId.ColumnChooserFormMessage:
          return Resources.UmEineSpalteZuVersteckenSchiebenSieSieVonDerTabelleAufDiesesFenster;
        case RadGridStringId.CustomFilterDialogCheckBoxNot:
          return Resources.Nicht;
        case RadGridStringId.GroupingPanelHeader:
          return "Gruppe(n):";
        case RadGridStringId.GroupingPanelDefaultMessage:
          return "Ziehen Sie den Spaltenkopf hier her, um die Tabelle zu gruppieren.";
        default:
          return base.GetLocalizedString(id);
      }
    }
  }
}