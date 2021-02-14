#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht
{
  public class ExporterWeblicht : AbstractExporter
  {
    public string CorpusLanguage { get; set; } = "de";
    public string CorpusTagset { get; set; } = "STTS";
    public string LayernameLemma { get; set; } = "Lemma";
    public string LayernamePos { get; set; } = "POS";

    public string LayernameWord { get; set; } = "Wort";

    public override void Export(IHydra hydra, string path)
    {
      path = path.Replace(".xml", "");
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);

      var i = 0;

      foreach (var guid in hydra.DocumentGuids)
        try
        {
          string text;
          using (var ms = new MemoryStream())
          {
            XmlSerializerHelper.Serialize(GetDSpin(hydra, guid, i++), ms);
            var lines = Configuration.Encoding.GetString(ms.ToArray())
                                     .Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            lines[1] = GetDspinMetadata(hydra.GetDocumentMetadata(guid));
            text = string.Join("\r\n", lines);
          }

          FileIO.Write(Path.Combine(path, guid + ".xml"), text, Configuration.Encoding);
        }
        catch
        {
        }
    }

    private string GetDspinMetadata(Dictionary<string, object> metadata)
    {
      var stb = new StringBuilder("<D-Spin xmlns=\"http://www.dspin.de/data\" version=\"0.4\"><MetaData xmlns=\"http://www.dspin.de/data/metadata\"><Services><cmd:CMD xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:cmd=\"http://www.clarin.eu/cmd/1\" CMDVersion=\"1.2\" xsi:schemaLocation=\"http://www.clarin.eu/cmd/1 http://catalog.clarin.eu/ds/ComponentRegistry/rest/registry/profiles/clarin.eu:cr1:p_1320657629623/xsd\"><cmd:Resources><cmd:ResourceProxyList></cmd:ResourceProxyList><cmd:JournalFileProxyList></cmd:JournalFileProxyList><cmd:ResourceRelationList></cmd:ResourceRelationList></cmd:Resources><cmd:Components><cmd:WebServiceToolChain><cmd:GeneralInfo><cmd:Descriptions><cmd:Description></cmd:Description></cmd:Descriptions><cmd:ResourceName>Custom chain</cmd:ResourceName><cmd:ResourceClass>Toolchain</cmd:ResourceClass></cmd:GeneralInfo><cmd:Toolchain><cmd:ToolInChain><cmd:PID>http://hdl.handle.net/11858/00-1778-0000-0004-BA56-7</cmd:PID><cmd:Parameter value=\"de\" name=\"lang\"></cmd:Parameter><cmd:Parameter value=\"text/plain\" name=\"type\"></cmd:Parameter></cmd:ToolInChain><cmd:ToolInChain><cmd:PID>http://hdl.handle.net/11022/1007-0000-0000-8E1F-F</cmd:PID><cmd:Parameter value=\"de\" name=\"lang\"></cmd:Parameter></cmd:ToolInChain><cmd:ToolInChain><cmd:PID>http://hdl.handle.net/11022/1007-0000-0000-8E22-A</cmd:PID><cmd:Parameter value=\"de\" name=\"lang\"></cmd:Parameter></cmd:ToolInChain></cmd:Toolchain></cmd:WebServiceToolChain></cmd:Components></cmd:CMD></Services>");
      stb.Append("<md name=\"Generator\" value=\"CorpusExplorer\"/>");
      foreach (var x in metadata)
        stb.Append($"<md name=\"{x.Key}\" value=\"{x.Value}\"/>");
      stb.Append("</MetaData>");
      return stb.ToString();
    }

    private DSpin GetDSpin(IHydra hydra, Guid guid, int i)
    {
      var docW = hydra.GetReadableDocument(guid, LayernameWord).Select(x => x.ToArray()).ToArray();
      // Die folgenden Layer sind optional
      var docL = hydra.GetReadableDocument(guid, LayernameLemma)?.Select(x => x.ToArray()).ToArray();
      var docP = hydra.GetReadableDocument(guid, LayernamePos)?.Select(x => x.ToArray()).ToArray();

      var text = new StringBuilder();
      var tokens = new List<token>();
      var lemmas = new List<lemma>();
      var tags = new List<tag>();
      var sents = new List<sentence>();

      var id = 1;

      var lId = 1;

      for (var j = 0; j < docW.Length; j++)
      {
        var sent = new StringBuilder();
        for (var k = 0; k < docW[j].Length; k++)
        {
          var iD = "t" + id++;
          sent.AppendFormat(" {0}", iD);
          tokens.Add(new token { ID = iD, Text = docW[j][k] });
          if (docL != null)
            lemmas.Add(new lemma { ID = "" + lId++, tokenIDs = iD, Text = docL[j][k] });
          if (docP != null)
            tags.Add(new tag { tokenIDs = iD, Text = docP[j][k] });

          if (docW[j][k].Length > 1)
            text.Append(" ");
          text.Append(docW[j][k]);
        }

        sents.Add(new sentence { tokenIDs = sent.ToString().Trim(), ID = "s" + j });
      }

      return new DSpin
      {
        version = (decimal)0.4,
        TextCorpus =
          new TextCorpus
          {
            text = hydra.GetReadableDocument(guid, "Wort").ReduceDocumentToText(),
            lang = CorpusLanguage,
            tokens = tokens.ToArray(),
            lemmas = docL == null ? null : lemmas.ToArray(),
            POStags = docP == null ? null : new POStags { tag = tags.ToArray(), tagset = CorpusTagset },
            sentences = sents.ToArray()
          }
      };
    }
  }
}