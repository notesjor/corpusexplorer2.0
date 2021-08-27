#region usings

using CorpusExplorer.Sdk.Data.Model.MetaInformationen;

#endregion

namespace CorpusExplorer.Sdk.Data.Model
{
  public delegate bool MetaDatenExtensionGroupCompareDelegate(
    GenerateGroupsFromMetadataEntry group, AbstrakterMetaEintrag entry);
}