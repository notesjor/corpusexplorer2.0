#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bcs.IO;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Extern.Plaintext.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup;
using HtmlAgilityPack;
using MsgReader.Mime;
using MsgReader.Mime.Header;

#endregion

namespace CorpusExplorer.Sdk.Extern.Plaintext.RawMailMsg
{
  public sealed class RawMsgMsgScraper : AbstractPlaintextScraper
  {
    private readonly StandardCleanup _cleanup = new StandardCleanup();
    private readonly object _cleanupLock = new object();
    private string _tempPath;

    public override string DisplayName => "Easy MSG E-Mail";

    public Dictionary<string, object> Inline(string eml, Encoding encoding = null)
    {
      if (encoding == null)
        encoding = Encoding.UTF8;

      return Bypass(encoding.GetBytes(eml));
    }

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      return new[] {Bypass(FileIO.ReadBytes(file))};
    }

    private Dictionary<string, object> Bypass(byte[] rawData)
    {
      Message message = null;
      try
      {
        message = new Message(rawData, true);
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
      }

      if (message == null)
        return null;

      return new Dictionary<string, object>
      {
        {"MessageID", message.Id},
        {"Datum", message.Headers.DateSent},
        {"Absender", message.Headers.From.Address},
        {"Betreff", message.Headers.Subject},
        {"ReplyID (First)", message.Headers.InReplyTo?.FirstOrDefault()},
        {"ReplyID (Last)", message.Headers.InReplyTo?.LastOrDefault()},
        {"Empfänger (To)", MailAddressListToString(message.Headers.To)},
        {"Empfänger (CC)", MailAddressListToString(message.Headers.Cc)},
        {"Text", ExtractText(message)}
      };
    }

    private string CleanHtml(string html)
    {
      var doc = new HtmlDocument();
      doc.LoadHtml(html);

      var nodes = doc.DocumentNode.SelectNodes("//script");
      if (nodes != null)
        foreach (var node in nodes)
          node.Remove();

      var text = doc.DocumentNode.SelectSingleNode("//body").InnerText;
      int t0;
      do
      {
        t0 = text.Length;
        text = text.Replace("\r\r", "\r\n").Replace("\n\n", "\r\n").Replace("\r\n\r\n", "\r\n").Replace("\r\n ", "\r\n")
          .Replace("  ", " ").Replace("\t", " ");
      } while (t0 != text.Length);


      var temp = new Dictionary<string, object>
      {
        {"Text", text}
      };

      lock (_cleanupLock)
      {
        _cleanup.Input.Enqueue(temp);
        _cleanup.Execute();

        return _cleanup.Output.First()["Text"] as string;
      }
    }

    private string ExtractText(Message message)
    {
      if (message.TextBody != null)
        return message.TextBody.BodyEncoding.GetString(message.TextBody.Body);
      return message.HtmlBody != null
        ? CleanHtml(message.HtmlBody.BodyEncoding.GetString(message.HtmlBody.Body))
        : null;
    }

    private string MailAddressListToString(List<RfcMailAddress> list)
    {
      return string.Join(";", list.Select(x => x.Address));
    }
  }
}