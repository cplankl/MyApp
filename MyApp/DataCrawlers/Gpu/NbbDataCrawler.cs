using System;
using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers.Gpu
{
    internal class NbbDataCrawler : DataCrawlerBase
    {
        public override string CrawlerName { get; } = "Nbb";

        protected override bool FoundContent(string content)
        {
            return content.Contains("rx 6800 xt", StringComparison.CurrentCultureIgnoreCase);
        }

        protected override string Url { get; } =
            "https://www.notebooksbilliger.de/produkte/Rx+6800#!/q/Rx%206800/limit/50";
    }
}