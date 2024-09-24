using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CryptoTest.Models;
using CryptoTest.Services.Interfaces;

namespace CryptoTest.Services
{
    public class CryptoService : ICryptoService
    {
        private readonly HttpClient _httpClient;

        public CryptoService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.coincap.io/v2/")
            };
        }

        public async Task<List<Asset>> GetTopCryptocurrenciesAsync(int topN)
        {
            var response = await _httpClient.GetAsync($"assets?limit={topN}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<GetAssetsResponse>();
            Console.WriteLine(result);
            return result.Data;
        }
        public async Task<Asset> GetCryptocurrencyDetailsAsync(string id)
        {
            var response = await _httpClient.GetAsync($"assets/{id}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<GetAssetByIdResponse>();
            return result?.Data;
        }

        public async Task<List<Market>> GetCryptocurrencyMarketsAsync(string id)
        {
            var response = await _httpClient.GetAsync($"assets/{id}/markets");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<GetAssetMarketsResponse>();
            return result?.Data;
        }

        public async Task<List<AssetHistory>> GetCryptocurrencyHistoryAsync(string id, string interval)
        {
            var response = await _httpClient.GetAsync($"assets/{id}/history?interval={interval}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<GetAssetsHistoryResponse>();
            return result?.Data;
        }

        public async Task<List<Candle>> GetCandlestickDataAsync(string id, string interval)
        {
            var response = await _httpClient.GetAsync($"candles?exchange={id}&interval={interval}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<GetCandlesResponse>();
            return result?.Data;
        }
    }
}
