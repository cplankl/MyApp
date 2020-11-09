using System;
using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers.Gpu
{
    internal class MediaMarktDataCrawler : DataCrawlerBase
    {
        public override string CrawlerName { get; } = "MediaMarkt";
        protected override bool FoundContent(string content)
        {
            throw new NotImplementedException();
        }

        protected override string Url { get; }
    }
}
