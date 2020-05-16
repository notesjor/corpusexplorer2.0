using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CorpusExplorer.Sdk.Universal.Ms
{
  public static class DataTableExtensions
  {
    public static IEnumerable<DataRow> AsEnumerable(this DataTable source)
    {
      return (IEnumerable<DataRow>)new DataRowEnumerable(source.Rows.GetEnumerator());
    }
  }

  public class DataRowEnumerable : IEnumerable<DataRow>
  {
    private IEnumerator<DataRow> m_enumerator;
    internal DataRowEnumerable(IEnumerator e)
    {
      m_enumerator = (IEnumerator<DataRow>)e;
    }
    public IEnumerator<DataRow> GetEnumerator()
    {
      return m_enumerator;
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}
