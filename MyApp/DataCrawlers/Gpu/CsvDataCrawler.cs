using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers.Gpu
{
    internal class CsvDataCrawler : DataCrawlerBase
    {
        public override string CrawlerName { get; } = "Csv";
        protected override bool FoundContent(string content)
        {
            throw new System.NotImplementedException();
        }

        protected override string Url { get; }
    }
}