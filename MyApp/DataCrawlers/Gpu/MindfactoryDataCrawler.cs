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
}