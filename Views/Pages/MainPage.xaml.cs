using System.Windows.Controls;
using CryptoTest.ViewModels;
using CryptoTest.Models;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using CryptoTest.Services.Interfaces;
using System.Diagnostics;

namespace CryptoTest.Views
{
    public partial class MainPage : Page
    {

        MainPageViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();

            // Retrieve the crypto service from the service provider
            var cryptoService = ((App)Application.Current).Services.GetService<ICryptoService>();
            viewModel = new MainPageViewModel(cryptoService);
            this.DataContext = viewModel;
        }
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Call the ViewModel to filter the cryptocurrencies based on the search text
            viewModel.FilterCryptocurrencies(SearchTextBox.Text);
            CryptoListView.ItemsSource = viewModel.FilteredCryptocurrencies; 
        }
    }
}
