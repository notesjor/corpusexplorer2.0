#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Extern.Xml.Talkbank.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Talkbank
{
  // ReSharper disable once UnusedMember.Global
  public class TalkbankScraper : AbstractXmlScraper
  {
    public override string DisplayName => "Talkbank-XML";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var model = XmlSerializerHelper.Deserialize<CHAT>(file);
      /*
       * Interessant für Importer
       * 
      var corpus = model.Corpus;
      var date = model.Date;
      var id = model.Id;
      var media = model.Media;
      var pid = model.PID;
      var version = model.Version;
      */

      var participants = model.Participants.ToDictionary(
        p => p.id,
        p =>
          $"{p.name} [{p.sex} - {p.role}] ({p.age} - {p.birthday})");

      Console.WriteLine(participants.Count);

      foreach (var item in model.Items.OfType<speakerUtteranceType>())
        Console.WriteLine(item.ToString());

      return null;
    }
  }
}