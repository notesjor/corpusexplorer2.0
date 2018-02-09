#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class SettingTypeExtension
  {
    public static IEnumerable<DescriptionType> GetAllDescriptionTypes(this SettingType settingType)
    {
      return settingType.Items.OfType<DescriptionType>().Select(o => o);
    }

    public static IEnumerable<ObjectType> GetAllObjectTypes(this SettingType settingType)
    {
      return settingType.Items.OfType<ObjectType>().Select(o => o);
    }

    public static IEnumerable<string> GetAllPersons(this SettingType settingType)
    {
      return settingType.Items.OfType<string>().Select(o => o);
    }
  }
}