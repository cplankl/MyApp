using System;
using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers.Gpu
{
    internal class SaturnDataCrawler : DataCrawlerBase
    {
        public override string CrawlerName { get; } = "Saturn";
        protected override bool FoundContent(string content)
        {
            throw new NotImplementedException();
        }

        protected override string Url { get; }
    }
}
