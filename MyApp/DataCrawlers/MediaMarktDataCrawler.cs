using System;
using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers
{
    internal class MediaMarktDataCrawler : DataCrawlerBase
    {
        public override string CrawlerName { get; } = "MediaMarkt";

        protected override bool FoundContent(string content)
        {
            var result = content.Contains("5900x", StringComparison.CurrentCultureIgnoreCase);

            return result;
        }

        protected override string Url { get; } =
            "https://www.mediamarkt.de/de/category/_amd-am4-cpu-692540.html?sort=initialimportdate%2Bdesc&id=692540";
    }
}