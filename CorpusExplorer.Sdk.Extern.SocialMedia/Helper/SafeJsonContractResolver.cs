using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Helper
{
  public class SafeJsonContractResolver : DefaultContractResolver
  {
    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
      var property = base.CreateProperty(member, memberSerialization);

      property.ShouldSerialize = instance =>
      {
        try
        {
          var prop = (PropertyInfo)member;
          if (prop.CanRead && prop.CanWrite)
          {
            prop.GetValue(instance, null);
            return true;
          }
        }
        catch
        {
          // ignore
        }
        return false;
      };

      return property;
    }
  }
}
