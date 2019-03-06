using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.EuroparlUds.Extension;
using CorpusExplorer.Sdk.Extern.Xml.EuroparlUds.Model;
using CorpusExplorer.Sdk.Extern.Xml.EuroparlUds.Serializer;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.EuroparlUds
{
  public class EuroParlUdsScraper : AbstractScraper
  {
    public override string DisplayName => "EuroParl-UDS";
    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var xml = new XmlDocument();
      using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
      using (var bs = new BufferedStream(fs))
        xml.Load(bs);

      var root = xml.DocumentElement.GetFirstSubNodeRecursive("text");

      var res = new List<Dictionary<string, object>>();

      var all = new Dictionary<string, object>
      {
        { "Datum", DateTimeHelper.Parse(root.GetAttribute("date"), "yyyy-MM-dd") },
        { "Ort", root.GetAttribute("place") },
        { "Sprache", root.GetAttribute("lang") }
      };

      var sections = root.GetSubNodesRecursive("section").ToArray();
      for (var i = 0; i < sections.Length; i++)
      {
        var section = sections[i];
        var interventions = section.GetSubNodesRecursive("intervention").ToArray();

        for (var j = 0; j < interventions.Length; j++)
        {
          var intervention = interventions[j];

          var ps = intervention.GetSubNodesRecursive("p")?.ToArray();
          if (ps == null || ps.Length < 1)
            continue;

          var birthday = DateTimeHelper.Parse(intervention.GetAttribute("birth_date"), "yyyy-MM-dd");
          var old = birthday.Year > 1800 ? (DateTime.Now - birthday).Days / 365 : -1;

          var dict = all.ToArray().ToDictionary(x => x.Key, x => x.Value);
          dict.Add("Sektion", i + 1);
          dict.Add("Beitrag", j + 1);
          dict.Add("Sektion (Titel)", section.GetAttribute("title"));
          dict.Add("Geburtstag", birthday);
          dict.Add($"Alter ({DateTime.Now.Year})", old);
          dict.Add("Geburtsort", intervention.GetAttribute("birth_place"));
          dict.Add("Ist MEP", intervention.GetAttribute("is_mep"));
          dict.Add("Modus", intervention.GetAttribute("mode"));
          dict.Add("Land", intervention.GetAttribute("m_state"));
          dict.Add("Nationalität", intervention.GetAttribute("nationality"));
          dict.Add("Name", intervention.GetAttribute("name"));
          dict.Add("Partei (National)", intervention.GetAttribute("n_party"));
          dict.Add("Partei (Europa)", intervention.GetAttribute("p_group"));
          dict.Add("Rolle", intervention.GetAttribute("role"));
          dict.Add("SpeakerID", intervention.GetAttribute("speaker_id"));
          dict.Add("Id", intervention.GetAttribute("id"));
          dict.Add("Text", string.Join("\r\n", ps.Select(x => x.InnerText)));

          res.Add(dict);
        }
      }

      return res;
    }
  }
}
