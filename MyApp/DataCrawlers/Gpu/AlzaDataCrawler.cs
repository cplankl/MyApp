using System;
using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers.Gpu
{
    internal class AlzaDataCrawler: DataCrawlerBase
    {
        public override string CrawlerName { get; } = "Alza";
        protected override bool FoundContent(string content)
        {
            throw new NotImplementedException();
        }

        protected override string Url { get; }
    }
}
