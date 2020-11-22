using System;
using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers.Gpu
{
    internal sealed class AmdExtendedDataCrawler : DataCrawlerBase
    {
        public override string CrawlerName { get; } = nameof(AmdExtendedDataCrawler);

        protected override bool FoundContent(string content)
        {
            return !content.Contains("Out of stock", StringComparison.CurrentCultureIgnoreCase);
        }

        protected override string Url { get; } = "https://www.amd.com/de/direct-buy/5458374100/de";
    }
}