using System;
using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers.Gpu
{
    internal class SaturnDataCrawler : DataCrawlerBase
    {
        public override string CrawlerName { get; } = "Saturn";
        protected override bool FoundContent(string content)
        {
            return content.Contains("rx 6800 xt", StringComparison.CurrentCultureIgnoreCase);
        }

        protected override string Url { get; } =
            "https://www.saturn.de/de/search.html?sort=initialimportdate%2Bdesc&query=rx%206800";
    }
}
