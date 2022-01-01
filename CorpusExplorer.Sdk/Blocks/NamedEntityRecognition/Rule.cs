﻿#region

using System;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Utils.Filter;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.NamedEntityRecognition
{
  [XmlRoot]
  [Serializable]
  public class Rule
  {
    private AbstractFilterQuery _filter;

    [XmlIgnore]
    public AbstractFilterQuery Filter
    {
      get
      {
        if (_filter != null)
          return _filter;

        _filter = QueryParser.Parse(Query);
        return _filter;
      }
      set => Query = QueryParser.Serialize(value);
    }

    [XmlElement]
    public string Query { get; set; }

    [XmlAttribute]
    public double Rank { get; set; }
  }
}