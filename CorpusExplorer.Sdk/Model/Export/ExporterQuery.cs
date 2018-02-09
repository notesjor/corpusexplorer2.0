using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Export.Abstract;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.Filter;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;

namespace CorpusExplorer.Sdk.Model.Export
{
  public class ExporterQuery : AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
      FileIO.Write(path.ForceFileExtension("ceusd"), ExportInline(hydra as Selection), Configuration.Encoding);
    }

    public static string ExportInline(Selection selection)
    {
      var queries = selection?.Queries?.ToArray();
      if (queries == null || queries.Length == 0)
        return null;

      try
      {
        return string.Join("\r\n", selection.Queries.Select(QueryParser.Serialize).Where(t => !string.IsNullOrEmpty(t)));
      }
      catch
      {
        return null;
      }
    }
  }
}
