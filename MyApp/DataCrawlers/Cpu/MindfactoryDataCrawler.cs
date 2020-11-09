using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers.Cpu
{
    internal sealed class MindfactoryDataCrawler : DataCrawlerBase
    {
        protected override string Url { get; } = "https://www.mindfactory.de/product_info.php/AMD-Ryzen-9-5900X-12x-3-70GHz-So-AM4-WOF_1380728.html";
        private const string MissingPage = "<title>404 - Die Seite konnte nicht gefunden werden | Mindfactory.de</title>";

        public override string CrawlerName { get; } = "Mindfactory";
        protected override bool FoundContent(string content) => !content.Contains(MissingPage);
    }
}
