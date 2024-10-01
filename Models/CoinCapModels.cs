using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace CryptoTest.Models
{
    public class Asset
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; } // This can be int if you want to keep the type

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("supply")]
        public decimal Supply { get; set; } // Use decimal to keep the type

        [JsonProperty("maxSupply")]
        public decimal? MaxSupply { get; set; } // Nullable decimal for max supply

        [JsonProperty("marketCapUsd")]
        public decimal MarketCapUsd { get; set; } // Use decimal to keep the type

        [JsonProperty("volumeUsd24Hr")]
        public decimal VolumeUsd24Hr { get; set; } // Use decimal to keep the type

        [JsonProperty("priceUsd")]
        public decimal PriceUsd { get; set; } // Use decimal to keep the type

        [JsonProperty("changePercent24Hr")]
        public decimal ChangePercent24Hr { get; set; } // Use decimal to keep the type

        [JsonProperty("vwap24Hr")]
        public decimal Vwap24Hr { get; set; } // Use decimal to keep the type

        [JsonProperty("explorer")]
        public string Explorer { get; set; }
    }

    public class AssetHistory
    {
        [JsonProperty("priceUsd")]
        public double PriceUsd { get; set; }
        [JsonProperty("time")]
        public decimal Time { get; set; }
        [JsonProperty("date")]
        public string Date { get; set; }
    }

    public class GetAssetsResponse
    {
        [JsonProperty("data")]
        public List<Asset> Data { get; set; }
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }

    public class GetAssetByIdResponse
    {
        public Asset Data { get; set; }
        public long Timestamp { get; set; }
    }

    public class GetAssetsHistoryResponse
    {
        public List<AssetHistory> Data { get; set; }
        public long Timestamp { get; set; }
    }

    public class Market
    {
        // Unique identifier for exchange
        [JsonProperty("exchangeId")]
        public string ExchangeId { get; set; }
        // Unique identifier for this asset
        [JsonProperty("baseId")]
        public string BaseId { get; set; }
        // Unique identifier for this asset
        [JsonProperty("quoteId")]
        public string QuoteId { get; set; }
        // Most common symbol
        [JsonProperty("baseSymbol")]
        public string BaseSymbol { get; set; }
        // Most common symbol
        [JsonProperty("quoteSymbol")]
        public string QuoteSymbol { get; set; }
        // Volume transacted in last 24 hours
        [JsonProperty("volumeUsd24Hr")]
        public decimal VolumeUsd24Hr { get; set; }
        // The amount of quote asset traded for one unit of base asset
        [JsonProperty("priceUsd")]
        public decimal PriceUsd { get; set; }
        // Percent of quote asset volume
        [JsonProperty("volumePercent")]
        public decimal VolumePercent { get; set; }
    }

    public class GetAssetMarketsResponse
    {
        public List<Market> Data { get; set; }
        public long Timestamp { get; set; }
    }

    public class Rate
    {
        // Unique identifier
        public string Id { get; set; }
        // Most common symbol
        public string Symbol { get; set; }
        // Currency symbol
        public string CurrencySymbol { get; set; }
        // Rate conversion to USD
        public decimal RateUsd { get; set; }
        // Type of currency
        public string Type { get; set; }
    }

    public class GetRatesResponse
    {
        public List<Rate> Data { get; set; }
        public long Timestamp { get; set; }
    }

    public class GetRateByIdResponse
    {
        public Rate Data { get; set; }
        public long Timestamp { get; set; }
    }

    public class Exchange
    {
        // Unique identifier for exchange
        public string Id { get; set; }
        // Proper name
        public string Name { get; set; }
        // Rank
        public int Rank { get; set; }
        // Amount of daily volume
        public decimal PercentTotalVolume { get; set; }
        // Daily volume
        public decimal VolumeUsd { get; set; }
        // Number of trading pairs
        public int TradingPairs { get; set; }
        // Trade socket availability
        public bool Socket { get; set; }
        // Website
        public string ExchangeUrl { get; set; }
        // UNIX timestamp
        public long Updated { get; set; }
    }

    public class GetExchangesResponse
    {
        public List<Exchange> Data { get; set; }
        public long Timestamp { get; set; }
    }

    public class GetExchangeByIdResponse
    {
        public Exchange Data { get; set; }
        public long Timestamp { get; set; }
    }

    public class MarketEx
    {
        // Unique identifier for exchange
        public string ExchangeId { get; set; }
        // Rank
        public int Rank { get; set; }
        // Most common symbol
        public string BaseSymbol { get; set; }
        // Unique identifier
        public string BaseId { get; set; }
        // Most common symbol
        public string QuoteSymbol { get; set; }
        // Unique identifier
        public string QuoteId { get; set; }
        // Amount of quote asset traded
        public decimal PriceQuote { get; set; }
        // Quote price in USD
        public decimal PriceUsd { get; set; }
        // Volume transacted
        public decimal VolumeUsd24Hr { get; set; }
        // Amount of daily volume
        public decimal PercentExchangeVolume { get; set; }
        // Number of trades
        public int TradesCount24Hr { get; set; }
        // UNIX timestamp
        public long Updated { get; set; }
    }

    public class GetMarketsResponse
    {
        public List<MarketEx> Data { get; set; }
        public long Timestamp { get; set; }
    }

    public class Candle
    {
        // Timestamp
        public long Period { get; set; }
        // The first transaction price
        public decimal Open { get; set; }
        // The top price
        public decimal High { get; set; }
        // The bottom price
        public decimal Low { get; set; }
        // The last transaction price
        public decimal Close { get; set; }
        // Amount of base asset traded
        public decimal Volume { get; set; }
    }

    public class GetCandlesResponse
    {
        public List<Candle> Data { get; set; }
        public long Timestamp { get; set; }
    }

}
