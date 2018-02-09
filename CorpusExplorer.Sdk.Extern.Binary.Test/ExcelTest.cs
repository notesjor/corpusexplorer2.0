#region

using CorpusExplorer.Sdk.Extern.Binary.Excel.Kidko.Reader;
using CorpusExplorer.Sdk.Extern.Binary.Excel.Universal.Reader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

#endregion

namespace CorpusExplorer.Sdk.Extern.Binary.Test
{
  [TestClass]
  public sealed class ExcelTest
  {
    [TestMethod]
    public void ExcelKidkoTest()
    {
      var reader = new ExcelKidkoDataReader();
      var data = reader.ReadData("testdata/KiDKo_E_Tabelle.xlsx")?.ToArray();

      Assert.IsNotNull(data);
      Assert.AreNotEqual(0, data.Count());
      Assert.AreEqual(1431, data.Count());

      var item = data.FirstOrDefault();
      Assert.IsNotNull(item);
      Assert.AreEqual("Kommentare", item.Category);

      /*
      var error = new List<string>();

      foreach (var d in data)
      {
        try
        {
          Assert.AreNotEqual(DateTime.MinValue, d.Date);
        }
        catch
        {
          error.Add(d.DateString);
        }

        Assert.IsNotNull(d.Name);
        Assert.AreNotEqual("", d.Name);
      }

      Assert.AreEqual(0, error.Count);
      */
    }

    // Hinweis: Die Datei testdata/KiDKo_E_Tabelle.xlsx
    // ist die Rohform des "kiezdeutschkorpus"
    // siehe: www.kiezdeutschkorpus.de/ 

    [TestMethod]
    public void ExcelUniversalTest()
    {
      var reader = new ExcelUniversalDataReader();
      var data = reader.ReadData("testdata/KiDKo_E_Tabelle.xlsx");

      Assert.IsNotNull(data);
      Assert.AreNotEqual(0, data.Count());

      var array = data.ToArray();

      Assert.IsNotNull(array[0]);
      Assert.AreNotEqual(0, array[0].Count());

      var item = array[0].ToArray();

      Assert.IsNotNull(item);
      Assert.AreEqual(7, item.Length);
      Assert.AreEqual("Typ", item[2].Key);
      Assert.IsNotNull(item[2].Value);
      Assert.AreNotEqual("Kommentare", item[2].Value);
      Assert.AreEqual("daily regional papers", item[2].Value);
    }
  }
}