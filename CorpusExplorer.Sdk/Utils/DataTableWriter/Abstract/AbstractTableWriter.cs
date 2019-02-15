using System;
using System.Data;
using System.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract
{
  public abstract class AbstractTableWriter
  {
    protected readonly object WriteLock = new object();
    protected bool _headInitialized;

    public AbstractTableWriter()
    {
      OutputStream = Console.OpenStandardOutput();
    }

    public Stream OutputStream { get; set; }

    public abstract string TableWriterTag { get; }

    public abstract string MimeType { get; }

    public void Destroy(bool closeStream = true)
    {
      lock (WriteLock)
      {
        WriteFooter();
      }

      if (closeStream)
        OutputStream?.Close();
    }

    /// <summary>
    ///   Schreibt eine Tabelle in den Ausgabestream (Threadsafe).
    /// </summary>
    /// <param name="table">Tabelle</param>
    public virtual void WriteTable(DataTable table)
    {
      lock (WriteLock)
      {
        if (!_headInitialized)
        {
          WriteHead(table);
          _headInitialized = true;
        }

        WriteBody(table);
      }
    }

    /// <summary>
    ///   Schreibt eine Tabelle in den Ausgabestream (Threadsafe).
    /// </summary>
    /// <param name="tid">Tabellen ID</param>
    /// <param name="table">Tabelle</param>
    public void WriteTable(string tid, DataTable table)
    {
      var tCol = table.Columns.Add("TID", typeof(string));
      tCol.SetOrdinal(0);
      foreach (DataRow row in table.Rows)
        row[0] = tid;
      WriteTable(table);
    }

    /// <summary>
    ///   Writes the head.
    /// </summary>
    /// <param name="table">The table.</param>
    protected abstract void WriteHead(DataTable table);

    /// <summary>
    ///   Writes the body.
    /// </summary>
    /// <param name="table">The table.</param>
    protected abstract void WriteBody(DataTable table);

    /// <summary>
    ///   Writes the footer.
    /// </summary>
    protected abstract void WriteFooter();

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

    public abstract AbstractTableWriter Clone(Stream stream);

    public void WriteError(string message)
    {
      var error = new DataTable();
      error.Columns.Add("error", typeof(string));
      error.Columns.Add("hasError", typeof(bool));

      error.Rows.Add(message, true);
      WriteTable(error);
    }
  }
}