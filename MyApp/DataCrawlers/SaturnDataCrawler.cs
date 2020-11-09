using System;
using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers
{
    internal class SaturnDataCrawler : DataCrawlerBase
    {
        public override string CrawlerName { get; } = "Saturn";

        protected override bool FoundContent(string content)
        {
            var result = content.Contains("5900x", StringComparison.CurrentCultureIgnoreCase);

            return result;
        }

        protected override string Url { get; } =
            "https://www.saturn.de/de/category/_amd-am4-cpu-693066.html?sort=initialimportdate%2Bdesc&id=693066";
    }
}