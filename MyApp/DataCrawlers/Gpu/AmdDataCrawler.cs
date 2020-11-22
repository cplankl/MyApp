using System.Collections.Generic;
using System.Text;
using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers.Gpu
{
    internal sealed class AmdDataCrawler: DataCrawlerBase
    {
        public override string CrawlerName { get; } = "AMD";
        protected override bool FoundContent(string content)
        {
            return content.Contains("6800");
        }

        protected override string Url => "https://www.amd.com/de/direct-buy/de";
    }
}
