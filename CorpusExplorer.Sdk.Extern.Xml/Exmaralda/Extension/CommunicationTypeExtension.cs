#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class CommunicationTypeExtension
  {
    public static IEnumerable<AsocFileType> GetAllAsocFileTypes(this CommunicationType communicationType)
    {
      return communicationType.Items.OfType<AsocFileType>().Select(o => o);
    }

    public static IEnumerable<CommunicationTypeSetting> GetAllCommunicationTypeSettings(
      this CommunicationType communicationType)
    {
      return communicationType.Items.OfType<CommunicationTypeSetting>().Select(o => o);
    }

    public static IEnumerable<DescriptionType> GetAllDescriptionTypes(this CommunicationType communicationType)
    {
      return communicationType.Items.OfType<DescriptionType>().Select(o => o);
    }

    public static IEnumerable<FileType> GetAllFileTypes(this CommunicationType communicationType)
    {
      return communicationType.Items.OfType<FileType>().Select(o => o);
    }

    public static IEnumerable<LanguageType> GetAllLanguageTypes(this CommunicationType communicationType)
    {
      return communicationType.Items.OfType<LanguageType>().Select(o => o);
    }

    public static IEnumerable<LocationType> GetAllLocationTypes(this CommunicationType communicationType)
    {
      return communicationType.Items.OfType<LocationType>().Select(o => o);
    }

    public static IEnumerable<RecordingType> GetAllRecordingTypes(this CommunicationType communicationType)
    {
      return communicationType.Items.OfType<RecordingType>().Select(o => o);
    }

    public static IEnumerable<TranscriptionType> GetAllTranscriptionTypes(this CommunicationType communicationType)
    {
      return communicationType.Items.OfType<TranscriptionType>().Select(o => o);
    }
  }
}