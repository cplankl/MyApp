using System;
using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers.Gpu
{
    internal class AlternateDataCrawler : DataCrawlerBase
    {
        public override string CrawlerName { get; } = "Alternate";
        protected override bool FoundContent(string content)
        {
            throw new NotImplementedException();
        }

        protected override string Url { get; }
    }
}
