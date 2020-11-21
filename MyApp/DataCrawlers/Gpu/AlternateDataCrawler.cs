using System;
using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers.Gpu
{
    internal class AlternateDataCrawler : DataCrawlerBase
    {
        public override string CrawlerName { get; } = "Alternate";
        protected override bool FoundContent(string content)
        {
            return !content.Contains("Aktualisierungsphase", StringComparison.CurrentCultureIgnoreCase);
        }

        protected override string Url { get; } = "https://m.alternate.de/listing.xhtml?articleId=1693000,1693003,1693517,1693527,1693351,1693352,1694279,1694280,1694766,1694767&showTree=8393";
    }
}
