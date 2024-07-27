using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.Helper
{
  public static class ExportXenodataHelper
  {
    public static string GenerateXenoData(Dictionary<string, object> meta)
    {
      var stb = new StringBuilder();
      foreach (var x in meta)
      {
        if (x.Value == null)
          continue;

        var type = GenerateXenoDataType(x.Value);
        switch (type)
        {
          case "number":
            stb.AppendLine($"        <meta name=\"{x.Key}\" type=\"number\">{x.Value.ToString().Replace(",", ".")}</meta>");
            break;
          case "date":
            stb.AppendLine($"        <meta name=\"{x.Key}\" type=\"date\">{x.Value:yyyy-MM-dd}</meta>");
            break;
          case "text":
            stb.AppendLine($"        <meta name=\"{x.Key}\" type=\"text\">{x.Value}</meta>");
            break;
        }
      }

      return stb.ToString();
    }


    private static string GenerateXenoDataType(object value)
    {
      switch (value)
      {
        case int _:
        case long _:
        case float _:
        case double _:
        case decimal _:
        case byte _:
        case short _:
          return "number";
        case DateTime _:
          return "date";
        default:
          return "text";
      }
    }

    public static Dictionary<string, object> RemoveDataByKey(Dictionary<string, object> meta, string key)
    {
      return meta.Where(x => x.Key != key).ToDictionary(x => x.Key, x => x.Value);
    }
  }
}
