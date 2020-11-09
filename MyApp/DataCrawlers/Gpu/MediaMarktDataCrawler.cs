using System;
using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers.Gpu
{
    internal class MediaMarktDataCrawler : DataCrawlerBase
    {
        public override string CrawlerName { get; } = "MediaMarkt";
        protected override bool FoundContent(string content)
        {
            return content.Contains("rx 6800 xt", StringComparison.CurrentCultureIgnoreCase);
        }

        protected override string Url { get; } =
            "https://www.mediamarkt.de/de/search.html?sort=initialimportdate%2Bdesc&query=rx%206800";
    }
}
