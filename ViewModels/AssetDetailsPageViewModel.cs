using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media.Animation;
using CryptoTest.Models;
using CryptoTest.Services.Interfaces;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;

namespace CryptoTest.ViewModels
{
    public class AssetDetailsPageViewModel :INotifyPropertyChanged
    {
        public bool IsLoading { get; private set; }
        private readonly ICryptoService _cryptoService;
        public ObservableCollection<Market> SelectedAssetMarkets { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public Asset SelectedAsset { get; set; }
        private PlotModel _plot;

        public PlotModel Plot
        {
            get { return _plot; }
            set
            {
                if (_plot != value)
                {
                    _plot = value;
                    OnPropertyChanged(nameof(Plot));
                }
            }
        }

        public AssetDetailsPageViewModel(ICryptoService cryptoService, Asset SelectedAsset)
        {
            _cryptoService = cryptoService;
            this.SelectedAsset = SelectedAsset;
            SelectedAssetMarkets = [];
            LoadMarketsData();
            LoadHistoryData();  

        }
        public async void LoadMarketsData()
        {
            IsLoading = true;
            try
            {

                var markets = await _cryptoService.GetCryptocurrencyMarketsAsync(SelectedAsset.Id);
                foreach (var market in markets)
                {
                    SelectedAssetMarkets.Add(market);
                }
            }
            finally
            {
                IsLoading = false;
            }
        }
        public async void LoadHistoryData()
        {
            try
            {
                List<AssetHistory> histordyData = await _cryptoService.GetCryptocurrencyHistoryAsync(SelectedAsset.Id, "m1");
                DateTime[] x = (from dataItem in histordyData
                                select DateTime.Parse(dataItem.Date)).ToArray();
                double[] y = (from dataItem in histordyData
                              select dataItem.PriceUsd).ToArray();
                lineChart(x, y);
                
            }
            finally
            {
                IsLoading = false;
            }
        }
        private void lineChart(DateTime[] x, double[] y)
        {
            var model = new PlotModel { Title = $"{SelectedAsset.Symbol}/USD" };

            model.Axes.Add(new OxyPlot.Axes.DateTimeAxis { Position = AxisPosition.Bottom, StringFormat = "HH:mm:ss" });
            model.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Y",
            });
            model = addLine(model, x, y, 2, OxyColors.Gray);

            model.Legends.Add(new OxyPlot.Legends.Legend()
            {
                LegendPosition = LegendPosition.TopLeft,
                LegendFontSize = 12
            });
            Plot = model;

        }
        private PlotModel addLine(PlotModel model, DateTime[] x, double[] y, double lineThick, OxyColor colorValue)
        {
            var lineSeries = new LineSeries { StrokeThickness = lineThick, Color = colorValue };
            for (int i = 0; i < x.Length; i++)
            {
                lineSeries.Points.Add(new DataPoint(DateTimeAxis.ToDouble(x[i]), y[i]));
            }
            model.Series.Add(lineSeries);
            return model;
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
