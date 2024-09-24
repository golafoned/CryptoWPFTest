using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoTest.Models; // Import your model namespace

namespace CryptoTest.Services.Interfaces
{
    public interface ICryptoService
    {
        Task<List<Asset>> GetTopCryptocurrenciesAsync(int topN);
        Task<Asset> GetCryptocurrencyDetailsAsync(string id);
        Task<List<Market>> GetCryptocurrencyMarketsAsync(string id);
        Task<List<AssetHistory>> GetCryptocurrencyHistoryAsync(string id, string interval);
        Task<List<Candle>> GetCandlestickDataAsync(string id, string interval);
    }
}