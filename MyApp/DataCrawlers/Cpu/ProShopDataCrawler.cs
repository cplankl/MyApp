using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers.Cpu
{
    internal class ProShopDataCrawler : DataCrawlerBase
    {
        protected override string Url { get; } =
            "https://www.proshop.de/CPU/AMD-Ryzen-9-5900X-CPU-12-Kerne-37-GHz-AMD-AM4-AMD-Boxed-WOF-kein-Kuehler/2884173";


        public override string CrawlerName { get; } = "Proshop";

        protected override bool FoundContent(string content)
        {
            return !content.Contains("Die Ware ist leider nicht mehr verfügbar.");
        }
    }
}