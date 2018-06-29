using System;
using System.Collections.Generic;
using System.IO;
using CorpusExplorer.Sdk.Extern.Plaintext.Abstract;

// ReSharper disable StringIndexOfIsCultureSpecific.2
// ReSharper disable StringIndexOfIsCultureSpecific.1

namespace CorpusExplorer.Sdk.Extern.Plaintext.Europarl
{
  public class EuroparlScraper : AbstractPlaintextScraper
  {
    public override string DisplayName => "EuroParl";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var res = new List<Dictionary<string, object>>();
      var raw =
        File.ReadAllText(file)
          .Replace("<P>", " ")
          .Replace("\r\n", " ")
          .Replace("\t", " ")
          .Replace("\r", " ")
          .Replace("\n", " ")
          .Replace("  ", " ")
          .Replace("  ", " ")
          .Replace("  ", " ");

      var labelChapter = "<CHAPTER";
      var labelSpeaker = "<SPEAKER";
      var labelClose = ">";
      var labelId = "ID=";
      var labelLanguage = "LANGUAGE=";
      var labelName = "NAME=";

      var utteranceId = 1;
      var chapter = 0;
      var speakerName = string.Empty;
      var speakerLanguage = string.Empty;
      var fileName = Path.GetFileNameWithoutExtension(file);

      var indexChapter = raw.IndexOf(labelChapter);
      var indexSpeaker = raw.IndexOf(labelSpeaker);
      var isChapter = indexChapter != -1 && indexChapter < indexSpeaker;
      var index = isChapter ? indexChapter : indexSpeaker;

      while (indexChapter > -1 ||
             indexSpeaker > -1)
      {
        var end = -1;
        var speakerId = 0;
        if (isChapter)
        {
          end = raw.IndexOf(labelClose, index);
          var info =
            raw.Substring(index, end - index)
              .Replace(labelChapter, string.Empty)
              .Replace(labelId, string.Empty)
              .Replace(labelClose, string.Empty)
              .Replace(" ", string.Empty);
          if (!int.TryParse(info, out chapter))
            chapter = 0;

          speakerName = string.Empty;
          speakerId = 0;
          speakerLanguage = string.Empty;
        }
        else
        {
          end = raw.IndexOf(labelClose, index);
          var info =
            raw.Substring(index, end - index)
              .Replace(labelSpeaker, string.Empty)
              .Replace(labelClose, string.Empty)
              .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

          speakerName = string.Empty;
          speakerId = 0;
          speakerLanguage = string.Empty;
          var eon = false;

          foreach (var x in info)
          {
            if (x.StartsWith(labelId))
              if (!int.TryParse(x.Replace(labelId, string.Empty), out speakerId))
                speakerId = 0;
            if (x.StartsWith(labelLanguage))
              speakerLanguage = x.Replace(labelLanguage, string.Empty).Replace("\"", string.Empty);
            if (x.StartsWith(labelName))
            {
              speakerName = x.Replace(labelName, string.Empty).Replace("\"", string.Empty);
              eon = !x.EndsWith("\"");
              continue;
            }

            if (eon)
            {
              speakerName += " " + x.Replace("\"", string.Empty);
              eon = !x.EndsWith("\"");
            }
          }
        }

        indexChapter = raw.IndexOf(labelChapter, index + 1);
        indexSpeaker = raw.IndexOf(labelSpeaker, index + 1);
        isChapter = indexChapter != -1 && indexChapter < indexSpeaker;
        index = isChapter ? indexChapter : indexSpeaker;

        var text = index > -1 ? raw.Substring(end + 1, index - (end + 1)) : raw.Substring(end + 1);

        res.Add(
          new Dictionary<string, object>
          {
            {"Text", text.Trim()},
            {"File", fileName},
            {"UtteranceId", utteranceId.ToString("D5")},
            {"Speaker", speakerName},
            {"Language", speakerLanguage},
            {"SpeakerID", speakerId.ToString("D5")},
            {"Chapter", chapter}
          });

        utteranceId++;
      }

      return res;
    }
  }
}