#region

using System;
using System.Runtime.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Exceptions
{
  [Serializable]
  public class NotReadyException : Exception
  {
    public NotReadyException()
    {
    }

    public NotReadyException(string message)
      : base(message)
    {
    }

    public NotReadyException(string message, Exception innerException)
      : base(message, innerException)
    {
    }

    public NotReadyException(SerializationInfo serializationInfo, StreamingContext context)
      : base(serializationInfo, context)
    {
    }
  }
}