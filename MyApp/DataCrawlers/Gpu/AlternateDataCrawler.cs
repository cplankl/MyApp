using System;
using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers.Gpu
{
    internal class AlternateDataCrawler : DataCrawlerBase
    {
        public override string CrawlerName { get; } = "Alternate";
        protected override bool FoundContent(string content)
        {
            return content.Contains("rx 6800 xt", StringComparison.CurrentCultureIgnoreCase);
        }

        protected override string Url { get; } = "https://www.alternate.de/html/search.html?size=500&query=rx+6800";
    }
}
