using System;
using System.Data;
using System.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract
{
  public abstract class AbstractTableWriter : IDisposable
  {
    public AbstractTableWriter()
    {
      OutputStream = System.Console.OpenStandardOutput();
    }

    public Stream OutputStream { get; set; }

    public abstract string TableWriterTag { get; }

    public void Dispose()
    {
      OutputStream?.Dispose();
    }

    public abstract void WriteTable(DataTable table);

    protected void WriteOutput(string line)
    {
      var buffer = Configuration.Encoding.GetBytes(line.Replace("&#", "#"));
      OutputStream.Write(buffer, 0, buffer.Length);
    }

    public void WriteDirectThroughStream(string line)
    {
      var buffer = Configuration.Encoding.GetBytes(line);
      OutputStream.Write(buffer, 0, buffer.Length);
    }
  }
}