using System.Collections.Generic;
using System.Globalization;
using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Extern.Xml.PostgreSqlDump.Model;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Extern.Xml.PostgreSqlDump
{
  public class PostgreSqlDumpScraper : AbstractXmlScraper
  {
    public override string DisplayName => "PostgreSQL";
    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var model = XmlSerializerHelper.Deserialize<data>(file);
      var res = new List<Dictionary<string, object>>();
      var types = new Dictionary<string, byte>();

      string txtName = null;
      foreach (var x in model.header)
      {
        if (x.name == "txt" || x.name == "text" || x.name == "txtlong")
          if (txtName == null)
            txtName = x.name;
          else if (x.name == "Text")
            txtName = x.name;

        if (x.type.StartsWith("int"))
          types.Add(x.name, 10);
        else if (x.type.StartsWith("float"))
          types.Add(x.name, 20);
        else if (x.type == "date")
          types.Add(x.name, 30);
        else
          types.Add(x.name, 0);
      }

      foreach (var row in model.records)
      {
        var ndoc = new Dictionary<string, object>();
        foreach (var c in row)
          if (c.name == txtName)
            ndoc.Add("Text", c.Value);
          else
            switch (types[c.name])
            {
              case 10:
                ndoc.Add(c.name, int.Parse(c.Value));
                break;
              case 20:
                ndoc.Add(c.name, double.Parse(c.Value, CultureInfo.InvariantCulture));
                break;
              case 30:
                ndoc.Add(c.name, DateTimeHelper.Parse(c.Value));
                break;
              default:
                ndoc.Add(c.name, c.Value);
                break;
            }
        res.Add(ndoc);
      }

      return res;
    }
  }
}