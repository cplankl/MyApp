using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers.Gpu
{
    public class MindfactoryDataCrawler : DataCrawlerBase
    {
        public override string CrawlerName { get; } = "Mindfactory";
        protected override bool FoundContent(string content)
        {
            throw new System.NotImplementedException();
        }

        protected override string Url { get; }
    }
}