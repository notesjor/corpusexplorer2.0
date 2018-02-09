﻿#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model;
using CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Serializer;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf
{
  // ReSharper disable once UnusedMember.Global
  public class DtaScraper : AbstractGenericXmlSerializerFormatScraper<DSpin>
  {
    public override string DisplayName { get { return "DTA-TCF-XML"; } }

    protected override AbstractGenericSerializer<DSpin> Serializer { get { return new DtaSerializer(); } }

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(DSpin model)
    {
      var corpus = model.TextCorpus;
      var tokens = corpus.tokens.ToDictionary(t => t.ID, t => t.Value);
      var stb = new StringBuilder();

      foreach (
        var tids in corpus.sentences.Select(s => s.tokenIDs.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)))
        stb.AppendLine(string.Join(" ", tids.Select(tid => tokens[tid])));

      return new[] {new Dictionary<string, object> {{"Text", stb.ToString()}}};
    }
  }
}