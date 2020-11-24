#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Simple.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Simple.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class PersonTypeExtension
  {
    public static IEnumerable<AsocFileType> GetAllAsocFileTypes(this PersonType personType)
    {
      return personType.Items.OfType<AsocFileType>().Select(o => o);
    }

    public static IEnumerable<DescriptionType> GetAllDescriptionTypes(this PersonType personType)
    {
      return personType.Items.OfType<DescriptionType>().Select(o => o);
    }

    public static IEnumerable<bool> GetAllKnownHumans(this PersonType personType)
    {
      return personType.Items.OfType<bool>().Select(o => o);
    }

    public static IEnumerable<string> GetAllLabels(this PersonType personType)
    {
      return personType.Items.OfType<string>().Select(o => o);
    }

    public static IEnumerable<LanguageType> GetAllLanguageTypes(this PersonType personType)
    {
      return personType.Items.OfType<LanguageType>().Select(o => o);
    }

    public static IEnumerable<LocationType> GetAllLocationTypes(this PersonType personType)
    {
      return personType.Items.OfType<LocationType>().Select(o => o);
    }

    public static IEnumerable<roleType> GetAllRoleTypes(this PersonType personType)
    {
      return personType.Items.OfType<roleType>().Select(o => o);
    }
  }
}