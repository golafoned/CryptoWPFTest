using System.Windows.Controls;
using CryptoTest.ViewModels;
using CryptoTest.Models;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using CryptoTest.Services.Interfaces;
using CryptoTest.Helpers;

namespace CryptoTest.Views.Pages
{
    public partial class MainPage : Page
    {
        MainPageViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();

            var cryptoService = ServiceLocator.GetService<ICryptoService>();
            viewModel = new MainPageViewModel(cryptoService);
            this.DataContext = viewModel;
        }
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.FilterCryptocurrencies(SearchTextBox.Text);
            CryptoListView.ItemsSource = viewModel.FilteredCryptocurrencies; 
        }
        private void CryptoListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CryptoListView.SelectedItem is Asset selectedAsset)
            {
                NavigationService.Navigate(new AssetDetailsPage(selectedAsset));
            }
        }
    }
}
