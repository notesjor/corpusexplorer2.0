using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

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
        switch (type) // Hinweis: Wenn hier case geändert wird - muss auch in type und in GenerateXenoDataType geändert werden.
        {
          case "integer":
            stb.AppendLine($"        <meta name=\"{x.Key}\" type=\"integer\">{x.Value.ToString().Replace(",", ".")}</meta>");
            break;
          case "date":
            stb.AppendLine($"        <meta name=\"{x.Key}\" type=\"date\">{x.Value:yyyy-MM-dd}</meta>");
            break;
          case "uri":
            stb.AppendLine($"        <meta name=\"{x.Key}\" type=\"uri\">{x.Value}</meta>");
            break;
          case "text":
            stb.AppendLine($"        <meta name=\"{x.Key}\" type=\"text\">{Escape(x.Value?.ToString())}</meta>");
            break;
        }
      }

      return stb.ToString();
    }


    private static string GenerateXenoDataType(object value)
    {
      switch (value) // Hinweis: Wenn hier case geändert wird - muss auch in GenerateXenoData geändert werden.
      {
        case int _:
        case long _:
        case float _:
        case double _:
        case decimal _:
        case byte _:
        case short _:
          return "integer";
        case DateTime _:
          return "date";
        default:
          if (value is string str && !string.IsNullOrWhiteSpace(str) && str.StartsWith("http"))
            return "uri";
          return "text";
      }
    }

    public static Dictionary<string, object> RemoveDataByKey(Dictionary<string, object> meta, string key)
    {
      return meta.Where(x => x.Key != key).ToDictionary(x => x.Key, x => x.Value);
    }

    private static string Escape(string text)
      => _escapeL1.Aggregate(text, (current, kvp) => current.Replace(kvp.Key, kvp.Value));

    private static Dictionary<string, string> _escapeL1 = new Dictionary<string, string>
    {
      { "&", "&amp;" },
      { "<", "&lt;" },
      { ">", "&gt;" }
    };
  }
}
