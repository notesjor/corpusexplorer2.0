using CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Text
{
  public class TextAutoFixPdfLineBreaks : AbstractTextAutoFix
  {
    protected override string Apply(string text)
    {
      int len;
      do
      {
        len = text.Length;
        // Hinweis: Das sind unterschiedliche Zeichen, die in PDFs verwendet werden
        text = text.Replace("-\r\n", "").Replace("-\n", "").Replace("‐\r\n", "").Replace("‐\n", "");
      } while (len > text.Length);

      return text;
    }
  }
}
