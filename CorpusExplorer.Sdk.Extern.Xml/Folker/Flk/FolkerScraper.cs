#region

using System.Collections.Generic;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.Folker.Flk.Model;
using CorpusExplorer.Sdk.Extern.Xml.Helper;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Folker.Flk
{
  public class FolkerScraper : AbstractXmlScraper
  {
    public override string DisplayName => "FOLKER-FLK";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var model = XmlSerializerHelper.Deserialize<folkertranscription>(file);
      var dic = new Dictionary<string, object>();

      // model.head - Scheint sinnlos zu sein

      for (var i = 0; i < model.speakers.Length; i++)
      {
        var speaker = model.speakers[i];
        dic.Add($"Sprecher Nr. {i + 1}", $"{speaker.name} ({speaker.speakerid})");
      }

      if (model.recording != null &&
          string.IsNullOrEmpty(model.recording.path))
        dic.Add("Datei", model.recording.path);

      /* ToDo: Timeline wird aktuell ignoriert - Ausschnitt aus UnitTest
      Assert.AreEqual(42, folker.timeline.Length);
      Assert.AreEqual(((decimal)1.1648), Math.Round(folker.timeline[2].absolutetime, 4));
      */

      var stb = new StringBuilder();
      foreach (var item in model.contribution.SelectMany(contribution => contribution.Items).OfType<w>())
        stb.AppendFormat("{0} ", string.Join(" ", item.Text).Trim());
      dic.Add("Text", stb.ToString().Trim());

      return new[] {dic};
    }
  }
}