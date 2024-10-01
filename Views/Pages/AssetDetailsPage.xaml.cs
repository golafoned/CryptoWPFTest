using CryptoTest.Helpers;
using CryptoTest.Models;
using CryptoTest.Services.Interfaces;
using CryptoTest.ViewModels;
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
        AssetDetailsPageViewModel viewModel;
        public AssetDetailsPage(Asset SelectedAsset)
        {
            viewModel = new AssetDetailsPageViewModel(ServiceLocator.GetService<ICryptoService>(), SelectedAsset);
            this.DataContext = viewModel;
            InitializeComponent();
        }
    }
}

