using System.IO;

namespace CorpusExplorer.Sdk.Helper
{
  public static class Splitter
  {
    public static char[] Space { get; } = { ' ' };
    public static char[] Tab { get; } = { '\t' };
    public static char[] Greater { get; } = { '>' };
    public static char[] Equal { get; } = { '=' };
    public static char[] Hashtag { get; } = { '#' };
    public static char[] Question { get; } = { '?' };
    public static char[] Pipe { get; } = { '|' };
    public static char[] LF { get; } = { '\n' };
    public static string[] CRLF { get; } = { "\r\n" };
    public static string[] LineBreaks { get; } = { "\r\n", "\n\r", "\r", "\n" };
    public static char[] Semicolon { get; } = { ';' };
    public static char[] TabAndSpace { get; } = { '\t', ' ' };
    public static string[] CRLFCRLF { get; } = { "\r\n\r\n" };
    public static char[] Colon { get; } = { ':' };
    public static char[] Dash { get; } = { '-' };
    public static char[] At { get; } = { '@' };
    public static char[] Comma { get; } = { ',' };
    public static char[] Slash { get; } = { '/' };
    public static string[] TabSpaceAndLineBreaks { get; } = { " ", "\t", "\r\n", "\r", "\n" };
    public static string[] ColonColon { get; } = { "::" };
  }
}
