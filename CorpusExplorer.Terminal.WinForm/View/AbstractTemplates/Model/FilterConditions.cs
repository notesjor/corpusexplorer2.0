using System;
using System.Xml.Serialization;
using Telerik.WinControls.Data;

namespace CorpusExplorer.Terminal.WinForm.View.AbstractTemplates.Model
{
  [XmlRoot("condition")]
  [Serializable]
  public class FilterConditions
  {
    [XmlAttribute("operator")] public FilterOperator Operator { get; set; }

    [XmlElement] public object Value { get; set; }
  }
}