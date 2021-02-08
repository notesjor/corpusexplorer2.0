using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using CorpusExplorer.Sdk.Extern.TileGridMap;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Abstract;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Colorizer;
using CorpusExplorer.Terminal.WinForm.Helper;

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  [ToolboxItem(true)]
  public partial class MapSwitch : AbstractUserControl
  {
    private readonly Colorizer _colorizer = new Colorizer
    {
      VerticalAlignment = VerticalAlignment.Stretch,
      HorizontalAlignment = HorizontalAlignment.Stretch
    };

    private readonly RealMap _mapR = new RealMap
    {
      VerticalAlignment = VerticalAlignment.Stretch,
      HorizontalAlignment = HorizontalAlignment.Stretch
    };

    private readonly TileGridMapAlpha2 _mapT = new TileGridMapAlpha2
    {
      VerticalAlignment = VerticalAlignment.Stretch,
      HorizontalAlignment = HorizontalAlignment.Stretch
    };

    private Dictionary<string, double> _data;

    public MapSwitch()
    {
      InitializeComponent();
      RadPageViewHelper.MakeHeaderInvisible(radPageView1);
      ShowVectorMap();

      elementHost1.Child = _mapR;
      elementHost2.Child = _mapT;
      elementHost3.Child = _colorizer;

      // Style TileGridMapAlpha2
      _mapT.SetCountryBorder(_mapT.GetAllCountriesOfRegion("Asia"), new SolidColorBrush(Color.FromRgb(255, 204, 0)));
      _mapT.SetCountryBorder(_mapT.GetAllCountriesOfRegion("Europe"), new SolidColorBrush(Color.FromRgb(0, 201, 255)));
      _mapT.SetCountryBorder(_mapT.GetAllCountriesOfRegion("Africa"), new SolidColorBrush(Color.FromRgb(0, 238, 153)));
      _mapT.SetCountryBorder(_mapT.GetAllCountriesOfRegion("Americas"),
                             new SolidColorBrush(Color.FromRgb(241, 74, 155)));
      _mapT.SetCountryBorder(_mapT.GetAllCountriesOfRegion("Oceania"), new SolidColorBrush(Color.FromRgb(242, 88, 7)));

      _mapT.FixInnerBorder(2);
      _mapT.SetAllCountryBackground(new SolidColorBrush(Colors.White));
      _mapT.NoCountry = new SolidColorBrush(Color.FromRgb(150, 180, 255));
      _mapT.AddCountryAlpha3(8, new SolidColorBrush(Colors.Black), new SolidColorBrush(Colors.White));

      // Style RealMap
      _mapR.SetAllCountryBackground(new SolidColorBrush(Colors.Black));

      // Colorizer
      _colorizer.ColorsChanged += _colorizer_ColorsChanged;
    }

    private void _colorizer_ColorsChanged(object sender, EventArgs e)
    {
      Recolor();
    }

    private void Recolor()
    {
      SetData(_data);
    }

    public void SetData(Dictionary<string, double> data)
    {
      _data = data;
      var max = data.Max(x => x.Value);
      var palette = _colorizer.GetValueGradientColorizer(0, 1);
      foreach (var d in data)
      {
        var brush = new SolidColorBrush(ColorGradientPickHelper.GetColor(palette, d.Value / max));
        _mapR.SetCountryBackground(d.Key, brush);
        _mapT.SetCountryBackground(d.Key, brush);
      }

      SetToolTip(data);
    }

    public void ShowTileMap()
    {
      radPageView1.SelectedPage = radPageViewPage2;
    }

    public void ShowVectorMap()
    {
      radPageView1.SelectedPage = radPageViewPage1;
    }

    private void SetToolTip(Dictionary<string, double> data)
    {
      foreach (var x in data)
      {
        _mapR.SetCountryValue(x.Key, x.Value);
        _mapT.SetCountryValue(x.Key, x.Value);
      }
    }
  }
}