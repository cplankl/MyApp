using System;
using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers.Cpu
{
    internal class AlzaDataCrawler : DataCrawlerBase
    {
        public override string CrawlerName { get; } = "Alza";
        protected override bool FoundContent(string content)
        {
            return !content.Contains("Mit Spannung erwartet", StringComparison.InvariantCultureIgnoreCase);
        }

        protected override string Url { get; } = "https://www.alza.de/amd-ryzen-9-5900x-d6215746.htm?o=1";
    }
}
