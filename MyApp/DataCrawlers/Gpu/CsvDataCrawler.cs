using System;
using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers.Gpu
{
    internal class CsvDataCrawler : DataCrawlerBase
    {
        public override string CrawlerName { get; } = "Csv";
        protected override bool FoundContent(string content)
        {
            return !content.Contains("Ihre Suche ergab keine Treffer", StringComparison.CurrentCultureIgnoreCase);
        }

        protected override string Url { get; } = "https://www.csv.de/artsearchresult.php?STICHWORT=rx+6800";
    }
}