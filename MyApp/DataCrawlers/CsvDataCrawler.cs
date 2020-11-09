using System;
using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers
{
    internal class CsvDataCrawler : DataCrawlerBase
    {
        public override string CrawlerName { get; } = "Csv";
        protected override bool FoundContent(string content)
        {
            return !content.Contains("Ware nicht lagernd", StringComparison.CurrentCultureIgnoreCase);
        }

        protected override string Url { get; } = "https://www.csv.de/artinfo.php?artnr=A0138073&KATEGORIE=0138";
    }
}
