using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Extern.QuickIndex.Helper
{
  public static class FileNameHelper
  {
    private static char[] Chars = Path.GetInvalidFileNameChars();

    public static string EnsureFileName(this string path, char replaceWith = '_')
      => string.Join(replaceWith.ToString(), path.Split(Chars)).ToLower();
  }
}
