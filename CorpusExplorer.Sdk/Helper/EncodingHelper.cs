using System.Text;

namespace CorpusExplorer.Sdk.Helper
{
  public static class EncodingHelper
  {
    public static string Convert(Encoding srcEncoding, Encoding dstEncoding, string text)
    {
      return dstEncoding.GetString(Encoding.Convert(srcEncoding, dstEncoding, srcEncoding.GetBytes(text)));
    }
  }
}