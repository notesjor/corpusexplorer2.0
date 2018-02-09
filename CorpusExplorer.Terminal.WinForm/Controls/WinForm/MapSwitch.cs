using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using CorpusExplorer.Sdk.Extern.TileGridMap;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Abstract;
using CorpusExplorer.Terminal.WinForm.Helper;

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  [ToolboxItem(true)]
  public partial class MapSwitch : AbstractUserControl
  {
    private RealMap _mapR = new RealMap
    {
      VerticalAlignment = System.Windows.VerticalAlignment.Stretch,
      HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch
    };

    private TileGridMapAlpha2 _mapT = new TileGridMapAlpha2
    {
      VerticalAlignment = System.Windows.VerticalAlignment.Stretch,
      HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch
    };

    public MapSwitch()
    {
      InitializeComponent();
      radPageView1.MakeHeaderInvisible();
      ShowVectorMap();

      elementHost1.Child = _mapR;
      elementHost2.Child = _mapT;

      // Style TileGridMapAlpha2
      _mapT.SetCountryBorder(_mapT.GetAllCountriesOfRegion("Asia"), new SolidColorBrush(Color.FromRgb(255, 204, 0)));
      _mapT.SetCountryBorder(_mapT.GetAllCountriesOfRegion("Europe"), new SolidColorBrush(Color.FromRgb(0, 201, 255)));
      _mapT.SetCountryBorder(_mapT.GetAllCountriesOfRegion("Africa"), new SolidColorBrush(Color.FromRgb(0, 238, 153)));
      _mapT.SetCountryBorder(_mapT.GetAllCountriesOfRegion("Americas"), new SolidColorBrush(Color.FromRgb(241, 74, 155)));
      _mapT.SetCountryBorder(_mapT.GetAllCountriesOfRegion("Oceania"), new SolidColorBrush(Color.FromRgb(242, 88, 7)));

      _mapT.FixInnerBorder(2);
      _mapT.SetAllCountryBackground(new SolidColorBrush(Colors.White));
      _mapT.NoCountry = new SolidColorBrush(Color.FromRgb(150, 180, 255));
      _mapT.AddCountryAlpha3(8, new SolidColorBrush(Colors.Black), new SolidColorBrush(Colors.White));

      // Style RealMap
      _mapR.SetAllCountryBackground(new SolidColorBrush(Colors.Black));
    }

    public void ShowVectorMap()
    {
      radPageView1.SelectedPage = radPageViewPage1;
    }

    public void ShowTileMap()
    {
      radPageView1.SelectedPage = radPageViewPage2;
    }

    public void SetData(Dictionary<string, double> data)
    {
      var cdata = new Dictionary<string, double>(data);
      var max = cdata.Max(x => x.Value);
      var min = cdata.Min(x => x.Value);
      var keys = cdata.Keys.ToArray();

      if (min < 0)
      {
        max -= min;
        foreach (var x in keys)
          cdata[x] -= min;
      }

      foreach (var x in keys)
        cdata[x] = 255 - ((cdata[x] / max) * 255);

      var color = new Dictionary<string, UniversalColor>();
      foreach (var x in cdata)
      {
        var val = x.Value;
        if (val > 255)
          val = 255;
        if (val < 0)
          val = 0;
        color.Add(x.Key, new UniversalColor((byte)val));
      }
      
      SetColor(color);
      SetToolTip(data);
    }

    private void SetToolTip(Dictionary<string, double> data)
    {
      foreach (var x in data)
      {
        _mapR.SetCountryValue(x.Key, x.Value);
        _mapT.SetCountryValue(x.Key, x.Value);
      }
    }

    public void SetColor(Dictionary<string, UniversalColor> data)
    {
      foreach (var x in data)
      {
        _mapR.SetCountryBackground(x.Key, new SolidColorBrush(x.Value.ToWpfColor()));
        _mapT.SetCountryBackground(x.Key, new SolidColorBrush(x.Value.ToWpfColor()));        
      }
    }
  }
}
