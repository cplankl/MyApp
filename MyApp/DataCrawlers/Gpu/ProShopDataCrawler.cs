using System;
using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers.Gpu
{
    internal class ProShopDataCrawler : DataCrawlerBase
    {
        public override string CrawlerName { get; } = "ProShop";
        protected override bool FoundContent(string content)
        {
            return content.Contains("rx 6800 xt", StringComparison.CurrentCultureIgnoreCase);
        }

        protected override string Url { get; } = "https://www.proshop.de/?l=1&s=rx+6800&o=2304";
    }
}
