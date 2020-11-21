using System;
using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers.Gpu
{
    public class MindfactoryDataCrawler : DataCrawlerBase
    {
        public override string CrawlerName { get; } = "Mindfactory";

        protected override bool FoundContent(string content)
        {
            return !content.Contains("ergab 0 Treffer.", StringComparison.CurrentCultureIgnoreCase);
        }

        protected override string Url { get; } = "https://www.mindfactory.de/search_result.php?search_query=rx+6800";
    }

    public sealed class MfSapphireDataCrawler : DataCrawlerBase
    {
        public override string CrawlerName { get; } = nameof(MfSapphireDataCrawler);

        protected override bool FoundContent(string content)
        {
            return !content.Contains("Nicht mehr lieferbar.", StringComparison.CurrentCultureIgnoreCase);
        }

        protected override string Url { get; } =
            "https://www.mindfactory.de/product_info.php/16GB-Sapphire-Radeon-RX-6800-XT-GDDR6-HDMI-DUAL-DP-USB-C--Retail-_1383028.html";
    }

    public sealed class MfPowerColorDataCrawler : DataCrawlerBase
    {
        public override string CrawlerName { get; } = nameof(MfPowerColorDataCrawler);

        protected override bool FoundContent(string content)
        {
            return !content.Contains("Nicht mehr lieferbar.", StringComparison.CurrentCultureIgnoreCase);
        }

        protected override string Url { get; } =
            "https://www.mindfactory.de/product_info.php/16GB-PowerColor-Radeon-RX-6800-XT-GDDR6-HDMI-DUAL-DP-USB-C--Retail-_1383761.html";
    }
}