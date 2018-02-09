#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.DortmunderChatKorpus.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.DortmunderChatKorpus.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class MessageBodyExtension
  {
    public static IEnumerable<address> GetAllAddresseItems(this messageBody messageBody)
    {
      return messageBody.Items.OfType<address>().Select(o => o);
    }

    public static IEnumerable<img> GetAllImgItems(this messageBody messageBody)
    {
      return messageBody.Items.OfType<img>().Select(o => o);
    }

    public static IEnumerable<nickname> GetAllNicknameItems(this messageBody messageBody)
    {
      return messageBody.Items.OfType<nickname>().Select(o => o);
    }

    public static IEnumerable<string> GetAllStringItems(this messageBody messageBody)
    {
      return messageBody.Items.OfType<string>().Select(o => o);
    }
  }
}