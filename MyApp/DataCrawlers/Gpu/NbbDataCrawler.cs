using System;
using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers.Gpu
{
    internal class NbbDataCrawler : DataCrawlerBase
    {
        public override string CrawlerName { get; } = "Nbb";
        protected override bool FoundContent(string content)
        {
            throw new NotImplementedException();
        }

        protected override string Url { get; }
    }
}
