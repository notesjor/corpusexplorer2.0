using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.ViewModel.Abstract;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class DocumentMetadataImportExportViewModel : AbstractViewModel
  {
    protected override void ExecuteAnalyse()
    {
    }

    public void Export(string path)
    {
      var columns = Selection.GetDocumentMetadataPrototypeOnlyPropertiesAndTypes();
      var tcolumns = new List<string>();
      foreach (var column in columns)
      {
        string pre;
        if (column.Value == typeof(DateTime))
          pre = "?";
        else if (column.Value == typeof(double))
          pre = "~";
        else if (column.Value == typeof(int))
          pre = "#";
        else
          pre = ">";

        tcolumns.Add(pre + column.Key);
      }
      
      using(var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
      using (var writer = new StreamWriter(fs, Configuration.Encoding))
      {
        writer.WriteLine(string.Join("\t", tcolumns));

        var guids = Selection.DocumentGuids;
        foreach (var guid in guids)
        {
          var meta = Selection.GetDocumentMetadata(guid);
          var buffer = new List<string>();
          foreach (var column in columns)
          {
            if (meta.ContainsKey(column.Key) && meta[column.Key] != null)
              buffer.Add(meta[column.Key].ToString());
            else
              buffer.Add(string.Empty);
          }
          writer.WriteLine(string.Join("\t", buffer));
        }
      }
    }

    public void Import(string path)
    {
      var lines = FileIO.ReadLines(path, Configuration.Encoding);
      
    }

    protected override bool Validate()=>true;
  }
}
