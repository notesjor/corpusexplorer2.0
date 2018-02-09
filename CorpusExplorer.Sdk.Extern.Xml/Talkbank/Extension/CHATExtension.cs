#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Talkbank.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Talkbank.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class CHATExtension
  {
    public static IEnumerable<CHATBegingem> GetAllChatBegingems(this CHAT chat)
    {
      return chat.Items.OfType<CHATBegingem>().Select(o => o);
    }

    public static IEnumerable<CHATEndgem> GetAllChatEndgems(this CHAT chat)
    {
      return chat.Items.OfType<CHATEndgem>().Select(o => o);
    }

    public static IEnumerable<CHATLazygem> GetAllChatLazygem(this CHAT chat)
    {
      return chat.Items.OfType<CHATLazygem>().Select(o => o);
    }

    public static IEnumerable<commentType> GetAllCommentTypes(this CHAT chat)
    {
      return chat.Items.OfType<commentType>().Select(o => o);
    }

    public static IEnumerable<speakerUtteranceType> GetAllSpeakerUtteranceTypes(this CHAT chat)
    {
      return chat.Items.OfType<speakerUtteranceType>().Select(o => o);
    }

    public static IEnumerable<tcuType1> GetAllTcuTypes(this CHAT chat)
    {
      return chat.Items.OfType<tcuType1>().Select(o => o);
    }
  }
}