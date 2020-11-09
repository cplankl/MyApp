using System;
using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers.Gpu
{
    internal class AlzaDataCrawler: DataCrawlerBase
    {
        public override string CrawlerName { get; } = "Alza";
        protected override bool FoundContent(string content)
        {
            return !content.Contains("keine genaue Ergebnis wurde gefunden.", StringComparison.CurrentCultureIgnoreCase);
        }

        protected override string Url { get; } = "https://www.alza.de/search.htm?exps=rx%206800";
    }
}
