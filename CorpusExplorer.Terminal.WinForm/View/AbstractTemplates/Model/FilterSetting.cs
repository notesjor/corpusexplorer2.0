using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Telerik.WinControls.Data;

namespace CorpusExplorer.Terminal.WinForm.View.AbstractTemplates.Model
{
  [XmlRoot("filter")]
  [Serializable]
  public class FilterSetting
  {
    [XmlArray("conditions")] public List<FilterConditions> Conditions { get; set; }

    [XmlAttribute("invert")] public bool InvertFilter { get; set; }

    [XmlAttribute("logical")] public FilterLogicalOperator LogicalOperator { get; set; }

    [XmlAttribute("name")] public string PropertyName { get; set; }
  }
}