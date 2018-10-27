#region

using System.Collections.Generic;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Folker.Model;
using CorpusExplorer.Sdk.Extern.Xml.Folker.Serializer;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Folker
{
  public class FolkerScraper : AbstractGenericXmlSerializerFormatScraper<folkertranscription>
  {
    public override string DisplayName => "FOLKER";

    protected override AbstractGenericSerializer<folkertranscription> Serializer => new FolkerSerializer();

    /*
      Assert.AreEqual(42, folker.timeline.Length);
      Assert.AreEqual(((decimal)1.1648), Math.Round(folker.timeline[2].absolutetime, 4));
      Assert.AreEqual(21, folker.contribution.Length);
      Assert.AreEqual(13, folker.contribution[2].Items.Length);
      Assert.IsTrue(folker.contribution[2].Items[1] is pause);
      Assert.IsTrue(folker.contribution[2].Items[2] is w);
      Assert.IsTrue((folker.contribution[2].Items[2] as w).Text[0] == "segment");
    */

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(string file, folkertranscription model)
    {
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