#region

using CorpusExplorer.Sdk.Extern.Xml.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.DSpin.Serializer
{
  // ReSharper disable once MemberCanBeInternal
  public sealed class DSpinSerializer : AbstractGenericSerializer<Model.DSpin>
  {
    protected override void DeserializePostValidation(Model.DSpin obj, string path) { }

    protected override void DeserializePreValidation(string path) { CheckFileExtension(path, "xml"); }

    protected override void SerializePostValidation(Model.DSpin obj, string path) { }

    protected override void SerializePreValidation(Model.DSpin obj, string path) { CheckFileExtension(path, "xml"); }
  }
}