using CryptoTest.Models;

using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryptoTest.Views.Pages
{
    public partial class AssetDetailsPage : Page
    {
        public Asset SelectedAsset { get; set; }
        public PlotModel plot { get; set; }
        public AssetDetailsPage(Asset SelectedAsset)
        {
            this.SelectedAsset = SelectedAsset;
            //this.PlotModel.Series.Add(new CandleStickSeries());
            plot = new PlotModel();
            lineSeries_Click();
            InitializeComponent();
            this.DataContext = this;
        }
        private void lineSeries_Click()
        {
            double[] x = Enumerable.Range(1, 100).Select(v => ((double)v) / 10).ToArray();
            double[] y = x.Select(v => v * v).ToArray();

            var model = new PlotModel { Title = "OxyPlot - Line Series" };
            model.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Y",
            });
            model.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Number of items",
            });
            model = addLine(model, x, y, 2, OxyColors.Gray);
            model.Series[model.Series.Count - 1].Title = "X2";
            model.Legends.Add(new OxyPlot.Legends.Legend()
            {
                LegendPosition = LegendPosition.TopLeft,
                LegendFontSize = 12
            });
            plot = model;

        }





        #region Methods

        private PlotModel addLine(PlotModel model, double[] x, double[] y, double lineThick, OxyColor colorValue)
        {
            var lineSeries = new LineSeries { StrokeThickness = lineThick, Color = colorValue };
            for (int i = 0; i < x.Length; i++)
            {
                lineSeries.Points.Add(new DataPoint(x[i], y[i]));
            }
            model.Series.Add(lineSeries);
            return model;
        }
        

        #endregion

    }
}

