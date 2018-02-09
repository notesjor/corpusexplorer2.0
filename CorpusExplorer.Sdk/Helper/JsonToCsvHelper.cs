using System.Data;
using System.Text;
using System.Xml;
using Bcs.IO;
using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Helper
{
  public static class JsonToCsvHelper
  {
    public static void SaveJsonAsCsvFile(string path, string jsonString, string csvDelimator = ";", Encoding enc = null)
    {
      XmlNode xml = JsonConvert.DeserializeXmlNode("{records:{record:" + jsonString + "}}");

      var xmldoc = new XmlDocument();
      xmldoc.LoadXml(xml.InnerXml);

      var xmlReader = new XmlNodeReader(xmldoc);
      var dataSet = new DataSet();
      dataSet.ReadXml(xmlReader);

      var tempQualifier = dataSet.Tables[0];
      var result = new StringBuilder();

      for (var i = 0; i < tempQualifier.Columns.Count; i++)
      {
        result.Append(tempQualifier.Columns[i].ColumnName);
        result.Append(i == tempQualifier.Columns.Count - 1 ? "\n" : csvDelimator);
      }

      foreach (DataRow row in tempQualifier.Rows)
        for (var i = 0; i < tempQualifier.Columns.Count; i++)
        {
          result.Append(row[i]);
          result.Append(i == tempQualifier.Columns.Count - 1 ? "\n" : csvDelimator);
        }

      FileIO.Write(path, result.ToString().TrimEnd('\r', '\n'), enc);
    }
  }
}