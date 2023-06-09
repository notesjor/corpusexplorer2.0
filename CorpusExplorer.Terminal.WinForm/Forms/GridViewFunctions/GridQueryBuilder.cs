using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.Forms.GridViewFunctions
{
  public partial class GridQueryBuilder : AbstractDialog
  {
    private const string _fileExtension = "CorpusExplorer Tabellen-Abfrage (*.{0}.cetq)|*.{0}.cetq";
    private readonly string _name;
    private Dictionary<string, Type> _definition;

    public GridQueryBuilder(Dictionary<string, Type> definition, string expression, string name)
    {
      _name = name;
      DataFilterLocalizationProvider.CurrentProvider = new GermanDataFilterLocalizationProvider();
      InitializeComponent();
      ButtonOkClick += GridQueryBuilder_ButtonOkClick;

      _definition = definition;
      ReloadDefinition();

      radDataFilter1.Expression = expression;
    }

    private void ReloadDefinition()
    {
      foreach (var x in _definition)
        radDataFilter1.Descriptors.Add(new DataFilterDescriptorItem { DescriptorName = x.Key, DescriptorType = x.Value });
    }

    public string Result { get; set; }

    private void btn_load_Click(object sender, EventArgs e)
    {
      radDataFilter1.Descriptors.Clear();
      ReloadDefinition();

      var ofd = new OpenFileDialog
      {
        CheckFileExists = true,
        Filter = string.Format(_fileExtension, _name)
      };
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      radDataFilter1.Expression = File.ReadAllText(ofd.FileName);
    }

    private void btn_new_Click(object sender, EventArgs e)
    {
      radDataFilter1.Descriptors.Clear();
      ReloadDefinition();
    }

    private void btn_save_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog
      {
        CheckPathExists = true,
        Filter = string.Format(_fileExtension, _name)
      };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      File.WriteAllText(sfd.FileName, radDataFilter1.Expression);
    }

    private void GridQueryBuilder_ButtonOkClick(object sender, EventArgs e)
    {
      Result = radDataFilter1.Expression;
    }


    public class GermanDataFilterLocalizationProvider : Telerik.WinControls.UI.DataFilterLocalizationProvider
    {
      public override string GetLocalizedString(string id)
      {
        switch (id)
        {
          case DataFilterStringId.LogicalOperatorAnd:
            return "Alle folgenden Bedingungen müssen";
          case DataFilterStringId.LogicalOperatorOr:
            return "Eine der folgenden Bedingungen muss";
          case DataFilterStringId.LogicalOperatorDescription:
            return " wahr sein:";

          case DataFilterStringId.FieldNullText:
            return "Spalte auswählen";
          case DataFilterStringId.ValueNullText:
            return "Wert eingeben";

          case DataFilterStringId.AddNewButtonText:
            return "Hinzufügen";
          case DataFilterStringId.AddNewButtonExpression:
            return "Suchausdruck";
          case DataFilterStringId.AddNewButtonGroup:
            return "Gruppe";

          case DataFilterStringId.DialogTitle:
            return "Daten Filter";
          case DataFilterStringId.DialogOKButton:
            return "OK";
          case DataFilterStringId.DialogCancelButton:
            return "Abbrechen";
          case DataFilterStringId.DialogApplyButton:
            return "Übernehmen";

          case DataFilterStringId.ErrorAddNodeDialogTitle:
            return "Fehler";
          case DataFilterStringId.ErrorAddNodeDialogText:
            return "ERROR PROV001";

          case DataFilterStringId.FilterFunctionBetween:
            return "zwischen";
          case DataFilterStringId.FilterFunctionContains:
            return "enthält";
          case DataFilterStringId.FilterFunctionDoesNotContain:
            return "enthält nicht";
          case DataFilterStringId.FilterFunctionEndsWith:
            return "endet auf";
          case DataFilterStringId.FilterFunctionEqualTo:
            return "gleich";
          case DataFilterStringId.FilterFunctionGreaterThan:
            return "größer";
          case DataFilterStringId.FilterFunctionGreaterThanOrEqualTo:
            return "größer oder gleich";
          case DataFilterStringId.FilterFunctionIsEmpty:
            return "ist leer";
          case DataFilterStringId.FilterFunctionIsNull:
            return "ist NULL";
          case DataFilterStringId.FilterFunctionLessThan:
            return "kleiner";
          case DataFilterStringId.FilterFunctionLessThanOrEqualTo:
            return "kleiner oder gleich";
          case DataFilterStringId.FilterFunctionNoFilter:
            return "Kein Filter";
          case DataFilterStringId.FilterFunctionIsContainedIn:
            return "ist in der Liste enthalten";
          case DataFilterStringId.FilterFunctionIsNotContainedIn:
            return "ist nicht in der Liste enthalten";
          case DataFilterStringId.FilterFunctionNotBetween:
            return "außerhalb";
          case DataFilterStringId.FilterFunctionNotEqualTo:
            return "ungleich";
          case DataFilterStringId.FilterFunctionNotIsEmpty:
            return "ist nicht leer";
          case DataFilterStringId.FilterFunctionNotIsNull:
            return "ist nicht NULL";
          case DataFilterStringId.FilterFunctionStartsWith:
            return "beginnt mit";
          case DataFilterStringId.FilterFunctionCustom:
            return "manueller Filter";
        }
        return base.GetLocalizedString(id);
      }
    }
  }
}