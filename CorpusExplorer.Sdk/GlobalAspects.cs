#if !DEBUG
using CorpusExplorer.Sdk.Aspect;
using PostSharp.Extensibility;

[assembly:
  ErrorReportingAspect(
    AttributeTargetTypeAttributes =
      MulticastAttributes.Private | MulticastAttributes.Protected | MulticastAttributes.Internal |
      MulticastAttributes.Public,
    AttributeTargetMemberAttributes =
      MulticastAttributes.Private | MulticastAttributes.Protected | MulticastAttributes.Internal |
      MulticastAttributes.Public)]
#endif