using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers.Gpu
{
    public class NvidiaDataCrawler : DataCrawlerBase
    {
        public override string CrawlerName { get; } = nameof(NvidiaDataCrawler);


        protected override bool FoundContent(string content)
        {
            //var doc = new HtmlAgilityPack.HtmlDocument();
            //doc.LoadHtml(content);

            //doc.GetElementbyId()
            return false;
        }

        protected override string Url { get; } = "https://www.nvidia.com/de-de/shop/geforce/?page=1&limit=9&locale=de-de";
    }
}