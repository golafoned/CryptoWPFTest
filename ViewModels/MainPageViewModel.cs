using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using CryptoTest.Models;
using CryptoTest.Services.Interfaces;

namespace CryptoTest.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private readonly ICryptoService _cryptoService;
        private ObservableCollection<Asset> _assets;
        public ObservableCollection<Asset> FilteredCryptocurrencies { get; private set; }

        private bool _isLoading;
        public string LableData { get; set; } = "Binded lable";
        public ObservableCollection<Asset> CryptoAssets
        {
            get => _assets;
            set
            {
                _assets = value;
                OnPropertyChanged();
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
            CryptoAssets = new ObservableCollection<Asset>();
            LoadDataAsync(); // Load data on initialization
            FilteredCryptocurrencies = [];

        }

        public async Task LoadDataAsync()
        {
            IsLoading = true; // Set loading state
            try
            {
                var assetData = await _cryptoService.GetTopCryptocurrenciesAsync(8);
                CryptoAssets.Clear();
                foreach (var asset in assetData)
                {
                    CryptoAssets.Add(asset);
                }
            }
            finally
            {
                IsLoading = false; // Reset loading state
            }
        }

        public void FilterCryptocurrencies(string searchText)
        {
            FilteredCryptocurrencies.Clear();
            var filtered = string.IsNullOrWhiteSpace(searchText)
                ? CryptoAssets
                : CryptoAssets.Where(c => c.Name.ToLower().Contains(searchText.ToLower()) ||
                                               c.Symbol.ToLower().Contains(searchText.ToLower()));

            foreach (var crypto in filtered)
            {
                FilteredCryptocurrencies.Add(crypto);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
