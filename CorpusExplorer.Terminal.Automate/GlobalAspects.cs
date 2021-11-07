#region

using CorpusExplorer.Sdk.Aspect;
using PostSharp.Extensibility;

#endregion

[assembly:
  ErrorReportingAspect(
    AttributeTargetTypeAttributes =
      MulticastAttributes.Private | MulticastAttributes.Protected | MulticastAttributes.Internal |
      MulticastAttributes.Public,
    AttributeTargetMemberAttributes =
      MulticastAttributes.Private | MulticastAttributes.Protected | MulticastAttributes.Internal |
      MulticastAttributes.Public)]